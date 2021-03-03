using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {

        public static string SameBrandAvailable = "Aynı marka mevcut";
        public static string SameColorAvailable = "Aynı renk mevcut";
        public static string SameUsernameAvailable = "Aynı kullanıcı adı mevcut";

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
        public static string CarImageLimitError ="Resim yükleme sınırına ulaşıldı";
    }
}
