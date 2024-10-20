using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeknorixJobs.API.Helper;
using TeknorixJobs.Application.DTOs.Authorize;

namespace TeknorixJobs.API.Controllers
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
