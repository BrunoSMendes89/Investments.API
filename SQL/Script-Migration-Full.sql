CREATE SCHEMA `investment` ;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `customers` (
    `CustomerId` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(80) CHARACTER SET utf8mb4 NULL,
    `AccountNumber` varchar(80) CHARACTER SET utf8mb4 NULL,
    `AccountBalance` double NOT NULL,
    CONSTRAINT `PK_customers` PRIMARY KEY (`CustomerId`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `products` (
    `ProductId` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(80) CHARACTER SET utf8mb4 NULL,
    `Price` double NOT NULL,
    `Quantity` int NOT NULL,
    `ProductType` int NOT NULL,
    `DueDate` datetime(6) NOT NULL,
    `Active` tinyint(1) NOT NULL,
    CONSTRAINT `PK_products` PRIMARY KEY (`ProductId`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `users` (
    `UserId` int NOT NULL AUTO_INCREMENT,
    `UserName` varchar(80) CHARACTER SET utf8mb4 NULL,
    `Email` varchar(80) CHARACTER SET utf8mb4 NULL,
    `Active` tinyint(1) NOT NULL,
    CONSTRAINT `PK_users` PRIMARY KEY (`UserId`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `customersproducts` (
    `CustomerId` int NOT NULL,
    `ProductId` int NOT NULL,
    `Quantity` int NOT NULL,
    CONSTRAINT `PK_customersproducts` PRIMARY KEY (`CustomerId`, `ProductId`),
    CONSTRAINT `FK_customersproducts_customers_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `customers` (`CustomerId`) ON DELETE CASCADE,
    CONSTRAINT `FK_customersproducts_products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `products` (`ProductId`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `transactions` (
    `TransactionId` int NOT NULL AUTO_INCREMENT,
    `Date` datetime(6) NOT NULL,
    `Description` varchar(80) CHARACTER SET utf8mb4 NULL,
    `Amount` double NOT NULL,
    `TransactionType` int NOT NULL,
    `CustomerId` int NOT NULL,
    `ProductId` int NULL,
    CONSTRAINT `PK_transactions` PRIMARY KEY (`TransactionId`),
    CONSTRAINT `FK_transactions_customers_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `customers` (`CustomerId`) ON DELETE CASCADE,
    CONSTRAINT `FK_transactions_products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `products` (`ProductId`)
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_customersproducts_ProductId` ON `customersproducts` (`ProductId`);

CREATE INDEX `IX_transactions_CustomerId` ON `transactions` (`CustomerId`);

CREATE INDEX `IX_transactions_ProductId` ON `transactions` (`ProductId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240701163917_Initial-Migration', '8.0.6');

COMMIT;

