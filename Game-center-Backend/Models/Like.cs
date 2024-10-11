using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace Game_center_Backend.Models;

public class Like
{
    [Key]
    public int id { get; set; }
    
    public UserEntity User { get; set; }
}