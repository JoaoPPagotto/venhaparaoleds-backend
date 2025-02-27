using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using venhaparaoleds_backend.src.Application;
using venhaparaoleds_backend.src.Controller;
using venhaparaoleds_backend.src.Busisness.Entities;

namespace venhaparaoleds_backend.src
{
    class Program()
    {
        static void Main()
        {
            Console.WriteLine("Inicializando aplicação...");

            CandidatoController candidatoController = new CandidatoController();
            ConcursoController concursoController = new ConcursoController();

            List<Concurso> concursos = new List<Concurso>();
            List<Candidato> candidatos = new List<Candidato>();

            concursos = concursoController.GetConcursos();
            Console.WriteLine("Arquivo de Concursos lido");

            candidatos = candidatoController.GetCandidatos();
            Console.WriteLine("Arquivo de Candidatos lido");

            candidatoController.CandidatoPorCodigo(candidatos, concursos);
            Console.WriteLine("Arquivo de CandidatosPorCodigo Gerado");

            concursoController.ConcursoPorCPF(candidatos, concursos);
            Console.WriteLine("Arquivo de ConcursosPorCPF Gerado");
        }
    }
}