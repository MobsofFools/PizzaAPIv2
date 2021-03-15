using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaAPIv2.Models;

namespace PizzaAPIv2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly PizzaContext _context;

        public OrdersController(PizzaContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET");
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET");
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "PUT");
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "POST");
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        [Route("SetInProgress/{id}")]
        [HttpPatch]
        public async Task<ActionResult<OrderDetails>> SetInProgress(int id)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "PATCH");
            if (OrderExists(id))
            {
                var order = await _context.Orders.FindAsync(id);
                order.OrderStatus = "In Progress";
                await _context.SaveChangesAsync();
                var od = (from o in _context.Orders
                             join c in _context.Customers
                             on o.CustomerId equals c.CustomerId
                             where o.OrderId == id
                             select new OrderDetails
                             {
                                 OrderId = o.OrderId,
                                 OrderDate = o.OrderDate,
                                 CustomerFname = c.CustomerFname,
                                 CustomerLname = c.CustomerLname,
                                 CustomerEmail = c.CustomerEmail,
                                 Total = o.Total,
                                 OrderStatus = o.OrderStatus
                             }).FirstOrDefault();
                return od;

            }
            else
            {
                return NotFound();
            }
        }
        [Route("SetCompleted/{id}")]
        [HttpPatch]
        public async Task<ActionResult<OrderDetails>> SetCompleted(int id)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "PATCH");
            if (OrderExists(id))
            {
                var order = await _context.Orders.FindAsync(id);
                order.OrderStatus = "Completed";
                await _context.SaveChangesAsync();
                var od = (from o in _context.Orders
                             join c in _context.Customers
                             on o.CustomerId equals c.CustomerId
                             where o.OrderId == id
                             select new OrderDetails
                             {
                                 OrderId = o.OrderId,
                                 OrderDate = o.OrderDate,
                                 CustomerFname = c.CustomerFname,
                                 CustomerLname = c.CustomerLname,
                                 CustomerEmail = c.CustomerEmail,
                                 Total = o.Total,
                                 OrderStatus = o.OrderStatus
                             }).FirstOrDefault();
                return od;
            }
            else
            {
                return NotFound();
            }
        }
        [Route("/S/{id}")]
        [HttpGet]
        public async Task<ActionResult<string>> GetStatus(int id)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET");
            await using (_context)
            {
                if (OrderExists(id))
                {
                    var status = (from o in _context.Orders
                                  where o.OrderId == id
                                  select new
                                  {
                                      o.OrderStatus
                                  }).FirstOrDefault().OrderStatus;
                    return status;
                }
                else return NotFound();
            }
        }


        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
