using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KarekodBarkodUygulaması.Models
{
    //Veritabanındaki Ürünler tablosuna karşılık gelen product sınıfı
    public class Product
    {
        //Veritabanında productID alanının primaryKey olduğunu belirtmek için DataAnnotations kütüphanesinden faydalanıyoruz.
        [Key]
        //Ürün bilgileri
        public int productID { get; set; }
        public string productBarkod { get; set; }
        public string productImgUrl { get; set; }
        public string productBarkodImgUrl { get; set; }
        public string karekodImgUrl { get; set; }
        public string productName { get; set; }
        public string productAciklama { get; set; }
        public string productFiyat { get; set; }
        public int productAdet { get; set; }
        
    }
}
