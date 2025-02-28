using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using venhaparaoleds_backend.src.Controller;
using venhaparaoleds_backend.src.Busisness.Entities;
using venhaparaoleds_backend.src.Busisness.Data;

namespace venhaparaoleds_backend.src
{
    class Program()
    {
        static void Main()
        {
            Console.WriteLine("Inicializando aplicação...");

            BaseDB db = BaseDB.Instance;

            CandidatoController candidatoController = new CandidatoController();
            ConcursoController concursoController = new ConcursoController();

            List<Concurso> concursos = new List<Concurso>();
            List<Candidato> candidatos = new List<Candidato>();

            concursoController.ReadFileConcursos();
            Console.WriteLine("Arquivo de Concursos lido, dados no banco");

            candidatoController.ReadFileCandidatos();
            Console.WriteLine("Arquivo de Candidatos lido, dados no banco");

            candidatoController.CandidatoPorCodigo();
            Console.WriteLine("Arquivo de CandidatosPorCodigo Gerado");

            concursoController.ConcursoPorCPF();
            Console.WriteLine("Arquivo de ConcursosPorCPF Gerado");
        }
    }
}