using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ClassAddedSuccessfully = "Sınıf başarıyla eklendi.";
        public static string ClassQueryLengthExceeded = "Sınıf şubesi en fazla 10 haneli olabilir.";
        public static string ClassQueryLengthNotEnough = "Sınıf şubesi en az 1 haneli olabilir.";
        public static string ClassNumberTooHigh = "En fazla 12.sınıf eklenebilir.";
        public static string ClassNumberTooLow = "En az 1.sınıf eklenebilir.";
        public static string ClassListedSuccessfully = "Sınıflar başarıyla listelendi.";
        public static string ClassRemoveFailed = "Sınıf silinemedi.";
        public static string ClassRemovedSuccessfully = "Sınıf başarıyla silindi.";
        public static string ClassGetFailed = "İstenen sınıf çekilemedi.";

        public static string TeacherAddedSuccessfully = "Öğretmen başarıyla eklendi.";
        public static string TeacherAddingFailed = "Öğretmen eklenemedi. Lütfen verileri kontrol edin.";
        public static string TeacherMailAlreadyTaken = "Bu e-posta adresi kullanımda.";
        public static string TeacherDeletedSuccessfully = "Öğretmen başarıyla silindi.";
        public static string TeacherDeleteFailed = "Öğretmen silinemedi.";
        public static string TeacherLoginFailed = "Öğretmen giriş yapma başarısız.";

        public static string LessonAddedSuccessfully = "Ders başarıyla eklendi.";
        public static string LessonNameTooShort = "Ders adı en az 2 haneli olmalıdır.";
        public static string LessonDeletedSuccessfully = "Ders başarıyla silindi.";
        public static string LessonDeleteFailed = "Belirtilen ders bulunamadı.";
        public static string LessonUpdateFailed = "Belirtilen ders bilgisi güncellenemedi.";
        public static string LessonUpdatedSuccessfully = "Belirtilen ders bilgisi başarıyla güncellendi.";

        public static string TimeTableLessonAddedSuccessfully = "Haftalık programa istenen ders işlendi.";
        public static string TimeTableLessonAddFailedTimeError = "Bu sınıfın belirtilen saatler arasında dersi var.";
        public static string TimeTableLessonAddDaysOutOfRange = "Gün indexleri 0'dan başlayıp 6'ya kadar gider. Pazartesi 0, Pazar 6 kabul edilir. Lütfen isteğinizi buna göre yapınız.";


        public static string AccessDenied = "İstenen kaynağa erişim anabilgisayar tarafından reddedildi. İzin durumunuzu kontrol ettikten sonra tekrar bu hatayı alıyorsanız lütfen yazılım üreticinize başvurun.";
    }
}
