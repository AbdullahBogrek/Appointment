using WebApi.DBOperations;

namespace WebApi.Applications.AppointmentOperations.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommand
    {
        private readonly AppointmentDbContext _dbContext;
        public int AppointmentId { get; set; }
        public DeleteAppointmentCommand(AppointmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var appointment = _dbContext.Appointments.SingleOrDefault(appt => appt.AppointmentId == AppointmentId);

            if (appointment is null)
                throw new InvalidOperationException("Böyle bir randevu bulunmamaktadır.");

            _dbContext.Appointments.Remove(appointment);
            _dbContext.SaveChanges();
        }

    }

}