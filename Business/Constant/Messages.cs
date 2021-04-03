using Core.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constant
{
   public static class Messages
    {
        public static string Added = "ürün eklendi";
        public static string MinError = "Ürün en az 2 karakter olmalıdır";
        public static string ProductListed = "Ürünler Listelendi";
        public static string ProductDeleted = "Ürün Silindi";
        public static string ProductUpdated = "Ürün Güncellendi";
        public static string ProductGet = "Ürün Getirildi";
        public static string MaxProductForCategoryType = "Category Başına Ürün Sayısı Aşıldı" ;
        public static string ProductNameDouble = "Bu Ada Sahip Bir Ürün Mevcut ";
        public static string ProductImageLimitExtended = "Bu Ürün için maksimum resim sayısına ulaşıldı";
        public static string AuthorizationDenied = "Gerekli yetkiye sahip değilsiniz";
        public static string SuccessfulLogin = "Başarıyla giriş yapıldı";
        public static string UserNotFound = "Kullanıcı bulunumadı";
        public static string PasswordError = "Şifre hatalı";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string UserRegistered = "Kullanıcı kayıdı başarıyla tamamlandı";
        public static string Listed = "Listelendi";

        public static string UserAlreadyExists { get; internal set; }
    }
}
