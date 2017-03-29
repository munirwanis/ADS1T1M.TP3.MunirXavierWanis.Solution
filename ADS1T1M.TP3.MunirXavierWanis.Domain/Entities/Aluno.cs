using System;

namespace ADS1T1M.TP3.MunirXavierWanis.Domain.Entities
{
    public class Aluno
    {
        public string identificador { get; set; }
        public string nome { get; set; }
        public string matricula { get; set; }
        public DateTime datadenascimento { get; set; }
        public string cpf { get; set; }
        public bool ativo { get; set; }
    }
}
