using System.Text;
using CrudApp_AspNetCoreWebAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CrudApp_AspNetCoreWebAPP.Controllers
{
    public class ProductsController : Controller
    {
        private string Base_Url = "https://localhost:7069/api/Products/";
        private HttpClient Client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Products> products = new List<Products>();
            HttpResponseMessage response = Client.GetAsync(Base_Url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Products>>(result);
                if(data != null)
                {
                    products = data;
                }
            }
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Products products) 
        { 
            string data = JsonConvert.SerializeObject(products);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = Client.PostAsync(Base_Url, stringContent).Result;
            if (response.IsSuccessStatusCode) 
            {
                TempData["Insert_Data"] = "Product has been Added!";
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Products products = new Products();
            HttpResponseMessage response = Client.GetAsync(Base_Url + id).Result;
            if (response.IsSuccessStatusCode) 
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Products>(result);
                if (data != null) 
                {
                    products = data;
                }
            }
            return View(products);
        }

        [HttpPost]
        public IActionResult Edit(Products products)
        {
            string data = JsonConvert.SerializeObject(products);
            StringContent Content = new(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = Client.PutAsync(Base_Url+products.itemId, Content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Update_Data"] = "Product has been Updated!";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Products products = new Products();
            HttpResponseMessage response = Client.GetAsync(Base_Url + id).Result;
            if (response.IsSuccessStatusCode) 
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var Convert_data = JsonConvert.DeserializeObject<Products>(data);
                if(Convert_data != null)
                {
                    products = Convert_data;
                    
                }
            }
            return View(products);
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            Products products = new Products();
            HttpResponseMessage response = Client.GetAsync(Base_Url + id).Result;
            if (response.IsSuccessStatusCode) 
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Products>(result);
                if(data != null) 
                {
                    products = data;
                }
            }
            return View(products);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmedDelete(int id)
        {
            Products products = new Products();
            HttpResponseMessage response = Client.DeleteAsync(Base_Url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Delete_Data"] = "Product has been Deleted!";
                return RedirectToAction("Index");
                
            }
            return View();
        }
    }
}
