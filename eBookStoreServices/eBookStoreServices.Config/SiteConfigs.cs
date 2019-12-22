using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace eBookStoreServices.Config
{
    public static class SiteConfigs
    {
        public static string GetDBConnectionString() {
            return ConfigurationManager.ConnectionStrings["eBookStore"].ConnectionString;
        }

    }
}
