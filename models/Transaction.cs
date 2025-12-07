
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
namespace Minecraft.Models
{
    public class Transaction
    {
        [Key]
        public int Id {get;set;}
        public int PlayerId {get;set;}
        public Player Player {get;set;}
        public int? ItemId {get;set;}
        public Item Item {get;set;}
        public int? VehicleId {get;set;}
        public Vehicle Vehicle {get;set;}
        public int ExpCost {get;set;}
        public DateTime TransactionDateTime { get; set; }

    }
}