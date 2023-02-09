using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WokHub.DAL;
using WokHub.DTO;
using WokHub.Services;

namespace WokHub.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly WokHubDbContext _wokHubDbContext;
        private readonly ITokenService _tokenService;

        public AuthController(WokHubDbContext wokHubDbContext, ITokenService tokenService)
        {
            _wokHubDbContext = wokHubDbContext ?? throw new ArgumentNullException("DbContext not supplied");
            _tokenService = tokenService ?? throw new ArgumentNullException("tokenService not supplied");
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _wokHubDbContext.Users.FirstOrDefaultAsync(x => (x.Email == loginDTO.Email) && (x.Password == loginDTO.Password));
            if (user is null)
            {
                return BadRequest("Invalid credentials");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _wokHubDbContext.SaveChangesAsync();

            return Ok(new AuthenticateSuccessDTO
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            });
        }

        [HttpPost, Route("refresh")]
        public async Task<IActionResult> Refresh(RefreshDTO refreshDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var principal = _tokenService.GetPrincipalFromToken(refreshDTO.AccessToken ?? throw new ArgumentNullException("Access token not supplied"));

            var user = await _wokHubDbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == principal.Identity.Name);

            if (user is null || user.RefreshToken != refreshDTO.RefreshToken || user.RefreshTokenExpiryTime < DateTime.UtcNow)
            {
                return BadRequest();
            }

            var accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _wokHubDbContext.SaveChangesAsync();

            return Ok(new AuthenticateSuccessDTO
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            });
        }

        [HttpPost, Authorize, Route("revoke")]
        public async Task<IActionResult> Revoke()
        {
            var user = await _wokHubDbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == User.Identity.Name);
            if (user is null)
            {
                return BadRequest();
            }

            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = null;

            await _wokHubDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
