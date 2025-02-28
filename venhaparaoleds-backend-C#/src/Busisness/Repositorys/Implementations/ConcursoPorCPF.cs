using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using venhaparaoleds_backend.src.Busisness.Repositorys.Interfaces;
using venhaparaoleds_backend.src.Busisness.Entities;
using venhaparaoleds_backend.src.Busisness.Data;
using Npgsql;
using System.Collections.Specialized;

namespace venhaparaoleds_backend.src.Busisness.Repositorys.Implementations
{
    public class ConcursoPorCPF : IConcursoPorCPF
    {
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../src/Busisness/Data/concurso_PorCPF.txt");

        void IConcursoPorCPF.GerarArquivoConcursoPorCPF()
        {
            using (var conn = new NpgsqlConnection(BaseDB.StringConnection))
            {
                conn.Open();
                string sql = @"SELECT c.nome, c.cpf, array_to_string(c.profissoes, ', ') as profissoes, co.orgao, co.edital, co.codigo 
                          FROM candidatos c 
                          JOIN concursos co ON c.profissoes && co.vagas 
                          ORDER BY c.cpf;";

                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    using (var sw = new StreamWriter(filePath))
                    {
                        while (reader.Read())
                        {
                            sw.WriteLine($"{reader["cpf"]} -> {reader["nome"]}, {reader["profissoes"]} | {reader["orgao"]}, {reader["edital"]}, {reader["codigo"]}");
                        }
                    }
                }
            }
        }
    }
}