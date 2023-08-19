using CameraShop.API.JWT;
using CameraShop.Application.Dto;
using CameraShop.Application.Dto.BrandDto;
using CameraShop.Application.Dto.Searches;
using CameraShop.Application.Dto.Searches.StockSearches;
using CameraShop.Application.Dto.SensorTypeDto;
using CameraShop.Application.UseCases.BrandUseCases;
using CameraShop.Application.UseCases.SensorTypeUseCases;
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
    public class SensorTypeController : ControllerBase
    {
        private readonly IUseCaseHandler _useCaseHandler;

        public SensorTypeController(IUseCaseHandler useCaseHandler)
        {
            this._useCaseHandler = useCaseHandler;
        }

        [HttpGet("sensorTypeSelection")]
        [AllowAnonymous]
        public IActionResult SensorTypeSelection([FromQuery] BasicSearch search, [FromServices] ISelectAllSensorType query)
        {
            return Ok(this._useCaseHandler.HandleQuery(query,search));
        }

        [HttpPost("createNewSensorType")]
        public IActionResult CreateNewSensorType([FromBody] NewSensorTypeDto action, [FromServices] INewSensorType command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
        [HttpPatch("updateSensorType")]
        public IActionResult UpdateSensorType([FromBody] UpdateSensorTypeDto action, [FromServices] IUpdateSensorType command)
        {
            this._useCaseHandler.HandleCommand(command, action);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveSensorType(int id, [FromServices] IRemoveSensorType command)
        {
            var idOnly = new IdOnlyDto();
            idOnly.Id = id;

            this._useCaseHandler.HandleCommand(command, idOnly);
            return NoContent();
        }
    }
}
