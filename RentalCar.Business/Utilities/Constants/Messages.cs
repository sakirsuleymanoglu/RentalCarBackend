using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RentalCar.Business.Utilities.Constants
{
    public static class Messages
    {
        public static string UserNotAuthorized = "Yetkiniz yok";
        public static string CreateAccessToken = "Token oluşturuldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı";
        public static string UserInsertionError = "Kullanıcı eklenirken bir hata meydana geldi";
        public static string RegistirationSuccessful = "Kayıt başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string BrandsListed = "Markalar listelendi";
        public static string BrandNotFound = "Marka bulunamadı";
        public static string ThereIsABrand = "Marka bulundu";
        public static string BrandInsertionSuccess = "Marka eklendi";
        public static string BrandDeletedSuccess = "Marka silindi";
        public static string BrandUpdatedSuccess = "Marka güncellendi";
        public static string ImageInsertionSuccess = "Resim eklendi";
        public static string NumberOfPicturesError = "En fazla 5 tane resim eklenebilir";
        internal static string ImageDeletedSuccess;
        internal static string CarNotFound;
        internal static string PictureCanBeAttached;
        internal static string ThereIsACar;
        internal static string ImageNotFound;
        internal static string ThereIsAImage;
        internal static string ImageUpdatedSuccess;
        internal static string PicturesListed;
    }
}
