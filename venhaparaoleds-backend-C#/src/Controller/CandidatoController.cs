using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using venhaparaoleds_backend.src.Services.Interfaces;
using venhaparaoleds_backend.src.Services.Implementations;
using venhaparaoleds_backend.src.Busisness.Entities;


namespace venhaparaoleds_backend.src.Controller
{
    public class CandidatoController
    {
        public dynamic GetCandidatos()
        {
            ICandidatoService candidatoService = new CandidatoService();
            return candidatoService.GetData();
        }

        public void CandidatoPorCodigo(List<Candidato> candidatos, List<Concurso> concursos)
        {
            ICandidatoService candidatoService = new CandidatoService();
            candidatoService.CandidatoPorCodigo(candidatos, concursos);
        }
    }
}

