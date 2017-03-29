using ADS1T1M.TP3.MunirXavierWanis.Domain.Entities;
using System.Data.Entity;

namespace ADS1T1M.TP3.MunirXavierWanis.Infra.Data.Contexts
{
    public class EntityContextDb : DbContext
    {
        public DbSet<Aluno> AlunoDb { get; set; }
    }
}
