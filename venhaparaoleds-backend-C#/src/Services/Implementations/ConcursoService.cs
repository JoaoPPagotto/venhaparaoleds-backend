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
    public class ConcursoService : IConcursoService
    {
        public void ReadData()
        {
            try
            {
                IReadConcurso readData = new ReadConcurso();
                readData.ReadConcurso();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ler aquivo de Concursos mensagem original: " + ex.Message);
            }
        }

        public void ConcursoPorCPF()
        {
            IConcursoPorCPF concursoPorCPF = new ConcursoPorCPF();
            concursoPorCPF.GerarArquivoConcursoPorCPF();
        }
    }
}

