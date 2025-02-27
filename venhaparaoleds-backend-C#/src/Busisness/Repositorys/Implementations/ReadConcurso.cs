using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using venhaparaoleds_backend.src.Busisness.Repositorys.Interfaces;
using venhaparaoleds_backend.src.Busisness.Entities;

namespace venhaparaoleds_backend.src.Busisness.Repositorys.Implementations
{
	public class ReadConcurso : IReadConcurso
	{
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../src/Busisness/Data/concursos.txt");

        List<Concurso> IReadConcurso.ReadConcurso()
        {
            return File.ReadAllLines(filePath)
                   .Skip(1)
                   .Select(linha => linha.Split(','))
                   .Select(campos => new Concurso
                   {
                       Orgao = campos[0],
                       Edital = campos[1],
                       Codigo = campos[2],
                       Vagas = campos[3].Trim('[', ']').Split(';').ToList()
                   }).ToList();
        }
    }
}