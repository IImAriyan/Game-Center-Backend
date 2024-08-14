using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace Game_center_Backend.Models;

public class games
{
    public string gameTitle { get; set; }

    public string gameScore { get; set; }
}