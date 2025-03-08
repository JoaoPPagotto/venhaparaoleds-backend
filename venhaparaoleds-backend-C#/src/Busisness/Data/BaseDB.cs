using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Threading.Tasks;

namespace venhaparaoleds_backend.src.Busisness.Data
{
    public class BaseDB
    {
        private static BaseDB instance;
        private static readonly object lockObject = new object();

        // String de conexão para acessar o banco concursos
        public static string StringConnection = "";

        // Propriedade para acessar a instância única
        public static BaseDB Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new BaseDB();
                            CriarBancoDeDados();
                            CriarTabelas();
                        }
                    }
                }
                return instance;
            }
        }

        // Construtor privado para evitar instâncias externas
        private BaseDB() { }

        // Método para criar o banco de dados
        static void CriarBancoDeDados()
        {
            try
            {
                using (var conn = new NpgsqlConnection(StringConnection))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT 1 FROM pg_database WHERE datname = 'concursos'", conn))
                    {
                        var exists = cmd.ExecuteScalar();
                        if (exists == null)
                        {
                            using (var createCmd = new NpgsqlCommand("CREATE DATABASE concursos", conn))
                            {
                                createCmd.ExecuteNonQuery();
                                Console.WriteLine("Banco de dados 'concursos' criado com sucesso!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Banco de dados 'concursos' já existe.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar banco de dados: " + ex.Message);
            }
        }

        // Método para criar as tabelas
        static void CriarTabelas()
        {
            try
            {
                using (var conn = new NpgsqlConnection(StringConnection))
                {
                    conn.Open();

                    string criarTabelaCandidatos = @"CREATE TABLE IF NOT EXISTS candidatos (
                        id SERIAL PRIMARY KEY,
                        nome VARCHAR(100),
                        data_nascimento DATE,
                        cpf VARCHAR(14),
                        profissoes TEXT[]
                    );";

                    string criarTabelaConcursos = @"CREATE TABLE IF NOT EXISTS concursos (
                        id SERIAL PRIMARY KEY,
                        orgao VARCHAR(100),
                        edital VARCHAR(20),
                        codigo VARCHAR(20),
                        vagas TEXT[]
                    );";

                    using (var cmd = new NpgsqlCommand(criarTabelaCandidatos, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Tabela 'candidatos' criada ou já existente.");
                    }

                    using (var cmd = new NpgsqlCommand(criarTabelaConcursos, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Tabela 'concursos' criada ou já existente.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar tabelas: " + ex.Message);
            }
        }
    }
}
