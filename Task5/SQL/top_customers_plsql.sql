-- Ativa a exibição de saída no console
SET SERVEROUTPUT ON;

DECLARE
  ---------------------------------------------------------------------------
  -- Cursor principal:
  -- Seleciona os 5 clientes que mais gastaram nos últimos 6 meses
  ---------------------------------------------------------------------------
  CURSOR top_customers_cur IS
    SELECT
      c.customer_id,
      c.name,
      SUM(o.total_amount) AS total_spent
    FROM
      Customers c
      JOIN Orders o ON c.customer_id = o.customer_id
    WHERE
      o.order_date >= SYSDATE - 180  -- considera apenas pedidos dos últimos 180 dias (~6 meses)
    GROUP BY
      c.customer_id, c.name
    ORDER BY
      total_spent DESC
    FETCH FIRST 5 ROWS ONLY;  -- retorna apenas os 5 clientes com maior gasto

  ---------------------------------------------------------------------------
  -- Cursor secundário:
  -- Lista os produtos comprados por um cliente específico,
  -- somando as quantidades adquiridas nos últimos 6 meses
  ---------------------------------------------------------------------------
  CURSOR products_cur(p_customer_id Customers.customer_id%TYPE) IS
    SELECT
      p.product_name,
      SUM(oi.quantity) AS total_quantity
    FROM
      Orders o
      JOIN Order_Items oi ON o.order_id = oi.order_id
      JOIN Products p ON oi.product_id = p.product_id
    WHERE
      o.customer_id = p_customer_id
      AND o.order_date >= SYSDATE - 180
    GROUP BY
      p.product_name;

BEGIN
  ---------------------------------------------------------------------------
  -- Loop pelos 5 principais clientes (por valor gasto)
  ---------------------------------------------------------------------------
  FOR cust IN top_customers_cur LOOP
    DBMS_OUTPUT.PUT_LINE('Customer ID: ' || cust.customer_id);
    DBMS_OUTPUT.PUT_LINE('Customer Name: ' || cust.name);
    DBMS_OUTPUT.PUT_LINE('Total Amount Spent: $' || TO_CHAR(cust.total_spent, '999,999.99'));
    DBMS_OUTPUT.PUT_LINE('Products Purchased:');

    -------------------------------------------------------------------------
    -- Loop pelos produtos adquiridos por esse cliente
    -------------------------------------------------------------------------
    FOR prod IN products_cur(cust.customer_id) LOOP
      DBMS_OUTPUT.PUT_LINE('  - ' || prod.product_name || ': ' || prod.total_quantity || ' units');
    END LOOP;

    DBMS_OUTPUT.PUT_LINE('------------------------------');
  END LOOP;
END;
/
