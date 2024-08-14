using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace Game_center_Backend.Models;

[Table("Users")]
public class UserEntity
{
    [Required]
    [Key] 
    [SwaggerIgnore] 
    public Guid Id { get; set; } = new Guid();
    
    [Required(ErrorMessage = "Username is Required !!!")]
    [Display(Name = "Username")]
    [MaxLength(300)]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Password is Required !!!")]
    [Display(Name = "Password")]
    [MaxLength(300)]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "Email is Required !!!")]
    [Display(Name = "Email")]
    [MaxLength(300)]
    public string Email { get; set; }
    
    [Display(Name = "Games")]
    [MaxLength(300)]
    public games[] Games { get; set; }
    
    [Required(ErrorMessage = "adminRole is Required !!!")]
    [Display(Name = "adminRole")]
    [MaxLength(40)]
    public string adminRole { get; set; }
    
}