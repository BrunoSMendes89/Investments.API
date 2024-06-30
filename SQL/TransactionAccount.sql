START TRANSACTION;

DROP TABLE `CustomersProducts`;

ALTER TABLE `customers` MODIFY COLUMN `AccountNumber` varchar(50) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `customers` ADD `AccountBalance` double NOT NULL DEFAULT 0.0;

CREATE TABLE `CustomerProduct` (
    `CustomersCustomerId` int NOT NULL,
    `ProductsProductId` int NOT NULL,
    CONSTRAINT `PK_CustomerProduct` PRIMARY KEY (`CustomersCustomerId`, `ProductsProductId`),
    CONSTRAINT `FK_CustomerProduct_customers_CustomersCustomerId` FOREIGN KEY (`CustomersCustomerId`) REFERENCES `customers` (`CustomerId`) ON DELETE CASCADE,
    CONSTRAINT `FK_CustomerProduct_products_ProductsProductId` FOREIGN KEY (`ProductsProductId`) REFERENCES `products` (`ProductId`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `transactions` (
    `TransactionId` int NOT NULL AUTO_INCREMENT,
    `Date` datetime(6) NOT NULL,
    `Description` varchar(50) CHARACTER SET utf8mb4 NULL,
    `Amount` double NOT NULL,
    `TransactionType` int NOT NULL,
    `CustomerId` int NOT NULL,
    CONSTRAINT `PK_transactions` PRIMARY KEY (`TransactionId`),
    CONSTRAINT `FK_transactions_customers_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `customers` (`CustomerId`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_CustomerProduct_ProductsProductId` ON `CustomerProduct` (`ProductsProductId`);

CREATE INDEX `IX_transactions_CustomerId` ON `transactions` (`CustomerId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240630173358_TransacionAccount', '8.0.6');

COMMIT;

