using WebApi.DBOperations;

namespace WebApi.Applications.ServiceOperations.Commands.UpdateService
{
    public class UpdateServiceCommand
    {
        private readonly ServiceDbContext _dbContext;

        public int ServiceId { get; set; }
        public UpdateServiceModel Model { get; set; }
        public UpdateServiceCommand(ServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var service = _dbContext.Services.SingleOrDefault(x => x.ServiceId == ServiceId);
            
            if (service is null)
                throw new InvalidOperationException("Böyle bir randevu kaydı bulunmamaktadır.");
            
            if (_dbContext.Services.Any(x => x.ServiceName.ToLower() == Model.ServiceName.ToLower() && x.ServiceId != ServiceId))
                throw new InvalidOperationException("Aynı isme sahip bir servis kaydı zaten mevcuttur.");

            service.ServiceName = string.IsNullOrEmpty(Model.ServiceName.Trim()) ? service.ServiceName : Model.ServiceName ;
        
            _dbContext.SaveChanges();
        }
    }

    public class UpdateServiceModel
    {
        public string ServiceName { get; set; } = string.Empty;
    } 

}