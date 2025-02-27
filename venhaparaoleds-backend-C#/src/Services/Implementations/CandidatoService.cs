using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using venhaparaoleds_backend.src.Busisness.Repositorys.Interfaces;
using venhaparaoleds_backend.src.Busisness.Repositorys.Implementations;
using venhaparaoleds_backend.src.Busisness.Entities;
using venhaparaoleds_backend.src.Services.Interfaces;


namespace venhaparaoleds_backend.src.Services.Implementations
{
    public class CandidatoService : ICandidatoService
    {
        public dynamic GetData()
        {
            try
            {
                IReadCandidato readData = new ReadCandidato();
                return readData.ReadCandidato();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ler aquivo de Candidatos mensagem original: " + ex.Message);
            }
        }

        public void CandidatoPorCodigo(List<Candidato> candidatos, List<Concurso> concursos)
        {
            ICandidatoPorCodigoConcurso candidatoPorCod = new CandidatoPorCodigoConcurso();
            candidatoPorCod.CandidatoPorCodigo(candidatos, concursos);
        }
    }
}

