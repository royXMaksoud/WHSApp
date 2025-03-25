

using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using WHS.Domain.Entities.Code;
using WHS.Domain.Exceptions;
using Xunit;

namespace WebAPI.Middleware.Tests
{
    public class ErrorHandlingMiddlewareTests
    {
        [Fact()]
        public async Task InvokeAsync_WhenNoExceptionThrown_ShouldCallNextDelegate()
        {
            //arrange

            var loggerMock = new Mock<ILogger<ErrorHandlingMiddleware>>();
            var middleWare=new ErrorHandlingMiddleware(loggerMock.Object);
            var context = new DefaultHttpContext();
            var nextDelegateMock=new Mock<RequestDelegate>();

            //act
            await middleWare.InvokeAsync(context, nextDelegateMock.Object);
            //assert
            nextDelegateMock.Verify(next=>next.Invoke(context),Times.Once());   
        }
        [Fact()]
        public async Task InvokeAsync_WhenNotFoundExceptionThrown_ShouldCallStatusCode404()
        {
            //arrange
            var context = new DefaultHttpContext();
            var loggerMock = new Mock<ILogger<ErrorHandlingMiddleware>>();
            var middleWare = new ErrorHandlingMiddleware(loggerMock.Object);
            
            var notFoundException = new NotFoundException(nameof(Warehouse), "e0911b06-1391-4b88-9b03-62a54b2ffc7e");

            //act
            await middleWare.InvokeAsync(context, _=>throw notFoundException);
            //assert
            context.Response.StatusCode.Should().Be(404);
        }

        [Fact()]
        public async Task InvokeAsync_WhenForbidExceptionThrown_ShouldCallStatusCode403()
        {
            //arrange
            var context = new DefaultHttpContext();
            var loggerMock = new Mock<ILogger<ErrorHandlingMiddleware>>();
            var middleWare = new ErrorHandlingMiddleware(loggerMock.Object);

            var forbidException =new ForbidException();

            //act
            await middleWare.InvokeAsync(context, _ => throw forbidException);
            //assert
            context.Response.StatusCode.Should().Be(403);
        }
        [Fact()]
        public async Task InvokeAsync_WhenGenericExceptionThrown_ShouldCallStatusCode500()
        {
            //arrange
            var context = new DefaultHttpContext();
            var loggerMock = new Mock<ILogger<ErrorHandlingMiddleware>>();
            var middleWare = new ErrorHandlingMiddleware(loggerMock.Object);

            var exception = new Exception();

            //act
            await middleWare.InvokeAsync(context, _ => throw exception);
            //assert
            context.Response.StatusCode.Should().Be(500);
        }
      
    }
}