
using System.Collections.Generic;

namespace Minecraft.Models.ViewModels
{
    public class PlayerVM
    {
        public int Id {get;set;}
        public string CharacterName {get;set;}
        public int Level {get ; set;}
        public int Food {get;set;}
        public int Health {get;set;}
        public int Exp {get;set;}
    }
}