using Game_center_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_center_Backend.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController(ApplicationDbContext dbContext) : ControllerBase
    {
        [HttpGet("users/list")]
        public IEnumerable<UserEntity> getUsers()
        {
            return dbContext.Users;
        }
    }
}
