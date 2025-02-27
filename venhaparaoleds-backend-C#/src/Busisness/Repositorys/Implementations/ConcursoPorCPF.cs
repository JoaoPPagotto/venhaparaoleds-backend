using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using venhaparaoleds_backend.src.Busisness.Repositorys.Interfaces;
using venhaparaoleds_backend.src.Busisness.Entities;

namespace venhaparaoleds_backend.src.Busisness.Repositorys.Implementations
{
    public class ConcursoPorCPF : IConcursoPorCPF
    {
        private string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../src/Busisness/Data/concurso_PorCPF.txt");

        void IConcursoPorCPF.ConcursoPorCPF(List<Candidato> candidatos, List<Concurso> concursos)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(caminhoArquivo, true))
                {
                    foreach (var candidato in candidatos)
                    {
                        writer.WriteLine($"Concursos para {candidato.Nome} ({candidato.CPF}):");
                        foreach (var concurso in concursos)
                        {
                            if (candidato.Profissoes.Any(prof => concurso.Vagas.Contains(prof)))
                            {
                                writer.WriteLine($"Órgão: {concurso.Orgao}, Edital: {concurso.Edital}, Código: {concurso.Codigo}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fala ao criar arquivo de resultado 'concurso_PorCPF' mensagem original: " + ex.Message);
            }
        }
    }
}