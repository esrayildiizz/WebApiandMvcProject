using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using UI.Models;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            IEnumerable<ProductModel> calList;
            HttpResponseMessage responce = GlobalVaribles.WebApClient.GetAsync("Products/").Result;

            calList = responce.Content.ReadAsAsync<IEnumerable<ProductModel>>().Result;
            return View(calList);
        }

        public ActionResult Ekle(int id = 0) //crup:create,update
        {
            if (id == 0)
            {
                //burada ekleme sayfası çalışacak.
                return View();
            }
            else
            {
                //burada guncelle çalışacak.
                HttpResponseMessage responce = GlobalVaribles.WebApClient.GetAsync("Products/" + id.ToString()).Result;
                return View(responce.Content.ReadAsAsync<ProductModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult Ekle(ProductModel product) //crup
        {
            if (product.ProductId == 0)
            {
                HttpResponseMessage responce = GlobalVaribles.WebApClient.PostAsJsonAsync("Products/", product).Result;
                TempData["SuccessMesaage"] = "Başarılı şekilde eklendi.";
            }
            else
            {
                HttpResponseMessage responce = GlobalVaribles.WebApClient.PutAsJsonAsync("Products/" + product.ProductId, product).Result;
                TempData["SuccessMesaage"] = "Başarılı şekilde güncellendi.";
            }
            return RedirectToAction("Index");
        }



        public ActionResult Sil(int id)
        {
            HttpResponseMessage responce = GlobalVaribles.WebApClient.DeleteAsync("Products/" + id.ToString()).Result;
            TempData["SuccessMesaage"] = "Başarılı şekilde silindi.";
            return RedirectToAction("Index");

        }

    }
}