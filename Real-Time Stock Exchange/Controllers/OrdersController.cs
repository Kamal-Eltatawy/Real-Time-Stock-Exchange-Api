using ApplicationService.Services.OrderServices;
using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;


namespace Real_Time_Stock_Exchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices orderServices;

        public OrdersController(IOrderServices orderServices)
        {
            this.orderServices = orderServices;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(OrderRequestDTO orderRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await orderServices.CreateAsync(orderRequest);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDataResponseDTO>>> GetOrderHistory()

        {

            return await orderServices.GetAllOrderAsync();

        }





    }
}
