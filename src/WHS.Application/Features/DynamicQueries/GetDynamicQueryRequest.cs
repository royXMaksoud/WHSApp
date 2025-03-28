using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.Common.Queries;
using WHS.Domain.Entities;

namespace WHS.Application.Features.DynamicQueries
{
    public class GetDynamicQueryRequest<T> : IRequest<List<T>> where T : BaseEntity
    {
        public DynamicQuery Query { get; set; }

        public GetDynamicQueryRequest(DynamicQuery query)
        {
            Query = query;
        }
    }

}
