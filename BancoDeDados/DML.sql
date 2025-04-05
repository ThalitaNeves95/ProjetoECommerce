-- DML - Inserir dados na tabela

-- DML - Criar, Alterar ou Apagar dados
-- DML - Data Manipulation Language

-- INSERT INTO - Inserir dados

USE ECommerce;

SELECT * FROM Produto;

INSERT INTO Produto (NomeProduto, Descricao, Preco, Estoque, Categoria, Imagem) 
VALUES
('Smartphone X', 'Tela de 6.5", 128GB de armazenamento, c�mera dupla', 2500.00, 20, 'Eletr�nicos', 'smartphone_x.jpg'),
('Notebook Y', 'Processador Intel i5, 8GB RAM, SSD 256GB', 4800.00, 15, 'Inform�tica', 'notebook_y.jpg'),
('Cadeira Gamer Z', 'Ergon�mica, ajuste de altura e inclina��o', 1200.00, 10, 'M�veis', 'cadeira_gamer_z.jpg'),
('Fone de Ouvido W', 'Cancelamento de ru�do, Bluetooth 5.0', 450.00, 30, '�udio', 'fone_ouvido_w.jpg'),
('Smartwatch V', 'Monitor card�aco, GPS integrado', 899.00, 25, 'Acess�rios', 'smartwatch_v.jpg');
