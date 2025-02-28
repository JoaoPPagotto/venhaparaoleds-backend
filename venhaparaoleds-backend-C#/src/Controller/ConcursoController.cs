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
        public void ReadFileConcursos()
        {
            IConcursoService concursoService = new ConcursoService();
            concursoService.ReadData();
        }

        public void ConcursoPorCPF()
        {
            IConcursoService concursoService = new ConcursoService();
            concursoService.ConcursoPorCPF();
        }
    }
}

