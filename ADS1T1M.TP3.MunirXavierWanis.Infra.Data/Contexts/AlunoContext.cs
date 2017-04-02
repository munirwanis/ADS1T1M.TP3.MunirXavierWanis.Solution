using System.Linq;
using ADS1T1M.TP3.MunirXavierWanis.Domain.Entities;

namespace ADS1T1M.TP3.MunirXavierWanis.Infra.Data.Contexts
{
    public class AlunoContext : IAlunoContext
    {
        public void AddAluno(Aluno aluno)
        {
            using (var context = new EntityContextDb())
            {
                context.AlunoDb.Add(aluno);
                context.SaveChanges();
            }
        }

        public Aluno GetAluno(string enrollment)
        {
            using (var context = new EntityContextDb())
            {
                var alunoDb = (from db in context.AlunoDb
                               where db.Enrollment == enrollment
                               select db).SingleOrDefault();
                return alunoDb;
            }
        }

        public void UpdateAluno(Aluno aluno)
        {
            using (var context = new EntityContextDb())
            {
                var alunoDb = (from db in context.AlunoDb
                               where db.Enrollment == aluno.Enrollment
                               select db).SingleOrDefault();
                alunoDb.Enabled = aluno.Enabled;
                context.SaveChanges();
            }
        }
    }
}
