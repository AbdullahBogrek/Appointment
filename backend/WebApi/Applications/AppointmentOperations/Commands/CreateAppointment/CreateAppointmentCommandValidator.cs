using FluentValidation;

namespace WebApi.Applications.AppointmentOperations.Commands.CreateAppointment
{
    public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator()
        {
            RuleFor(command => command.Model.PatientName).NotEmpty().MinimumLength(1);
            RuleFor(command => command.Model.AppointmentDate).NotEmpty().GreaterThan(DateTime.Now);
            RuleFor(command => command.Model.Services).NotEmpty().MinimumLength(1);
            RuleFor(command => command.Model.StaffId).NotEmpty().GreaterThan(0);

        }
    }
}