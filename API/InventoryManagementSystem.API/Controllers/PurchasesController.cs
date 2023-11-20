using InventoryManagementSystem.API.Models;
using InventoryManagementSystem.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IRepository<Purchases> _repository;
        public PurchasesController(IRepository<Purchases> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [ActionName("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult<List<Purchases>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResult<DefaultPayload>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ActionResult<DefaultPayload>))]
        public async Task<IActionResult> GetAllPurchases()
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult<Purchases>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResult<DefaultPayload>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ActionResult<DefaultPayload>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResult<DefaultPayload>))]
        public async Task<IActionResult> GetPurchase([FromQuery] long id)
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
        public async Task<IActionResult> AddPurchase([FromBody] Purchases purchases)
        {
            DefaultPayload response = new DefaultPayload();
            try
            {
                var purId = await _repository.AddAsync(purchases);
                if (purId == 0)
                {
                    response.Message = "Error Inserting the Entity";
                    return BadRequest(response);
                }
                return Ok(new { PurchaseId = purId });
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
        public async Task<IActionResult> UpdatePurchase([FromBody] Purchases purchase, [FromQuery] long id)
        {
            DefaultPayload response = new DefaultPayload();
            try
            {
                purchase.Id = id;
                var status = await _repository.UpdateAsync(purchase);
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
        public async Task<IActionResult> DeletePurchase([FromQuery] long id)
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
