using Game_center_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using System.IO;
using System.Threading.Tasks;
using SixLabors.ImageSharp.Processing;

namespace Game_center_Backend.Controllers
{
    [Route("api")]
    [ApiController]
    public class fileUploader(ApplicationDbContext dbContext) : ControllerBase
    {
        [HttpPost("upload/file")]
        public async Task<IActionResult> UploadFile(uploaderEntity model)
        {
            if (model.file == null || model.file.Length == 0)
            {
                return BadRequest("No File Uploaded .");
            }

            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "assets/files/images");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var filePath = Path.Combine(uploadPath, model.file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.file.CopyToAsync(stream);
            }

            return Ok(new { message = "File Successfully Uploaded !"});
        }
        
        [HttpPost("upload/avatar")]
        public async Task<IActionResult> UploadAvatar(uploadAvatar model)
        {
            if (model.Avatar == null || model.Avatar.Length == 0)
            {
                return BadRequest("No File Uploaded .");
            }

            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "assets/files/images");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var filePath = Path.Combine(uploadPath, model.userID+".png");
                                                                    
            
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.Avatar.CopyToAsync(stream);
                
            }

            return Ok(new { message = "Avatar Successfully Uploaded !"});
        }

        [HttpGet("avatars/{id:guid}/{width:int}x{height:int}")]
        public async Task<IActionResult> getAvatarByID(Guid id,int width,int height)
        {
            UserEntity user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            var filePath = $"assets/files/images/{id}.png";
            

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            using (var image = await Image.LoadAsync(filePath) )
            {
                image.Mutate(x => x.Resize(width,height));
                var ms = new MemoryStream();
                await image.SaveAsPngAsync(ms);
                ms.Position = 0;

                return File(ms.ToArray(), "image/png");
            }
        }
    }
}
