﻿using System.Web;
using System.Web.Mvc;

namespace G2G3TechnicalTest
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
