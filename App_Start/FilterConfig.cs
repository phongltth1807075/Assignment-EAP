﻿using System.Web;
using System.Web.Mvc;

namespace Assignment_EAP_Coin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
