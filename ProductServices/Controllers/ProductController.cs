using Microsoft.AspNetCore.Mvc;
using ProductServices.Data;
using ProductServices.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _db;

        public ProductController(ProductDbContext db)
        {
            _db = db;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _db.Products.ToList();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _db.Products.Find(id);
        }

        [HttpGet("order/{order}")]
        public IEnumerable<Product> Order(string order)
        {
            switch (order)
            {
                case "ExpDate_Asc":
                    return _db.Products.OrderBy(pro => pro.ExpireDate).ToList();
                case "ExpDate_Desc":
                    return _db.Products.OrderByDescending(pro => pro.ExpireDate).ToList();
                case "Supplier_Asc":
                    return _db.Products.OrderBy(pro => pro.SupplierId).ToList();
                case "Supplier_Desc":
                    return _db.Products.OrderByDescending(pro => pro.SupplierId).ToList();
                case "Category_Asc":
                    return _db.Products.OrderBy(pro => pro.CategoryId).ToList();
                case "Category_Desc":
                    return _db.Products.OrderByDescending(pro => pro.CategoryId).ToList();
                case "Inventory_Asc":
                    return _db.Products.OrderBy(pro => pro.InventoryId).ToList();
                case "Inventory_Desc":
                    return _db.Products.OrderByDescending(pro => pro.InventoryId).ToList();
            }
            return _db.Products.ToList();
        }

        [HttpGet("search/{search}")]
        public IEnumerable<Product> Search(string search)
        {
            IQueryable<Product> product = _db.Products;
            if(!string.IsNullOrEmpty(search))
            {
                product = product.Where(p => p.Name.Contains(search));
                return product;
            }
            return product;
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                _db.Products.Add(product);
                _db.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            try
            {
                Product pro = Get(id);
                pro.Name = product.Name;
                pro.Description = product.Description;
                pro.BuingPrice = product.BuingPrice;
                pro.SellingPrice = product.SellingPrice;
                pro.ProductionDate = product.ExpireDate;
                pro.SupplierId = product.SupplierId;
                pro.CategoryId = product.CategoryId;
                pro.TypeId = product.TypeId;
                pro.InventoryId = product.InventoryId;
                pro.IsActive = product.IsActive;

                _db.SaveChanges();

                return StatusCode(StatusCodes.Status202Accepted, product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _db.Products.Remove(Get(id));
                _db.SaveChanges();

                return StatusCode(StatusCodes.Status202Accepted);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
