namespace ADS1T1M.TP3.MunirXavierWanis.Domain.Entities
{
    public static class Directories
    {
        public static string BaseDirectory { get; } = System.AppDomain.CurrentDomain.BaseDirectory;

        public static string ExportAlunoDirectory { get; } = $@"{BaseDirectory}\Data\exporte-alunos.xml";
    }
}
