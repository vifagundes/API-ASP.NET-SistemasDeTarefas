using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemasDeTarefas.Models;
using SistemasDeTarefas.Repositories.Interfaces;

namespace SistemasDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   

    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRespository;

        public UserController(IUserRepository userRepository)
        {
            _userRespository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRespository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserById(int id)
        {
            UserModel user = await _userRespository.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Register([FromBody] UserModel user)
        {
            UserModel newUser = await _userRespository.AddUser(user);
            return Ok(newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel user, int id)
        {
            user.Id = id;
            UserModel newUser = await _userRespository.UpdateUser(user, id);
            return Ok(newUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {
            bool IsDeleted = await _userRespository.DeleteUser(id);
            return Ok(IsDeleted);                
        }
    }
}
