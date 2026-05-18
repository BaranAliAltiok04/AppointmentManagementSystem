using System.ComponentModel.DataAnnotations;

namespace AppointmentManagementSystem.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}