START TRANSACTION;

ALTER TABLE `products` ADD `Quantity` int NOT NULL DEFAULT 0;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240630220304_ProductQuantity', '8.0.6');

COMMIT;
