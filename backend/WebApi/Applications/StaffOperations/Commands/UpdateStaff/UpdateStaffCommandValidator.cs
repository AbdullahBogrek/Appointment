using FluentValidation;

namespace WebApi.Applications.StaffOperations.Commands.UpdateStaff
{
    public class UpdateStaffCommandValidator : AbstractValidator<UpdateStaffCommand>
    {
        public UpdateStaffCommandValidator()
        {
            RuleFor(command => command.Model.StaffName).MinimumLength(1).When(x => x.Model.StaffName.Trim() != string.Empty);
        } 

    }

}