using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace StockAnalyzer.Data
{
    public class Utility
    {
        private const string DefaultConnectionStringName = "LocalDbConn";
        public static string GetConnectionString(string name)
        {
            //Assembly executingAssembly = Assembly.GetExecutingAssembly();
            //var collection2 = ConfigurationManager.OpenExeConfiguration(executingAssembly.Location).ConnectionStrings;
            ////Assembly entryAssembly = Assembly.GetEntryAssembly();
            ////var collection3 = ConfigurationManager.OpenExeConfiguration(entryAssembly.Location).ConnectionStrings;
            //Assembly callingAssembly = Assembly.GetCallingAssembly();
            //var collection4 = ConfigurationManager.OpenExeConfiguration(callingAssembly.Location).ConnectionStrings;
            ConnectionStringSettingsCollection collection = ConfigurationManager.ConnectionStrings;
            if (collection != null)
            {
                ConnectionStringSettings connectionString = collection[name];//collection.ConnectionStrings[name];
                if(connectionString != null)
                {
                    return connectionString.ConnectionString;
                }
            }
            throw new Exception($"ConnectionString {name} is not found in configuration file");
        }
        public static string GetDefaultConnectionString()
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            var collection = ConfigurationManager.OpenExeConfiguration(executingAssembly.Location).ConnectionStrings;
            //ConnectionStringSettingsCollection collection = ConfigurationManager.ConnectionStrings;
            if (collection != null)
            {
                ConnectionStringSettings connectionString = collection.ConnectionStrings[DefaultConnectionStringName];
                if (connectionString != null)
                {
                    return connectionString.ConnectionString;
                }
            }
            throw new Exception($"ConnectionString {DefaultConnectionStringName} is not found in configuration file");
        }
    }
}
