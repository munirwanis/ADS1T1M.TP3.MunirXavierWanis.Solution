using System;
using System.Xml.Serialization;

namespace ADS1T1M.TP3.MunirXavierWanis.Domain.Entities
{
    public class Aluno
    {
        [XmlElement("identificador")]
        public string Identifier { get; set; }

        [XmlElement("nome")]
        public string Name { get; set; }

        [XmlElement("matricula")]
        public string Enrollment { get; set; }

        [XmlElement("datadenascimento")]
        public DateTime Birthdate { get; set; }

        [XmlElement("cpf")]
        public string Cpf { get; set; }

        [XmlElement("ativo")]
        private int EnabledField { get; set; }

        public bool Enabled { get { return this.EnabledField > 0; } }
    }
}
