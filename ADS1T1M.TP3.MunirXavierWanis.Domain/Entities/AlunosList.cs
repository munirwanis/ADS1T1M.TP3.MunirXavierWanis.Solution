﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ADS1T1M.TP3.MunirXavierWanis.Domain.Entities
{
    [Serializable, XmlRoot("alunos")]
    public class AlunosList
    {
        [XmlElement("aluno")]
        public List<Aluno> Alunos { get; set; }
    }
}
