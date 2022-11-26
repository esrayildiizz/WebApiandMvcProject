using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "KATEGORİ AD GİRİLMESİ ZORUNLUDUR...")]
        public string CategoryName { get; set; }
    }
}