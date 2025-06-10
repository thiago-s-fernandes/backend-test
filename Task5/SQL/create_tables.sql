-- Tabela de clientes
CREATE TABLE Customers (
  customer_id NUMBER PRIMARY KEY,
  name VARCHAR2(100),
  email VARCHAR2(100),
  created_date DATE
);

-- Tabela de pedidos
CREATE TABLE Orders (
  order_id NUMBER PRIMARY KEY,
  customer_id NUMBER,
  order_date DATE,
  total_amount NUMBER,
  FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)
);

-- Tabela de produtos
CREATE TABLE Products (
  product_id NUMBER PRIMARY KEY,
  product_name VARCHAR2(100),
  category VARCHAR2(100)
);

-- Tabela de itens de pedidos
CREATE TABLE Order_Items (
  order_item_id NUMBER PRIMARY KEY,
  order_id NUMBER,
  product_id NUMBER,
  quantity NUMBER,
  price NUMBER,
  FOREIGN KEY (order_id) REFERENCES Orders(order_id),
  FOREIGN KEY (product_id) REFERENCES Products(product_id)
);
