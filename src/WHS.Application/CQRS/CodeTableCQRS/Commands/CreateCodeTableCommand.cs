using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.DTO.DutyStation;
using WHS.Application.UserAuth;
using WHS.Domain.Entities.Code;
using WHS.Domain.Repositories;

namespace WHS.Application.CQRS.CodeTableCQRS.Commands
{
    public class CreateCodeTableCommand : IRequest<Guid>
    {
        public string TableName { get; set; } = default!;
    }

    public class CreateCodeTableCommandHandler(ILogger<CreateCodeTableCommandHandler> logger,
                                               IMapper mapper,
                                               ICodeTableRepository codeTableRepository,
                                               IUserContext userContext) : IRequestHandler<CreateCodeTableCommand, Guid>
    {
        public async Task<Guid> Handle(CreateCodeTableCommand request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser();
            logger.LogInformation("{UserEmail} [{UserId}] is creating a new code table {@CodeTable}", currentUser?.Email, currentUser?.Id, request);
            var result = mapper.Map<CodeTable>(request);
            result.OwnerUserId = currentUser.Id;
            Guid id=await codeTableRepository.Create(result);
            return id;
        }
    }

}
