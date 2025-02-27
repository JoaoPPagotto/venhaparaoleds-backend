using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using venhaparaoleds_backend.src.Services.Interfaces;
using venhaparaoleds_backend.src.Services.Implementations;
using venhaparaoleds_backend.src.Busisness.Entities;

namespace venhaparaoleds_backend.src.Controller
{
    public class ConcursoController
    {
        public dynamic GetConcursos()
        {
            IConcursoService concursoService = new ConcursoService();
            return concursoService.GetData();
        }

        public void ConcursoPorCPF(List<Candidato> candidatos, List<Concurso> concursos)
        {
            IConcursoService concursoService = new ConcursoService();
            concursoService.ConcursoPorCPF(candidatos, concursos);
        }
    }
}

