using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WokHub.DAL;
using WokHub.DAL.Models;

namespace WokHub.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly WokHubDbContext _wokHubDbContext;

        public UserController(WokHubDbContext wokHubDbContext)
        {
            _wokHubDbContext = wokHubDbContext;
        }

        [HttpGet, Route("profile"), Authorize]
        public async Task<IActionResult> GetProfile()
        {
            var user = await _wokHubDbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == User.Identity.Name);

            if (user == null)
            {
                return NotFound("Unknown user");
            }

            var responce = new ProfileDTO
            {
                Address = user.Address,
                birthDate = user.BirthDate,
                Email = user.Email,
                FullName = user.FullName,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber
            };

            return Ok(responce);
        }

        [HttpPut, Route("profile"), Authorize]
        public async Task<IActionResult> EditProfile(EditProfileDTO editProfileDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _wokHubDbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == User.Identity.Name);

            {
                user.PhoneNumber = editProfileDTO.PhoneNumber;
                user.Address = editProfileDTO.Address;
                user.FullName = editProfileDTO.FullName;
                user.Gender = editProfileDTO.Gender;
                user.BirthDate = editProfileDTO.birthDate;
            }

            await _wokHubDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
