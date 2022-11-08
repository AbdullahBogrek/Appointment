using FluentValidation;

namespace WebApi.Applications.ServiceOperations.Commands.DeleteService
{
    public class DeleteServiceCommandValidator : AbstractValidator<DeleteServiceCommand>
    {
        public DeleteServiceCommandValidator()
        {
            RuleFor(command => command.ServiceId).GreaterThan(0);

        }
        
    }

}