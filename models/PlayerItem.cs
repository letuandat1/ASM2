
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Minecraft.Models;
public class PlayerItem
{
    [Key]
    public int Id {get;set;}
    [Required]
    public int ItemId {get;set;}
    [Required]
    [MaxLength(30)]
    public string Quality {get;set;}
    [Required]
    public int Exp {get;set;}
    [Required]
    public int PlayerId {get;set;}
    [ForeignKey("ItemId")]
    public Item Item {get;set;}
    [ForeignKey("PlayerId")]
    public Player Player {get;set;}
}