START TRANSACTION;

ALTER TABLE `transactions` ADD `ProductId` int NOT NULL DEFAULT 0;

CREATE INDEX `IX_transactions_ProductId` ON `transactions` (`ProductId`);

ALTER TABLE `transactions` ADD CONSTRAINT `FK_transactions_products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `products` (`ProductId`) ON DELETE CASCADE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240630181023_ProductTransaction', '8.0.6');

COMMIT;
