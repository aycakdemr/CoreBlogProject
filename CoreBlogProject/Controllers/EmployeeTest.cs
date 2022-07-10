using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlogProject.Controllers
{
    public class EmployeeTest : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44351/api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<class1>>(jsonString);

            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(class1 p)
        {
            var httpClient = new HttpClient();
            
            var values = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(values, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44351/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44351/api/Default/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonemployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<class1>(jsonemployee);
                return View(values);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(class1 p)
        {
            var httpClient = new HttpClient();

            var values = JsonConvert.SerializeObject(p);
            var content = new StringContent(values, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44351/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44351/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
    public class class1
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}
