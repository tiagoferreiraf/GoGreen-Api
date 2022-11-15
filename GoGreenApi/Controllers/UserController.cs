using GoGreenApi.Models;
using GoGreenApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoGreenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepo.GetAllUsers();

            return Ok(users);
        }


        [HttpGet("search/{id}")]
        public async Task<ActionResult<UserModel>> GetById(int id)
        {
            UserModel user = await _userRepo.SearchById(id);

            return Ok(user);

        }
        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> RegisterUser([FromBody] UserModel newUser)
        {
            UserModel user = await _userRepo.AddUser(newUser);

            return Ok(user);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel user, int id)
        {
            user.Id = id;
            UserModel lUser = await _userRepo.UpdateUser(user, id);
            return Ok(lUser);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id)
        {
            bool userDeleted = await _userRepo.DeleteUser(id);
            return Ok(userDeleted);

        }

    }
}
