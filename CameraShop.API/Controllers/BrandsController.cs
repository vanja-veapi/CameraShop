using CameraShop.API.JWT;
using CameraShop.Application.Dto;
using CameraShop.Application.Dto.BrandDto;
using CameraShop.Application.Dto.Searches;
using CameraShop.Application.Dto.Searches.StockSearches;
using CameraShop.Application.UseCases.BrandUseCases;
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
    public class BrandsController : ControllerBase
    {
        private readonly IUseCaseHandler _useCaseHandler;

        public BrandsController(IUseCaseHandler useCaseHandler)
        {
            this._useCaseHandler = useCaseHandler;
        }

        [HttpGet("brandSelection")]
        [AllowAnonymous]
        public IActionResult BrandSelection([FromQuery] BasicSearch search, [FromServices] ISelectAllBrands query)
        {
            return Ok(this._useCaseHandler.HandleQuery(query,search));
        }

        [HttpPost("createNewBrand")]
        public IActionResult CreateNewBrand([FromBody] NewCameraBrandDto action, [FromServices] INewCameraBrand command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
        [HttpPatch("updateBrand")]
        public IActionResult UpdateBrand([FromBody] UpdateBrandDto action, [FromServices] IUpdateCameraBrand command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveBrand(int id, [FromServices] IRemoveBrand command)
        {
            var idOnly = new IdOnlyDto();
            idOnly.Id = id;

            this._useCaseHandler.HandleCommand(command, idOnly);
            return NoContent();
        }
    }
}
