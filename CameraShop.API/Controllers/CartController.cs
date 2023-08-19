using CameraShop.API.JWT;
using CameraShop.Application.Dto;
using CameraShop.Application.Dto.CartDto;
using CameraShop.Application.Dto.Searches;
using CameraShop.Application.Dto.Searches.StockSearches;
using CameraShop.Application.Dto.Searches.User;
using CameraShop.Application.Dto.StockDto;
using CameraShop.Application.Dto.UserDto;
using CameraShop.Application.UseCases.CartUseCases;
using CameraShop.Application.UseCases.StocksUseCases;
using CameraShop.Application.UseCases.UseCaseHandlers;
using CameraShop.Application.UseCases.UserUseCases;
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
    public class CartController : ControllerBase
    {
        private readonly IUseCaseHandler _useCaseHandler;

        public CartController(IUseCaseHandler useCaseHandler)
        {
            this._useCaseHandler = useCaseHandler;
        }

        [HttpGet("CartPreview")]
        public IActionResult cartPreview([FromQuery] EmptySearch search, [FromServices] IViewCart query)
        {
            return Ok(this._useCaseHandler.HandleQuery(query,search));
        }
        [HttpPost("PutInCart")]
        public IActionResult putInCart([FromBody] IteminCartDto action, [FromServices] IPutItemInCart command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
        [HttpPatch("RemoveFromCart")]
        public IActionResult removeFromCart([FromBody] RemoveItemFromCartDto action, [FromServices] IRemoveitemFromCart command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
        [HttpPost("PlaceOrder")]
        public IActionResult placeOrder([FromBody] IdOnlyDto action, [FromServices] IPlaceOrder command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
        [HttpPatch("CompleteOrder")]
        public IActionResult CompleteOrder([FromBody] IdOnlyDto action, [FromServices] ICompleteOrder command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
    }
}
