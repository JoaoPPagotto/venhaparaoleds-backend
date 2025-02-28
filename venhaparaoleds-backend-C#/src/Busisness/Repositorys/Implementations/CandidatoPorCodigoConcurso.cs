using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using venhaparaoleds_backend.src.Busisness.Repositorys.Interfaces;
using venhaparaoleds_backend.src.Busisness.Entities;
using venhaparaoleds_backend.src.Busisness.Data;
using Npgsql;

namespace venhaparaoleds_backend.src.Busisness.Repositorys.Implementations
{
    public class CandidatoPorCodigoConcurso : ICandidatoPorCodigoConcurso
    {
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../src/Busisness/Data/candidatos_PorCodigo.txt");

        void ICandidatoPorCodigoConcurso.GerarArquivoCandidatoPorCodigoConcurso()
        {
            using (var conn = new NpgsqlConnection(BaseDB.StringConnection))
            {
                conn.Open();
                string sql = @"SELECT co.orgao, co.codigo, array_to_string(co.vagas, ', ') as vagas, c.nome, c.cpf, array_to_string(c.profissoes, ', ') as profissoes 
                          FROM concursos co 
                          JOIN candidatos c ON co.vagas && c.profissoes 
                          ORDER BY co.codigo;";

                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    using (var sw = new StreamWriter(filePath))
                    {
                        while (reader.Read())
                        {
                            sw.WriteLine($"{reader["codigo"]} -> {reader["orgao"]}, {reader["vagas"]} | {reader["cpf"]}, {reader["nome"]}, {reader["profissoes"]}");
                        }
                    }
                }
            }
        }

    }
}



    