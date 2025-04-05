-- DML - Inserir dados na tabela

-- DML - Criar, Alterar ou Apagar dados
-- DML - Data Manipulation Language

-- INSERT INTO - Inserir dados

USE ECommerce;

SELECT * FROM Produto;

INSERT INTO Produto (NomeProduto, Descricao, Preco, Estoque, Categoria, Imagem) 
VALUES
('Smartphone X', 'Tela de 6.5", 128GB de armazenamento, câmera dupla', 2500.00, 20, 'Eletrônicos', 'smartphone_x.jpg'),
('Notebook Y', 'Processador Intel i5, 8GB RAM, SSD 256GB', 4800.00, 15, 'Informática', 'notebook_y.jpg'),
('Cadeira Gamer Z', 'Ergonômica, ajuste de altura e inclinação', 1200.00, 10, 'Móveis', 'cadeira_gamer_z.jpg'),
('Fone de Ouvido W', 'Cancelamento de ruído, Bluetooth 5.0', 450.00, 30, 'Áudio', 'fone_ouvido_w.jpg'),
('Smartwatch V', 'Monitor cardíaco, GPS integrado', 899.00, 25, 'Acessórios', 'smartwatch_v.jpg');
