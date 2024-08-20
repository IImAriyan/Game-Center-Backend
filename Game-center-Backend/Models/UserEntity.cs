using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace Game_center_Backend.Models;

[Table("Users")]
public class UserEntity
{
    [Required] [Key] [SwaggerIgnore] public Guid Id { get; set; } = new Guid();

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



    [Required(ErrorMessage = "adminRole is Required !!!")]
    [Display(Name = "adminRole")]
    [MaxLength(40)]
    public string adminRole { get; set; }



    [Display(Name = "firstName")]
    [MaxLength(40)]
    public string firstName { get; set; }
    
    [Display(Name = "lastName")]
    [MaxLength(40)]
    public string lastName { get; set; }
    
    
    [Display(Name = "age")]
    [MaxLength(100)]
    public int age { get; set; }

    [Display(Name = "telephone")]
    [MaxLength(200)]
    public string telephone { get; set; }
    
    [Display(Name = "nationalCode")]
    [MaxLength(200)]
    public string nationalCode { get; set; }
    
    [Display(Name = "gender")]
    [MaxLength(200)]
    public string gender { get; set; }

    [Display(Name = "accountLocked")]
    [MaxLength(200)]
    public string accountLocked { get; set; }
    
    [Display(Name = "coins")]
    [MaxLength(200)]
    public string coins { get; set; }

    [Display(Name = "accountBanned")]
    [MaxLength(200)]
    public string accountBanned { get; set; }
    
}