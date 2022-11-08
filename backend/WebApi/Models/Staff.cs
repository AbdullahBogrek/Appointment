using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Staff
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }

        public string StaffName { get; set; } = string.Empty;

    }

}

