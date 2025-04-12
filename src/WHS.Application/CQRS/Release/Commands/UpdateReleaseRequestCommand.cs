using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.CQRS.Entry.EntryDetailCQRS.Commands;
using WHS.Domain.Entities.Code;
using WHS.Domain.Entities.Entry;
using WHS.Domain.Entities.Release;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories.Entry;
using WHS.Domain.Repositories.Release;
using WHS.Domin.Constants;
using WHS.Domin.Services;

namespace WHS.Application.CQRS.Release.Commands
{
    public class UpdateReleaseRequestCommand:IRequest
    {
        public Guid ReleaseRequestGUID { get; set; }
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
    public class UpdateReleaseCommandHandler(ILogger<UpdateReleaseRequestCommand> logger,
                                                 IMapper mapper,
                                                 IReleaseRequestRepository repository,
                                                 IAuthorizationService<ReleaseRequest> authorizationSercice) 
                                               : IRequestHandler<UpdateReleaseRequestCommand>
    {
        public async Task Handle(UpdateReleaseRequestCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Updating entry with id: {request.ReleaseRequestGUID}");

            var result = await repository.GetByIdAsync(request.ReleaseRequestGUID);
            if (result is null)
                throw new NotFoundException(nameof(ReleaseRequest), request.ReleaseRequestGUID.ToString());

            // Authorization check
            if (!authorizationSercice.Authorize(result, ResourceOperation.Update))
                throw new ForbidException();

            // Update and save
            mapper.Map(request, result);
            await repository.SaveChanges();
        }
    }
}
