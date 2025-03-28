using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.Interfaces;
using WHS.Domain.Entities;

namespace WHS.Application.Features.DynamicQueries
{
    public class GetDynamicQueryHandler<T> : IRequestHandler<GetDynamicQueryRequest<T>, List<T>> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;

        public GetDynamicQueryHandler(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<List<T>> Handle(GetDynamicQueryRequest<T> request, CancellationToken cancellationToken)
        {
            return await _repository.GetFilteredAsync(request.Query, cancellationToken);
        }
    }

}
