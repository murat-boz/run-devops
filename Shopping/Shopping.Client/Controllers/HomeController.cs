using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopping.Client.Models;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Shopping.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<HomeController> logger;

        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            this.logger     = logger ?? throw new ArgumentNullException(nameof(logger));
            this.httpClient = httpClientFactory.CreateClient("ShoppingAPIClient");
        }

        public async Task<IActionResult> Index()
        {
            var response = await this.httpClient.GetAsync("/product");
            var content  = await response.Content.ReadAsStringAsync();

            var productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);

            return View(productList);
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
