using WebApi.DBOperations;
using WebApi.Models;

namespace WebApi.Applications.StaffOperations.Queries.GetStaffs
{
    public class GetStaffsQuery
    {
        private readonly AppointmentDbContext _dbContext;
        public GetStaffsQuery(AppointmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<StaffsViewModel> Handle()
        {
            var staffList = _dbContext.Staffs.OrderBy(x => x.StaffId).ToList<Staff>();
            List<StaffsViewModel> vm = new List<StaffsViewModel>();
            foreach (var staff in staffList)
            {
                vm.Add(new StaffsViewModel(){
                    StaffId = staff.StaffId,
                    StaffName = staff.StaffName,
                });
            }
            return vm;
        }
    }

    public class StaffsViewModel
    {
        public int StaffId { get; set; }

        public string StaffName { get; set; } = string.Empty;

    } 
}