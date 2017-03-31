using ADS1T1M.TP3.MunirXavierWanis.Domain.Entities;
using System;
using System.Diagnostics;
using System.IO;

namespace ADS1T1M.TP3.MunirXavierWanis.Presentation.Logger
{
    public static class Log
    {
        public static void LogNew(Aluno aluno) =>
            Logging(aluno, LogType.New);

        public static void LogChanged(Aluno aluno) =>
            Logging(aluno, LogType.Changed);

        public static void LogNotChanged(Aluno aluno) =>
            Logging(aluno, LogType.NotChanged);

        private static void Logging(Aluno aluno, LogType type)
        {
            int enabled = aluno.Enabled ? 1 : 0;
            var toLogText = $"matricula>{aluno.Enrollment}; nome>{aluno.Name}; ativo>{enabled}; ";
            switch (type)
            {
                case LogType.New:
                    toLogText = string.Concat(toLogText, "Adicionado;");
                    break;
                case LogType.Changed:
                    toLogText = string.Concat(toLogText, $"Alterado: ativo>{enabled};");
                    break;
                case LogType.NotChanged:
                    toLogText = string.Concat(toLogText, "OK;");
                    break;
                default:
                    break;
            }
            Console.WriteLine(toLogText);
            Debug.WriteLine(toLogText);
            using (var fs = new FileStream(Directories.LogDirectory, FileMode.Append, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine(toLogText);
                }
            }
        }

        private enum LogType
        {
            New,
            Changed,
            NotChanged
        }
    }
}
