using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.CQRS.Entry.EntryDetailCQRS.Commands;
using WHS.Application.UserAuth;
using WHS.Domain.Entities.Entry;
using WHS.Domain.Entities.Release;
using WHS.Domain.Repositories.Entry;
using WHS.Domain.Repositories.Release;

namespace WHS.Application.CQRS.Release.Commands
{
    public class CreateReleaseRequestCommand:IRequest<Guid>
    {
 
        public Guid RequestTypeGUID { get; set; }
        public Guid RequestNameGUID { get; set; }
        public Guid WarehouseUserGUID { get; set; }
        public Guid LastRequestStatusGUID { get; set; }
        public int SequenceNumber { get; set; }
        public int SequenceCode { get; set; }
        public int YearId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Active { get; set; }
    }
    public class CreateReleaseRequestCommanddHandler(ILogger<CreateReleaseRequestCommanddHandler> logger,
                                             IMapper mapper,
                                             IReleaseRequestRepository repository,
                                             IUserContext userContext) : IRequestHandler<CreateReleaseRequestCommand, Guid>
    {
        public async Task<Guid> Handle(CreateReleaseRequestCommand request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser();
            logger.LogInformation("{UserEmail} {UserId} is creating a new {@Entry}", currentUser.Email, currentUser.Id, request);
            var result = mapper.Map<ReleaseRequest>(request);
            result.CreatedByUserId = currentUser.Id;
            Guid id = await repository.Create(result);
            return id;
        }
    }
}
