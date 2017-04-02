using ADS1T1M.TP3.MunirXavierWanis.Domain.Entities;
using ADS1T1M.TP3.MunirXavierWanis.Domain.Utility;
using System.Data.Entity;

namespace ADS1T1M.TP3.MunirXavierWanis.Infra.Data.Contexts
{
    internal class EntityContextDb : DbContext
    {
        private static IConfigurationUtility ConfigurationUtility { get; } = new ConfigurationUtility();

        internal EntityContextDb() : base(ConfigurationUtility.ConnectionString) {}

        public DbSet<Aluno> AlunoDb { get; set; }
    }
}
