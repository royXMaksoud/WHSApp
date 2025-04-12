using MediatR;
using Microsoft.AspNetCore.Mvc;
using WHS.Application.CQRS.Shipment.ShipmentRequest.Queries;
using WHS.Application.CQRS.ShipmentRequestCQRS.Commands;
using WHS.Application.DTO.ShipmentDTO.ShipmentRequest;
using WHS.Domain.Entities.Shipment;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentRequestController : BaseController<
        ShipmentRequestDto,
        ShipmentRequest,
        CreateShipmentRequestCommand,
        UpdateShipmentRequestCommand,
        DeleteShipmentRequestCommand,
        GetAllShipmentRequestQuery>
    {
        public ShipmentRequestController(IMediator mediator) : base(mediator)
        {
        }
    }
}
