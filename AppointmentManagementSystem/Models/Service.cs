using System.ComponentModel.DataAnnotations;

namespace AppointmentManagementSystem.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int DurationInMinutes { get; set; }
    }
}
