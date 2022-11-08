using FluentValidation;

namespace WebApi.Applications.AppointmentOperations.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommandValidator : AbstractValidator<UpdateAppointmentCommand>
    {
        public UpdateAppointmentCommandValidator()
        {
            RuleFor(command => command.AppointmentId).GreaterThan(0);
            RuleFor(command => command.Model.StaffId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.PatientName).NotEmpty().MinimumLength(1);
            RuleFor(command => command.Model.AppointmentDate).NotEmpty().GreaterThan(DateTime.Now);
            RuleFor(command => command.Model.Services).NotEmpty().MinimumLength(1);
        } 
    }

}