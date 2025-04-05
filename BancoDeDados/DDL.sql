USE ECommerce;

-- T-SQL (Microsoft), PL/SQL (Oracle) - 
-- Tem if/else, funcoes

-- SQL - Comandos 

-- DDL - Criar, Alterar ou Apagar Banco de Dados e Tabelas
-- DDL - Data Definition Language
-- DDL = CREATE e DROP

-- CREATE DATABASE nomeDoBanco; (Criar o banco)
-- CREATE TABLE nomeDaTabela; (Criar a tabela)

-- DROP DATABASE nomeDoBanco (Apagar o banco)

-- Nome sempre no Singular e começando com letra maiúscula
CREATE TABLE Cliente (
-- PRIMARY KEY - Coluna que identifica o cliente
-- IDENTITY - Seja gerada automaticamente
	IdCliente INT PRIMARY KEY IDENTITY,
	NomeCompleto VARCHAR(150),
	Email VARCHAR(100),
	Telefone VARCHAR(20),
	Endereco VARCHAR(255),
	DataCadastro DATE
);

CREATE TABLE Pedido (
	IdPedido INT PRIMARY KEY IDENTITY,
	DataPedido DATE,
	StatusPedido VARCHAR(20),
	ValorTotal DECIMAL(18, 6),
	IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente)
);

CREATE TABLE Pagamento (
	IdPagamento INT PRIMARY KEY IDENTITY,
	FormaPagamento VARCHAR(20),
	StatusPagamento VARCHAR(20),
	IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido)
);

CREATE TABLE Produto (
	IdProduto INT PRIMARY KEY IDENTITY,
	NomeProduto VARCHAR(200),
	Descricao VARCHAR(255),
	Preco DECIMAL(12, 6),
	Estoque INT,
	Categoria VARCHAR(100),
	Imagem VARCHAR(255)
);

CREATE TABLE ItemPedido (
	IdItemPedido INT PRIMARY KEY IDENTITY,
	Quantidade INT,
	IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido),
	IdProduto INT FOREIGN KEY REFERENCES Produto(IdProduto)
);

-- Não posso apagar uma tabela, caso outra dependa dela - Apago primeiro a que existe a referencia
-- DROP TABLE nomeDaTabela (Apagar a tabela)
/*
DROP TABLE ItemPedido;
DROP TABLE Pagamento;
DROP TABLE Pedido;
DROP TABLE Produto;
DROP TABLE Cliente;

ALTER TABLE ItemPedido ();
*/

-- DQL - Ver os dados
-- DQL - Data Query Language