
using Microsoft.AspNetCore.Mvc;
using Minecraft.Models.ViewModels;
using Minecraft.Services;
using System.Collections.Generic;

namespace Minecraft.Controllers
{
    [Route("api/minecraft")]
    [ApiController]
    public class MinecraftGameController:ControllerBase
    {
        private readonly IMinecraftGame _minecraftGameService;
        public MinecraftGameController(IMinecraftGame minecraftGameService)
        {
            _minecraftGameService = minecraftGameService;
        }
        [HttpGet("resources")]
        public ActionResult<List<ResourceVM>>GetAllResources()
        {
            var resources = _minecraftGameService.GetAllResources();
            return Ok(resources);
        }
        [HttpGet("players/gamemode/{gameModeName}")]
        public ActionResult<List<PlayerVM>>GetPlayersByGameMode(string gameModeName)
        {
            var players =_minecraftGameService.GetPlayersByGameMode(gameModeName);
            return Ok (players);
        }
        [HttpGet("weapons/hight-exp")]
        public ActionResult<List<ItemVM>>GetWeaponsWithHoghtExp()
        {
            var weapons = _minecraftGameService.GetWeaponsWithHightExp();
            return Ok(weapons);
        }
        [HttpGet("items/purchaseble/{playerId}")]
        public ActionResult<List<ItemVM>> GetPurchasableItems(int playerId)
        {
            var items = _minecraftGameService.GetPurchasableItems(playerId);
            return Ok(items);
        }
        [HttpGet("items/diamond-under-500-exp")]
        public ActionResult<List<ItemVM>> GetDiamondItemsUnder500Exp()
        {
            var items =_minecraftGameService.GetDiamondItemsUnder500Exp();
            return Ok(items);
        }
        [HttpGet("transactions/player/{playerId}")]
        public ActionResult<List<TransactionVM>>GetTransactionsByPlayer(int playerId)
        {
            var transactions = _minecraftGameService.GetTransactionsByPlayer(playerId);
            return Ok(transactions);
        }
        [HttpPost("items/add")]
        public ActionResult<ItemVM>addNewItem([FromBody]ItemVM itemVM)
        {
            var newItem = _minecraftGameService.addNewItem(itemVM);
            return CreatedAtAction(nameof(addNewItem),new {id =newItem.Id},newItem);
        }
        [HttpPut("player/update-password")]
        public ActionResult<bool>UpdatePlayerPassword([FromBody]UpdatePasswordVM updatePasswordVM)
        {
            var success =_minecraftGameService.UpdatePlayerPassword(updatePasswordVM);
            if(!success)return BadRequest("Cập nhật mật khẩu thất bại.");
            return Ok(success);

        }
        [HttpGet("items/most-purchased")]
        public ActionResult <List<ItemPurchaseVM>>GetMostPurchasedItems()
        {
            var items =_minecraftGameService.GetMostPurchasedItems();
            return Ok(items);
        }
        [HttpGet("players/purchase-count")]
        public ActionResult<List<PlayerPurchaseVM>>GetAllplayersWithPurchaseCount()
        {
            var players = _minecraftGameService.GetAllPlayersWithPurchaseCount();
            return Ok(players);
        }

    }
}