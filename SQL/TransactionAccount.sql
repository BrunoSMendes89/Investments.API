START TRANSACTION;

DROP TABLE `CustomersProducts`;

ALTER TABLE `customers` MODIFY COLUMN `AccountNumber` longtext CHARACTER SET utf8mb4 NULL;

ALTER TABLE `customers` ADD `AccountBalance` double NOT NULL DEFAULT 0.0;

CREATE TABLE `bankstatements` (
    `BankStatementId` int NOT NULL AUTO_INCREMENT,
    `StatementDate` datetime(6) NOT NULL,
    `OpeningBalance` decimal(65,30) NOT NULL,
    `ClosingBalance` decimal(65,30) NOT NULL,
    `CustomerId` int NOT NULL,
    CONSTRAINT `PK_bankstatements` PRIMARY KEY (`BankStatementId`),
    CONSTRAINT `FK_bankstatements_customers_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `customers` (`CustomerId`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

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
    `Description` longtext CHARACTER SET utf8mb4 NULL,
    `Amount` decimal(65,30) NOT NULL,
    `TransactionType` int NOT NULL,
    `BankStatementId` int NOT NULL,
    CONSTRAINT `PK_transactions` PRIMARY KEY (`TransactionId`),
    CONSTRAINT `FK_transactions_bankstatements_BankStatementId` FOREIGN KEY (`BankStatementId`) REFERENCES `bankstatements` (`BankStatementId`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_bankstatements_CustomerId` ON `bankstatements` (`CustomerId`);

CREATE INDEX `IX_CustomerProduct_ProductsProductId` ON `CustomerProduct` (`ProductsProductId`);

CREATE INDEX `IX_transactions_BankStatementId` ON `transactions` (`BankStatementId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240630133614_TransacionAccount', '8.0.6');

COMMIT;

