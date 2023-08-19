using CameraShop.API.JWT;
using CameraShop.Application.Dto;
using CameraShop.Application.Dto.Searches;
using CameraShop.Application.Dto.Searches.StockSearches;
using CameraShop.Application.Dto.Searches.User;
using CameraShop.Application.Dto.StockDto;
using CameraShop.Application.Dto.UserDto;
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
    public class UserController : ControllerBase
    {
        private readonly IUseCaseHandler _useCaseHandler;

        public UserController(IUseCaseHandler useCaseHandler)
        {
            this._useCaseHandler = useCaseHandler;
        }

        [HttpGet("UseCaseSelection")]
        public IActionResult useCaseSelection([FromQuery] BasicSearch search, [FromServices] ISelectUseCases query)
        {
            return Ok(this._useCaseHandler.HandleQuery(query,search));
        }

        [HttpGet("SelectUsers")]
        public IActionResult selectUsers([FromQuery] UserSearch search, [FromServices] IUserSelection query)
        {
            return Ok(this._useCaseHandler.HandleQuery(query, search));
        }
        [HttpGet("ActivateUserAccount")]
        [AllowAnonymous]
        public IActionResult activateUserAccount([FromQuery] UserActivisionLinkDto action, [FromServices] IActivateUserAccount command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
        [HttpPost("CreateAccount")]
        [AllowAnonymous]
        public IActionResult createAccount([FromBody] NewUserDto action, [FromServices] ICreateNewUser command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
        [HttpPatch("MenageUserPriviledges")]
        public IActionResult menageUserPriviledges([FromBody] MenageUserPrivelegdesDto action, [FromServices] IMenageUserPriviledges command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
        [HttpPut("UpdateUserInfo")]
        public IActionResult updateUserInfo([FromBody] UpdateUserDataDto action, [FromServices] IUpdateUserInfo command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
    }
}
