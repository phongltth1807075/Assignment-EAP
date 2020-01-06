using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_EAP_Coin.Models
{
    public class MyContext : IdentityDbContext<Account>
    {
        public MyContext() : base("name=Context")
        {
        }

        public static MyContext Create()
        {
            return new MyContext();
        }

        public System.Data.Entity.DbSet<Assignment_EAP_Coin.Models.Market> Markets { get; set; }
        public System.Data.Entity.DbSet<Assignment_EAP_Coin.Models.Coin> Coins { get; set; }
    }
        
}