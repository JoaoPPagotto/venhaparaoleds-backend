using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using venhaparaoleds_backend.src.Busisness.Entities;


namespace venhaparaoleds_backend.src.Services.Interfaces
{
    public interface IConcursoService
    {
        public dynamic GetData();
        public void ConcursoPorCPF(List<Candidato> candidatos, List<Concurso> concursos);
    }
}

