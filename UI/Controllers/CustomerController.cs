using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using UI.Models;

namespace UI.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            IEnumerable<CustomerModel> calList;
            HttpResponseMessage responce = GlobalVaribles.WebApClient.GetAsync("Customers/").Result;

            calList = responce.Content.ReadAsAsync<IEnumerable<CustomerModel>>().Result;
            return View(calList);
        }

        public ActionResult CustomerEkle(int id = 0) //crup:create,update
        {
            if (id == 0)
            {
                //burada ekleme sayfası çalışacak.
                return View();
            }
            else
            {
                //burada guncelle çalışacak.
                HttpResponseMessage responce = GlobalVaribles.WebApClient.GetAsync("Customers/" + id.ToString()).Result;
                return View(responce.Content.ReadAsAsync<CustomerModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult CustomerEkle(CustomerModel customer) //crup
        {
            if (customer.CustomerId == 0)
            {
                HttpResponseMessage responce = GlobalVaribles.WebApClient.PostAsJsonAsync("Customers/", customer).Result;
                TempData["SuccessMesaage"] = "Başarılı şekilde eklendi.";
            }
            else
            {
                HttpResponseMessage responce = GlobalVaribles.WebApClient.PutAsJsonAsync("Customers/" + customer.CustomerId, customer).Result;
                TempData["SuccessMesaage"] = "Başarılı şekilde güncellendi.";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            HttpResponseMessage responce = GlobalVaribles.WebApClient.DeleteAsync("Customers/" + id.ToString()).Result;
            TempData["SuccessMesaage"] = "Başarılı şekilde silindi.";
            return RedirectToAction("Index");

        }
    }
}