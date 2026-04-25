# API-AspNetCore-MySQL-Dapper

Exemplo de API Asp.Net Core utilizando banco de dados MySQL acessando com Dapper.

## Requisitos e Detalhe do uso do docker

### Docker/Docker-compose (Instruções de instalação)

Para facilitar a execução da API de forma independente de instalações de servidor, foi adicionao ao repositório um pasta denominada **database** e um arquivo **docker-compose-mysql.yml**.

- **database** - esta pasta contém um arquivo, script_inicial.sql, que será executado quando o container da imagem MySQL for instanciado. Neste aquivo apenas existe a criação do script.
  
- **docker-compose-mysql.json** - Arquivo de composição docker para facilitar orquestrar a execução do container do MySQL com alguns parâmetros(variáveis de ambiente), contendo nome do banco de dados, senha e volumes(Criação automática do Script).

### Execução no VSCode

Criar o Container:

```bash
    docker-compose -f docker-compose-mysql.yml up -d
```

Fechar o container:

```bash
    docker-compose -f docker-compose-mysql.yml down
```

Para executar a aplicação é necessário a execução do container MySQL. 
Após iniciar o Container, execute o apalicação:

```bash
    dotnet restore
```

```bash
    dotnet run
```

