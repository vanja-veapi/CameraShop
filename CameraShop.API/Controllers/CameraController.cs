using CameraShop.API.JWT;
using CameraShop.Application.Dto;
using CameraShop.Application.Dto.BrandDto;
using CameraShop.Application.Dto.CameraDto;
using CameraShop.Application.Dto.Searches;
using CameraShop.Application.Dto.Searches.CameraSearches;
using CameraShop.Application.Dto.Searches.StockSearches;
using CameraShop.Application.UseCases.BrandUseCases;
using CameraShop.Application.UseCases.CameraUseCases;
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
    public class CameraController : ControllerBase
    {
        private readonly IUseCaseHandler _useCaseHandler;

        public CameraController(IUseCaseHandler useCaseHandler)
        {
            this._useCaseHandler = useCaseHandler;
        }

        [HttpGet("camera/cameraSelection")]
        [AllowAnonymous]
        public IActionResult BrandSelection([FromQuery] CameraSearch search, [FromServices] ISelectCameras query)
        {
            return Ok(this._useCaseHandler.HandleQuery(query,search));
        }

        [HttpPost("camera/newCamera")]
        public IActionResult CreateNewCamera([FromForm] NewCameraDto action, [FromServices] INewCamera command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
        [HttpPatch("camera/updateCamera")]
        public IActionResult UpdateCamera([FromBody] UpdateCameraDto action, [FromServices] IUpdateCamera command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
        [HttpDelete("camera/{id}")]
        public IActionResult RemoveCamera(int id, [FromServices] IRemoveCamera command)
        {
            var idOnly = new IdOnlyDto();
            idOnly.Id = id;

            this._useCaseHandler.HandleCommand(command, idOnly);
            return NoContent();
        }
        [HttpDelete("discount/{id}")]
        public IActionResult RemoveCameraDiscount(int id, [FromServices] IRemoveCameraDiscount command)
        {
            var idOnly = new IdOnlyDto();
            idOnly.Id = id;

            this._useCaseHandler.HandleCommand(command, idOnly);
            return NoContent();
        }
        [HttpPost("discount/newDiscount")]
        public IActionResult NewCameraDiscount([FromBody]CameraOnDiscountDto action, [FromServices] IAddCameraDiscount command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
    }
}
