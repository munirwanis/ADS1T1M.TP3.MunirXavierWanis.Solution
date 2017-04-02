using System;
using System.IO;

namespace ADS1T1M.TP3.MunirXavierWanis.Domain.Entities
{
    public class Directories
    {
        public static string BaseDirectory { get; } = AppDomain.CurrentDomain.BaseDirectory;

        public static string ExportAlunoFileDirectory { get; } = $@"..{Slash}..{Slash}..{Slash}Data{Slash}exporte-alunos.xml";

        public static string LogFileDirectory { get; } = $@"..{Slash}..{Slash}..{Slash}Data{Slash}exporte-alunos-log-de-carga-{DateTime.Now.ToString("yyyyMMddhhmm")}.txt";

        public static string ProjectDataDirectory { get; } = $@"{Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).FullName}{Slash}ADS1T1M.TP3.MunirXavierWanis.Infra.Data{Slash}";

        private static string Slash {
            get {
                var platformId = Environment.OSVersion.Platform;
                switch (platformId)
                {
                    case PlatformID.MacOSX:
                    case PlatformID.Unix:
                        return "/";
                    case PlatformID.Win32NT:
                    case PlatformID.Win32S:
                    case PlatformID.Win32Windows:
                    case PlatformID.WinCE:
                    case PlatformID.Xbox:
                    default:
                        return @"\";
                }
            }
        }
    }
}
