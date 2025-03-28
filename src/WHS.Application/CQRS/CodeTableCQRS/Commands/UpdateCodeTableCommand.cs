using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Domain.Entities.Code;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories;
using WHS.Domin.Constants;
using WHS.Domin.Services;

namespace WHS.Application.CQRS.CodeTableCQRS.Commands
{
    public class UpdateCodeTableCommand:IRequest
    {
        public Guid TableId { get; set; }
        public string TableName { get; set; }
    }
    public class UpdateCodeTableCommandHandler(ILogger<UpdateCodeTableCommandHandler> logger,
                                               ICodeTableRepository codeTableRepository,
                                               IMapper mapper,
                                               IWarehouseAuthorizationService warehouseAuthorizationService) : IRequestHandler<UpdateCodeTableCommand>
    {
        public async Task Handle(UpdateCodeTableCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Updateing code table with id: {request.TableId}");
            var result = await codeTableRepository.GetByIdAsync(request.TableId);
            if (result is null)
                throw new NotFoundException(nameof(CodeTable), request.TableId.ToString());
            if (!warehouseAuthorizationService.AuthorizeCodeTable(result, ResourceOperation.Update))
                throw new ForbidException();

            mapper.Map(request, result);
            await codeTableRepository.SaveChanges();
        }
    }

}
