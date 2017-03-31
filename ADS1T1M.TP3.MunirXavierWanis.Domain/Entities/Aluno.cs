using System;
using System.Globalization;
using System.Xml.Serialization;

namespace ADS1T1M.TP3.MunirXavierWanis.Domain.Entities
{
    public class Aluno
    {
        public Guid Id { get; set; }

        [XmlElement("nome")]
        public string Name { get; set; }

        [XmlElement("matricula")]
        public string Enrollment { get; set; }

        [XmlElement("datadenascimento")]
        public string BirthdateField { 
            get { return this.Birthdate.ToString("dd/mm/yyyy"); }
            set
            {
                var date = DateTime.Now;
                DateTime.TryParseExact(value, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                this.Birthdate = date;
            }
        }

        public DateTime Birthdate { get; set; }

        [XmlElement("cpf")]
        public string Cpf { get; set; }

        [XmlElement("ativo")]
        public bool Enabled { get; set; }
    }
}
