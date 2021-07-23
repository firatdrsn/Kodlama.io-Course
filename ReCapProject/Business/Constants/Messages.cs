using Entities.Concrete;
using System.Runtime.Serialization;

namespace Business.Constants
{
    public static class Messages
    {

        public static string SameBrandAvailable = "Aynı marka mevcut";
        public static string SameColorAvailable = "Aynı renk mevcut";

        public static string UserHasCompany = "Bu kullanıcının kayıtlı olduğu bir şirket zaten var";

        public static string CarNotDelivered = "Araç teslim edilmedi";
        public static string CarNameOrDailPriceInvalid = "Araç ismi veya günlük ücreti geçersiz";

        public static string NoRecordsToList = "Listelenecek kayıt yok";
        public static string RecordsListed = "Kayıtlar listelendi";
        public static string RecordFound = "Kayıt bulundu";
        public static string RecordAdded = "Kayıt eklendi";
        public static string RecordUpdated = "Kayıt güncellendi";
        public static string IdInvalid = "Geçersiz Id";
        public static string IdOrDateInvalid = "Geçersiz Id veya Tarih";
        public static string RecordDeleted = "Kayıt silindi";
        public static string CarImageLimitError = "Resim yükleme sınırına ulaşıldı";
        public static string RecordNull = "Kayıt yok. Null olarak geliyor";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UserAlreadyExists = "Aynı kullanıcı adı mevcut";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessForLogin = "Sisteme Giriş Başarılı";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string SuccessfulLogin = "Giriş başarılı";
    }
}
