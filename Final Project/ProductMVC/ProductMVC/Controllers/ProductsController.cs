using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductMVC.Models;
using System.Text;

namespace ProductMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _httpClient;  //send  Http req to api
        private readonly string _apiUrl = "https://localhost:7218/api/products"; 

        public ProductsController(IHttpClientFactory factory)
                                                  // create an HttpClient instance.
        {
            _httpClient = factory.CreateClient();
        }

       
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(_apiUrl); //pause exe http res receive
            var products = new List<Product>();

            if (response.IsSuccessStatusCode)  //check response success
            {
                var json = await response.Content.ReadAsStringAsync();  // read res as string
                products = JsonConvert.DeserializeObject<List<Product>>(json); //convert json to list
            }

            return View("~/Views/Products/Index.cshtml", products);
        }


       
        public IActionResult Create()
        {
            return View("~/Views/Products/Create.cshtml");
        }

      
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var json = JsonConvert.SerializeObject(product);  //product list to json and send to api
            var content = new StringContent(json, Encoding.UTF8, "application/json");   //media type ,sendng in json

            var response = await _httpClient.PostAsync(_apiUrl, content); 

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Error creating product");
            return View("~/Views/Products/Create.cshtml", product);
        }

   
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiUrl}/{id}");

            return RedirectToAction(nameof(Index));
        }

 
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();  
            var product = JsonConvert.DeserializeObject<Product>(json);

            return View("~/Views/Products/Edit.cshtml", product);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_apiUrl}/{id}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Error updating product");
            return View("~/Views/Products/Edit.cshtml", product);
        }
      
        [HttpGet]
        public IActionResult Search()
        {
          
            return View("~/Views/Products/Search.cshtml");
        }

      
        [HttpPost]
      
        public async Task<IActionResult> Search(string category)
        {
            var products = new List<Product>();      
             
            if (!string.IsNullOrEmpty(category))
            {
                var response = await _httpClient.GetAsync(_apiUrl);  //Retreive product
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Product>>(json); //json to list

                   
                    products = products.Where(p => p.Category == category).ToList(); //filter by cat
                }
            }

            return View("~/Views/Products/SearchResult.cshtml", products);
        }
    }
}

