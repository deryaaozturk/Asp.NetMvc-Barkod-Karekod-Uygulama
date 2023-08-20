using BarcodeLib;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZXing;
using ZXing.QrCode;

namespace KarekodBarkodUygulaması.Models
{
    //Database CRUD işlemlerinin yapılacağı fonksiyonlar ve EF sınıfı
    public class EFProductsRepository : IProductsRepository
    {

        private readonly IWebHostEnvironment _hostEnvironment;


        private DatabaseContext context;
        public EFProductsRepository(DatabaseContext ctx, IWebHostEnvironment hostEnvironment)
        {
            context = ctx;
            _hostEnvironment = hostEnvironment;
        }

        public IQueryable<Product> Products => context.products;

        public void GenereteQrCode(string barkod)
        {
            var writer = new QRCodeWriter();
            var resultBit = writer.encode(barkod, BarcodeFormat.QR_CODE, 100, 100);
            var matrix = resultBit;
            int scale = 2;
            Bitmap result = new Bitmap(matrix.Width * scale, matrix.Height * scale);
            for (int x = 0; x < matrix.Height; x++)
            {
                for (int y = 0; y < matrix.Width; y++)
                {
                    Color pixel = matrix[x, y] ? Color.Black : Color.White;
                    for (int i = 0; i < scale; i++)
                        for (int j = 0; j < scale; j++)
                            result.SetPixel(x * scale + i, y * scale + j, pixel);
                }
            }
            string webRootPath = _hostEnvironment.WebRootPath+ "\\img\\productKarekodImg\\";
            result.Save(webRootPath + barkod + ".png");
        }

        public void BarcodeGenerete(string barkod)
        {
            Barcode barcode = new Barcode();
            Image img = barcode.Encode(TYPE.EAN13,barkod,Color.Black,Color.White,250,100);
            string webRootPath = _hostEnvironment.WebRootPath + "\\img\\productBarkodImg\\";
            img.Save(webRootPath+barkod+".png");
        }

        public void CreateProducts(Product u)
        {
            try
            {
                GenereteQrCode(u.productBarkod);
                BarcodeGenerete(u.productBarkod);
                u.karekodImgUrl = "/img/productKarekodImg/" + u.productBarkod.ToString() + ".png";
                u.productBarkodImgUrl = "/img/productBarkodImg/" + u.productBarkod.ToString() + ".png";
                context.Add(u);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteProducts(Product u)
        {
            context.Remove(u);
            context.SaveChanges();
        }

        public void SaveProducts(Product u)
        {
            context.SaveChanges();
        }
    }
}
