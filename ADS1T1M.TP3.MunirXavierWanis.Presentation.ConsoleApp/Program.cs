using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ADS1T1M.TP3.MunirXavierWanis.Domain.Entities;
using ADS1T1M.TP3.MunirXavierWanis.Infra.Data.Contexts;

namespace ADS1T1M.TP3.MunirXavierWanis.Presentation.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new XmlSerializer(typeof(AlunosList));
            var alunos = new AlunosList();
            using (var fs = new FileStream(Directories.ExportAlunoFileDirectory, FileMode.Open))
            {
                alunos = (AlunosList)serializer.Deserialize(fs);
            }

            using (var context = new EntityContextDb())
            {
                foreach (var aluno in alunos.Alunos)
                {
                    var alunoDb = (from db in context.AlunoDb
                                   where db.Enrollment == aluno.Enrollment
                                   select db).SingleOrDefault();
                    if (alunoDb == null)
                    {
                        context.AlunoDb.Add(aluno);
                        Logger.Log.LogNew(aluno);
                    }
                    else if (alunoDb.Enabled != aluno.Enabled)
                    {
                        alunoDb.Enabled = aluno.Enabled;
                        Logger.Log.LogChanged(aluno);
                    }
                    else
                    {
                        Logger.Log.LogNotChanged(aluno);
                    }
                    context.SaveChanges();
                }
            }
            Console.WriteLine("================================================");
            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
