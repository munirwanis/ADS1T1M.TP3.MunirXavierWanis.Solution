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
            try
            {
                var serializer = new XmlSerializer(typeof(AlunosList));
                var alunos = new AlunosList();
                using (var fs = new FileStream(Directories.ExportAlunoFileDirectory, FileMode.Open))
                {
                    alunos = (AlunosList)serializer.Deserialize(fs);
                }
                var alunoContext = new AlunoContext();

                foreach (var aluno in alunos.Alunos)
                {
                    var alunoDb = alunoContext.GetAluno(aluno);

                    if (alunoDb == null)
                    {
                        alunoContext.AddAluno(aluno);
                        Logger.Log.LogNew(aluno);
                    }
                    else if (alunoDb.Enabled != aluno.Enabled)
                    {
                        alunoContext.UpdateAluno(aluno);
                        Logger.Log.LogChanged(aluno);
                    }
                    else
                    {
                        Logger.Log.LogNotChanged(aluno);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.LogException(ex);
            }
            Console.WriteLine("================================================");
            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
