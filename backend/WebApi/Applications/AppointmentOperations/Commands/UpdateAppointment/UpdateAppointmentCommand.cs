using WebApi.DBOperations;

namespace WebApi.Applications.AppointmentOperations.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommand
    {
        private readonly AppointmentDbContext _dbContext;

        public int AppointmentId { get; set; }
        public UpdateAppointmentModel Model { get; set; }
        public UpdateAppointmentCommand(AppointmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var appointment = _dbContext.Appointments.SingleOrDefault(appt => appt.AppointmentId == AppointmentId);
            
            if (appointment is null)
                throw new InvalidOperationException("Böyle bir randevu kaydı bulunmamaktadır.");

            appointment.PatientName = Model.PatientName != default ? Model.PatientName : appointment.PatientName;
            appointment.StaffId = Model.StaffId != default ? Model.StaffId : appointment.StaffId;
            appointment.AppointmentDate = Model.AppointmentDate != default ? Model.AppointmentDate : appointment.AppointmentDate;
            appointment.Services = Model.Services != default ? Model.Services : appointment.Services;
        
            _dbContext.SaveChanges();
        }
    }

    public class UpdateAppointmentModel
    {
        public string PatientName { get; set; } = string.Empty;
        public int StaffId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public String Services { get; set; } = string.Empty;
    } 

}