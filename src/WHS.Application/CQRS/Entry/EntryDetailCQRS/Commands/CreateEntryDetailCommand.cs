using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.DTO.Entry.EntryDeterminer;
using WHS.Application.UserAuth;
using WHS.Domain.Entities.Code;
using WHS.Domain.Entities.Enntry;
using WHS.Domain.Entities.Entry;
using WHS.Domain.Repositories.Code;
using WHS.Domain.Repositories.Entry;

namespace WHS.Application.CQRS.Entry.EntryDetailCQRS.Commands;

public class CreateEntryDetailCommand():IRequest<Guid>
{
    public Guid ShipmentRequestDetailGUID { get; set; } // Foreign Key to Warehouse
    public Guid CurrentOwnedWarehousGUID { get; set; }
    public Guid CurrentProductStatusGUID { get; set; } //Funcational , GS45,Maintaince , not functioanl,
    public Guid CurrentMovementStatusGUID { get; set; } // confirmed,pending confirmed,
    public Guid CurrentPhysicalStatusGUID { get; set; } // in stock , in service ,GS45
    public int Quantity { get; set; } // 1 for product has SN/QR and number for consumable products 
    public int ShipmentNumber { get; set; }

    public decimal CurrentUSDPrice { get; set; } // Price per unit at the time of the orde
    public string Comments { get; set; } = default!;
    public bool Active { get; set; }

    public DateOnly CreateDate { get; set; }

    public string CreatedByUserId { get; set; }
    public List<EntryDeterminerDto> EntryDeterminerDtos { get; set; } = [];  
}

public class CreateEntryDetailCommandHandler(ILogger<CreateEntryDetailCommandHandler> logger,
                                             IMapper mapper,
                                             IEntryDetailRepository entryDetailRepository,
                                             IUserContext userContext) : IRequestHandler<CreateEntryDetailCommand, Guid>
{
    public async Task<Guid> Handle(CreateEntryDetailCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();
        logger.LogInformation("{UserEmail} {UserId} is creating a new {@Entry}", currentUser.Email, currentUser.Id, request);
        var result=mapper.Map<EntryDetail>(request);
        result.CreatedByUserId = currentUser.Id;
        Guid id = await entryDetailRepository.Create(result);
        return id;
    }
}
