using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProvaWeek6.Core.Entity;
using ProvaWeek6.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaWeek6.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IManagerBL mainBL;

        public OrdersController(IManagerBL mainBL)
        {
            this.mainBL = mainBL;
        }

        [HttpGet]
        public IActionResult FetchOrders()
        {
            var output = this.mainBL.FetchOrders();
            return Ok(output);
        }
      
        [HttpGet("{id}")]
        public IActionResult FetchOrderById(int id)
        {
            if (id<= 0)
                    return BadRequest("Invalid Order id.");

            var order = this.mainBL.FetchOrderById(id);
            if (order == null)
                return NotFound("Order not found.");
            return Ok(order);
        }

        [HttpPost]
        public IActionResult AddNewOrder(Order newOrder)
        {
            if (newOrder == null)
                return BadRequest("Invalid data received");

            var output = this.mainBL.CreateOrder(newOrder);

            if (!output)
                return StatusCode(500, "Cannot add new Order.");

            return CreatedAtAction(nameof(FetchOrderById), new { id = newOrder.Id }, newOrder);
        }

        [HttpPut("{id}")]
        public IActionResult EditOrder(int id, Order editedOrder)
        {
            if (id <= 0)
                return BadRequest("Invalid Order Id.");

            if (id != editedOrder.Id)
                return BadRequest("ERROR: Order IDs must match.");

            var output = this.mainBL.EditOrder(editedOrder);

            if (!output)
                return StatusCode(500, "Cannot modify the order.");

            return Ok(editedOrder);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Order Id.");

            var output = this.mainBL.DeleteOrderById(id);

            if (!output)
                return StatusCode(500, "Cannot delete the Order.");

            return Ok();
        }



    }
}
