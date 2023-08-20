using BarcodeLib;
using KarekodBarkodUygulaması.Models;
using KarekodBarkodUygulaması.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using ZXing;
using ZXing.Windows.Compatibility;

namespace KarekodBarkodUygulaması.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository repository;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(IProductsRepository repo, IWebHostEnvironment hostEnvironment)
        {
            repository = repo;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index(int productID)
        {
            return View(new ProductsViewModel
            {
                Products = repository.Products.Where(s => s.productID == productID)
            });
        }

        public IActionResult AllProduct(int page =1)
        {
            return View(repository.Products.ToList().ToPagedList(page,8));
        }

        public IActionResult SearchProduct(string ProdSearch)
        {
            return View(new ProductsViewModel
            {
                Products = repository.Products.Where(x => x.productName.Contains(ProdSearch) || x.productBarkod.Contains(ProdSearch))
            });
        }

        public IActionResult CodeScanner()
        {
            return View();
        }

        public async Task<IActionResult> QRCodeScanner([Bind("QRCodeImageFile")] BarcodeScannerViewModel Barkod)
        {
            var file = Barkod.QRCodeImageFile;
            string webRootPath = _hostEnvironment.WebRootPath + "\\img\\productKarekodImg\\ScanQRCodeImg\\";
            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string path = Path.Combine(webRootPath + fileName + ".png");
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(filestream);
            }
            var reader = new BarcodeReaderGeneric();
            Bitmap image = (Bitmap)Image.FromFile(path);
            Result result;
            string sonuc = "Geçersiz Barkod Girdiniz...";
            using (image)
            {
                LuminanceSource source;
                source = new ZXing.Windows.Compatibility.BitmapLuminanceSource(image);
                result = reader.Decode(source);
                if (result != null)
                {
                    sonuc = result.Text;
                    ViewBag.QRCodeText = sonuc;
                }
                else
                {
                    ViewBag.QRCodeText = sonuc;
                }
            }
            return View(new ProductsViewModel
            {
                Products = repository.Products.Where(x => x.productBarkod == sonuc)
            });
        }
        public async Task<IActionResult> BarcodeScanner([Bind("BarkodImageFile")] BarcodeScannerViewModel Barkod)
        {
            var file = Barkod.BarkodImageFile;
            string webRootPath = _hostEnvironment.WebRootPath + "\\img\\productBarkodImg\\ScanBarcodeImg\\";
            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string path = Path.Combine(webRootPath + fileName +".png");
            using (var filestream = new FileStream(path,FileMode.Create))
            {
                await file.CopyToAsync(filestream);
            }
            var reader = new BarcodeReaderGeneric();
            Bitmap image = (Bitmap)Image.FromFile(path);
            Result result;
            string sonuc = "Geçersiz Barkod Girdiniz...";
            using (image)
            {
                LuminanceSource source;
                source = new ZXing.Windows.Compatibility.BitmapLuminanceSource(image);
                result = reader.Decode(source);
                if (result != null)
                {
                    sonuc = result.Text;
                    ViewBag.BarcodeText = sonuc;
                }
                else
                {
                    ViewBag.BarcodeText = sonuc;
                }
            }
            return View(new ProductsViewModel
            {
                Products = repository.Products.Where(x => x.productBarkod == sonuc)
            });
        }

        [HttpPost]
        public string WebcamCapture()
        {
            var filePath = "";
            Result result = null;
            string sonuc = "Geçersiz Barkod Girdiniz...";
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files!= null)
                {
                    foreach (var file in files)
                    {
                        if (file.Length >0)
                        {
                            var fileName = file.FileName;
                            var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                            var fileExtension = Path.GetExtension(fileName);
                            var newFileName = string.Concat(myUniqueFileName, fileExtension);
                            string webRootPath = _hostEnvironment.WebRootPath + "\\img\\WebcamImg\\";
                            filePath = Path.Combine(webRootPath + newFileName);
                            if (!string.IsNullOrEmpty(filePath))
                            {
                                StoreInFolder(file,filePath);
                                var reader = new BarcodeReaderGeneric();
                                Bitmap image = (Bitmap)Image.FromFile(filePath);
                                using (image)
                                {
                                    LuminanceSource source;
                                    source = new ZXing.Windows.Compatibility.BitmapLuminanceSource(image);
                                    result = reader.Decode(source);
                                    if (result != null)
                                    {
                                        sonuc = result.Text;
                                    }
                                    else
                                    {
                                        sonuc = "null";
                                    }
                                    
                                }

                            }
                        }
                    }
                    StoreDeleteInFolder(filePath);
                    return sonuc;
                }
                else
                {
                    return "false";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        [HttpPost]
        public string WebcamAddCart()
        {
            var filePath = "";
            Result result = null;
            Product product = new Product();
            string sonuc = "Geçersiz Barkod Girdiniz...";
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = file.FileName;
                            var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                            var fileExtension = Path.GetExtension(fileName);
                            var newFileName = string.Concat(myUniqueFileName, fileExtension);
                            string webRootPath = _hostEnvironment.WebRootPath + "\\img\\WebcamImg\\";
                            filePath = Path.Combine(webRootPath + newFileName);
                            if (!string.IsNullOrEmpty(filePath))
                            {
                                StoreInFolder(file, filePath);
                                var reader = new BarcodeReaderGeneric();
                                Bitmap image = (Bitmap)Image.FromFile(filePath);
                                using (image)
                                {
                                    LuminanceSource source;
                                    source = new ZXing.Windows.Compatibility.BitmapLuminanceSource(image);
                                    result = reader.Decode(source);
                                    if (result != null)
                                    {
                                        product = repository.Products.Where(p => p.productBarkod == result.ToString()).FirstOrDefault();
                                        if (product != null)
                                        {
                                            sonuc = product.productID.ToString();
                                        }
                                        else
                                        {
                                            sonuc = "null";
                                        }
                                    }
                                    else
                                    {
                                        sonuc = "null";
                                    }

                                }

                            }
                        }
                    }
                    StoreDeleteInFolder(filePath);
                    return sonuc;
                }
                else
                {
                    return "false";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult WebcamListView(string id)
        {
            ViewBag.QRCodeText = id;
            return View(new ProductsViewModel
            {
                Products = repository.Products.Where(x => x.productBarkod == id)
            });
        }

        public void StoreInFolder(IFormFile file, string fileName)
        {
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }
        public void StoreDeleteInFolder(string fileName)
        {
            System.IO.File.Delete(fileName);
        }
    }
}
