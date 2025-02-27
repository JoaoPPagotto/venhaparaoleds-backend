using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using venhaparaoleds_backend.src.Busisness.Entities;

namespace venhaparaoleds_backend.src.Busisness.Repositorys.Interfaces
{
    public interface ICandidatoPorCodigoConcurso
    {
        public void CandidatoPorCodigo(List<Candidato> candidatos, List<Concurso> concursos);
    }
}