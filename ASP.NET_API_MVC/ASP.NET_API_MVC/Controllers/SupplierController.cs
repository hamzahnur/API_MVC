
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_API_MVC.Controllers
{


    public class SupplierController : Controller
    {


        readonly HttpClient Clien = new HttpClient { BaseAddress = new Uri("https://localhost:44349/API/") };
        // GET: Supplier
        public ActionResult Index()
        {
            IEnumerable<Supplier> suppliers = null;
            var respondTask = Clien.GetAsync("Suppliers");
            respondTask.Wait();
            var result = respondTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                suppliers = readTask.Result;
            }

            return View(suppliers);

        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {

            HttpResponseMessage respone = Clien.PostAsJsonAsync("Suppliers", supplier).Result;

            return RedirectToAction("Index");
        }

        public ActionResult Details(int Id)
        {
            IEnumerable<Supplier> suppliers = null;
            var respondTask = Clien.GetAsync("Suppliers");
            respondTask.Wait();
            var result = respondTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                suppliers = readTask.Result;
            }

            return View(suppliers.FirstOrDefault(s => s.Id == Id));
        }

        public ActionResult Delete(int Id)
        {

            IEnumerable<Supplier> suppliers = null;
            var respondTask = Clien.GetAsync("Suppliers/" + Id.ToString());
            respondTask.Wait();
            var result = respondTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                suppliers = readTask.Result;
            }
            return View(suppliers.FirstOrDefault(s => s.Id == Id));
        }

        [HttpPost]
        public ActionResult Delete(Supplier supplier, int Id)
        {
            var deleteTask = Clien.DeleteAsync("Suppliers/" + Id);
            deleteTask.Wait();

            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {
            IEnumerable<Supplier> suppliers = null;
            var respondTask = Clien.GetAsync("Suppliers");
            respondTask.Wait();
            var result = respondTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                suppliers = readTask.Result;
            }

            return View(suppliers.FirstOrDefault(s => s.Id == Id));
        }

        [HttpPost]
        public ActionResult Edit(Supplier supplier, int Id)
        {
            HttpResponseMessage response = Clien.PutAsJsonAsync<Supplier>("Suppliers/" + Id, supplier).Result;
            return RedirectToAction("Index");
        }


    }
}