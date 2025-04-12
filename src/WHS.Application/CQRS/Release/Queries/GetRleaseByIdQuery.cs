using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Application.DTO.Release.ReleaseRequest;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories.Release;

namespace WHS.Application.CQRS.Release.Queries
{
    public class GetReleaseDetialByIdQuery(Guid id) : IRequest<ReleaseRequestDto>
    {
        public Guid Id { get; } = id;
    }

    public class GetReleaseDetialByIdQueryHandler(ILogger<GetReleaseDetialByIdQueryHandler> logger,
                                                IMapper mapper,
                                                IReleaseRequestRepository ReleaseRequestlRepository)
                                            : IRequestHandler<GetReleaseDetialByIdQuery, ReleaseRequestDto?>
    {
        public async Task<ReleaseRequestDto?> Handle(GetReleaseDetialByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Getting Release Product{request.Id}");
            var tempResult = await ReleaseRequestlRepository.GetByIdAsync(request.Id);
            if (tempResult is null)
                throw new NotFoundException(nameof(ReleaseRequestlRepository), request.Id.ToString());
            var ReleaseRequestDto = mapper.Map<ReleaseRequestDto?>(tempResult);
            return ReleaseRequestDto;

        }
    }
}
