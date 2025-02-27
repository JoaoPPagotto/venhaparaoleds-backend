using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace venhaparaoleds_backend.src.Busisness.Entities
{
    public class Candidato
    {
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string CPF { get; set; }
        public List<string> Profissoes { get; set; }
    }
}