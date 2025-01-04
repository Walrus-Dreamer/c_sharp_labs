# Установка.

```sh
dotnet add package Microsoft.Extensions.Hosting ;
dotnet add package Microsoft.Extensions.DependencyInjection ;
dotnet add package xunit ;
dotnet add package Newtonsoft.Json ;
dotnet add package Moq ;
dotnet add package Microsoft.EntityFrameworkCore ;
dotnet add package Microsoft.EntityFrameworkCore.Sqlite ;
dotnet add package Microsoft.EntityFrameworkCore.Design
```

# Запуск проекта.

Перейти в директорию требуемой лабораторной работы, затем выполнить команды:

```sh
dotnet run
```

# Запуск тестов.

Перейти в директорию требуемой лабораторной работы, затем выполнить команды:

```sh
dotnet restore
dotnet test
```
