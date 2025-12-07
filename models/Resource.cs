
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Minecraft.Models;
public class Resource
{
    [Key]
    public int Id {get;set;}
    [Required]
    [MaxLength(255)]
    public string Name {get;set;}
    public ICollection<PlayerResource> PlayerResources {get;set;}
}