using WebApi.DBOperations;

namespace WebApi.Applications.StaffOperations.Commands.UpdateStaff
{
    public class UpdateStaffCommand
    {
        private readonly StaffDbContext _dbContext;

        public int StaffId { get; set; }
        public UpdateStaffModel Model { get; set; }
        public UpdateStaffCommand(StaffDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var staff = _dbContext.Staffs.SingleOrDefault(x => x.StaffId == StaffId);
            
            if (staff is null)
                throw new InvalidOperationException("Böyle bir randevu kaydı bulunmamaktadır.");

            if (_dbContext.Staffs.Any(x => x.StaffName.ToLower() == Model.StaffName.ToLower() && x.StaffId != StaffId))
                throw new InvalidOperationException("Aynı isme sahip bir servis kaydı zaten mevcuttur.");

            staff.StaffName = string.IsNullOrEmpty(Model.StaffName.Trim()) ? staff.StaffName : Model.StaffName;
        
            _dbContext.SaveChanges();
        }
    }

    public class UpdateStaffModel
    {
        public string StaffName { get; set; } = string.Empty;
    } 

}