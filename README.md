# Doccure 🏥

Mikroservis mimarisiyle geliştirilen hastane yönetim sistemi. Hasta, doktor, randevu, reçete, eczane ve ilaç yönetimi, hasta sırası ve online ilaç siparişi gibi modüller bağımsız mikroservisler olarak tasarlanmıştır.

> **Not:** Bu proje, bir Udemy mikroservis kursu takip edilerek geliştirilmiştir. Geliştirme devam etmektedir; aşağıda tamamlanan ve planlanan kısımlar ayrı ayrı belirtilmiştir.

---

## 🧩 Mimari

Her mikroservis kendi veritabanına sahiptir ve ihtiyaç duyduğu veri modeline uygun veritabanı ile çalışır. İstemci, tüm isteklerini **Ocelot API Gateway** üzerinden mikroservislere iletir.

```
WebUI (ASP.NET Core MVC)
        │
        ▼
Ocelot API Gateway
        │
        ├── Identity   ──► MSSQL
        ├── Patient    ──► MSSQL
        ├── Appointment──► MSSQL
        ├── Pharmacy   ──► MSSQL
        ├── Queue      ──► MSSQL      (SignalR Hub)
        ├── Market     ──► MSSQL + Redis (sepet)
        ├── Order      ──► MariaDB
        ├── Prescription──► PostgreSQL
        ├── Doctor     ──► MongoDB
        ├── Branch     ──► MongoDB
        └── Review     ──► MongoDB
```

## 📦 Mikroservisler

| Servis | Sorumluluk | Veritabanı | Durum |
|---|---|---|---|
| **Identity** | Kayıt, giriş, rol ve kullanıcı yönetimi, JWT üretimi | MSSQL | ✅ Tamamlandı |
| **Patient** | Hasta kayıtları; doktor, branş ve son geliş tarihi bilgisi | MSSQL | ✅ Tamamlandı |
| **Appointment** | Randevu oluşturma ve listeleme | MSSQL | ✅ Tamamlandı |
| **Doctor** | Doktor bilgileri | MongoDB | ✅ Tamamlandı |
| **Branch** | Branş yönetimi | MongoDB | ✅ Tamamlandı |
| **Pharmacy** | Eczane ve ilaç yönetimi | MSSQL | ✅ Tamamlandı |
| **Queue** | Hasta sırası, SignalR ile anlık güncelleme | MSSQL | ✅ Tamamlandı |
| **Market** | Ürün listeleme, Redis ile sepet, checkout | MSSQL + Redis | ✅ Tamamlandı |
| **Order** | Sipariş yönetimi | MariaDB | ✅ Tamamlandı |
| **Prescription** | Reçete işlemleri | PostgreSQL | 🚧 Temel yapı mevcut, geliştirme sürüyor |
| **Review** | Doktor değerlendirmeleri | MongoDB | 🚧 Temel yapı mevcut, geliştirme sürüyor |

## ✨ Öne Çıkan Özellikler

- **API Gateway:** Ocelot ile tek giriş noktası ve servis yönlendirme
- **JWT kimlik doğrulama ve rol bazlı yetkilendirme:** Identity servisi token üretir, diğer servisler doğrular
- **Gerçek zamanlı hasta sırası:** SignalR Hub ile admin panelinde sayfa yenilemeden çağrılan hasta güncellemesi
- **Redis ile sepet yönetimi:** Market servisinde sepet verisi Redis'te tutulur; ardından checkout ile Order servisine sipariş oluşturulur
- **Polyglot persistence:** MSSQL, MongoDB, PostgreSQL ve MariaDB aynı sistemde, servise uygun şekilde kullanılır
- **Admin paneli:** Hasta listesi, hasta sırası, ilaç/eczane yönetimi, ürün ve sipariş sayfaları

## 🛠️ Kullanılan Teknolojiler

| Alan | Teknoloji |
|---|---|
| Framework | .NET 6, ASP.NET Core Web API, ASP.NET Core MVC |
| API Gateway | Ocelot |
| Veri erişimi | Entity Framework Core (SQL Server, PostgreSQL/Npgsql, MariaDB/Pomelo), MongoDB.Driver |
| Önbellek | Redis (StackExchange.Redis) |
| Kimlik | ASP.NET Core Identity, JWT Bearer |
| Gerçek zamanlı | SignalR |
| Diğer | AutoMapper, Swagger (Swashbuckle) |

## 🗂️ Proje Yapısı

```
Doccure/
├── ApiGateway/Doccure.Gateway/     # Ocelot API Gateway
├── Frontends/Doccure.WebUI/        # ASP.NET Core MVC arayüzü (admin paneli dahil)
├── Microservices/
│   ├── Doccure.IdentityService/
│   ├── Doccure.PatientService/
│   ├── Doccure.AppointmentService/
│   ├── Doccure.DoctorService/
│   ├── Doccure.BranchService/
│   ├── Doccure.PharmacyService/
│   ├── Doccure.QueueService/
│   ├── Doccure.MarketService/
│   ├── Doccure.OrderService/
│   ├── Doccure.PrescriptionService/
│   └── Doccure.ReviewService/
└── Doccure.sln
```

## 🚀 Çalıştırma

> Bu bölüm kısa bir özettir; ayrıntılı kurulum eklenecektir.

1. Depoyu klonlayın:
   ```
   git clone https://github.com/isakcmz/DocCure-HastaneWebSitesi.git
   ```
2. Gerekli veritabanlarını (MSSQL, MongoDB, PostgreSQL, MariaDB) ve Redis'i ayağa kaldırın.
3. Her mikroservisin `appsettings.json` dosyasındaki bağlantı bilgilerini kendi ortamınıza göre güncelleyin.
4. EF Core kullanan servisler için migration'ları uygulayın:
   ```
   dotnet ef database update
   ```
5. Mikroservisleri, ardından Gateway'i ve en son WebUI'ı başlatın. Gateway'in yönlendirdiği adresler `ocelot.json` dosyasındadır.

## 🗺️ Yol Haritası

- [ ] Prescription ve Review servislerinin tamamlanması
- [ ] Elasticsearch ile arama
- [ ] RabbitMQ ile servisler arası asenkron haberleşme
- [ ] Docker Compose ile tüm sistemin tek komutla çalıştırılması
- [ ] CQRS / MediatR ile servislerin yeniden yapılandırılması

## 👤 Geliştirici

**İsa Furkan Kaçmaz** · [LinkedIn](https://linkedin.com/in/isa-furkan-kaçmaz-21a77a32a) · [GitHub](https://github.com/isakcmz)
