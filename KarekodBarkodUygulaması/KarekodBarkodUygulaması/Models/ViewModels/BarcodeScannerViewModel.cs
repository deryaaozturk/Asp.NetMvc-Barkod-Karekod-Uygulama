using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KarekodBarkodUygulaması.Models.ViewModels
{
    public class BarcodeScannerViewModel
    {
        [NotMapped]
        [DisplayName("Upload Barcode File")]
        public IFormFile BarkodImageFile { set; get; }

        [NotMapped]
        [DisplayName("Upload QRCode File")]
        public IFormFile QRCodeImageFile { set; get; }
    }
}
