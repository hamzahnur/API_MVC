
using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_API_MVC.Controllers
{
    public class ItemsController : Controller
    {
        MyContext myContext = new MyContext();

        readonly HttpClient Clien = new HttpClient { BaseAddress = new Uri("https://localhost:44349/API/") };
        // GET: Items
        public ActionResult Index()
        {
            IEnumerable<ViewModel> items = null;
            var respondTask = Clien.GetAsync("Item");
            respondTask.Wait();
            var result = respondTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ViewModel>>();
                readTask.Wait();
                items = readTask.Result;
            }

            return View(items);
        }
        public ActionResult Create()
        {


            return View();

        }
        [HttpPost]
        public ActionResult Create(Item item)
        {
            HttpResponseMessage respone = Clien.PostAsJsonAsync("Item", item).Result;

            return RedirectToAction("Index");
        }

        public ActionResult Details(int Id)
        {
            IEnumerable<ViewModel> items = null;
            var respondTask = Clien.GetAsync("Item");
            respondTask.Wait();
            var result = respondTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ViewModel>>();
                readTask.Wait();
                items = readTask.Result;
            }

            return View(items.FirstOrDefault(s => s.Id == Id));

        }
        public ActionResult Delete(int Id)
        {
            IEnumerable<ViewModel> items = null;
            var respondTask = Clien.GetAsync("Item/" + Id.ToString());
            respondTask.Wait();
            var result = respondTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ViewModel>>();
                readTask.Wait();
                items = readTask.Result;
            }

            return View(items.FirstOrDefault(s => s.Id == Id));
        }

        [HttpPost]
        public ActionResult Delete(ViewModel viewModel, int Id)
        {
            var deleteTask = Clien.DeleteAsync("Item/" + Id);
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
            IEnumerable<Item> items = null;
            var respondTask = Clien.GetAsync("Item");
            respondTask.Wait();
            var result = respondTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Item>>();
                readTask.Wait();
                items = readTask.Result;
            }

            return View(items.FirstOrDefault(s => s.Id == Id));
        }

        [HttpPost]
        public ActionResult Edit(Item item, int Id)
        {
            HttpResponseMessage response = Clien.PutAsJsonAsync<Item>("Item/" + Id, item).Result;
            return RedirectToAction("Index");
        }
    }
}