using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using venhaparaoleds_backend.src.Busisness.Repositorys.Interfaces;
using venhaparaoleds_backend.src.Busisness.Entities;
using Npgsql;
using venhaparaoleds_backend.src.Busisness.Data;

namespace venhaparaoleds_backend.src.Busisness.Repositorys.Implementations
{
	public class ReadConcurso : IReadConcurso
	{
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../src/Busisness/Data/concursos.txt");

        void IReadConcurso.ReadConcurso()
        {
            var linhas = File.ReadAllLines(filePath).Skip(1);
            using (var conn = new NpgsqlConnection(BaseDB.StringConnection))
            {
                conn.Open();
                foreach (var linha in linhas)
                {
                    var campos = linha.Split(',');

                    // Verificar se o concurso já existe no banco pelo código
                    string checkSql = "SELECT COUNT(1) FROM concursos WHERE codigo = @codigo";
                    using (var checkCmd = new NpgsqlCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@codigo", campos[2]);

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            // Concurso já existe, não inserir novamente
                            continue;
                        }
                    }

                    string sql = "INSERT INTO concursos (orgao, edital, codigo, vagas) VALUES (@orgao, @edital, @codigo, @vagas)";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@orgao", campos[0]);
                        cmd.Parameters.AddWithValue("@edital", campos[1]);
                        cmd.Parameters.AddWithValue("@codigo", campos[2]);
                        cmd.Parameters.AddWithValue("@vagas", campos[3].Trim('[', ']').Split(';'));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}