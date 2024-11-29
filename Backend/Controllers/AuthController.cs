using Backend.Adapters;
using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserAdapter _userAdapter = new();

        [HttpPost("signup")]
        public bool Signup(UserRequest model) => _userAdapter.CreateUser(model);

        [HttpPost("login")]
        public bool Login(UserRequest model) => _userAdapter.ReadUser(model);
    }
}
