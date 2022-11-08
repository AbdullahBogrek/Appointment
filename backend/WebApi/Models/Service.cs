using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Service
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceId { get; set; }

        public string ServiceName { get; set; } = string.Empty;

    }

}

