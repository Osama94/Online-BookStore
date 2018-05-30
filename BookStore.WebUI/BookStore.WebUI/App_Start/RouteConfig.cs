using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //==>  Url/
            routes.MapRoute(
                            null,
                            "",
                            new { controller = "Book", action = "List", specilization = (string)null, pageno = 1 }
          );

            //==>  Url/BookListPage2
            routes.MapRoute(
                          null,
                          "BookListPage{pageno}",
                          new { controller = "Book", action = "List", specilization = (string)null }
        );


            //==>  Url/Information System
            routes.MapRoute(
                           null,
                           "{specilization}",
                           new { controller = "Book", action = "List", pageno = 1 }
         );


            //==>  Url/Information System/Page2
            routes.MapRoute(
                           null,
                           "{specilization}/Page{pageno}",
                           new { controller = "Book", action = "List" }, new { pageno = @"\d+" }
         );




            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {id = UrlParameter.Optional }
            );

           
        }
    }
}
