using MediatR;
using WHS.Domain.Entities.NotMapped;

using WHS.Domain.Repositories.Dropdown;

namespace WHS.Application.CQRS.Dropdown;

public  class GetCascadeDropdownDataQuery:IRequest<List<DropdownItem>>
{
    public string EntityName { get; set; }
    public Guid ParentId { get; set; }
    public GetCascadeDropdownDataQuery(string entityName, Guid parentId)
    {
        EntityName = entityName.ToLower();
        ParentId = parentId;
    }
}

public class GetCascadeDropdownDataQueryHandler(IDropdownRepository dropdownRepository)
    : IRequestHandler<GetCascadeDropdownDataQuery, List<DropdownItem>>
{
    public async Task<List<DropdownItem>> Handle(GetCascadeDropdownDataQuery request, CancellationToken cancellationToken)
    {
        return await dropdownRepository.GetCascadeDropdownData(request.EntityName, request.ParentId);
    }
}
