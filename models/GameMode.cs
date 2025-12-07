
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Minecraft.Models;

public class GameMode
{
    [Key]
    public int Id{get;set;}
    [Required]
    [MaxLength(255)]
    public string Name{get;set;}

    public ICollection<PlayMode> PlayModes {get;set;}
    
}