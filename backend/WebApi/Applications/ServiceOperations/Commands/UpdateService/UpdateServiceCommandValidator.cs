using FluentValidation;

namespace WebApi.Applications.ServiceOperations.Commands.UpdateService
{
    public class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCommand>
    {
        public UpdateServiceCommandValidator()
        {
            RuleFor(command => command.Model.ServiceName).MinimumLength(1).When(x => x.Model.ServiceName.Trim() != string.Empty);
        } 
        
    }

}