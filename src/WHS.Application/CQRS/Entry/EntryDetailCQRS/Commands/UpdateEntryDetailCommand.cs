using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Application.DTO.Entry.EntryDeterminer;
using WHS.Domain.Entities.Code;
using WHS.Domain.Entities.Entry;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories.Entry;
using WHS.Domin.Constants;
using WHS.Domin.Services;

namespace WHS.Application.CQRS.Entry.EntryDetailCQRS.Commands
{
    public class UpdateEntryDetailCommand():IRequest
    {
        public Guid EntryDetailGUID { get; set; }
        public string ProductName { get; set; } = default!;
        public int ShipmentNumber { get; set; }
        public DateOnly ShipmentDate { get; set; }
        public decimal USDPrice { get; set; }
        public decimal LocalCurrencyPrice { get; set; }
        public decimal EuroPrice { get; set; }

        public int Quantity { get; set; }
        public decimal CurrentUSDPrice { get; set; }
        public string CreatedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }
        public DateOnly? UpdateDate { get; set; }
        public string Comments { get; set; } = default!;
        public bool Active { get; set; }
        public List<EntryDeterminerDto> EntryDeterminerDtos { get; set; } = [];
    }

    public class UpdateEntryDetailCommandHandler(ILogger<UpdateEntryDetailCommandHandler> logger,
                                                 IMapper mapper,
                                                 IEntryDetailRepository entityRepository,
                                                 IAuthorizationService<EntryDetail> authorizationSercice)
                                                 : IRequestHandler<UpdateEntryDetailCommand>
    {
        public async Task Handle(UpdateEntryDetailCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Updating entry with id: {request.EntryDetailGUID}");

            var result = await entityRepository.GetByIdAsync(request.EntryDetailGUID);
            if (result is null)
                throw new NotFoundException(nameof(Warehouse), request.EntryDetailGUID.ToString());

            // Authorization check
            if (!authorizationSercice.Authorize(result, ResourceOperation.Update))
                throw new ForbidException();

            // Update and save
            mapper.Map(request, result);
            await entityRepository.SaveChanges();
        }
    }
}
