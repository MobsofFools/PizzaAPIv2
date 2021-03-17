using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaAPIv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAPIv2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PController : ControllerBase
    {
        private readonly PizzaContext _context;
        public PController(PizzaContext context)
        {
            _context = context;
        }

        [Route("GetRecipes")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET");
            return await _context.Recipes.ToListAsync();
        }

        [Route("Check")]
        [HttpPost]
        public async Task<ActionResult<int>> CheckCustomer(Customer customer)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET");
            await using (_context)
            {
                if (_context.Customers.Any(e => e.CustomerEmail == customer.CustomerEmail))
                {
                    var cust = (from c in _context.Customers
                                where c.CustomerEmail == customer.CustomerEmail
                                select c).FirstOrDefault().CustomerId;
                    return cust;

                }
                else
                {
                    return 0;
                };
            }
        }
        [Route("GetOrderItems/{id}")]
        [HttpGet]
        public async Task<List<OrderItemInfo>> GetOrderItems(string id)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET");

            await using (_context)
            {
                var items = from oi in _context.OrderedItems
                            join o in _context.Orders on
                            oi.OrderId equals o.OrderId
                            join r in _context.Recipes on
                            oi.RecipeId equals r.RecipeId
                            where oi.OrderId == Convert.ToInt32(id)
                            select new OrderItemInfo
                            {
                                RecipeId = oi.RecipeId,
                                RecipeName = r.RecipeName,
                                Quantity = oi.Quantity,
                                RecipeImgSrc = r.RecipeImgSrc
                            };
                return await items.ToListAsync();
            }
        }

        [Route("GetAllOrderDetails")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetAllOrderDetails()
        {
            await using (_context)
            {
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                Response.Headers.Add("Access-Control-Allow-Headers", "*");
                Response.Headers.Add("Access-Control-Allow-Methods", "GET");

                var orders = (from o in _context.Orders
                              join c in _context.Customers
                              on o.CustomerId equals c.CustomerId
                              select new OrderDetails
                              {
                                  OrderId = o.OrderId,
                                  OrderDate = o.OrderDate,
                                  CustomerFname = c.CustomerFname,
                                  CustomerLname = c.CustomerLname,
                                  CustomerEmail = c.CustomerEmail,
                                  Total = o.Total,
                                  OrderStatus = o.OrderStatus
                              }).ToListAsync();
                return await orders;
            }
        }

        [Route("GetOrderDetails/{id}")]
        [HttpGet]
        public async Task<ActionResult<OrderDetails>> GetOrderDetails(int id)
        {
            await using (_context)
            {
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                Response.Headers.Add("Access-Control-Allow-Headers", "*");
                Response.Headers.Add("Access-Control-Allow-Methods", "GET");

                var order = (from o in _context.Orders
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
               
                return order;
            }
        }

        [Route("GetInProgress")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetInProgress()
        {
            await using (_context)
            {
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                Response.Headers.Add("Access-Control-Allow-Headers", "*");
                Response.Headers.Add("Access-Control-Allow-Methods", "GET");

                var orders = (from o in _context.Orders
                              join c in _context.Customers
                              on o.CustomerId equals c.CustomerId
                              where o.OrderStatus == "In Progress"
                              select new OrderDetails
                              {
                                  OrderId = o.OrderId,
                                  OrderDate = o.OrderDate,
                                  CustomerFname = c.CustomerFname,
                                  CustomerLname = c.CustomerLname,
                                  CustomerEmail = c.CustomerEmail,
                                  Total = o.Total,
                                  OrderStatus = o.OrderStatus
                              }).ToListAsync();
                return await orders;
            }
        }

        [Route("GetCompleted")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetCompleted()
        {
            await using (_context)
            {
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                Response.Headers.Add("Access-Control-Allow-Headers", "*");
                Response.Headers.Add("Access-Control-Allow-Methods", "GET");

                var orders = (from o in _context.Orders
                              join c in _context.Customers
                              on o.CustomerId equals c.CustomerId
                              where o.OrderStatus == "Completed"
                              select new OrderDetails
                              {
                                  OrderId = o.OrderId,
                                  OrderDate = o.OrderDate,
                                  CustomerFname = c.CustomerFname,
                                  CustomerLname = c.CustomerLname,
                                  CustomerEmail = c.CustomerEmail,
                                  Total = o.Total,
                                  OrderStatus = o.OrderStatus
                              }).ToListAsync();
                return await orders;
            }
        }
        [Route("GetPending")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetPending()
        {
            await using (_context)
            {
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                Response.Headers.Add("Access-Control-Allow-Headers", "*");
                Response.Headers.Add("Access-Control-Allow-Methods", "GET");

                var orders = (from o in _context.Orders
                              join c in _context.Customers
                              on o.CustomerId equals c.CustomerId
                              where o.OrderStatus == "Pending"
                              select new OrderDetails
                              {
                                  OrderId = o.OrderId,
                                  OrderDate = o.OrderDate,
                                  CustomerFname = c.CustomerFname,
                                  CustomerLname = c.CustomerLname,
                                  CustomerEmail = c.CustomerEmail,
                                  Total = o.Total,
                                  OrderStatus = o.OrderStatus
                              }).ToListAsync();
                return await orders;
            }
        }
    }
}
