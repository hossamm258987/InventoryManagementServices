using Microsoft.AspNetCore.Mvc;
using TypeServices.Data;
using TypeServices.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TypeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly TypeDbContext _db;

        public TypeController(TypeDbContext db)
        {
            _db = db;
        }

        // GET: api/<TypeController>
        [HttpGet]
        public IEnumerable<ProType> Get()
        {
            return _db.ProTypes.ToList();
        }

        // GET api/<TypeController>/5
        [HttpGet("{id}")]
        public ProType Get(int id)
        {
            return _db.ProTypes.Find(id);
        }

        // POST api/<TypeController>
        [HttpPost]
        public IActionResult Post([FromBody] ProType type)
        {
            try
            {
                _db.ProTypes.Add(type);
                _db.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, type);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<TypeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProType type)
        {
            try
            {
                ProType t = Get(id);

                t.Name = type.Name;
                t.Description = type.Description;
                t.IsActive = type.IsActive;
                
                _db.SaveChanges();

                return StatusCode(StatusCodes.Status202Accepted, type);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<TypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _db.ProTypes.Remove(Get(id));

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
