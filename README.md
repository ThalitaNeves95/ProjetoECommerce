# Projeto E-Commerce 🛒

### - Modelar o banco de dados (Conceitual, Lógico e Físico)
<ins>Pode utilizar a ferramenta draw.io</ins>
    
### - Criar o banco de dados (Arquivos DDL e DML)

### - - Instalar os pacotes necessários para rodar a aplicação
    EntityFrameworkCore.Design
    EntityFrameworkCore.SqlServer
    EntityFrameworkCore.Tools
    
### - Realizar o Scaffold

Utilizar os comandos abaixo no terminal - o segundo comando instala as ferramentas do EntityFrameWork:
```
dotnet tool install --global dotnet-ef
```
    
    dotnet ef dbcontext scaffold "Data Source=NOTE-VINICIO\SQLEXPRESS;Initial Catalog=ECommerce;User Id=sa;Password=Senai@134;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --context-dir Context --output-dir Models
       
    
### - Caso dê algum erro no passo anterior, pode adicionar o código abaixo no arquivo/pasta API-ECommerce:
    - <GenerateRuntimeConfigurationFiles>True</GenerateRuntimeConfigurationFiles>
    
![image](https://github.com/user-attachments/assets/0e48b397-85df-4669-92b9-2a360c8532ca)

### - Criar a estrutura e pastas do projeto:
    Controlles
    Interfaces
    Repositories  
![Screenshot 2025-04-14 212635](https://github.com/user-attachments/assets/2dcdbbd5-2589-4282-815e-9bd3dced1075)


### - Criar os arquivos de Interface:
Definir Metodos de CRUD

### - Criar Repository
Herdar da Interface
Implementar Interface
Criar a Variável Contexto
Injetar o Contexto
Implementar Metódos

### - Configurar Injeção de Dependência - Arquivo Program.cs

### - Criar a Classe Controller
Injetar o Repository
Criar Metodos do CRUD
    Listar
    Criar
    Editar
    Deletar
    

    



