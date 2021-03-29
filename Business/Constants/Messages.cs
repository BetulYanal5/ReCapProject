using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string Deleted = "silindi";
        public static string Updated = "Bilgiler güncellendi";
        public static string Listed = "Listelendi";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string RentalError = "Araç şu anda kullanımda olduğu için kiralanamaz,başka bir tarih için deneyin";
        public static string RentalTimeError = "Geçersiz tarih girildi";
        public static string ImageLimitExceded="En fazla 5 fotoğraf olabilir";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered="Kayıt oldu";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Parola hatası";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string AccessTokenCreated="Token oluşturuldu";
        internal static string SuccessfulLogin="Başarılı giriş";
    }
}
