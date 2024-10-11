using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace Game_center_Backend.Models;


[Table("Posts")]
public class Posts
{
    
    [Key]
    [SwaggerIgnore]
    public int id { get; set; }
    
    [Display(Name = "title")]
    public string title { get; set; }
    
    [Display(Name = "description")]
    public string description { get; set; }
    
    [Display(Name = "titleDescription")]
    public string titleDescription { get; set; }
    
    [Display(Name = "image")]
    public string image { get; set; }
    
    [Display(Name = "likes")]
    public string likes { get; set; }

    [Display(Name = "comments")] 
    public List<comments> comments { get; set; } = new List<comments>();
    
    [Display(Name = "createdAt")]
    public string createdAt { get; set; }
    
    [Display(Name = "createdBy")]
    public string createdBy { get; set; }
    
    [Display(Name = "details")]
    public string details { get; set; }
    
    [Display(Name = "routePath")]
    public string routePath { get; set; }
    
    [Display(Name = "cImage")]
    public string cImage { get; set; }
    
}