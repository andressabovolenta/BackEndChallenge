## Requisitos:

[Baixar o .Net 5.0 Runtime (v5.0.9) de acordo com o processador].
x64: (https://download.visualstudio.microsoft.com/download/pr/f3bb58e7-45e1-46ef-9b90-877a450e345e/b18e3d2c429422e9c1238c9b66ded855/dotnet-runtime-5.0.9-win-x64.exe)
x86: (https://download.visualstudio.microsoft.com/download/pr/334f5618-b0fa-474c-b55e-1d10c9142161/61eb66bf79d0e6cf36f894a5fe847634/dotnet-runtime-5.0.9-win-x86.exe) <br /><br />


## Instalação e restauração de pacotes:

Abra o console, navegue até a pasta root e digite o seguinte comando:
### `dotnet restore`<br /><br />


## Execução:

A partir da pasta root, navegue até a pasta <b>API</b> e execute o seguinte comando na pasta do repositório:
### `dotnet run` <br />

A API deverá estar rodando em um destes endereços:
[http://localhost:5001/](http://localhost:5001/)

## Testes unitários:

Com a API rodando, abra o console, a partir da pasta root navegue até a pasta <b>UnitTest</b> e execute o seguinte comando:
### `dotnet test`<br />

## Testes de integração:

Com a API rodando, abra o console, a partir da pasta root navegue até a pasta <b>IntegrationTest</b> e execute o seguinte comando:
### `dotnet test`<br />