
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Minecraft.Models.ViewModels
{
    public class UpdatePasswordVM
    {
        public int PlayerId {get;set;}
        public string OldPassword {get;set;}
        public string NewPassword {get;set;}
    }
}