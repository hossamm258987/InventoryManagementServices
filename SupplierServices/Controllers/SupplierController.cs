using Microsoft.AspNetCore.Mvc;
using SupplierServices.Data;
using SupplierServices.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SupplierServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly SupplierDbContext _db;

        public SupplierController(SupplierDbContext db)
        {
            _db = db;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public IEnumerable<Supplier> Get()
        {
            return _db.Suppliers.ToList();
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public Supplier Get(int id)
        {
            return _db.Suppliers.Find(id);
        }

        // POST api/<SupplierController>
        [HttpPost]
        public IActionResult Post([FromBody] Supplier supplier)
        {
            try
            {
                _db.Suppliers.Add(supplier);
                _db.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, supplier);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Supplier supplier)
        {
            try
            {
                Supplier supp = Get(id);

                supp.Name = supplier.Name;
                supp.Description = supplier.Description;
                supp.Phone = supplier.Phone;
                supp.Email = supplier.Email;
                supp.Country = supplier.Country;
                supp.City = supplier.City;
                supp.Street = supplier.Street;
                supp.PostalCode = supplier.PostalCode;
                supp.CompanyId = supplier.CompanyId;
                supp.IsActive = supplier.IsActive;

                _db.SaveChanges();

                return StatusCode(StatusCodes.Status202Accepted, supplier);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _db.Suppliers.Remove(Get(id));

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
