
using Minecraft.Models.ViewModels;
using System.Collections.Generic;

namespace Minecraft.Services
{
    public interface IMinecraftGame
    {
        List<ResourceVM> GetAllResources();
        List<PlayerVM> GetPlayersByGameMode(string gameModeName);
        List<ItemVM> GetWeaponsWithHightExp();
        List<ItemVM> GetPurchasableItems(int playerId);
        List<ItemVM> GetDiamondItemsUnder500Exp();
        List<TransactionVM> GetTransactionsByPlayer(int playerId);
        ItemVM addNewItem(ItemVM itemVM);
        bool UpdatePlayerPassword(UpdatePasswordVM updatePasswordVM);
        List<ItemPurchaseVM> GetMostPurchasedItems();
        List<PlayerPurchaseVM>GetAllPlayersWithPurchaseCount();
    }
}