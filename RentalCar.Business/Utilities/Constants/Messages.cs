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
        public static string BrandNameAlreadyExists = "Marka zaten var";
        public static string ColorsListed = "Renkler listelendi";
        public static string ColorInsertionSuccess = "Renk eklendi";
        public static string ColorNameAlreadyExists = "Renk zaten var";
        public static string ColorDeletedSuccess = "Renk silindi";
        public static string ColorUpdatedSuccess = "Renk güncellendi";
        public static string CustomersListed = "Müşretiler listelendi";
        public static string CustomerNotFound = "Müşteri bulunamadı";
        public static string ThereIsACustomer = "Müşteri bulundu";
        public static string CustomerInsertionSuccess = "Müşteri eklendi";
        public static string CustomerDeletedSuccess = "Müşteri silindi";
        public static string CustomerUpdatedSuccess = "Müşteri güncellendi";
        public static string RentalsListed = "Kiralamalar listelendi";
        public static string RentalNotFound = "Kiralama bulunamadı";
        public static string ThereIsARental = "Kiralama bulundu";
        public static string RentalInsertionSuccess = "Araba kiralandı";
        public static string RentalDeletedSuccess = "Kiralama silindi";
        public static string RentalUpdatedSuccess = "Kiralama güncellendi";
        public static string RentalDateAlreadyExists = "Araba aynı tarih aralığında zaten kiralanmış";
    }
}
