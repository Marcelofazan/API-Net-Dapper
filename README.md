# Api Mysql

Exemplo de API AspNetCore com banco de dados MySQL utilizando Dapper.

## Requisitos e Detalhe do uso do docker

- Docker/Docker-compose (Instruções de instalação)

Para facilitar a execução da API de forma independente de instalações de base de dados, foi adicionao ao repositório um pasta denominada **Database** e um arquivo **docker-compose-mysql.yml**.
- **Database** - esta pasta contém um arquivo, script_inicial.sql, que será executado quando o container da imagem MySql for isntanciado. Neste aquivo apenas existe um script para criação de uma tabela e alguns registros.
- **docker-compose-mysql.json** - Arquivo de composição docker para facilitar orquestrar a execução do container do MySQl com alguns parâmetros(variáveis de ambiente), contendo informações como usuário, senha e volumes.

## Execução da aplicação

Para executar a aplicação é necessário a execução do container MySql. 
Primeiramente execute o seguinte comando:

```bash
docker-compose -f docker-compose-mysql.yml up -d
```

Este comando executan um container com base no descritivo do arquvo de composição.
Após o container iniciado, execute o comando:

```bash
dotnet run
```
Se desejar fechar o container após a execução, digite o comando:

```bash
docker-compose -f docker-compose-mysql.yml down
```

## String de conexão do banco

Se já possuir um banco de dados MySql e deseja utilizá-lo na aplicação, modifique a string de conexão no arquivo **appsettings.json**, no trecho indicado:

```json
...
  "ConnectionStrings": {
    "MySqlDbConnection": "server=127.0.0.1;userid=root;password=SUASENHA;database=SEUBANCO;persistsecurityinfo=True"
  },
...

```

O script para criação da tabela do exemplo e alguns dados iniciais encontra-se na pasta **Database**.