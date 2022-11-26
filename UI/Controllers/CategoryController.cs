using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using UI.Models;

namespace UI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            IEnumerable<CategoryModel> calList;
            HttpResponseMessage responce = GlobalVaribles.WebApClient.GetAsync("Categories/").Result;

            calList = responce.Content.ReadAsAsync<IEnumerable<CategoryModel>>().Result;
            return View(calList);
        }

        public ActionResult CategoryEkle(int id = 0) //crup:create,update
        {
            if (id == 0)
            {
                //burada ekleme sayfası çalışacak.
                return View();
            }
            else
            {
                //burada guncelle çalışacak.
                HttpResponseMessage responce = GlobalVaribles.WebApClient.GetAsync("Categories/" + id.ToString()).Result;
                return View(responce.Content.ReadAsAsync<CategoryModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult CategoryEkle(CategoryModel category) //crup
        {
            if (category.CategoryId == 0)
            {
                HttpResponseMessage responce = GlobalVaribles.WebApClient.PostAsJsonAsync("Categories/", category).Result;
                TempData["SuccessMesaage"] = "Başarılı şekilde eklendi.";
            }
            else
            {
                HttpResponseMessage responce = GlobalVaribles.WebApClient.PutAsJsonAsync("Categories/" + category.CategoryId, category).Result;
                TempData["SuccessMesaage"] = "Başarılı şekilde güncellendi.";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            HttpResponseMessage responce = GlobalVaribles.WebApClient.DeleteAsync("Categories/" + id.ToString()).Result;
            TempData["SuccessMesaage"] = "Başarılı şekilde silindi.";
            return RedirectToAction("Index");

        }
    }
}