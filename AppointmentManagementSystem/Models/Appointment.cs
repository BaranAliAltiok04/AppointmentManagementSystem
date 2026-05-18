using System.ComponentModel.DataAnnotations;

namespace AppointmentManagementSystem.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }

        // Seçilen hizmetlerin ID'lerini virgülle ayırarak tutacağız (Örn: "1,2")
        [Required]
        public string SelectedServiceIds { get; set; } = string.Empty;

        // Ekranda yan yana rozet olarak basmak için hizmet isimleri alanı
        public string? ServiceNames { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public bool IsCancelled { get; set; } = false;
    }
}