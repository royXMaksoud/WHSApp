using WHS.Application.DTO.Entry.EntryDetail;
using WHS.Application.GenericValidtor;

namespace WHS.Application.CQRS.Entry.EntryDetailCQRS.Validtor
{
    class GetAllEntryDetailQueryValidtor:BaseQueryValidator<EntryDetailDto>
    {
        public GetAllEntryDetailQueryValidtor():
            base(new[] {5,10,15,20},
                new[] {nameof(EntryDetailDto.ProductName),nameof(EntryDetailDto.CurrentUSDPrice),nameof(EntryDetailDto.EuroPrice)})
        {
                
        }
    }
}
