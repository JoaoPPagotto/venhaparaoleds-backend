# Sistema de Cadastro de Candidatos e Concursos

Este é um sistema para cadastro de candidatos e concursos a partir de arquivos CSV, com integração com um banco de dados PostgreSQL. O sistema permite que você insira informações de candidatos e concursos no banco de dados, evitando duplicações usando identificadores exclusivos (CPF para candidatos e Código para concursos).

## Funcionalidades

- **Cadastro de Candidatos**: Lê dados de um arquivo CSV e insere informações no banco de dados, evitando duplicação por CPF.
- **Cadastro de Concursos**: Lê dados de um arquivo CSV e insere informações no banco de dados, evitando duplicação por código do concurso.
- **Conexão com PostgreSQL**: O sistema utiliza o banco de dados PostgreSQL para armazenar informações dos candidatos e concursos.
- - **Geração de Resultado**: O sistema vai ler os dados do banco de dados para gerar um resultado na forma de arquivos CSV.
## Requisitos

- .NET 8 ou superior
- PostgreSQL
- Conexão com a internet (para acessar o banco de dados remoto, se necessário)

## Como Usar

1. Clone este repositório:
    ```bash
    git clone https://github.com/JoaoPPagotto/venhaparaoleds-backend
    ```

2. Instale o .NET 8 ou superior, caso ainda não tenha.
   

3. Execute o projeto:
    ```bash
    dotnet run
    ```

4. O sistema irá processar os arquivos CSV e cadastrar os dados no banco de dados.

## Estrutura do Projeto

- **`Repository/ReadCandidato.cs`**: Contém a lógica para ler os dados do arquivo CSV de candidatos e inserir no banco de dados.
- **`Repository/ReadConcurso.cs`**: Contém a lógica para ler os dados do arquivo CSV de concursos e inserir no banco de dados.
- **`Data/BaseDB.cs`**: Contém o código para interagir com o banco de dados PostgreSQL.
- **`Data/Files/`**: Contém os arquivos CSV a serem processados.

