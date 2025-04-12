using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Application.DTO.Entry.EntryDetail;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories.Entry;

namespace WHS.Application.CQRS.Entry.EntryDetailCQRS.Queries;

public class GetEntryDetialByIdQuery(Guid id):IRequest<EntryDetailDto>
{
    public Guid Id { get; } = id;
}

public class GetEntryDetialByIdQueryHandler(ILogger<GetEntryDetialByIdQueryHandler> logger,
                                            IMapper mapper,
                                            IEntryDetailRepository entryDetailRepository
                                            ) 
                                        : IRequestHandler<GetEntryDetialByIdQuery, EntryDetailDto?>
{
    public async Task<EntryDetailDto?> Handle(GetEntryDetialByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting Entry Product{request.Id}");
        var tempResult=await entryDetailRepository.GetByIdAsync(request.Id);
        if (tempResult is null) 
            throw new NotFoundException(nameof(entryDetailRepository), request.Id.ToString());
        var entryDetailDto = mapper.Map<EntryDetailDto?>(tempResult); 
        return entryDetailDto;
  
    }
}