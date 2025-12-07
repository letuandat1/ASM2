
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Minecraft.Models
{
    public class Vehicle
    {
        [Key]
        public int Id {get;set;}
        [Required]
        [MaxLength(255)]
        public string Name {get;set;}
        [Required]
        public int Exp{get;set;}
        public string? ImageURL {get;set;}
        [Required]
        [MaxLength(255)]
        public string Type {get;set;}
        public ICollection<Transaction> Transactions {get;set;}
    }
}