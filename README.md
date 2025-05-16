# Cental Araç Kiralama Projesi

Cental, kullanıcıların farklı araç modellerini inceleyip hızlı ve kolay bir şekilde rezervasyon yapmalarını sağlayan modern bir araç kiralama web uygulamasıdır. Sistem, hem kullanıcılar hem de yöneticiler için özelleştirilmiş paneller sunarak kapsamlı bir yönetim ve kullanıcı deneyimi sağlar.

---

## Teknik Altyapı  
Proje, ASP.NET Core MVC mimarisi ile çok katmanlı (n-tier) yapıya uygun olarak geliştirilmiştir. Katmanlar şunlardır:
- **Entity Layer**  
- **Data Access Layer**  
- **Business Layer**  
- **DTO Layer**  
- **WebUI**  

---
## Rol Tabanlı Yetkilendirme

Sistem; Admin, Manager ve User olmak üzere üç farklı rol bazlı panel ile çalışmaktadır. Her panelin kendi yetkileri ve erişim alanları vardır.

---

## Admin Paneli
-Roller & Kullanıcı Yetkilendirme
-Dashboard ile istatistik ve sistem özeti
-Gelen kullanıcı mesajlarını yönetme
-Araçlara yapılan puanlamaları ve değerlendirmeleri yönetme
-Marka ve araç bilgilerini CRUD işlemleriyle düzenleme
-Hakkımızda, hizmet süreçleri, öne çıkan özellikler gibi sayfa içeriklerini güncelleme
-Kullanıcı paneli genel bilgilendirme amaçlıdır ve kullanıcı deneyimine odaklanmıştır.  

---

## Kullanıcı Paneli
- Kayıt ve giriş işlemleri (Identity destekli)
- Profil bilgilerini düzenleme
- Geçmiş rezervasyonları görüntüleme ve takip etme
- Araçlara puan verme ve yorum bırakma
- İletişim formu aracılığıyla site yönetimiyle iletişime geçme

---

## Kullanılan Kütüphaneler & Özellikler
- Entity Framework Core (Code First)
- ASP.NET Core MVC
- Identity
- Mapster
- AutoMapper
- FluentValidation
- SweetAlert
- Lazy Loading
- Areas & ViewComponents

## Görseller  
Aşağıda proje ile ilgili ekran görüntülerini bulabilirsiniz:  

1) **Anasayfa**
   ![Anasayfa](https://github.com/user-attachments/assets/d6d34271-9fec-4689-a51e-22f309545c49)
2) **İletişim**
  ![İletişim](https://github.com/user-attachments/assets/14106ced-1695-4400-b351-abcbec914303)
3) **İletişim 2**
  ![İletişim Mesajı](https://github.com/user-attachments/assets/20705d10-9359-4bf3-8e30-1e30213b52d9)
3) **Giriş Yap**
   ![Login](https://github.com/user-attachments/assets/e0087c3f-6ddd-4adb-b365-52e95223336e)
4) **Kayıt Ol**
  ![Register](https://github.com/user-attachments/assets/9e53269f-1972-4e42-8cfe-28c5cdcf1311)
5) **Kullanıcı Arayüzü**
![User](https://github.com/user-attachments/assets/700cff3f-4d32-4aec-86cb-3abfa0753a3e)
6) **Manager Arayüzü**
  ![Manager](https://github.com/user-attachments/assets/433c3e63-a5c3-455c-9fc4-294834155c3f)
7) **Dashboard**
  ![Dashboard](https://github.com/user-attachments/assets/06a8a04b-bfa6-436a-acb5-f9c015a48c76)
8) **Rol Atama**
![Rol Atama](https://github.com/user-attachments/assets/4eede1e0-a860-40ab-95fd-653b01c15a03)
9) **Manager Rolüne Sahip Kullanıcılar**
![Manager Rolüne Sahip Kullanıcılar](https://github.com/user-attachments/assets/e1867878-7a5b-4969-9e2b-c6d5968d7ad1)
10) **Mesaj Detayı**
   ![Mesaj Detayı](https://github.com/user-attachments/assets/1756c058-467e-4bca-9f8d-75ec2f891f20)
12) **Hata Sayfaları**
  ![404](https://github.com/user-attachments/assets/0ed1038b-6bb6-4f67-b2bc-8cb7f27273bf)
  ![403](https://github.com/user-attachments/assets/7ec8af7b-aba9-4e2e-9a6a-f7f445e3dc6c)



   



   
