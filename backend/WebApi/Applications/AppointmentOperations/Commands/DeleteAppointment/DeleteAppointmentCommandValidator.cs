using FluentValidation;

namespace WebApi.Applications.AppointmentOperations.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommandValidator : AbstractValidator<DeleteAppointmentCommand>
    {
        public DeleteAppointmentCommandValidator()
        {
            RuleFor(command => command.AppointmentId).GreaterThan(0);
        }
    }
}
