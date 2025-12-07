
using System.Data;

namespace Minecraft.Models.ViewModels
{
    public class TransactionVM
    {
        public int TransactionId {get;set;}
        public int PlayerId {get;set;}
        public string ItemName {get;set;}
        public string VehicleName {get;set;}
        public int ExpCost {get;set;}
        public DateTime TransactionDateTime { get; set; }
    }
}