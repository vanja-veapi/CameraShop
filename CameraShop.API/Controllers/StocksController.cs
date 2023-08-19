using CameraShop.API.JWT;
using CameraShop.Application.Dto;
using CameraShop.Application.Dto.Searches.StockSearches;
using CameraShop.Application.Dto.StockDto;
using CameraShop.Application.UseCases.StocksUseCases;
using CameraShop.Application.UseCases.UseCaseHandlers;
using CameraShop.EfDataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CameraShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StockController : ControllerBase
    {
        private readonly IUseCaseHandler _useCaseHandler;

        public StockController(IUseCaseHandler useCaseHandler)
        {
            this._useCaseHandler = useCaseHandler;
        }

        [HttpGet("stock/stockSelection")]
        [AllowAnonymous]
        public IActionResult SelectStocks([FromQuery] StockSearch search, [FromServices] ISelectStocks query)
        {
            return Ok(this._useCaseHandler.HandleQuery(query,search));
        }

        [HttpGet("stockPlace/stockPlacesSelection")]
        [AllowAnonymous]
        public IActionResult SelectStockPlaces([FromQuery] StockPlaceSearch search, [FromServices] ISelectStockPlaces query)
        {
            return Ok(this._useCaseHandler.HandleQuery(query, search));
        }
        [HttpPost("stockPlace/createStockPlace")]
        public IActionResult CreateStockPlace([FromBody] NewStockPlaceDto action, [FromServices] INewStockPlace command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
        [HttpPost("stock/createStock")]
        public IActionResult CreateStock([FromBody] PlaceInStockDto action, [FromServices] IPlaceStocks command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
        [HttpPatch("stockPlace/updateStockPlace")]
        public IActionResult UpdateStockPlace([FromBody] UpdateStockPlaceDto action, [FromServices] IUpdateStockPlace command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
        [HttpDelete("stockPlace/{id}")]
        public IActionResult RemoveStockPlace(int id, [FromServices] IRemoveStockPlace command)
        {
            var idOnly = new IdOnlyDto();
            idOnly.Id = id;

            this._useCaseHandler.HandleCommand(command, idOnly);
            return NoContent();
        }
        [HttpDelete("stock/{id}")]
        public IActionResult RemoveStock(int id, [FromServices] IRemoveStock command)
        {
            var idOnly = new IdOnlyDto();
            idOnly.Id = id;

            this._useCaseHandler.HandleCommand(command, idOnly);
            return NoContent();
        }
    }
}
