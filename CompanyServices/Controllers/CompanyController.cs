using CompanyServices.Data;
using CompanyServices.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyDbContext _db;

        public CompanyController(CompanyDbContext db)
        {
            _db = db;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return _db.Companies.ToList();
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public Company Get(int id)
        {
            return _db.Companies.Find(id);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public IActionResult Post([FromBody] Company company)
        {
            try
            {
                _db.Companies.Add(company);
                _db.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, company);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Company company)
        {
            try
            {
                Company com = Get(id);

                com.Name = company.Name;
                com.Description = company.Description;
                com.Phone = company.Phone;
                com.Email = company.Email;
                com.Country = company.Country;
                com.City = company.City;
                com.Street = company.Street;
                com.PostalCode = company.PostalCode;
                com.IsActive = company.IsActive;

                _db.SaveChanges();

                return StatusCode(StatusCodes.Status202Accepted, company);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _db.Companies.Remove(Get(id));
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
