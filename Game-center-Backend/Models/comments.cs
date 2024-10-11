
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace Game_center_Backend.Models;

[Table("Comments")]
public class comments
{
    [Key]
    [SwaggerIgnore]
    public int id { get; set; }
    
    [Display(Name = "user_id")]
    public UserEntity user_id { get; set; }

    [Display(Name = "likes_count")] 
    public List<Like> likes_count { get; set; } = new List<Like>();
    
    [Display(Name = "description")]
    public string description { get; set; }
    
    [Display(Name = "date")]
    public string date { get; set; }
}