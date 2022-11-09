using WebApi.DBOperations;

namespace WebApi.Applications.ServiceOperations.Commands.DeleteService
{
    public class DeleteServiceCommand
    {
        private readonly AppointmentDbContext _dbContext;
        public int ServiceId { get; set; }
        public DeleteServiceCommand(AppointmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var service = _dbContext.Services.SingleOrDefault(x => x.ServiceId == ServiceId);

            if (service is null)
                throw new InvalidOperationException("Böyle bir servis kaydı bulunmamaktadır.");

            _dbContext.Services.Remove(service);
            _dbContext.SaveChanges();
        }

    }

}