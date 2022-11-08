using WebApi.DBOperations;
using WebApi.Models;

namespace WebApi.Applications.AppointmentOperations.Commands.CreateAppointment
{
    public class CreateAppointmentCommand
    {
        public CreateAppointmentModel Model { get; set; }
        private readonly AppointmentDbContext _dbContext;

        public CreateAppointmentCommand(AppointmentDbContext dbContext)
        {   
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var appointment = _dbContext.Appointments.SingleOrDefault(
                appt => appt.AppointmentDate == Model.AppointmentDate && appt.PatientName == Model.PatientName
            );

            if (appointment is not null)
                throw new InvalidOperationException("Aynı tarihte, bu kişiye ait randevu kaydı bulunmaktadır.");

            appointment = new Appointment();
            appointment.PatientName = Model.PatientName;
            appointment.StaffId = Model.StaffId;
            appointment.AppointmentDate = Model.AppointmentDate;
            appointment.Services = Model.Services;

            _dbContext.Appointments.Add(appointment);
            _dbContext.SaveChanges();
        }

        public class CreateAppointmentModel
        {
            public string PatientName { get; set; } = string.Empty;
            public int StaffId { get; set; }
            public DateTime AppointmentDate { get; set; }
            public string Services { get; set; } = string.Empty;
        }
    }

}