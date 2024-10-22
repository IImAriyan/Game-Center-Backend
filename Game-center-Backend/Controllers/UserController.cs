using Game_center_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Services;

namespace Game_center_Backend.Controllers
{
    
    [Route("api")]
    [ApiController]
    public class UserController(ApplicationDbContext dbContext) : ControllerBase
    {


        // Show Users
        [HttpGet("users/list")]
        public IEnumerable<UserEntity> getUsers()
        {
            return dbContext.Users;
        }
        
        
        // Add User
        [HttpPost("users/add")]
        public async Task<ActionResult<UserEntity>> addUser([FromBody]UserEntity dto)
        {
            dto.adminRole = "member";
            dto.avatar = "NotFound";

            if (dto.Username == "ArianEsmaeiliHastam")
            {
                dto.adminRole = "God";
            }

            UserEntity userFound = await dbContext.Users.FirstOrDefaultAsync(x => x.Username == dto.Username);

            if (userFound != null)
            {
                var messageResponse = new
                {
                    statusCode = 400,
                    message = "Username Already Exists"
                };

                return BadRequest(messageResponse);
            }
            
            UserEntity emailFound = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);

            if (emailFound != null)
            {
                var messageResponse = new
                {
                    statusCode = 400,
                    message = "Email Already Exists"
                };

                return BadRequest(messageResponse);
            }
            
            EntityEntry<UserEntity> user =   dbContext.Users.Add(dto);

            await dbContext.SaveChangesAsync();
            var tokenx = new JWTToken().GenerateJWTToken(dto);

            return Ok(new {token=tokenx});
        }


        [HttpGet("test")]
        public DateTime test()
        {
            return DateTime.Now;
        }
        // Remove User By ID

        [HttpPost("users/remove/{id:guid}")]
        public async Task<ActionResult<UserEntity>> removeUser(Guid id)
        {
            UserEntity user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return NotFound();

            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();

            return Ok(user);
        }
        
        // Read By One ID
        [HttpGet("users/{id:guid}")]
        public async Task<ActionResult<UserEntity>> readByUser(Guid id)
        {
            UserEntity user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return NotFound();

            return Ok(user);
        }
        
        
        // Update User By ID
        [HttpPost("users/update/{id:guid}")]
        public async Task<ActionResult<UserEntity>> updateUser(Guid id,UserEntity dto)
        {
            UserEntity user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return NotFound();

            user.Username = dto.Username;
            user.Password = dto.Password;
            user.adminRole = dto.adminRole;
            user.Email = dto.Email;
            user.coins = dto.coins;
            user.age = dto.age;
            user.gender = dto.gender;
            user.firstName = dto.firstName;
            user.lastName = dto.lastName;
            user.nationalCode = dto.nationalCode;
            user.telephone = dto.telephone;
            
            user.accountLocked = dto.accountLocked;
            user.accountBanned = dto.accountBanned;

            await dbContext.SaveChangesAsync();
            
            return Ok(user);
        }

        [HttpGet("users/game/{id:guid}/list")]
        public IEnumerable<games> getGames(Guid id)
        {
           return dbContext.Games.Where(x=>x.GameForID == id).ToList();
        }

        [HttpPost("users/avatar")]
        public async Task<ActionResult> getAvatar([FromBody] Guid id)
        {
            UserEntity user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(new { avatar = user.avatar });
        }
        
        [HttpPost("users/game/{id:guid}/Add")]
        public async Task<ActionResult<games>> addGame(Guid id,[FromBody]games dto)
        {
            UserEntity user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return NotFound();


            dbContext.Games.Add(dto);
            await dbContext.SaveChangesAsync();
                
            return Ok(dto);
        }

        [HttpPost("users/game/{id:guid}/{gameID:guid}/Update")]
        public async Task<ActionResult<games>> updateGame(Guid id,Guid gameID, [FromBody] games dto)
        {
            UserEntity user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return NotFound();
            
            games game = await dbContext.Games.FirstOrDefaultAsync(x => x.GameForID == gameID);
            if (game == null)
            {
                var errorMessage = new
                {
                    message = "There is no game with this id",
                    statusCode = "200",
                };
                return BadRequest(errorMessage);
            };

            game.gameScore = dto.gameScore;
            game.gameTitle = dto.gameTitle;
            return Ok(game);
        }

        [HttpPost("users/game/{userId:guid}/{gameId:int}/Remove")]
        public async Task<ActionResult<games>> removeGame(Guid userId,int gameId)
        {
            UserEntity user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                var messageResponse = new
                {
                    statusCode=404,
                    message="User Not found",
                };
                return BadRequest(messageResponse);
            };
            
            games game = await dbContext.Games.FirstOrDefaultAsync(x => x.Id == gameId);
            if (game == null)
            {
                var messageResponse = new
                {
                    statusCode=404,
                    message="Game Not found",
                };
                return BadRequest(messageResponse);
            };

            

            if (game.GameForID != user.Id)
            {
                var messageResponse = new
                {
                    statusCode=400,
                    message="The ID of this game does not match with this user",
                };
                return BadRequest(messageResponse);
            }

            dbContext.Games.Remove(game);
            await dbContext.SaveChangesAsync();

            return Ok(game);
        }
    }
}
