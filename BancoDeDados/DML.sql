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

SELECT * FROM Produto

INSERT INTO Cliente (NomeCompleto, Email, Telefone, Endereco, DataCadastro)
VALUES 
('Josefina da Silva', 'zezinha@gmail.com', '(11)987654444', 'Rua dos Loucos, 0 - Sao Paulo/SP', '05/04/2025'),
('Thalita Neves', 'mavini@gmail.com', '(11)949274848', 'Rua Niteroi, 180 - São Caetano do Sul/SP', '05/04/2025'),
('Daniel Gutierrez', 'danigu@gmail.com', '(11)987652222', 'Rua Copacabana, 180 - São Bernardo do Campo/SP', '05/04/2025'),
('Jessica Silva', 'jesilva@gmail.com', '(11)987651111', 'Rua Amazonas, 180 - São Paulo/SP', '05/04/2025');

SELECT * FROM Cliente

INSERT INTO Pagamento (FormaPagamento, StatusPagamento, DataPagamento, IdPedido)
VALUES 
('Cartão de Crédito', 'Pago', '2025-04-05 15:30:00', 101),
('Boleto Bancário', 'Pendente', '2025-04-06 10:00:00', 102),
('PIX', 'Cancelado', '2025-04-06 12:45:00', 103);

INSERT INTO Pedido (DataPedido, StatusPedido, ValorTotal, IdCliente)
VALUES 
('05/04/2025', 'Concluído', 1299.80, 1), -- Pedido de Marcos Vinicius
('05/05/2025', 'Pendente', 399.90, 2),  -- Pedido de Daniel Gutierrez
('05/06/2025', 'Cancelado', 6999.99, 3); -- Pedido de Jessica Silva

SELECT * FROM Pedido

INSERT INTO Pagamento (FormaPagamento, StatusPagamento, IdPedido)
VALUES
('Cartão de Crédito', 'Pago', 1), -- Pagamento de um pedido de Marcos Vinicius
('Boleto Bancário', 'Pendente', 2), -- Pagamento de um pedido de Daniel Gutierrez
('PIX', 'Cancelado', 3); -- Pagamento de um pedido de Jessica Silva

SELECT * FROM Pagamento

INSERT INTO ItemPedido (Quantidade, IdPedido, IdProduto)
VALUES
(1, 1, 2), -- Teclado Mecânico RGB no pedido de Marcos Vinicius
(2, 2, 1), -- HD Externo no pedido de Daniel Gutierrez
(1, 3, 1); -- Notebook Gamer no pedido de Jessica Silva

SELECT * FROM ItemPedido

-- Faz um join com todas as tabelas
SELECT 
    Cliente.NomeCompleto,
    Cliente.Email,
    Pedido.IdPedido,
    Pedido.DataPedido,
    Pedido.StatusPedido,
    Pedido.ValorTotal,
    Pagamento.FormaPagamento,
    Pagamento.StatusPagamento,
    Produto.NomeProduto,
    Produto.Categoria,
    Produto.Preco,
    ItemPedido.Quantidade
FROM 
    Cliente
INNER JOIN Pedido ON Cliente.IdCliente = Pedido.IdCliente
INNER JOIN Pagamento ON Pedido.IdPedido = Pagamento.IdPedido
INNER JOIN ItemPedido ON Pedido.IdPedido = ItemPedido.IdPedido
INNER JOIN Produto ON ItemPedido.IdProduto = Produto.IdProduto;

-- Excluir uma linha de cliente
DELETE FROM Cliente WHERE NomeCompleto = 'Josefina da Silva' 
SELECT * from Cliente

-- DQL - Visualizar os dados

SELECT * FROM Cliente
