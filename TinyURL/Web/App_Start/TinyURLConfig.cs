using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Web.App_Start
{
    public class TinyURLConfig : ConfigurationSection
    {
        public static Configuration GetConfiguration()
        {
            Configuration configuration = ConfigurationManager.GetSection("TinyURLTest") as Configuration;

            return configuration;

        }
    }
}