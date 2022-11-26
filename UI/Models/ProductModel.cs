using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "ÜRÜN AD GİRİLMESİ ZORUNLUDUR...")]
        public string ProductName { get; set; }

        public string ProductColor { get; set; }

        public int? ProductWeight { get; set; }

        public int? CategoryId { get; set; }
    }
}