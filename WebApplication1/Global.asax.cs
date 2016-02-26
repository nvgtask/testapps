using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication1.Frame.DataAccess;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            using (var provider = new SQLiteDataProvider())
            {
                provider.ExecuteNonQuery("create table highscores (name varchar(100), score int)");
                provider.ExecuteNonQuery("insert into highscores (name, score) values ('Jim', 10000)");
                provider.ExecuteNonQuery("insert into highscores (name, score) values ('Mary', 3000)");
                provider.ExecuteNonQuery("insert into highscores (name, score) values ('Paul', 9500)");
                provider.ExecuteNonQuery("insert into highscores (name, score) values ('Kim', 2500)");
                provider.ExecuteNonQuery("insert into highscores (name, score) values ('John', 8000)");
            }
        }
    }
}
