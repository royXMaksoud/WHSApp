using FluentValidation;
using WHS.Application.CQRS.Entry.EntryDetailCQRS.Commands;
using WHS.Domain.Entities.Code;
using WHS.Domain.Repositories.Code;

namespace WHS.Application.CQRS.Entry.EntryDetailCQRS.Validtor
{
    public class CreateEntryDetailCommandValidtor : AbstractValidator<CreateEntryDetailCommand>
    {
        private readonly ICodeTableRepository _codeTableValueService;

        public CreateEntryDetailCommandValidtor(ICodeTableRepository codeTableValueService)
        {
            _codeTableValueService = codeTableValueService;

            RuleFor(x => x.CurrentUSDPrice).GreaterThan(0);
            RuleFor(x => x.CreateDate).NotEmpty().WithMessage("Please enter a creation date");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity should be more than 0");

            //RuleFor(x => x.CurrentMovementStatusGUID)
            //    .MustAsync(async (myValue, cancellation) =>
            //    {
            //        var codeTableValues = await _codeTableValueService.GetAllAsync();
            //        return codeTableValues.Any(x => x.TableGUID == Constants.CodeTableConstants.CurrentMovementStatusGUID &&
            //                                        x. == myValue);
            //    })
            //    .WithMessage("The provided ValueGUID does not match any valid value.");
        }
    }

}
