# 📅 AppointmentManagementSystem (Randevu Yönetim Sistemi API)

Bu proje, işletmelerin veya kurumların randevu süreçlerini dijital ortamda, modern ve performanslı bir şekilde yönetebilmesi için geliştirdiğim, tamamen kurumsal mimariye uygun bir **Backend Web API** altyapısıdır. 

Mülakat süreçlerinde teknik kaslarımı, nesne yönelimli programlama (OOP) prensiplerini ve veri tabanı yönetim yeteneklerimi göstermek amacıyla mimariyi sıfırdan inşa ettim.

---

## 🛠️ Kullanılan Teknolojiler ve Mimari

* **Backend:** .NET Core Web API (RESTful Mimari)
* **Veri Tabanı Köprüsü:** Entity Framework Core (Code-First Yaklaşımı)
* **Veri Tabanı:** SQLite (Yerel ortamda bağımsız ve taşınabilir çalışma için)
* **Konteynerleştirme:** Docker (Projenin her ortamda sıfır konfigürasyonla ayağa kalkması için `Dockerfile` entegrasyonu sağladım)
* **Test & Dokümantasyon:** Swagger UI & Thunder Client / Postman

---

## ✨ Öne Çıkan Özellikler ve İş Mantığı

* **CRUD İşlemleri:** Randevuların (Appointment) hatasız bir şekilde oluşturulması, listelenmesi, güncellenmesi ve silinmesi süreçlerini yöneten esnek uç noktalar (Endpoints).
* **Code-First Yaklaşımı:** Veri tabanı tablolarını doğrudan C# sınıfları üzerinden modelledim ve `Migration` mekanizmasını aktif olarak kullandım.
* **Docker Entegrasyonu:** Projeyi platform bağımsız hale getirmek için Docker altyapısını kurdum. Bu sayede sistem, hedef sunucularda tek komutla ayağa kalkabilecek esnekliktedir.

---

## 🚀 Projeyi Yerel Bilgisayarınızda Çalıştırın

Projenin bilgisayarınızda çalışması için .NET SDK veya Docker'ın yüklü olması yeterlidir.

### 1. Depoyu Klonlayın
```bash
git clone [https://github.com/BaranAliAltiok04/AppointmentManagementSystem.git](https://github.com/BaranAliAltiok04/AppointmentManagementSystem.git)
cd AppointmentManagementSystem
