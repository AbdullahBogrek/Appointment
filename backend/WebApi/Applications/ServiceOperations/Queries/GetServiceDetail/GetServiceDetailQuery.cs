using WebApi.DBOperations;

namespace WebApi.Applications.ServiceOperations.Queries.GetServiceDetail
{
    public class GetServiceDetailQuery
    {
        private readonly AppointmentDbContext _dbContext;
        public int ServiceId { get; set; }
        public GetServiceDetailQuery(AppointmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceDetailViewModel Handle()
        {
            var service = _dbContext.Services.Where(service => service.ServiceId == ServiceId).SingleOrDefault();
            if (service is null)
                throw new InvalidOperationException("Hizmet kaydı bulunamadı. Lütfen bilgileri kontrol ederek tekrar deneyiniz.");

            ServiceDetailViewModel vm = new ServiceDetailViewModel();
            vm.ServiceId = service.ServiceId;
            vm.ServiceName = service.ServiceName;
            return vm;
        }
    }

    public class ServiceDetailViewModel
    {
        public int ServiceId { get; set; }
        
        public string ServiceName { get; set; } = string.Empty;
    }

}