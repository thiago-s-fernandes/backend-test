-- Clientes
INSERT INTO customers VALUES (1, 'Thiago', 'thiago@example.com', SYSDATE - 180);
INSERT INTO customers VALUES (2, 'Junior', 'junior@example.com', SYSDATE - 150);
INSERT INTO customers VALUES (3, 'Balthasar', 'balthasar@example.com', SYSDATE - 100);
INSERT INTO customers VALUES (4, 'Maria', 'maria@example.com', SYSDATE - 90);
INSERT INTO customers VALUES (5, 'James', 'james@example.com', SYSDATE - 80);
INSERT INTO customers VALUES (6, 'Anna', 'anna@example.com', SYSDATE - 70);
INSERT INTO customers VALUES (7, 'João', 'joao@example.com', SYSDATE - 60);
INSERT INTO customers VALUES (8, 'Emilly', 'emilly@example.com', SYSDATE - 50);
INSERT INTO customers VALUES (9, 'Lucas', 'lucas@example.com', SYSDATE - 40);
INSERT INTO customers VALUES (10, 'Arthur', 'arthur@example.com', SYSDATE - 30);

-- Produtos
INSERT INTO products VALUES (1, 'Product A', 'Category 1');
INSERT INTO products VALUES (2, 'Product B', 'Category 2');
INSERT INTO products VALUES (3, 'Product C', 'Category 3');
INSERT INTO products VALUES (4, 'Product D', 'Category 4');
INSERT INTO products VALUES (5, 'Product E', 'Category 5');

-- Pedidos
INSERT INTO orders VALUES (1, 1, SYSDATE - 100, 1000);
INSERT INTO orders VALUES (2, 2, SYSDATE - 90, 1500);
INSERT INTO orders VALUES (3, 3, SYSDATE - 80, 800);
INSERT INTO orders VALUES (4, 4, SYSDATE - 70, 3000);
INSERT INTO orders VALUES (5, 5, SYSDATE - 60, 1200);
INSERT INTO orders VALUES (6, 6, SYSDATE - 50, 2500);
INSERT INTO orders VALUES (7, 7, SYSDATE - 40, 2200);
INSERT INTO orders VALUES (8, 8, SYSDATE - 30, 1800);
INSERT INTO orders VALUES (9, 9, SYSDATE - 20, 2700);
INSERT INTO orders VALUES (10, 10, SYSDATE - 10, 3500);

-- Itens dos pedidos
INSERT INTO order_items VALUES (1, 1, 1, 2, 500);   -- Thiago: 2x Product A
INSERT INTO order_items VALUES (2, 2, 2, 3, 500);   -- Junior: 3x Product B
INSERT INTO order_items VALUES (3, 3, 3, 4, 200);   -- Balthasar: 4x Product C
INSERT INTO order_items VALUES (4, 4, 4, 5, 600);   -- Maria: 5x Product D
INSERT INTO order_items VALUES (5, 5, 5, 2, 600);   -- James: 2x Product E
INSERT INTO order_items VALUES (6, 6, 1, 5, 500);   -- Anna: 5x Product A
INSERT INTO order_items VALUES (7, 7, 2, 4, 550);   -- João: 4x Product B
INSERT INTO order_items VALUES (8, 8, 3, 6, 300);   -- Emilly: 6x Product C
INSERT INTO order_items VALUES (9, 9, 4, 5, 540);   -- Lucas: 5x Product D
INSERT INTO order_items VALUES (10, 10, 5, 7, 500); -- Arthur: 7x Product E

COMMIT;
