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
    public class ReadCandidato : IReadCandidato
    {
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../src/Busisness/Data/candidatos.txt");

        void IReadCandidato.ReadCandidato()
        {
            try
            {
                var linhas = File.ReadAllLines(filePath).Skip(1);
                using (var conn = new NpgsqlConnection(BaseDB.StringConnection))
                {
                    conn.Open();
                    foreach (var linha in linhas)
                    {
                        var campos = linha.Split(',');

                        // Verificar se o CPF já existe no banco
                        string checkSql = "SELECT COUNT(1) FROM candidatos WHERE cpf = @cpf";
                        using (var checkCmd = new NpgsqlCommand(checkSql, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@cpf", campos[2]);

                            int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                            if (count > 0)
                            {
                                continue;
                            }
                        }

                        string sql = "INSERT INTO candidatos (nome, data_nascimento, cpf, profissoes) VALUES (@nome, @data_nascimento, @cpf, @profissoes)";
                        using (var cmd = new NpgsqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@nome", campos[0]);
                            cmd.Parameters.AddWithValue("@data_nascimento", DateTime.Parse(campos[1]));
                            cmd.Parameters.AddWithValue("@cpf", campos[2]);
                            cmd.Parameters.AddWithValue("@profissoes", campos[3].Trim('[', ']').Split(';'));
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir no banco de dados mensagem Original :" + ex.Message);
            }   
        }
    }
}