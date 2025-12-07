
using Microsoft.EntityFrameworkCore;
using Minecraft.AppDataContext;
using Minecraft.Models;
using Minecraft.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
namespace Minecraft.Services
{
    public class MinecraftGame : IMinecraftGame
    {
        private readonly AppDbContext _context;
        public MinecraftGame(AppDbContext context)
        {
            _context = context;
        }
        public List<ResourceVM>GetAllResources()
        {
            return _context.Resources
            .Select(r => new ResourceVM {Id = r.Id ,Name = r.Name})
            .ToList();
        }
        public List<PlayerVM>GetPlayersByGameMode(string gameModeName)
        {
           var players = (from p in _context.Players
                   join pm in _context.PlayModes on p.Id equals pm.PlayerId
                   join gm in _context.GameModes on pm.GameModeId equals gm.Id
                   where gm.Name.ToLower() == gameModeName.ToLower()
                   select new PlayerVM
                   {
                       Id = p.Id,
                       CharacterName = p.CharacterName,
                       Level = p.Level,
                       Food = p.Food,
                       Health = p.Health,
                       Exp = p.Exp
                   }).ToList();

    return players;
            }
            public List<ItemVM> GetWeaponsWithHightExp()
        {
            return _context.Items
            .Where (i => i.Type == "Weapon"&& i.Exp >100)
            .Select(i => new ItemVM{Id =i.Id , Name = i.Name , Type = i.Type , Exp = i.Exp})
            .ToList();
        }
        public List<ItemVM>GetPurchasableItems(int playerId)
        {
            var playerExp = _context.Players.Where(p => p.Id == playerId)
            .Select(p => p.Exp)
            .FirstOrDefault();
            return _context.Items.Where(i => i.Exp <= playerExp)
            .Select(i => new ItemVM { Id = i.Id , Name = i.Name , Type = i.Type, Exp = i.Exp})
            .ToList();
        }
        public List<ItemVM> GetDiamondItemsUnder500Exp()
        {
            return _context.Items
            .Where(i => i.Name.Contains("Diamond")&& i.Exp < 500)
            .Select (i => new ItemVM { Id = i.Id , Name = i.Name , Type = i.Type,Exp = i.Exp})
            .ToList();
        }
        public List<TransactionVM>GetTransactionsByPlayer(int playerId)
        {
            return _context.Transactions
            .Where(t => t.PlayerId == playerId)
            .OrderByDescending(t => t.TransactionDateTime)
            .Select (t => new TransactionVM
            {
                PlayerId = t.PlayerId,
                ItemName = t.Item != null ? t.Item.Name : null,
                VehicleName = t.Vehicle !=null ? t.Vehicle.Name : null ,
                TransactionDateTime = t.TransactionDateTime
            })
            .ToList();
        }
        public ItemVM addNewItem(ItemVM itemVM)
        {
            var item = new Item {Name = itemVM.Name , Type = itemVM.Type,Exp=itemVM.Exp};
            _context.Items.Add(item);
            _context.SaveChanges();
            return new ItemVM {Id =item.Id ,Name = item.Name ,Type = item.Type , Exp = item.Exp};
        }
        public bool UpdatePlayerPassword (UpdatePasswordVM updatePasswordVM)
        {
            var player =_context.Players.FirstOrDefault(p=>p.Id== updatePasswordVM.PlayerId);
            if (player ==null || player.Password != updatePasswordVM.OldPassword)
            return false;
            player.Password = updatePasswordVM.NewPassword;
            _context.SaveChanges();
            return true;
        }
        public List<ItemPurchaseVM> GetMostPurchasedItems()
        {
            return _context.Transactions.Where(t => t.ItemId.HasValue)
            .GroupBy(t => t.ItemId)
            .Select(group => new ItemPurchaseVM
            {
                ItemID = group.Key.Value ,
                ItemName = _context.Items.Where(i=>i.Id == group.Key.Value).Select(i =>i.Name).FirstOrDefault(),
                PurchaseCount = group.Count()
            })
            .OrderByDescending(item=> item.PurchaseCount)
            .ToList();
        }
        public List<PlayerPurchaseVM>GetAllPlayersWithPurchaseCount()
        {
            return _context.Players
            .Select(player => new PlayerPurchaseVM
            {
                PlayerId = player.Id,
                PlayerName =player.CharacterName,
                PurchaseCount =_context.Transactions.Count(t=> t.PlayerId == player.Id)

            })
            .OrderByDescending(p => p.PurchaseCount)
            .ToList();
        }

        
    }
    }
