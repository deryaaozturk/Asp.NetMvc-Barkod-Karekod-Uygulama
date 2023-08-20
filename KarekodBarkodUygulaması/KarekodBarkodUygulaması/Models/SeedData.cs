using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarekodBarkodUygulaması.Models
{
    /// <summary>
    /// Eğer database oluşmadıysa oluştursun, oluşturduktan sonra eğer products tablosu boş ise belirttiğimiz ürünleri otomatik olarak veritabanına eklemesini
    /// istiyoruz.
    /// </summary>
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            DatabaseContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<DatabaseContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.products.Any())
            {
                context.products.AddRange(
                    new Product
                    {
                        productBarkod = "2563654254145",
                        productImgUrl = "/img/productImg/2563654254145.jpg",
                        productBarkodImgUrl = "/img/productBarkodImg/2563654254145.png",
                        karekodImgUrl = "/img/productKarekodImg/2563654254145.png",
                        productName = "SanDisk Cruzer Glide 32GB USB 3.0 Usb Bellek SDCZ600-032G-G35",
                        productAdet = 120,
                        productFiyat = "74,00",
                        productAciklama = "Fotoğraf, video, müzik ve diğer dosyalarınız için hızlı, güvenilir ve güvenli USB 3.0 depolamasıyla aktarım " +
                        "yaparken daha az bekleyin. Beraberinde gelen SanDisk SecureAccess™ yazılımı1 parola koruması sağlayarak özel dosyalarınızı güvende " +
                        "tutarken, sürücünün geri kalanını paylaşım için uygun duruma getirir. Geri çekilebilir tasarım da sürücü kullanımda olmadığında USB " +
                        "3.0 bağlantısının güvende olmasını sağlar. Ayrıca, SanDisk USB flash sürücünüzün beş yıl sınırlı garanti2" +
                        " desteği verdiğini bilmek gönlünüzü rahatlatacak."
                    },
                    new Product
                    {
                        productBarkod = "8697445992049",
                        productAciklama = "Günümüzde internet teknolojileri, evlerin ve iş yerlerinin vazgeçilmezleri arasında ilk sırada yer alıyor. " +
                        "Bilgisayarların, telefonların ve televizyonların internete hızlı ve sorunsuz bir şekilde erişebilmesi, modemler veya telefon hatlarının " +
                        "hücresel veri özellikleri sayesinde mümkün oluyor.Kullanım kolaylığı sağlaması yönüyle kablosuz ağa bağlanmak için modemler tercih ediliyor. " +
                        "Bazı durumlarda uzaklık dolayısıyla kablosuz ağ sinyalleri zayıflıyor ve Wi-fi erişiminde kesintiler oluşabiliyor. Kablosuz ağa bağlanma " +
                        "sorunlarını ortadan kaldırmak için sinyal yakınlaştırıcı ve güçlendirici aletlerin kullanılması tavsiye ediliyor.Şıklığı kalite ile birleştiren " +
                        "Xiaomi markası, birçok üründe olduğu gibi sinyal yakınlaştırıcı ürünleriyle de kullanıcıların beğenisini topluyor. Fonksiyonel özellikleri ve " +
                        "kurulum kolaylığı ile Xiaomi Mi Wifi Pro sinyal yakınlaştırıcı - güçlendirici 300 Mbps - global versiyonu, wireless adaptörler kategorisinde ön " +
                        "plana çıkıyor.Fonksiyonel Özellikleri ile Mi Wifi Pro sinyal Yakınlaştırıcı Sinyal güçlendirici, adaptör şeklinde prize takılabilme özelliği ile " +
                        "kullanım kolaylığı sağlıyor. İki küçük anteni sayesinde Wi-fi çekim gücünün artmasını sağlıyor. Siyah rengi ve minimal tasarımı ile Xiaomi sinyal " +
                        "yakınlaştırıcı, kablosuz olması yönüyle de sıklıkla tercih ediliyor. Taşınabilir özellikte ve hafif yapıda olması, ürünün işlevselliğini artırıyor." +
                        "Mi wireless adaptör, evlerde ve ofislerde kablosuz ağ bağlantı noktasının kapsamını genişletmeye yardımcı oluyor. Cihazda bulunan wireless ağ " +
                        "bağdaştırıcısı sayesinde Xiaomi Pro sinyal yakınlaştırıcı, modemden aldığı Wi-fi sinyalini tekrarlayarak dağıtma mantığıyla çalışıyor. Ayrıca, " +
                        "kablosuz bağlantı hızını 300 Mbps artırabiliyor. Böylelikle hızlı ve sorunsuz bir şekilde internet bağlantısı gerçekleştirilebiliyor. Sinyal " +
                        "yakınlaştırıcının fonksiyonel özelliklerinden en üst seviyede yararlanmak için güçlendiriciyi, kablosuz ağ kapsama alanı içerisinde, orta noktada, " +
                        "kullanmak gerekiyor.Xiaomi Mi Wifi Pro sinyal yakınlaştırıcı ve güçlenirici, farklı modemlerde de kullanabiliyor. Sinyal yakınlaştırıcı aletin alt " +
                        "tarafında reset noktası bulunuyor. İğne yardımıyla bu noktaya 10 saniye boyunca basılı tutularak aleti fabrika ayarlarına döndürebilirsiniz. " +
                        "Böylelikle sinyal güçlendirici, başka modemlerde rahatlıkla kullanılabilir hâle gelir.Fiyat performans ürünü olarak kullanıcıların beğenisini " +
                        "toplayan sinyal güçlendirici adaptör, kullanıcılara en iyi sinyal garantisini sunuyor. İnternet bağlantısında sorun yaşayan kişiler, evlerinde " +
                        "ya da işyerlerinde, kablosuz ağa bağlanmanın en zor olduğu noktalarda bile rahatlıkla Wi-fi ağına ulaşmanın keyfini yaşıyorlar.Kurulum Kolaylığı " +
                        "ile Xiaomi Wifi Sinyal Güçlendirici Mi Wifi sinyal yakınlaştırıcı wireless adaptörün kullanımı oldukça kolaydır. Öncelikle adaptörü bir prize takın." +
                        " Ardından cep telefonunuzun Playstore ya da App store uygulamalarından Mi Home uygulamasını yükleyin.Mi Home uygulamasını açın ve ekranın sağ üst " +
                        "köşesindeki “+” işaretine tıklayın. Açılan sayfada sinyal yakınlaştırıcı ürün sembolünün üzerine tıklayın. Hangi ağa bağlanmak isterseniz o ağın " +
                        "üzerine tıklayın ve “ileri” seçeneğine tıklayın. Kısa bir süre sonra bağlantı işlemi tamamlanır. Telefonunuzda “bağlantı başarılı” yazısının " +
                        "çıkması ile kurulum işlem tamamlanmış olur.Xiaomi Mi Wifi Pro sinyal yakınlaştırıcı - güçlendirici aletin altında yanıp sönen LED ışıkların " +
                        "yardımı ile bağlantı hakkında bilgi sahibi olabiliyorsunuz. Sinyal yakınlaştırıcının alt kısmındaki LED ışık noktasında beliren sarı ışık, " +
                        "aletin modemle bağlantıya hazır olduğunu; mavi ışık ise aletin modemle bağlantısının tamamlanmış olduğunu belirtiyor.İsterseniz Mi Pro sinyal " +
                        "güçlendirici için telefonunuza kısayol oluşturabilirsiniz. Oluşturduğunuz kısayolda sinyal güçlendiricinin adını değiştirebilir ve yeni bir " +
                        "şifre belirleyebilirsiniz.Xiaomi Mi Wifi Pro sinyal güçlendiriciye farklı aletlerin bağlanabilmesi için her defasında telefon uygulamasından " +
                        "kurulum yapmak gerekmiyor. Sinyal güçlendiriciyi modeme bağlamak için bir kereliğine telefon uygulamasından kurulumun yapılması yeterli oluyor. " +
                        "Kurulumu yapılan sinyal yakınlaştırıcı alete birden fazla cihaz sorunsuzca bağlanabiliyor.",
                        productFiyat = "199,00",
                        productImgUrl = "/img/productImg/8697445992049.jpg",
                        productBarkodImgUrl = "/img/productBarkodImg/8697445992049.png",
                        karekodImgUrl = "/img/productKarekodImg/8697445992049.png",
                        productName = "Xiaomi Mi Wifi Pro Sinyal Yakınlaştırıcı - Güçlendirici 300 Mbps - Global Versiyon",
                        productAdet = 15
                    },
                    new Product
                    {
                        productBarkod = "2569872563245",
                        productAciklama = "Bilgisayarda, telefonda, tablette ve diğer cihazlarda yazı yazmak için ideal, kolayca bluetooth ile bağlanabilen, " +
                        "ultra ince tasarımlı Çoklu Cihaz klavyesidir. Farklı renk seçenekleriyle, minimalist ve modern tasarımıyla, tarzınıza ve masa düzeninize " +
                        "uyum sağlar. Ayrıca hafif ve kompakt olduğu için kolayca taşınabilir. Harici klavye desteği olan tüm Bluetooth kablosuz aygıtlara bağlanma " +
                        "özelliğiyle Windows, macOS, iPadOS, Chrome OS, Android, iOS ve hatta Apple TV üzerinden kolaylıkla çalışmanıza olanak tanır. Farklı işletim " +
                        "sistemlerine sahip olsalar bile üç cihazla eşleştirebilir ve tek dokunuşla cihazlar arasında geçiş yapabilirsiniz. 2 yıl pil ömrü vardır. Akıcı, " +
                        "sessiz ve dizüstü bilgisayara benzer bir yazma deneyimi sunan kavisli, düşük profilli çatal tuşlar parmak uçlarınızla uyum sağlar.",
                        productFiyat = "479,00",
                        productAdet = 95,
                        productBarkodImgUrl = "/img/productBarkodImg/2569872563245.png",
                        productImgUrl = "/img/productImg/2569872563245.jpg",
                        productName = "Logitech K380 Kompakt Kablosuz Bluetooth Türkçe Klavye - Siyah",
                        karekodImgUrl = "/img/productKarekodImg/2569872563245.png",
                    },
                    new Product
                    {
                        productBarkod = "2546325874125",
                        productAciklama = "Yemeklerinize lezzet katacak olan TAÇ Granit Derin Tencere.. Kusursuz granit iç kaplaması, yanmaz, yapışmaz duruşu yapısının " +
                        "yanında bakterilerin olmasını ve yayılmasını önler. Oval duruşa sahip olan derin tencere, çizilmelere karşı dayanıklı ve sağlamdır. Mutfağınızda " +
                        "severek kullanacağınız bu tasarımın çelik tutacakları kararmaz, paslanmaz yapıdadır. Sağlam, kırılmazcam kapağı sayesinde yemeklerinizin pişme " +
                        "süresini kolaylıkla takip edebilirsiniz. Uzun yıllar güvenli ve sağlıklı şekilde kullanabileceğiniz derin tencere; bulaşık makinesinde " +
                        "yıkanabilir, elde yıkama tavsiye edilir. Metal gereçlerin tencereye temas etmemesi önerilir. Dilerseniz tekli dilerseniz de farklı boyutları" +
                        " ve çeşitlerini inceleyip set halinde alıp kullanabilirsiniz.",
                        productFiyat = "589,00",
                        productAdet = 68,
                        productBarkodImgUrl = "/img/productBarkodImg/2546325874125.png",
                        productImgUrl = "/img/productImg/2546325874125.jpg",
                        productName = "Taç Gravita Beyaz Derin Granit Tencere 24 cm",
                        karekodImgUrl = "/img/productKarekodImg/2546325874125.png",
                    },
                    new Product
                    {
                        productBarkod = "2546398574125",
                        productAciklama = "Grundig Soup Maker’ın önceden programlanmış 5 menü özelliği sayesinde ihtiyaca uygun menü, tek tuşla seçilebiliyor. " +
                        "Taneli Çorba, Pürüzsüz Çorba ve Sos menüleri sayesinde isteğe göre karışım hazırlayabilen Grundig Soup Maker’ın Buz Kırma özelliği ise " +
                        "soğuk karışımların daha ferahlatıcı olmasını sağlıyor. Auto Clean özelliği ile ise bıçak ve hazne temizliği pratik bir şekilde " +
                        "gerçekleştiriliyor.",
                        productFiyat = "1.749,00",
                        productAdet = 57,
                        productBarkodImgUrl = "/img/productBarkodImg/2546398574125.png",
                        productImgUrl = "/img/productImg/2546398574125.jpg",
                        productName = "Grundig Çorba Makinesi ve Blender Professional Line CB 8760",
                        karekodImgUrl = "/img/productKarekodImg/2546398574125.png",
                    },
                    new Product
                    {
                        productBarkod = "1386301780018",
                        productAciklama = "Silerek temizleyebilirsiniz. Detaylı bakım talimatları için lütfen ürün etiketini kontrol ediniz.",
                        productFiyat = "174,90",
                        productAdet = 856,
                        productBarkodImgUrl = "/img/productBarkodImg/1386301780018.png",
                        productImgUrl = "/img/productImg/1386301780018.jpg",
                        productName = "Hummel David Sırt Çantası",
                        karekodImgUrl = "/img/productKarekodImg/1386301780018.png",
                    },
                    new Product
                    {
                        productBarkod = "8569523547585",
                        productAciklama = "Viko Multi-Let Üçlü Priz Topraklı Kablolu Çocuk Korumalı 5 Metre-Beyaz Viko Multi-Let Üçlü Priz Topraklı Kablolu Çocuk Korumalı 5 Metre-Beyaz",
                        productFiyat = "95,77",
                        productAdet = 785,
                        productBarkodImgUrl = "/img/productBarkodImg/8569523547585.png",
                        productImgUrl = "/img/productImg/8569523547585.jpg",
                        productName = "Viko Multi-Let Üçlü Priz Topraklı Kablolu Çocuk Korumalı 5 Metre-Beyaz",
                        karekodImgUrl = "/img/productKarekodImg/8569523547585.png",
                    },
                    new Product
                    {
                        productBarkod = "5875421526354",
                        productAciklama = "Faber-Castell Silgi 4'lü Beyaz - Faber - Castell Beyaz Silgi 4 adet",
                        productFiyat = "24,65",
                        productAdet = 569,
                        productBarkodImgUrl = "/img/productBarkodImg/5875421526354.png",
                        productImgUrl = "/img/productImg/5875421526354.jpg",
                        productName = "Faber-Castell Silgi 4'lü Beyaz",
                        karekodImgUrl = "/img/productKarekodImg/5875421526354.png",
                    },
                    new Product
                    {
                        productBarkod = "9652452147852",
                        productAciklama = "Jump 27355 Kadın Spor Ayakkabısı Tekstil + Suni Deridir",
                        productFiyat = "399,90",
                        productAdet = 569,
                        productBarkodImgUrl = "/img/productBarkodImg/9652452147852.png",
                        productImgUrl = "/img/productImg/9652452147852.jpg",
                        productName = "Jump 27355 Kadın Spor Ayakkabı",
                        karekodImgUrl = "/img/productKarekodImg/9652452147852.png",
                    },
                    new Product
                    {
                        productBarkod = "3654721587542",
                        productAciklama = "SANDAL Oda ve Çamaşır Spreyi",
                        productFiyat = "77,35 ",
                        productAdet = 54,
                        productBarkodImgUrl = "/img/productBarkodImg/3654721587542.png",
                        productImgUrl = "/img/productImg/3654721587542.jpg",
                        productName = "ARR Trader Frangrance Sandal Oda ve Çamaşır Spreyi",
                        karekodImgUrl = "/img/productKarekodImg/3654721587542.png",
                    },
                    new Product
                    {
                        productBarkod = "4582369514258",
                        productAciklama = "Reflex Glove Flex Eldiven 100lü Beyaz M 4 Kutu",
                        productFiyat = "145,01",
                        productAdet = 158,
                        productBarkodImgUrl = "/img/productBarkodImg/4582369514258.png",
                        productImgUrl = "/img/productImg/4582369514258.jpg",
                        productName = "Reflex Glove Flex Eldiven 100LÜ Beyaz M 4 Kutu",
                        karekodImgUrl = "/img/productKarekodImg/4582369514258.png",
                    },
                    new Product
                    {
                        productBarkod = "5968754253654",
                        productAciklama = "Hassas bebek cildine özel olarak geliştirilen ıslak havlu çeşitleri, bez bölgesi ve tüm vücut temizliğinde etkili temizlik " +
                        "sağlar. Anne ve babalara pratiklik sunan bebek bakım ürünleri, farklı cilt tiplerine uygun olarak üretilir. Sleepy Sensitive ıslak havlu, bebek" +
                        " ve çocukların hassas cilt yapısının ihtiyaç duyduğu narin dokunuşu sunar. Doğal içeriklere sahip formülü ile bir adım öne çıkan ıslak havlu ile" +
                        " bebeğinizin temizlik ihtiyaçlarını etkili şekilde karşılayabilirsiniz. Her açıdan güvenli ve konforlu hijyen sunan Sleepy Sensitive ıslak havlu," +
                        " temizliğin yanı sıra bebeğinizin cildine hassas bakım da sağlar. Ekstra yumuşak ve kalın dokuya sahip ıslak havluları bebeğiniz ve kendiniz için" +
                        " güvenle tercih edebilirsiniz.",
                        productFiyat = "139,99",
                        productAdet = 70,
                        productBarkodImgUrl = "/img/productBarkodImg/5968754253654.png",
                        productImgUrl = "/img/productImg/5968754253654.jpg",
                        productName = "Sleepy Sensitive Islak Havlu 90'lı 12 Adet 1080 Yaprak",
                        karekodImgUrl = "/img/productKarekodImg/5968754253654.png",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
