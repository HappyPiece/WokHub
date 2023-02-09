using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WokHub.DAL;
using WokHub.Services;

namespace WokHub.Controllers
{
    [Route("api/check")]
    public class HealthController : ControllerBase
    {
        private readonly WokHubDbContext _context;
        private readonly ITokenService _tokenService;

        public HealthController(WokHubDbContext context, ITokenService tokenService)
        {
            _context = context ?? throw new ArgumentNullException();
            _tokenService = tokenService ?? throw new ArgumentNullException();
        }

        [HttpGet, Route("health")]
        public IActionResult Healthcheck()
        {
            return Ok("healthy");
        }

        [HttpGet, Route("if-authenticated"), Authorize]
        public IActionResult CheckAuthentication()
        {
            return Ok("authenticated");
        }
    }
}
