using WebApi.DBOperations;

namespace WebApi.Applications.StaffOperations.Queries.GetStaffDetail
{
    public class GetStaffDetailQuery
    {
        private readonly StaffDbContext _dbContext;
        public int StaffId { get; set; }
        public GetStaffDetailQuery(StaffDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public StaffDetailViewModel Handle()
        {
            var staff = _dbContext.Staffs.Where(x => x.StaffId == StaffId).SingleOrDefault();
            if (staff is null)
                throw new InvalidOperationException("Personel kaydı bulunamadı. Lütfen bilgileri kontrol ederek tekrar deneyiniz.");

            StaffDetailViewModel vm = new StaffDetailViewModel();
            vm.StaffId = staff.StaffId;
            vm.StaffName = staff.StaffName;
            return vm;
        }
    }

    public class StaffDetailViewModel
    {
        public int StaffId { get; set; }
        
        public string StaffName { get; set; } = string.Empty;
    }

}