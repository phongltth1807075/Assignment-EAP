using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_EAP_Coin.Models
{
    public class Market
    {
        public string MarketId { get; set; }
        public string MarketName { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Description { get; set; }
        public enum MarketStatus
        {
            Active = 1,
            Deactive = 0,
            Delete = -1
        }
        public virtual ICollection<Coin> Coins { get; set; }
    }
}