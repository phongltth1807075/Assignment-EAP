using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_EAP_Coin.Models
{
    public class Account: IdentityUser
    {
        public string Avatar { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}