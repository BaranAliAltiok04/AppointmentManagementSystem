# 🚀 SignalR Gerçek Zamanlı Sohbet Uygulaması (Chat App)

Bu projede, **ASP.NET Core** ve **SignalR** teknolojilerini kullanarak, kullanıcıların herhangi bir sayfa yenilemesine gerek kalmadan anlık olarak mesajlaşabildiği gerçek zamanlı (Real-Time) bir sohbet odası uygulaması geliştirdim. Uygulamayı tamamen Dockerize ederek bulut sunucusu üzerinde kesintisiz çalışacak şekilde canlıya aldım.

## 🔗 Canlı Önizleme
Geliştirdiğim uygulamayı tarayıcınızda doğrudan test etmek için aşağıdaki bağlantıyı kullanabilirsiniz:
👉 **[SignalR Chat App Canlı Demo](https://signalrchatapp.onrender.com)**

*(Not: Ücretsiz bulut planı kullandığım için ilk açılışta sunucunun uyanması 20-30 saniye sürebilir.)*

## ✨ Özellikler
- **Anlık Mesajlaşma:** Sayfa yenilenmeden, SignalR WebSockets protokolü ile milisaniyeler içinde mesaj iletimi sağladım.
- **Kullanıcı Tanımlama:** Giriş ekranında kullanıcıların dinamik olarak kendi adlarını belirleyebileceği bir yapı kurdum.
- **Evrensel Erişim:** Docker konteyner mimarisi kullanarak projenin platform bağımsız (Cross-Platform) kararlı çalışmasını sağladım.
- **Responsive Tasarım:** Arayüzün mobil, tablet ve masaüstü cihazlarla tam uyumlu olmasını sağladım.

## 🛠️ Kullanılan Teknolojiler
- **Backend:** .NET 8.0 / ASP.NET Core Web API
- **Real-Time Protokolü:** Microsoft AspNetCore.SignalR (WebSockets fallback desteğiyle)
- **Frontend:** HTML5, CSS3, JavaScript (SignalR Client JS Library)
- **Dağıtım (Deployment):** Docker & Render Cloud

## 🚀 Yerel Bilgisayarda Çalıştırma (Local Setup)

Projeyi kendi yerel ortamınızda test etmek isterseniz:

1. Bu depoyu klonlayın:
   ```bash
   git clone [https://github.com/BaranAliAltiok04/SignalRChatApp.git](https://github.com/BaranAliAltiok04/SignalRChatApp.git)
