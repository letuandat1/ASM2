
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Transactions;
namespace Minecraft.Models;
public class Player
{
    [Key]
    public int Id{get;set;}
    [Required]
    [MaxLength(255)]
    public string Email {get;set;}
    [Required]
    [MaxLength(255)]
    public string Password{get;set;}
    [Required]
    [MaxLength(255)]
    public string CharacterName{get;set;}
    [Required]
    public int Level{get;set;}
    [Required]
    public int Food {get;set;}
    [Required]
    public int Health {get;set;}
    [Required]
    public int Exp {get;set;}
    public ICollection <PlayerItem> PlayerItems{get;set;}
    public ICollection<PlayerResource> PlayerResources {get;set;}
    public ICollection <PlayMode> PlayModes {get;set;}
    public ICollection <Transaction> Transactions {get;set;}

}