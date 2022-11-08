using WebApi.DBOperations;
using WebApi.Models;

namespace WebApi.Applications.ServiceOperations.Queries.GetServices
{
    public class GetServicesQuery
    {
        private readonly ServiceDbContext _dbContext;
        public GetServicesQuery(ServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ServicesViewModel> Handle()
        {
            var serviceList = _dbContext.Services.OrderBy(service => service.ServiceId).ToList<Service>();
            List<ServicesViewModel> vm = new List<ServicesViewModel>();
            foreach (var service in serviceList)
            {
                vm.Add(new ServicesViewModel(){
                    ServiceId = service.ServiceId,
                    ServiceName = service.ServiceName,
                });
            }
            return vm;
        }
    }

    public class ServicesViewModel
    {
        public int ServiceId { get; set; }

        public string ServiceName { get; set; } = string.Empty;

    } 
}