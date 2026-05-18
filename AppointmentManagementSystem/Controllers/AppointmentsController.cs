using AppointmentManagementSystem.Data;
using AppointmentManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagementSystem.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly AppDbContext _context;

        public AppointmentsController(AppDbContext context)
        {
            _context = context;
        }

        // 1. Randevu Listeleme Sayfası (Zamanı Geçenleri Otomatik Siler)
        public async Task<IActionResult> Index()
        {
            var suAnkiZaman = DateTime.Now;

            // 🧹 OTOMATİK TEMİZLEME: Süresi geçmiş randevuları bul ve veri tabanından sil
            var gecmisRandevular = await _context.Appointments
                .Where(a => a.AppointmentDate < suAnkiZaman)
                .ToListAsync();

            if (gecmisRandevular.Any())
            {
                _context.Appointments.RemoveRange(gecmisRandevular);
                await _context.SaveChangesAsync();
            }

            // Ekrana sadece AKTİF ve İPTAL EDİLMEMİŞ olan randevuları getir
            var appointments = await _context.Appointments
                .Include(a => a.Customer)
                .Where(a => a.IsCancelled == false)
                .ToListAsync();

            return View(appointments);
        }

        // 2. Randevu Ekleme Sayfası (İstediğin Net 4 Hizmeti Buradan Besliyoruz)
        public IActionResult Create()
        {
            // 💇‍♂️ Eğer veri tabanı boşsa, sadece senin istediğin o net 4 hizmeti ekliyoruz (Fiyat yok)
            if (!_context.Services.Any())
            {
                _context.Services.AddRange(
                    new Service { Name = "Saç Kesimi", Price = 0, DurationInMinutes = 30 },
                    new Service { Name = "Sakal Kesimi", Price = 0, DurationInMinutes = 20 },
                    new Service { Name = "Cilt Bakımı", Price = 0, DurationInMinutes = 45 },
                    new Service { Name = "Maske", Price = 0, DurationInMinutes = 20 }
                );
                _context.SaveChanges();
            }

            ViewBag.Services = _context.Services.ToList();
            return View();
        }

        // 3. Tik Atılan Form Gönderildiğinde Çalışacak Kod (GÜNCELLENDİ)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment, string customerFirstName, string customerLastName, string customerPhone, int[] selectedServices)
        {
            // 1. Önce validation hatalarını temizliyoruz çünkü SelectedServiceIds ve CustomerId'yi aşağıda biz elle dolduracağız
            ModelState.Remove("SelectedServiceIds");
            ModelState.Remove("CustomerId");
            ModelState.Remove("Customer");

            // 🔒 ÇAKIŞMA KONTROLÜ: Aynı saatte aktif başka randevu var mı?
            bool isBusy = await _context.Appointments.AnyAsync(a => a.AppointmentDate == appointment.AppointmentDate && a.IsCancelled == false);
            if (isBusy)
            {
                ModelState.AddModelError("", "Seçilen tarih ve saatte başka bir randevu mevcuttur! Lütfen farklı bir zaman seçiniz.");
            }

            // Tik atılan hizmetlerin kontrolü ve metne dönüştürülmesi
            if (selectedServices == null || selectedServices.Length == 0)
            {
                ModelState.AddModelError("", "Lütfen en az bir hizmet seçiniz!");
            }
            else
            {
                // ID'leri virgülle birleştirip modele yazıyoruz
                appointment.SelectedServiceIds = string.Join(",", selectedServices);

                // Sorgunun patlamaması için List haline getirip isimleri çekiyoruz
                var selectedIdList = selectedServices.ToList();
                var dbServices = await _context.Services.Where(s => selectedIdList.Contains(s.Id)).ToListAsync();
                appointment.ServiceNames = string.Join(", ", dbServices.Select(s => s.Name));
            }

            // Hızlı Müşteri Kaydı
            if (!string.IsNullOrEmpty(customerFirstName) && !string.IsNullOrEmpty(customerLastName))
            {
                var newCustomer = new Customer
                {
                    FirstName = customerFirstName,
                    LastName = customerLastName,
                    PhoneNumber = customerPhone,
                    Email = $"{customerFirstName.ToLower()}@randevu.com"
                };

                _context.Customers.Add(newCustomer);
                await _context.SaveChangesAsync(); // SQL'in verdiği otomatik ID'yi üretiyoruz

                appointment.CustomerId = newCustomer.Id; // Randevuyu müşteriye bağlıyoruz
            }

            // 🚀 TERTEMİZ KONTROL: Artık her şey eksiksiz dolduğu için kaydı tetikliyoruz
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Kayıt başarılıysa direkt listeye fırlatır
            }

            // Eğer bir hata varsa formu hizmetlerle birlikte ekrana geri bas
            ViewBag.Services = _context.Services.ToList();
            return View(appointment);
        }

        // 4. Randevuyu İptal Etme Aksiyonu
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                appointment.IsCancelled = true; // Durumu iptal olarak işaretle
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}