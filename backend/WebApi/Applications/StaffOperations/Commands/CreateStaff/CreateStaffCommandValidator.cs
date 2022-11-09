using FluentValidation;

namespace WebApi.Applications.StaffOperations.Commands.CreateStaff
{
    public class CreateStaffCommandValidator : AbstractValidator<CreateStaffCommand>
    {
        public CreateStaffCommandValidator()
        {
            RuleFor(command => command.Model.StaffName).NotEmpty().MinimumLength(1);
        }
    }
}