using WebApi.DBOperations;
using WebApi.Models;

namespace WebApi.Applications.ServiceOperations.Commands.CreateService
{
    public class CreateServiceCommand
    {
        public CreateServiceModel Model { get; set; }
        private readonly ServiceDbContext _dbContext;

        public CreateServiceCommand(ServiceDbContext dbContext)
        {   
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var service = _dbContext.Services.SingleOrDefault(
                x => x.ServiceName == Model.ServiceName
            );

            if (service is not null)
                throw new InvalidOperationException("Bu servis kaydı zaten mevcuttur. Lütfen başka bir servis ekleyiniz.");

            service = new Service();
            service.ServiceName = Model.ServiceName;

            _dbContext.Services.Add(service);
            _dbContext.SaveChanges();
        }

        public class CreateServiceModel
        {
            public string ServiceName { get; set; } = string.Empty;
        }
    }

}