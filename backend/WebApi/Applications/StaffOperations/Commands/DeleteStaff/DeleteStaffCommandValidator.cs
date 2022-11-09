using FluentValidation;

namespace WebApi.Applications.StaffOperations.Commands.DeleteStaff
{
    public class DeleteStaffCommandValidator : AbstractValidator<DeleteStaffCommand>
    {
        public DeleteStaffCommandValidator()
        {
            RuleFor(command => command.StaffId).GreaterThan(0);

        }

    }
    
}