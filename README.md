# Otel Rezervasyon Sistemi

## Proje Hakkında
Bu proje, .NET Framework kullanılarak geliştirilmiş n-katmanlı mimariye sahip bir otel rezervasyon sistemidir. Sistem, MySQL veritabanı ile entegre çalışmaktadır ve modern yazılım geliştirme prensiplerine uygun olarak tasarlanmıştır.

## Teknik Özellikler
- **Framework:** .NET Framework
- **Veritabanı:** MySQL
- **Mimari:** N-Katmanlı Mimari
- **Dil:** C#

## Sistem Özellikleri
- Müşteri yönetimi
- Oda yönetimi
- Rezervasyon işlemleri
- Ekstra hizmet yönetimi
- Fatura oluşturma ve takibi
- Yönetici paneli ile tam sistem kontrolü

## Veri Doğrulama ve Kısıtlamalar

### Müşteri İşlemleri
- TC Kimlik Numarası:
  - 11 haneli olmak zorunda
  - Sistem aynı TC kimlik numarası ile müşteri kaydına izin vermez
  - Sadece rakam girişi yapılabilir

- Telefon Numarası:
  - Başında 0 olmadan 10 haneli olmalı
  - Sadece rakam girişi yapılabilir
  - Örnek format: 5XX XXX XX XX

### Oda İşlemleri
- Oda Numarası:
  - Benzersiz olmalıdır
  - Aynı oda numarası ile yeni oda kaydı yapılamaz
  - Sistem otomatik kontrol yapar

### Rezervasyon İşlemleri
- Oda Müsaitlik Kontrolü:
  - Sistem dolu odalara rezervasyon yapılmasına izin vermez
  - Rezervasyon tarih aralığında otomatik kontrol yapılır
  - Çakışan rezervasyonlar engellenir

## Katmanlar

1. **Sunum Katmanı (Presentation Layer(UI))**
   - Kullanıcı arayüzü
   - Kullanıcı etkileşimleri
   - Form kontrolleri

2. **İş Katmanı (Business Layer)**
   - İş kuralları
   - Veri doğrulama
   - İşlem yönetimi

3. **Veri Erişim Katmanı (Data Access Layer)**
   - Veritabanı işlemleri
   - CRUD operasyonları
   - MySQL bağlantı yönetimi

## Veritabanı Yapısı

Sistem aşağıdaki ana tablolardan oluşmaktadır:
- Yonetici_tablo
- Musteri_tablo
- Oda_tablo
- Rezervasyon_tablo
- Fatura_tablo
- Ekstra_tablo

## Temel Fonksiyonlar

1. **Ana Sayfa**
   - Sayfalar arası geçiş
   - Anlık tarih/saat gösterimi
   - Çıkış yapma
    
     ![image](https://github.com/user-attachments/assets/bbceb69b-a3ea-4bfe-83d7-e2e9c5322244)

1. **Yönetici İşlemleri**
   - Sistem yönetimi
   - Giriş yapma
   - Kayıt Olma
     
     ![image](https://github.com/user-attachments/assets/a36791d5-46bf-4186-bc03-eebc12290425)
     ![image](https://github.com/user-attachments/assets/dd55597c-a5e8-4184-b027-3981690a3f5a)
     ![image](https://github.com/user-attachments/assets/c4821188-0916-475a-ba9d-634b347722cf)



2. **Müşteri İşlemleri**
   - Müşteri kaydı
   - Müşteri bilgi güncelleme
   - Müşteri silme
   
     ![image](https://github.com/user-attachments/assets/a0957940-98cd-4dcd-86a8-b07b2b32007f)

     

3. **Oda İşlemleri**
   - Oda oluşturma
   - Oda fiyat belirleme
   - Oda bilgi güncelleme
   - Oda silme
   
     ![image](https://github.com/user-attachments/assets/61deddf4-afdd-4ff1-986b-9d35f1746ac9)

  
4. **Kampanya İşlemleri**
   - Kampanya oluşturma
   - Kampanya fiyat belirleme
   
     ![image](https://github.com/user-attachments/assets/2a82ea2a-46fd-49f9-a834-5e4b3cebcf4d)


5. **Rezervasyon İşlemleri**
   - Yeni rezervasyon oluşturma
   - Rezervasyon güncelleme
   - Rezervasyon iptali
   - Oda müsaitlik kontrolü
   - Toplam tutar hesaplama
   
     ![image](https://github.com/user-attachments/assets/a95017db-c5c2-4d04-8357-07014a3cc61e)

  
6. **Fatura İşlemleri**
   - Otomatik fatura oluşturma
   - Fatura görüntüleme
   - Ödeme takibi
     
     ![image](https://github.com/user-attachments/assets/341dd1a5-2a34-4130-a11f-7433ce329fb6)
     ![image](https://github.com/user-attachments/assets/c60f30e8-b300-4e94-a7f4-35e673f9e47d)



## Diyagramlar
### ER Diyagramı

![23c3b3bd-01ee-4d7e-9043-2486c928defc](https://github.com/user-attachments/assets/5885c417-bf3c-443d-9e6a-bc1d2a1e0bf9)

### Use-Case Diyagramı

![a90a37e5-b0ca-4efa-8930-eb5cc8af55c9](https://github.com/user-attachments/assets/7bc92ea8-d130-4d10-9cf0-d64f7ecee888)

### UML Sınıf Diyagramı

![55dfbaa3-e1bc-4672-8f67-e196787ec1a7](https://github.com/user-attachments/assets/db1c71f7-3ff2-4239-9375-da9447677cc1)

## Geliştirici

**Yaren Kök**

## Program Videosu


