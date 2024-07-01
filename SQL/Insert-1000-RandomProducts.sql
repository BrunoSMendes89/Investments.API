DELIMITER $$

CREATE PROCEDURE InsertRandomProducts()
BEGIN
    DECLARE i INT DEFAULT 1;
    DECLARE random_name VARCHAR(4);
    DECLARE random_price DECIMAL(10, 2);
    DECLARE random_product_type INT;
    DECLARE random_due_date DATE;
    DECLARE random_char CHAR(1);
    DECLARE random_num CHAR(1);
    DECLARE random_product_quantity INT;
    DECLARE random_product_Active BOOL;

    WHILE i <= 1000 DO
        -- Generate a random name with up to 3 letters followed by 1 number
        SET random_name = CONCAT(
            CHAR(FLOOR(65 + (RAND() * 26))), 
            CHAR(FLOOR(65 + (RAND() * 26))), 
            CHAR(FLOOR(65 + (RAND() * 26))), 
            FLOOR(RAND() * 10)  -- Last character is a random number
        );
        
        SET random_price = ROUND(RAND() * 1000, 2);
        SET random_product_type = FLOOR(1 + RAND() * 5);
        SET random_due_date = CURDATE() + INTERVAL FLOOR(RAND() * 365) DAY;
        SET random_product_quantity = FLOOR(RAND() * 1000);
        SET random_product_Active = (FLOOR(RAND() * 2) = 1);

        INSERT INTO products (ProductId, Name, Price, ProductType, Quantity, DueDate, Active) 
        VALUES (i, random_name, random_price, random_product_type, random_product_quantity, random_due_date, random_product_Active);
        
        SET i = i + 1;
    END WHILE;
END$$

DELIMITER ;

-- Execute the stored procedure
CALL InsertRandomProducts();