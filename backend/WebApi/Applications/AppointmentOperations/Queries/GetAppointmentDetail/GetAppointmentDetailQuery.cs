using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Applications.AppointmentOperations.Queries.GetAppointmentDetail
{
    public class GetAppointmentDetailQuery
    {
        private readonly AppointmentDbContext _dbContext;
        public int AppointmentId { get; set; }
        public GetAppointmentDetailQuery(AppointmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AppointmentDetailViewModel Handle()
        {
            var appointment = _dbContext.Appointments.Where(appt => appt.AppointmentId == AppointmentId).SingleOrDefault();
            if (appointment is null)
                throw new InvalidOperationException("Randevu kaydı bulunamadı. Lütfen bilgileri kontrol ederek tekrar deneyiniz.");

            AppointmentDetailViewModel vm = new AppointmentDetailViewModel();
            vm.PatientName = appointment.PatientName;
            vm.StaffName = ((StaffEnum)appointment.StaffId).ToString();
            vm.AppointmentDate = appointment.AppointmentDate.ToString("dd/MM/yyyy HH:mm");
            vm.Services = appointment.Services;
            vm.CreatedAt = appointment.CreatedAt.ToString("dd/MM/yyyy HH:mm");
            return vm;
        }
    }

    public class AppointmentDetailViewModel
    {
        public string PatientName { get; set; } = string.Empty;

        public string StaffName { get; set; } = string.Empty;

        public string AppointmentDate { get; set; } = string.Empty;

        public string Services { get; set; } = string.Empty;

        public string CreatedAt { get; set; } = string.Empty;
    }

}