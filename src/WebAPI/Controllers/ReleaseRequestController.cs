using MediatR;
using Microsoft.AspNetCore.Mvc;
using WHS.Application.CQRS.Release.Commands;
using WHS.Application.CQRS.Release.Queries;
using WHS.Application.DTO.Release.ReleaseRequest;
using WHS.Domain.Entities.Release;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReleaseRequestController : BaseController
        <ReleaseRequestDto,
        ReleaseRequest,
        CreateReleaseRequestCommand,
        UpdateReleaseRequestCommand,
        DeleteReleaseRequestCommand,
        GetAllReleaseRequestQuery>
    {
        public ReleaseRequestController(IMediator mediator) : base(mediator)
        {
        }
   
    }
}
