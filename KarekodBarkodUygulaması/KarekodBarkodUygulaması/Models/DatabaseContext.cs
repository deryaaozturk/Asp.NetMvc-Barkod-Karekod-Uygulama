using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarekodBarkodUygulaması.Models
{
    /// <summary>
    /// DbContext sınıfı EntityFreamwork Core ile birlikte gelmektedir
    /// Code First yöntemi gereği veritabanını kod ile oluşturma işlemi için gerekli sınıf DbContext sınıfından kalıtım almaktadır
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }
        //Veritabanında oluşturulacak tabloları listeliyoruz şimdilik sadece products tablosu bulunmakta.
        public DbSet<Product> products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
