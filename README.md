# API-AspNetCore-MySQL-Dapper

Exemplo de API Asp.Net Core utilizando banco de dados MySQL acessando com Dapper.

## Requisitos e Detalhes do uso do Docker/Docker-compose

Baixar Container temporário do Servidor MySQL e executar o Script por linha de código.

Na pasta **database** esta pasta contém um arquivo, (script_inicial.sql), que será executado quando o container da imagem MySQL for instanciado.

## O que você vai encontrar neste projeto

- **Dapper** - Utilização de mapeamento rápido de resultados de consultas SQL diretas pela aplicação.
- **docker-compose-mysql.yml** - Arquivo container do MySQL contendo a criação do banco de dados e volumes(Geração do Script automático).

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

### Configuração Driver MySQL para IDE (**DBeaver** ou Workbench) 

Navegue até Propriedades do driver: Clique na guia Propriedades do driver (ao lado da guia “Principal”).
Habilitar recuperação:

- Encontre a propriedade chamada permitirPublicKeyRetrieval. 
Mude seu valor de falso para **verdadeiro**.

- Alternativa (guia SSL): Nas versões mais recentes do DBeaver, você também pode ir até a aba SSL e marcar a caixa **Permitir recuperação de chave pública**.


Desativar verificação de certificado (correção rápida) 
Se você estiver em um ambiente de desenvolvimento e não precisar de validação SSL rigorosa:

- Clique com o botão direito na sua conexão > Editar conexão.
Navegue até as configurações de SSL.
Desmarque Verificar certificado do servidor.
