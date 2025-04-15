# Projeto E-Commerce 🛒

### - Modelar o banco de dados (Conceitual, Lógico e Físico)
    - Pode utilizar a ferramenta draw.io
### - Criar o banco de dados (Arquivos DDL e DML)
### - - Instalar os pacotes necessários para rodar a aplicação
    - EntityFrameworkCore.Design
    - EntityFrameworkCore.SqlServer
    - EntityFrameworkCore.Tools    
### - Realizar o Scaffold

Utilizar os comandos abaixo no terminal - o segundo comando instala as ferramentas do EntityFrameWork:
    -  dotnet tool install --global dotnet-ef
    -  dotnet ef dbcontext scaffold "Data Source=NOTE-VINICIO\SQLEXPRESS;Initial Catalog=ECommerce;User Id=sa;Password=Senai@134;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --context-dir Context --output-dir Models
   
    
### - Caso dê algum erro no passo anterior, pode adicionar o código abaixo no arquivo/pasta API-ECommerce:
    - <GenerateRuntimeConfigurationFiles>True</GenerateRuntimeConfigurationFiles>
    
<img src="https://ibb.co/yTrQ7QT" alt="exemplo">
    



