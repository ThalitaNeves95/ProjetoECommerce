# Projeto E-Commerce 🛒

### - Modelar o banco de dados (Conceitual, Lógico e Físico)
### - Criar o banco de dados (Arquivos DDL e DML)
### - - Instalar os pacotes necessários para rodar a aplicação
    - EntityFrameworkCore.Design
    - EntityFrameworkCore.SqlServer
    - EntityFrameworkCore.Tools
### - Realizar o Scaffold
    - dotnet tool install --global dotnet-ef
    - dotnet ef dbcontext scaffold "Data Source=NOTE-VINICIO\SQLEXPRESS;Initial Catalog=ECommerce;User Id=sa;Password=Senai@134;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --context-dir Context --output-dir Models
### - 


