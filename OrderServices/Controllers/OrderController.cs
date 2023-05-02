using Microsoft.AspNetCore.Mvc;
using OrderServices.Data;
using OrderServices.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderDbContext _db;
        public OrderController(OrderDbContext db)
        {
            _db = db;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return _db.Orders.ToList();
        }

        // GET api/<OrderController>/5
        [HttpGet("order/{id}")]
        public Order GetOrder(int id)
        {
            return _db.Orders.Find(id);
        }

        // GET api/<OrderController>/5
        [HttpGet("ordDetails/{id}")]
        public IEnumerable<OrderDetail> GetOrdDetails(int id)
        {
            return _db.OrderDetails.Where(od => od.OrderId == id).ToList();
        }

        // GET api/<OrderController>/5
        [HttpGet("orderDetail/{id}")]
        public OrderDetail GetOrderDetail(int id)
        {
            return _db.OrderDetails.Find(id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] Order order,[FromBody] List<OrderDetail> orderDetail)
        { 
            try
            {
                _db.Orders.Add(order);
                _db.OrderDetails.AddRange(orderDetail);

                _db.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, order);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order order)
        {
            try
            {
                //List<OrderDetail> ordD = GetOrdDetails(id).ToList();
                //foreach (OrderDetail od in ordD)
                //{
                //    _db.OrderDetails.Remove(GetOrderDetail(od.Id));
                //}
                //_db.Orders.Remove(GetOrder(id));

                _db.SaveChanges();

                return StatusCode(StatusCodes.Status202Accepted);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                List<OrderDetail> ordD = GetOrdDetails(id).ToList();
                foreach(OrderDetail od in ordD)
                {
                    _db.OrderDetails.Remove(GetOrderDetail(od.Id));
                }
                _db.Orders.Remove(GetOrder(id));

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
