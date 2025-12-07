
using System.ComponentModel.DataAnnotations.Schema;
namespace Minecraft.Models;
public class PlayMode
{
    public int PlayerId {get;set;}
    public Player Player {get;set;}
    public int GameModeId {get ;set;}
    public GameMode GameMode {get;set;}
}