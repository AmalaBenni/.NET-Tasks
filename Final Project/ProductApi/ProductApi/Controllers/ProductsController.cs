using ProductApi.Data;
using ProductApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public ProductsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

       
        [HttpGet]
        public IActionResult GetProduct()
        {
            var products = dbContext.Products.ToList();
            return Ok(products);
        }

       
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = dbContext.Products.Find(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

      
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
           
            product.AddedDate = DateTime.Now;

            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return Ok(new { Data = product });
        }

      
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = dbContext.Products.Find(id);
            if (product == null) return NotFound();

            product.Name = updatedProduct.Name;
            product.Category = updatedProduct.Category;
            product.Price = updatedProduct.Price;
            product.StockQuantity = updatedProduct.StockQuantity;


            dbContext.SaveChanges();
            return Ok(new { Data = product });
        }

      
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = dbContext.Products.Find(id);
            if (product == null) return NotFound();

            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return Ok(new { Data = product });
        }
    }
}