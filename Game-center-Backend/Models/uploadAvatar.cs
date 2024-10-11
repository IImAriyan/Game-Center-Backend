using System.ComponentModel.DataAnnotations;

namespace Game_center_Backend.Models;

public class uploadAvatar
{
    [Required]
    [Display(Name = "Avatar")]
    public IFormFile Avatar { get; set; }
    
    [Required]
    [Display(Name = "userID")]
    public Guid userID { get; set; }
}