using Game_center_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Game_center_Backend.Controllers
{
    [Route("api")]
    [ApiController]
    public class PostController(ApplicationDbContext dbContext) : ControllerBase
    {

        [HttpGet("posts")]
        public IEnumerable<Posts> getPosts()
        {
            return dbContext.Posts;
        }

        [HttpPost("posts/add")]
        public async Task<ActionResult<Posts>> addPosts(Posts dto)
        {
            dto.comments = [];
            dto.likes = "";
            
            
            EntityEntry<Posts> newPost = dbContext.Posts.Add(dto);
            
            
            await dbContext.SaveChangesAsync();

            return Ok(new
            {
                message="Post Successfully added!",
                statusCode=200
            });
        }
    
        [HttpPost("posts/add/comment")]
        public async Task<ActionResult<Posts>> addComment(int Commentid , comments dto)
        {
            Posts post = await dbContext.Posts.FirstOrDefaultAsync(x=>x.id == Commentid);
            if (post == null) return BadRequest(new { message = "Post Not Found !" });

            dto.user_id.Id = new Guid();

            if (ModelState.IsValid)
            {
                            
                post.comments.Add(dto);
                dbContext.Entry(post).State = EntityState.Modified;

                await dbContext.SaveChangesAsync();

            }
            return Ok(post);
        }
        
        
    }
}
