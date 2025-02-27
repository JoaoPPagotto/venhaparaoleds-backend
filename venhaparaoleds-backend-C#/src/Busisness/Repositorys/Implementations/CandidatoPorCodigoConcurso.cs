using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using venhaparaoleds_backend.src.Busisness.Repositorys.Interfaces;
using venhaparaoleds_backend.src.Busisness.Entities;

namespace venhaparaoleds_backend.src.Busisness.Repositorys.Implementations
{
    public class CandidatoPorCodigoConcurso : ICandidatoPorCodigoConcurso
    {
        private string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../src/Busisness/Data/candidatos_PorCodigo.txt");

        public void CandidatoPorCodigo(List<Candidato> candidatos, List<Concurso> concursos)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(caminhoArquivo, true))
                {
                    foreach (var concurso in concursos)
                    {
                        writer.WriteLine($"Candidatos para o concurso {concurso.Codigo} ({concurso.Orgao} - {concurso.Edital}):");
                        foreach (var candidato in candidatos)
                        {
                            if (candidato.Profissoes.Any(prof => concurso.Vagas.Contains(prof)))
                            {
                                writer.WriteLine($"Nome: {candidato.Nome}, Data de Nascimento: {candidato.DataNascimento}, CPF: {candidato.CPF}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fala ao criar arquivo de resultado 'candidatos_PorCodigo' mensagem original: " + ex.Message);
            }
        }
    }
}



    