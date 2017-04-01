using System;

namespace ADS1T1M.TP3.MunirXavierWanis.Domain.Entities
{
    public static class Directories
    {
        public static string BaseDirectory { get; } = AppDomain.CurrentDomain.BaseDirectory;

        public static string ExportAlunoDirectory { get; } = $@"..{Slash}..{Slash}..{Slash}Data{Slash}exporte-alunos.xml";

        public static string LogDirectory { get; } = $@"..{Slash}..{Slash}..{Slash}Data{Slash}exporte-alunos-log-de-carga-{DateTime.Now.ToString("yyyyMMddhhmm")}.txt";

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
