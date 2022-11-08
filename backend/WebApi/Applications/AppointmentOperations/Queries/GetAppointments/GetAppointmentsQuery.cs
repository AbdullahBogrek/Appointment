using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Models;

namespace WebApi.Applications.AppointmentOperations.Queries.GetAppointments
{
    public class GetAppointmentsQuery
    {
        private readonly AppointmentDbContext _dbContext;
        public GetAppointmentsQuery(AppointmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AppointmentsViewModel> Handle()
        {
            var appointmentList = _dbContext.Appointments.OrderBy(appt => appt.AppointmentId).ToList<Appointment>();
            List<AppointmentsViewModel> vm = new List<AppointmentsViewModel>();
            foreach (var appt in appointmentList)
            {
                vm.Add(new AppointmentsViewModel(){
                    AppointmentId = appt.AppointmentId,
                    PatientName = appt.PatientName,
                    StaffName = ((StaffEnum)appt.StaffId).ToString(),
                    AppointmentDate = appt.AppointmentDate.ToString("dd/MM/yyyy HH:mm"),
                    Services = appt.Services,
                    CreatedAt = appt.CreatedAt.ToString("dd/MM/yyyy HH:mm"),
                });
            }
            return vm;
        }
    }

    public class AppointmentsViewModel
    {
        public int AppointmentId { get; set; }

        public string PatientName { get; set; } = string.Empty;

        public string StaffName { get; set; } = string.Empty;

        public string AppointmentDate { get; set; } = string.Empty;

        public string Services { get; set; } = string.Empty;

        public string CreatedAt { get; set; } = string.Empty;
    } 
}