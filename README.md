# XBankQuery

##### Resumo
O XBankQuery é uma web api que tem a finalidade de ser um serviço de geração de extrato e faturas de uma conta bancária, ele servirá como uma api de consultas para o projeto https://github.com/Vinicius9-Nunes/XBank

##### Requisitos
* Atender os requisitos do projeto XBank (https://github.com/Vinicius9-Nunes/XBank) e ter conseguindo executar o projeto com sucesso.
* Validar string de conexão do sql server local, caso necessario atualizar a string atual no arquivo XBankQuery\XBankQuery\appsettings.json.
***Obs:*** O projeto utiliza Dapper para o acesso aos dados, sendo assim basta ter uma connectionString valida para acessar o banco.

##### Executar o projeto
Depois de atender os rerquisitos basta acessar a pasta do projeto a seguir XBankQuery\XBankQuery\XBankQuery.csproj e rodar o comando dotnet run. 