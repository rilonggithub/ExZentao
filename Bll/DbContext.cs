using System.IO;
using Chloe.MySql;
using Microsoft.Extensions.Configuration;

namespace Bll
{
    public class DataContent
    {
        static MySqlContext ctx = null;
        public static MySqlContext Context()
        {
            if (DataContent.ctx == null)
            {
                IConfigurationRoot Configuration;
                ConfigurationBuilder Builder=new ConfigurationBuilder();
                Builder.SetBasePath(Directory.GetCurrentDirectory());
                Builder.AddJsonFile("appsettings.json");
                Configuration =Builder.Build();
                string ConnectionStr =Configuration.GetConnectionString("MySqlConnectionString");
                MySqlConnectionFactory factory = new MySqlConnectionFactory(ConnectionStr);
                DataContent.ctx = new MySqlContext(factory);
            }
            return DataContent.ctx;
        }
    }
}