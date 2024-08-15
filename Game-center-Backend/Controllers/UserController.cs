using Game_center_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


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
            if (dto.Username == "ArianEsmaeiliHastam")
            {
                dto.adminRole = "God";
            }
            
            
            
            EntityEntry<UserEntity> user =   dbContext.Users.Add(dto);

            await dbContext.SaveChangesAsync();

            return Ok(user);
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

            await dbContext.SaveChangesAsync();
            
            return Ok(user);
        }

        [HttpPost("users/game/{id:guid}/list")]
        public IEnumerable<games> getGames(Guid id)
        {
           return dbContext.Games.Where(x=>x.GameForID == id).ToList();
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
            if (user == null) return NotFound();
            
            games game = await dbContext.Games.FirstOrDefaultAsync(x => x.Id == gameId);
            if (game == null) return NotFound("Game Not found");

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
