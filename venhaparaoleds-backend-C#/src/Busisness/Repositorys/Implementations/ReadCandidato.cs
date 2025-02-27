using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using venhaparaoleds_backend.src.Busisness.Repositorys.Interfaces;
using venhaparaoleds_backend.src.Busisness.Entities;

namespace venhaparaoleds_backend.src.Busisness.Repositorys.Implementations
{
    public class ReadCandidato : IReadCandidato
    {
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../src/Busisness/Data/candidatos.txt");

        List<Candidato> IReadCandidato.ReadCandidato()
        {
            return File.ReadAllLines(filePath)
                   .Skip(1)
                   .Select(linha => linha.Split(','))
                   .Select(campos => new Candidato
                   {
                       Nome = campos[0],
                       DataNascimento = campos[1],
                       CPF = campos[2],
                       Profissoes = campos[3].Trim('[', ']').Split(';').ToList()
                   }).ToList();
        }
    }
}