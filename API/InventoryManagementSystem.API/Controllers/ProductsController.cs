using InventoryManagementSystem.API.Models;
using InventoryManagementSystem.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Products> _repository;
        public ProductsController(IRepository<Products> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [ActionName("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult<List<Products>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResult<DefaultPayload>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ActionResult<DefaultPayload>))]
        public async Task<IActionResult> GetAllProducts()
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult<Products>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResult<DefaultPayload>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ActionResult<DefaultPayload>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResult<DefaultPayload>))]
        public async Task<IActionResult> GetProduct([FromQuery] long id)
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
        public async Task<IActionResult> AddProduct( [FromBody] Products product)
        {
            DefaultPayload response = new DefaultPayload();
            try
            {
                var proId = await _repository.AddAsync(product);
                if (proId == 0)
                {
                    response.Message = "Error Inserting the Entity";
                    return BadRequest(response);
                }
                return Ok(new { ProductId = proId });
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
        public async Task<IActionResult> UpdateProduct([FromBody] Products product, [FromQuery] long id)
        {
            DefaultPayload response = new DefaultPayload();
            try
            {
                product.Id = id;
                var status = await _repository.UpdateAsync(product);
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
        public async Task<IActionResult> DeleteProduct( [FromQuery] long id)
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
