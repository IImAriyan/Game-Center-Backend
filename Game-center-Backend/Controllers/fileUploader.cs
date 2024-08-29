using Game_center_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_center_Backend.Controllers
{
    [Route("api")]
    [ApiController]
    public class fileUploader : ControllerBase
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
    }
}
