using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JobPortal.Application.Abstraction.Services;
using JobPortal.Application.DTOs.Location;

namespace JobPortal.API.Controllers
{
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_locationService.GetAllLocations());
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _locationService.GetLocation(id));
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateLocationDto request)
        {
            var location = await _locationService.CreateLocation(request);
            var url = Url.Action("Get", "Location", new { id = location.Id }, Request.Scheme);

            return Ok(url);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateLocationDto request)
        {
            await _locationService.UpdateLocation(request);
            return Ok();
        }
    }
}
