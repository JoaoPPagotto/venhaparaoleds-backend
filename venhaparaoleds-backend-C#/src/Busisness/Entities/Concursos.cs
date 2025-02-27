using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace venhaparaoleds_backend.src.Busisness.Entities
{
    public class Concurso
    {
        public string Orgao { get; set; }
        public string Edital { get; set; }
        public string Codigo { get; set; }
        public List<string> Vagas { get; set; }
    }
}