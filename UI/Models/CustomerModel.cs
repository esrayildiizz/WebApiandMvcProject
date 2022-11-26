using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "MÜŞTERİ AD GİRİLMESİ ZORUNLUDUR...")]
        public string CustomerName { get; set; }

        public string CustomerCity { get; set; }
    }
}