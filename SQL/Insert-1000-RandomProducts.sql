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

        INSERT INTO products (ProductId, Name, Price, ProductType, DueDate) 
        VALUES (i, random_name, random_price, random_product_type, random_due_date);
        
        SET i = i + 1;
    END WHILE;
END$$

DELIMITER ;

-- Execute the stored procedure
CALL InsertRandomProducts();