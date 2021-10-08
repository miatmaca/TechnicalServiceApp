using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
   public  static class Messages
    {
       
        public static string Listed = "Başarıyla Listelendi";
        public static string ErrorMessage = "Hata Mesajı";
        public static string Added = "Eklendi";
        public static string Deleted = "Silindi";
        public static string Update = "Güncellendi";
       
        public static string NotFound="Öğe Bulunamadı";
        public static string UserNotFound="Kullanıcı Bulunamadı";
        public static string UserRegistered="Kullanıcı Kaydedildi";
        public static string PasswordError="Parola Hatası";
        public static string SuccessfulLogin="Kayıt Yapıldı";
        public static string UserAlreadyExists="Kayıtlı Kullanıcı";
        public static string AccessTokenCreated="Giriş Yapıldı";
        public static string AuthorizationDenied="Yetkiniz Yok";
      

        public static string PaymentAdded = "Payment Eklendi";
        public static string PaymentDelete = "Payment Silindi";
        public static string PaymentUpdate = "Payment Güncellendi";

        public static string CreditCardAdded="Kredi Kartı Eklendi";
        public static string CreditCardDelete = "Kredi Kartı Silindi";
        public static string CreditCardUpdate = "Kredi Kartı Güncellendi";
        public static string NoEmptyCreditCard = "Geçerli Kredi Kartı Bulunamadı";
        public static string InsBalance = "Yetersiz Bakiye";
        public static string Succes = "Ödeme Gerçekleştirildi";

        public static string useroperationclaimAdded = "Operasyon Eklendi";
        public static string useroperationclaimDelete = "Operasyon Silindi";
        public static string useroperationclaimUpdate= "Operasyon Güncellendi";
        public static string useroperationclaimListed= "Operasyon Listelendi";
        
        
        public static string CustomerAdded="Müşteri Başarıyla Eklendi";
        public static string CustomerUpdate = "Müşteri Başarıyla Güncellendi";
        public static string CustomerDelete= "Müşteri Başarıyla Silindi";

        public static string EmployeeAdded = "Personel Başarıyla Eklendi";
        public static string EmployeeUpdate = "Personel Başarıyla Güncellendi";
        public static string EmployeeDelete= "Personel Başarıyla Silindi";

        public static string ProcessAdded="İşlem Eklendi";
        public static string ProcessUpdate = "İşlem Güncellendi";
        public static string ProcessDelete = "İşlem Silindi";
        
        public static string StateAdded="Durum Eklendi";
        public static string StateUpdate = "Durum Güncellendi";
        public static string StateDelete = "Durum Silindi";
        
        public static string productInfoAdded="Ürün Bilgisi Eklendi";
        public static string productInfoUpdate = "Ürün Bilgisi Güncellendi";
        public static string productInfoDelete = "Ürün Bilgisi Silindi";
        public static string productInfoListed = "Ürün Bilgisi Listelendi";
       
        public static string FaultInfoAdded="Arıza Bilgisi Eklendi";
        public static string FaultInfoUpdate = "Arıza Bilgisi Güncellendi";
        public static string FaultInfoDelete = "Arıza Bilgisi Silini";
       
        public static string MaterialUsedAdded="Kullanılan Malzeme Eklendi";
        public static string MaterialUsedUpdate = "Kullanılan Malzeme Güncellendi";
        public static string MaterialUsedDelete = "Kullanılan Malzeme Silindi";
        public static string MaterialUsedListed = "Kullanılan Malzeme Listelendi";

        public static string MadeProcessAdded="Yapılan İşlemler Eklendi";
        public static string MadeProcessUpdate = "Yapılan İşlemler Güncellendi";
        public static string MadeProcessDelete = "Yapılan İşlemler Silindi";
        public static string MadeProcessListed = "Yapılan İşlemler Listelendi";
    }
}
