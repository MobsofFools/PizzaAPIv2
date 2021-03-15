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
    public class ItemsController : ControllerBase
    {
        private readonly PizzaContext _context;

        public ItemsController(PizzaContext context)
        {
            _context = context;
        }

        // GET: api/OrderedItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderedItem>>> GetOrderedItems()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET");
            return await _context.OrderedItems.ToListAsync();
        }

        // GET: api/OrderedItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderedItem>> GetOrderedItem(int id)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET");
            var orderedItem = await _context.OrderedItems.FindAsync(id);

            if (orderedItem == null)
            {
                return NotFound();
            }

            return orderedItem;
        }

        // PUT: api/OrderedItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderedItem(int id, OrderedItem orderedItem)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "PUT");
            if (id != orderedItem.OrderedItemId)
            {
                return BadRequest();
            }

            _context.Entry(orderedItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderedItemExists(id))
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

        // POST: api/OrderedItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderedItem>> PostOrderedItem(OrderedItem orderedItem)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "POST");
            _context.OrderedItems.Add(orderedItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderedItem", new { id = orderedItem.OrderedItemId }, orderedItem);
        }

        private bool OrderedItemExists(int id)
        {
            return _context.OrderedItems.Any(e => e.OrderedItemId == id);
        }
    }
}
