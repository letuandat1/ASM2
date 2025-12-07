
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Components;
namespace Minecraft.Models;
public class PlayerResource
{
    public int PlayerId {get;set;}
    public int ResourceId {get;set;}
    public Player Player {get;set;}
    public Resource Resource {get;set;}
}