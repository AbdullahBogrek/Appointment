using FluentValidation;

namespace WebApi.Applications.ServiceOperations.Commands.CreateService
{
    public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceCommandValidator()
        {
            RuleFor(command => command.Model.ServiceName).NotEmpty().MinimumLength(1);
        }
    }
}