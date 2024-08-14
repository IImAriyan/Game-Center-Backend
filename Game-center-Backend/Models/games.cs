using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace Game_center_Backend.Models;

public class games
{
    [Key]
    [Required]
    [SwaggerIgnore]
    public int Id { get; set; }
    [Required]
    [Display(Name = "GameTitle")]
    [MaxLength(50)]
    public string gameTitle { get; set; }
    
    [Required]
    [Display(Name = "Game Score")]
    [MaxLength(50)]
    public string gameScore { get; set; }
    
    
    [Required]
    [Display(Name = "GameForID")]
    public Guid GameForID { get; set; }
}