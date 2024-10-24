using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobPortal.API.Helper;
using JobPortal.Application.DTOs.Authorize;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : Controller
    {
        [HttpPost]
        public IActionResult GetToken(AuthorizedDetailsDto authorizedDetails)
        {
            var authorizeService = new AuthorizedService();
            var token = authorizeService.GenerateToken(authorizedDetails);
            if (token != null)
                return Ok(new { token = token });
            else
                return Unauthorized();
        }
    }
}
