# Crud de Mensagens em ASP NET 2.1 com Razor e AdminLTE - AdminPanel

```
Tecnologias: 
ASP NET 2.1
MySQL 8+
Razor Engine
```

Para executar o projeto, entre na pasta do arquivo do projeto e execute os comandos a seguir


**Entre no diretório do ASP NET 2.1**
```
(ASP NET 2.1)
1 - Entre no arquivo em ASP NET 2.1, certifique-se de ter o ASP NET 2.1 instalado e MySQL versão 8+
2 - Após isso, entre no terminal de projeto, execute a série de comandos a seguir
```

**Rodar o Asp Net 2.1**
```
# Mude as credencias com seu banco de dados local em appsettings.json
    1° Deve ser gerado o banco de dados local e importar o dump, com as seguintes orientações
    CREATE DATABASE teste(nome do banco de dados); - Através do terminal do MySql

    2° Após isso, utilize algum gerenciador de banco de dados como Dbeaver, faça a conexão e import o Dump 


#O comando a seguir não é necessário, somente em caso do dump estiver com erro, para criar as migrations 
dotnet ef migrations add NomeDaMigracao

# Em seguida para atualizar com as novas migrations
dotnet ef database update


# Build do projeto(Terminal usado Gitbash, os comandos variam entre terminais)
dotnet build

# Rodar o servidor
dotnet run 

Dcoumentaçao para auxílio:
https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.1
```

**Pacotes externos**
```
Pacotes Externos:
Enity Framework Core 
AdminLte Lib
```