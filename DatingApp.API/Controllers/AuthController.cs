using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.DTO;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo=repo;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register(UserForRegisterDTO userForRegisterDTO)
        {
            //validate request
            

            userForRegisterDTO.UserName = userForRegisterDTO.UserName.ToLower();

            if(await _repo.UserExists(userForRegisterDTO.UserName)){
                return BadRequest("User already exist");
            }

            var userToCreate = new User
            {
                UserName = userForRegisterDTO.UserName
                
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDTO.Password);

            return StatusCode(201);
        }
        
    }
}