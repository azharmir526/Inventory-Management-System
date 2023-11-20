using InventoryManagementSystem.API.Models;
using InventoryManagementSystem.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IRepository<Sales> _repository;
        public SalesController(IRepository<Sales> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [ActionName("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult<List<Sales>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResult<DefaultPayload>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ActionResult<DefaultPayload>))]
        public async Task<IActionResult> GetAllSales()
        {
            DefaultPayload response = new DefaultPayload();
            try
            {
                return Ok(await _repository.FindAllAsync());
            }
            catch (System.Exception)
            {
                response.Message = "Internal Error";
                return BadRequest(response);
            }
        }

        [HttpGet]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult<Sales>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResult<DefaultPayload>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ActionResult<DefaultPayload>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResult<DefaultPayload>))]
        public async Task<IActionResult> GetSale([FromQuery] long id)
        {
            DefaultPayload response = new DefaultPayload();
            try
            {
                var category = await _repository.FindByIdAsync(id);
                if (category == null)
                {
                    response.Message = "The Entity doesn't Exist";
                    return NotFound(response);
                }
                return Ok(category);
            }
            catch (System.Exception ex)
            {
                response.Message = "Internal Error";
                return BadRequest(response);
            }
        }

        [HttpPost]
        [ActionName("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IActionResult))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ActionResult<DefaultPayload>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResult<DefaultPayload>))]
        public async Task<IActionResult> AddSale([FromQuery]  long id,[FromQuery] long quantity)
        {
            DefaultPayload response = new DefaultPayload();
            try
            {
                if (id == 0)
                {
                    response.Message = "ProductsId is null";
                    return BadRequest(response);
                }
                Sales sales = new();
                sales.ProductsId = id;
                sales.Quantity = quantity;
                sales.Date = DateTime.Now;
                var salId = await _repository.AddAsync(sales);
                if (salId == 0)
                {
                    response.Message = "Error Inserting the Entity";
                    return BadRequest(response);
                }
                return Ok(new { SalesId = salId });
            }
            catch (System.Exception ex)
            {
                response.Message = "Internal Error";
                return BadRequest(response);
            }
        }

        [HttpPut]
        [ActionName("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult<DefaultPayload>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ActionResult<DefaultPayload>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResult<DefaultPayload>))]
        public async Task<IActionResult> UpdateSale([FromBody] Sales sales, [FromQuery] long id)
        {
            DefaultPayload response = new DefaultPayload();
            try
            {
                sales.Id = id;
                var status = await _repository.UpdateAsync(sales);
                if (!status)
                {
                    response.Message = "Error Updating the Entity";
                    return BadRequest(response);
                }
                response.Message = "Updated Successfully";
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                response.Message = "Internal Error";
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [ActionName("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult<DefaultPayload>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ActionResult<DefaultPayload>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResult<DefaultPayload>))]
        public async Task<IActionResult> DeleteSale([FromQuery] long id)
        {
            DefaultPayload response = new DefaultPayload();
            try
            {
                var status = await _repository.DeleteAsync(id);
                if (!status)
                {
                    response.Message = "Error Deleting the Entity";
                    return BadRequest(response);
                }
                response.Message = "Deleted Successfully";
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                response.Message = "Internal Error";
                return BadRequest(response);
            }
        }
    }
}
