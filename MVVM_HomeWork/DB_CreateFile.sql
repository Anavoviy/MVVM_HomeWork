CREATE DATABASE HomeDB;
--
-- Set default database
--
USE HomeDB;

--
-- Create table `provider`
--
CREATE TABLE provider (
  Id int NOT NULL AUTO_INCREMENT,
  Title varchar(255) NOT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 20,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Create table `category`
--
CREATE TABLE category (
  Id int NOT NULL,
  Title varchar(255) NOT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Create table `product`
--
CREATE TABLE product (
  Id int NOT NULL AUTO_INCREMENT,
  Title varchar(255) DEFAULT NULL,
  IdCategory int NOT NULL,
  IdProvider int NOT NULL,
  CostOfOne decimal(19, 2) UNSIGNED DEFAULT NULL,
  Discount tinyint DEFAULT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 21,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Create foreign key
--
ALTER TABLE product
ADD CONSTRAINT FK_product_IdCategory FOREIGN KEY (IdCategory)
REFERENCES category (Id);

--
-- Create foreign key
--
ALTER TABLE product
ADD CONSTRAINT FK_product_IdProvider FOREIGN KEY (IdProvider)
REFERENCES provider (Id);

-- 
-- Dumping data for table provider
--
INSERT INTO provider VALUES
(1, ' Apple'),
(2, ' ASICS'),
(3, ' ASUS'),
(4, ' Davidoff'),
(5, ' Ferrero'),
(6, ' IKEA'),
(7, ' JBL'),
(8, ' Koh-I-Noor'),
(9, ' LG'),
(10, ' L''Oreal'),
(11, ' Philips'),
(12, ' Tefal'),
(13, ' Under Armor'),
(14, ' Блумсбери'),
(15, ' Dell'),
(16, ' Lancome'),
(17, ' Lavazza'),
(18, ' Lenovo'),
(19, ' Lipton');

-- 
-- Dumping data for table category
--
INSERT INTO category VALUES
(1, ' литература'),
(2, ' техника'),
(3, ' спортивные товары'),
(4, ' продукты питания'),
(5, ' товары для школы'),
(6, ' бытовая техника'),
(7, ' товары для здоровья'),
(8, ' товары для красоты'),
(9, ' товары для кухни'),
(10, ' товары для творчества'),
(11, ' компьютеры и комплектующие'),
(12, ' кухонная техника'),
(13, ' аудиотехника'),
(14, ' товары для дома');

-- 
-- Dumping data for table product
--
INSERT INTO product VALUES
(1, ' Книга "Гарри Поттер и философский камень"', 1, 14, 500.00, 10),
(2, ' Смартфон iPhone 12 Pro', 2, 1, 99990.00, 5),
(3, ' Ноутбук IdeaPad 3', 2, 18, 44990.00, 15),
(4, ' Кроссовки Gel-Kayano 27', 3, 2, 12990.00, 20),
(5, ' Шоколадная конфета Ferrero Rocher', 4, 5, 150.00, 0),
(6, ' Рюкзак Back To School', 5, 13, 2990.00, 10),
(7, ' Кофе в зернах "Arabica"', 4, 17, 700.00, 0),
(8, ' Стиральная машина WM 1080', 6, 9, 29990.00, 7),
(9, ' Шампунь "Elseve" для волос', 7, 10, 300.00, 8),
(10, ' Ноутбук MacBook Air', 2, 1, 89990.00, 5),
(11, ' Парфюм "La Vie Est Belle"', 8, 16, 7900.00, 12),
(12, ' Керамическая сковорода "Titanium"', 9, 12, 1590.00, 20),
(13, ' Набор фломастеров "Capitan"', 10, 8, 490.00, 0),
(14, ' Чай "Голден Сенча"', 4, 19, 250.00, 15),
(15, ' Монитор UltraSharp 27', 11, 15, 33990.00, 10),
(16, ' Блендер UltraBlend', 12, 11, 5990.00, 0),
(17, ' Маршрутизатор RT-AC86U', 11, 3, 16490.00, 5),
(18, ' Колонки Xtreme 3', 13, 7, 14990.00, 10),
(19, ' Гель для душа "Cool Water"', 8, 4, 590.00, 0),
(20, ' Лампа настольная "Ella"', 14, 6, 1590.00, 15);
