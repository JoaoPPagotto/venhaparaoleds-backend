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
        public void ReadFileCandidatos()
        {
            ICandidatoService candidatoService = new CandidatoService();
            candidatoService.ReadData();
        }

        public void CandidatoPorCodigo()
        {
            ICandidatoService candidatoService = new CandidatoService();
            candidatoService.CandidatoPorCodigo();
        }
    }
}

