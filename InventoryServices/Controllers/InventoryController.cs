using InventoryServices.Data;
using InventoryServices.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryDbContext _db;

        public InventoryController(InventoryDbContext db)
        {
            _db = db;
        }

        // GET: api/<InventoryController>
        [HttpGet]
        public IEnumerable<Inventory> Get()
        {
            return _db.Inventories.ToList();
        }

        // GET api/<InventoryController>/5
        [HttpGet("{id}")]
        public Inventory Get(int id)
        {
            return _db.Inventories.Find(id);
        }

        // POST api/<InventoryController>
        [HttpPost]
        public IActionResult Post([FromBody] Inventory Inv)
        {
            try
            {
                _db.Inventories.Add(Inv);
                _db.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, Inv);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<InventoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Inventory Inv)
        {
            try
            {
                Inventory newInv = Get(id);
                newInv.Name = Inv.Name;
                newInv.Description = Inv.Description;
                newInv.Location = Inv.Location;
                newInv.MngId = Inv.MngId;
                newInv.IsActive = Inv.IsActive;

                _db.SaveChanges();

                return StatusCode(StatusCodes.Status202Accepted, Inv);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _db.Inventories.Remove(Get(id));
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
