using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarekodBarkodUygulaması.Models
{
    //Dependence Injection için kullanacağımız ürünler ve veritabanı işlemleri için gerekli interface sınıfı
    public interface IProductsRepository
    {
        IQueryable<Product> Products { get; }

        //Ürünlerin veritabanı üzerinde işlemlerini gerçekleştirecek gövdesiz fonksiyonlar (Gövdeleri kalıtım alan sınıf üzerinde belirtilecek)
        void SaveProducts(Product u);
        void CreateProducts(Product u);
        void DeleteProducts(Product u);
    }
}
