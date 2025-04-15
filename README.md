# Projeto E-Commerce 🛒

### 1. Modelar o banco de dados (Conceitual, Lógico e Físico)
<ins>Pode utilizar a ferramenta draw.io</ins>
    
### 2. Criar o banco de dados (Arquivos DDL e DML)

### 3. Instalar os pacotes necessários para rodar a aplicação
    EntityFrameworkCore.Design
    EntityFrameworkCore.SqlServer
    EntityFrameworkCore.Tools
    
### 4. Realizar o Scaffold

Utilizar os comandos abaixo no terminal - o segundo comando instala as ferramentas do EntityFrameWork:
```
dotnet tool install --global dotnet-ef
```
    
    dotnet ef dbcontext scaffold "Data Source=NOTE-VINICIO\SQLEXPRESS;Initial Catalog=ECommerce;User Id=sa;Password=Senai@134;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --context-dir Context --output-dir Models
       
    
### 5. Caso dê algum erro no passo anterior, pode adicionar o código abaixo no arquivo/pasta API-ECommerce:
    - <GenerateRuntimeConfigurationFiles>True</GenerateRuntimeConfigurationFiles>
    
![image](https://github.com/user-attachments/assets/0e48b397-85df-4669-92b9-2a360c8532ca)

### 6. Criar a estrutura e pastas do projeto:
    6.1 Controlles
    6.2 Interfaces
    6.3 Repositories  
![Screenshot 2025-04-14 212635](https://github.com/user-attachments/assets/2dcdbbd5-2589-4282-815e-9bd3dced1075)


### 7. Criar os arquivos de Interface:
    7.1 Definir Metodos de CRUD

### 8. Criar Repository
    8.1 Herdar da Interface
    8.2 Implementar Interface
    8.3 Criar a Variável Contexto
    8.4 Injetar o Contexto
    8.5 Implementar Metódos

### 9. Configurar Injeção de Dependência - Arquivo Program.cs
![image](https://github.com/user-attachments/assets/6b047aa9-6118-43ec-9162-2cc8deaf7e44)

### 10. Criar a Classe Controller
    10.1 Injetar o Repository
    10.2 Criar Metodos do CRUD
        10.2.1 Listar
        10.2.2 Criar
        10.2.3 Editar
        10.2.4 Deletar
    

    



