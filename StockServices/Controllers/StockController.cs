using Microsoft.AspNetCore.Mvc;
using StockServices.Data;
using StockServices.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockDbContext _db;
        
        public StockController(StockDbContext db)
        {
            _db = db;
        }

        // GET: api/<StockController>
        [HttpGet]
        public IEnumerable<Stock> Get()
        {
            return _db.Stocks.ToList();
        }

        // GET api/<StockController>/5
        [HttpGet("{id}")]
        public Stock Get(int id)
        {
            return _db.Stocks.Find(id);
        }

        // GET api/<StockController>/5
        [HttpGet("proid/{id}")]
        public IEnumerable<Stock> GetP(int id)
        {
            return _db.Stocks.Where(pId => pId.ProId == id).ToList();
        }

        // GET api/<StockController>/5
        [HttpGet("invid/{id}")]
        public IEnumerable<Stock> GetI(int id)
        {
            return _db.Stocks.Where(pId => pId.InvId == id).ToList();
        }

        [HttpGet("{pid}/{iid}")]
        public Stock GetpI(int pid, int iid)
        {
            return _db.Stocks.Where(sId => sId.ProId == pid && sId.InvId == iid).FirstOrDefault();
        }

        // POST api/<StockController>
        [HttpPost]
        public IActionResult Post([FromBody] Stock stk)
        {
            try
            {
                _db.Stocks.Add(stk);
                _db.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, stk);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status201Created, ex.Message);
            }
        }

        // PUT api/<StockController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Stock stk)
        {
            try
            {
                Stock newStk = Get(id);

                newStk.ProId = stk.ProId;
                newStk.InvId = stk.InvId;
                newStk.Quantity = stk.Quantity;
                newStk.IsActive = stk.IsActive;

                _db.SaveChanges();

                return StatusCode(StatusCodes.Status202Accepted, stk);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status201Created, ex.Message);
            }
        }

        // DELETE api/<StockController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _db.Stocks.Remove(Get(id));

                _db.SaveChanges();

                return StatusCode(StatusCodes.Status202Accepted);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status201Created, ex.Message);
            }
        }
    }
}
