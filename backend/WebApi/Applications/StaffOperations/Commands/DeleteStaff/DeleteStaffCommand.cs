using WebApi.DBOperations;

namespace WebApi.Applications.StaffOperations.Commands.DeleteStaff
{
    public class DeleteStaffCommand
    {
        private readonly StaffDbContext _dbContext;
        public int StaffId { get; set; }
        public DeleteStaffCommand(StaffDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var staff = _dbContext.Staffs.SingleOrDefault(x => x.StaffId == StaffId);

            if (staff is null)
                throw new InvalidOperationException("Böyle bir personel kaydı bulunmamaktadır.");

            _dbContext.Staffs.Remove(staff);
            _dbContext.SaveChanges();
        }

    }

}