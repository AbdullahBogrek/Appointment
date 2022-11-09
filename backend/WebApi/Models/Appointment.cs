using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Appointment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; set; }

        public string PatientName { get; set; } = string.Empty;

        public int StaffId { get; set; }

        public Staff Staff { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Services { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    }

}
