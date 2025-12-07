
using System.ComponentModel.DataAnnotations;
namespace Minecraft.Models.ViewModels
{
    public class ItemVM
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public int Exp {get;set;}
        public string? ImageURSL {get;set;}
        public string Type {get;set;}
    }
}