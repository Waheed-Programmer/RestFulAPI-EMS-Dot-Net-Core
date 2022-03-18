using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using WebEmp_DLL.Entities;
using WebEmploye.Web.Models;

namespace WebEmploye.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Employee> employe = new List<Employee>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7185/");
            HttpResponseMessage message = await client.GetAsync("api/employee");
            if (message.IsSuccessStatusCode)
            {
                var result =message.Content.ReadAsStringAsync().Result;
                employe = JsonConvert.DeserializeObject<List<Employee>>(result);

            }

            return View(employe);
        }


        public async Task<IActionResult> Details()
        {
            Employee employe = new Employee();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7185/");
            HttpResponseMessage message = await client.GetAsync($"api/employee/id");
            if (message.IsSuccessStatusCode)
            {
                var result = message.Content.ReadAsStringAsync().Result;
                employe = JsonConvert.DeserializeObject<Employee>(result);

            }

            return View(employe);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}