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
            #region TESTE DE LOG
            using (var fs = new FileStream(Directories.LogDirectory, FileMode.Append, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine("This is some text in the file.");
                }
            }
            using (var fs = new FileStream(Directories.LogDirectory, FileMode.Append, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine("This is some text in the file.");
                }
            }
            #endregion
            var serializer = new XmlSerializer(typeof(AlunosList));
            var alunos = new AlunosList();
            using (var fs = new FileStream(Directories.ExportAlunoDirectory, FileMode.Open))
            {
                alunos = (AlunosList)serializer.Deserialize(fs);
            }

            using (var context = new EntityContextDb())
            {
                foreach (var aluno in alunos.Alunos)
                {
                    var alunoDb = (from db in context.AlunoDb
                                   where db.Cpf == aluno.Cpf &&
                                         db.Enrollment == aluno.Enrollment &&
                                         db.Name == aluno.Name
                                   select db).SingleOrDefault();
                    if (alunoDb == null)
                    {
                        context.AlunoDb.Add(aluno);
                        //TODO: LOG new aluno
                    }
                    else if (alunoDb.Enabled != aluno.Enabled)
                    {
                        alunoDb.Enabled = aluno.Enabled;
                        //TODO: LOG changed aluno
                    }
                    else
                    {
                        //TODO: LOG not changed aluno
                    }
                    context.SaveChanges();
                    Console.WriteLine($"{aluno.Birthdate}, {aluno.Cpf}, {aluno.Enabled}, {aluno.Enrollment}, {aluno.Id}, {aluno.Name}");
                }
            }
            Console.ReadKey();
        }
    }
}
