# Projeto .NET Core

## Commandos

### Build

```
dotnet run
dotnet build
dotnet rebuild
dotnet clean
```

### Migrations

Criar _migrations_

```
dotnet ef migrations add nome
```

Atualizar banco de dados

```
dotnet ef database update
```

Remove _migrations_

```
dotnet ef migrations remove
```

Gera scripts _migrations_

```
dotnet ef migrations script
```

Criando a partir de outro projeto

```
dotnet ef --startup-project ../ProAgil.API comando
```
