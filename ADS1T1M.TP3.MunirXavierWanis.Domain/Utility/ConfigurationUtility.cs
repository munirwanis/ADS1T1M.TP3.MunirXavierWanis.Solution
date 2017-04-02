using ADS1T1M.TP3.MunirXavierWanis.Domain.Entities;
using System;
using System.Configuration;

namespace ADS1T1M.TP3.MunirXavierWanis.Domain.Utility
{
    public class ConfigurationUtility : IConfigurationUtility
    {
        public ConfigurationUtility()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directories.ProjectDataDirectory);
        }

        public string ConnectionString { get; } = ConfigurationManager.ConnectionStrings["AlunosConnection"].ConnectionString;
    }
}
