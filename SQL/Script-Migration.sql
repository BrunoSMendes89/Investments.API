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
    `AccountNumber` int NOT NULL,
    CONSTRAINT `PK_customers` PRIMARY KEY (`CustomerId`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `users` (
    `UserId` int NOT NULL AUTO_INCREMENT,
    `UserName` varchar(80) CHARACTER SET utf8mb4 NULL,
    `Email` varchar(80) CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_users` PRIMARY KEY (`UserId`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `products` (
    `ProductId` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(80) CHARACTER SET utf8mb4 NULL,
    `Price` double NOT NULL,
    `ProductType` int NOT NULL,
    `DueDate` datetime(6) NOT NULL,
    CONSTRAINT `PK_products` PRIMARY KEY (`ProductId`)
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_products_CustomersCustomerId` ON `products` (`CustomersCustomerId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240630014905_FirstMigration', '8.0.6');

COMMIT;

