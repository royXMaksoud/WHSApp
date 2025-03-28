using MediatR;

namespace WHSApp.Services
{
    public class DynamicRequestHandler
    {
        private readonly IMediator _mediator;

        public DynamicRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<object> HandleDynamicRequestAsync(Type entityType, object request)
        {
            // Build the method dynamically
            var method = typeof(IMediator).GetMethod("Send");
            var genericMethod = method.MakeGenericMethod(typeof(List<>).MakeGenericType(entityType));

            // Invoke the method dynamically and return the result
            var result = await (Task<object>)genericMethod.Invoke(_mediator, new object[] { request, default(CancellationToken) });
            return result;
        }
    }
}
