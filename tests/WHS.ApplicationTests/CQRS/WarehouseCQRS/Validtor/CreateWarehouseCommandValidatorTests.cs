using FluentValidation.TestHelper;
using WHS.Application.CQRS.Code.WarehouseCQRS.Commands;
using WHS.Application.CQRS.Code.WarehouseCQRS.Validtor;
using Xunit;

namespace WHS.Application.CQRS.WarehouseCQRS.Validtor.Tests
{
    [TestClass()]
    public class CreateWarehouseCommandValidatorTests
    {
        [Fact()]
        public void Validator_ForValidCommand_ShouldNotHaveValidtionErrors()
        {
            //arrange
            var command = new CreateWarehouseCommand
            {
                WarehouseName="Dresden",
                DutyStationGUID= Guid.Parse("90266a3c-8cec-4a20-8be7-4faf991d9f5c"),
                BranchId=Guid.Parse("90266a3c-8cec-4a20-8be7-4faf991d9f57"),


            };
            var validator = new CreateWarehouseCommandValidator();

            //act
            var result=validator.TestValidate(command);
            //assert
            result.ShouldNotHaveAnyValidationErrors();
        }
        [Fact()]
        public void Validator_ForInValidCommand_ShouldHaveValidtionErrors()
        {
            //arrange
            var command = new CreateWarehouseCommand
            {
                WarehouseName = "t",
                DutyStationGUID = Guid.Empty,
                BranchId = Guid.Empty,


            };
            var validator = new CreateWarehouseCommandValidator();

            //act
            var result = validator.TestValidate(command);
            //assert
            result.ShouldHaveValidationErrorFor(c => c.WarehouseName);
            result.ShouldHaveValidationErrorFor(c => c.DutyStationGUID);
            result.ShouldHaveValidationErrorFor(c => c.BranchId);
        }

        [Theory()]
        [InlineData("90266a3c-8cec-4a20-8be7-4faf991d9f56")]
    
        public void Validator_ForValidBranch_ShouldNotHaveValidationErrorsForBranchProperty(string branch)
        {
            //arrange
           
            var validator = new CreateWarehouseCommandValidator();
            var command = new CreateWarehouseCommand { BranchId = Guid.Parse(branch) };
            //act
            var result = validator.TestValidate(command);
            //assert
            result.ShouldHaveValidationErrorFor(c => c.BranchId);
          
        }
    }
}