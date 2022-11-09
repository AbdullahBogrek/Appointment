using WebApi.DBOperations;
using WebApi.Models;

namespace WebApi.Applications.StaffOperations.Commands.CreateStaff
{
    public class CreateStaffCommand
    {
        public CreateStaffModel Model { get; set; }
        private readonly AppointmentDbContext _dbContext;

        public CreateStaffCommand(AppointmentDbContext dbContext)
        {   
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var staff = _dbContext.Staffs.SingleOrDefault(
                x => x.StaffName == Model.StaffName
            );

            if (staff is not null)
                throw new InvalidOperationException("Bu personele ait kayıt bulunmaktadır.");

            staff = new Staff();
            staff.StaffName = Model.StaffName;

            _dbContext.Staffs.Add(staff);
            _dbContext.SaveChanges();
        }

        public class CreateStaffModel
        {
            public string StaffName { get; set; } = string.Empty;
        }
    }

}