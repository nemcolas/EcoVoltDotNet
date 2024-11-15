# Projeto EcoVolt

Este é o repositório do projeto EcoVolt, uma aplicação ASP.NET Core MVC desenvolvida com o objetivo de gerenciar e monitorar dados de consumo e geração de energia de diversas fontes e dispositivos.

## Tecnologias Utilizadas

- ASP.NET Core MVC
- Entity Framework Core
- Oracle Database

## Estrutura do Projeto

A aplicação EcoVolt possui os seguintes componentes principais:

### Models

A camada de Models contém as classes que representam as entidades do banco de dados, incluindo:
- `GsPais`: representa o país.
- `GsCidade`: representa a cidade.
- `GsEstado`: representa o estado.
- `GsBairro`: representa o bairro.
- `GsConsumidor`: representa o consumidor de energia.
- `GsConsumoEnergia`: representa os dados de consumo de energia.
- `GsDispositivo`: representa o dispositivo de consumo de energia.
- `GsFonteEnergia`: representa a fonte de energia.
- `GsGeracaoEnergia`: representa os dados de geração de energia.
- `GsLocalizacao`: representa a localização geográfica.
- `GsTipoConsumidor`, `GsTipoDispositivo`, `GsTipoFonte`: representam os tipos de consumidores, dispositivos e fontes de energia.

### Controllers

Os controllers gerenciam as requisições HTTP e conectam a camada de apresentação com a lógica de negócio. Os principais controllers incluem:
- `GsPaisController`
- `GsBairroController`
- `GsCidadeController`
- `GsConsumidorController`
- `GsConsumoEnergiaController`
- `GsDispositivoController`
- `GsEstadoController`
- `GsFonteEnergiaController`
- `GsGeracaoEnergiaController`
- `GsLocalizacaoController`
- `GsTipoConsumidorController`
- `GsTipoDispositivoController`
- `GsTipoFonteController`

### Repositories

A camada de Repositórios abstrai o acesso ao banco de dados, permitindo um código mais modular e testável. Cada entidade possui um repositório responsável pela manipulação dos dados.

## Configuração do Projeto

### Pré-requisitos

Certifique-se de ter o seguinte instalado:
- .NET SDK 8.0 ou superior
- Banco de dados Oracle
- Visual Studio ou Rider

### Configuração do Banco de Dados

1. Configure o banco de dados Oracle  para armazenar os dados da aplicação.
2. Atualize a string de conexão no arquivo `appsettings.json` com as credenciais do banco de dados.

### Executando a Aplicação

1. Clone o repositório.
   ```bash
   https://github.com/nemcolas/EcoVoltDotNet
   ```
2. Navegue até o diretório do projeto.
   ```bash
   cd EcoVolt
   ```
   
3. Execute a aplicação.
   ```bash
   dotnet run
   ```
   
### Visualizando a Aplicação

Após a execução da aplicação, acesse o endereço `https://localhost:5182` para visualizar a aplicação EcoVolt, navegue entre 
os endpoints exemplo: `https://localhost:5182/GsConsumidor` para visualizar cada uma das entidades.

### Funcionalidades

A aplicação EcoVolt permite:

- Gerenciamento de dados de consumidores, dispositivos, fontes de energia, etc.
- Visualização de dados de consumo, geração de energia, localização geográfica, etc.


## Membros da Equipe

Esse projeto foi desenvolvido por: Luana Sousa Matos, RM: 552621 e Nicola Martins, RM:553478

