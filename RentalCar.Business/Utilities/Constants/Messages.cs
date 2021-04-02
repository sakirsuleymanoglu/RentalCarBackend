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
        public static string ImageDeletedSuccess = "Resim silindi";
        public static string CarNotFound = "Araba bulunamadı";
        public static string PictureCanBeAttached = "Resim eklenebilir";
        public static string ThereIsACar = "Araba bulundu";
        public static string ImageNotFound = "Resim bulunamadı";
        public static string ThereIsAImage = "Resim bulundu";
        public static string ImageUpdatedSuccess = "Resim güncellendi";
        public static string PicturesListed = "Resimler listeledi";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarInsertionSuccess = "Araba eklendi";
        public static string CarDeletedSuccess = "Araba silindi";
        public static string ColorNotFound = "Renk bulunamadı";
        public static string ThereIsAColor = "Renk bulundu";
        public static string CarUpdatedSuccess = "Resim güncellendi";
        public static string ThereIsAModelYear = "Model yılı bulundu";
        public static string ModelYearNotFound = "Model yılı bulunamadı";
        public static string ModelNotFound = "Model bulunamadı";
        public static string ThereIsAModel = "Model bulundu";
        public static string LoginSuccessful = "Giriş başarılı";
        public static string BrandNameAlreadyExists = "Marka ismi zaten var";
        internal static string ColorsListed;
        internal static string ColorInsertionSuccess;
        internal static string ColorNameAlreadyExists;
        internal static string ColorDeletedSuccess;
        internal static string ColorUpdatedSuccess;
    }
}
