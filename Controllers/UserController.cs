using Microsoft.AspNetCore.Mvc;
using serviceApi.models;
using serviceApi.services;
using serviceApi.interfaces;
using serviceApi.interfaces.DTO;

namespace serviceApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        public UserController(IRepository<UserModel> context)
        {
            _service = new UserService(context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            var values = await _service.GetAllUsers();
            if (values == null) return NotFound();
            return Ok(values);
        }

        [HttpGet("$id")]
        public async Task<ActionResult<UserResponseDTO>> GetUserId (string id)
        {
          var user = await _service.GetUserId(id);
          if (user == null) return NotFound();
          return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<InsertUserResponse>> InsertUser([FromBody] InsertUserResponse body) 
        {
                Console.WriteLine(body);
                var user = await _service.CreatetUser(body);
                if (user == null) return NotFound();
                return Ok(user);
        }
    }
}