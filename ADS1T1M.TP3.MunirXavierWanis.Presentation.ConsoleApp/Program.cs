using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ADS1T1M.TP3.MunirXavierWanis.Domain.Entities;

namespace ADS1T1M.TP3.MunirXavierWanis.Presentation.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new XmlSerializer(typeof(AlunosList));
            var alunos = new AlunosList();
            using (var fs = new FileStream(Directories.ExportAlunoDirectory, FileMode.Open))
            {
                alunos = (AlunosList) serializer.Deserialize(fs);
            }
            foreach (var aluno in alunos.Alunos)
            {
                Console.WriteLine($"{aluno.Birthdate}, {aluno.Cpf}, {aluno.Enabled}, {aluno.Enrollment}, {aluno.Identifier}, {aluno.Name}");
            }
            Console.ReadKey();
        }
    }
}
