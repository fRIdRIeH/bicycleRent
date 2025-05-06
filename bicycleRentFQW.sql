-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Май 06 2025 г., 22:31
-- Версия сервера: 10.8.4-MariaDB
-- Версия PHP: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `bicycleRentFQW`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Client`
--

CREATE TABLE `Client` (
  `Client_Id` int(11) NOT NULL,
  `Client_Surname` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Client_Name` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Client_Patronymic` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Client_Telephone` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Client_Address` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Client_Features` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Client_Visit_Count` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Client`
--

INSERT INTO `Client` (`Client_Id`, `Client_Surname`, `Client_Name`, `Client_Patronymic`, `Client_Telephone`, `Client_Address`, `Client_Features`, `Client_Visit_Count`) VALUES
(1, 'Ворончихин', 'Николай', 'Батькович', '89991111111', 'деревня блин', 'Коля)', 0),
(2, 'Панин', 'Василий', 'Батькович', '89992222222', 'г. Ижевск', 'Вася)', 0),
(4, 'Макаров', 'Александр', 'Александрович', '89993333333', 'г. Ижевск - г. Москва', 'Санёчек)', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `Deposit`
--

CREATE TABLE `Deposit` (
  `Deposit_Id` int(11) NOT NULL,
  `Deposit_Name` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Deposit`
--

INSERT INTO `Deposit` (`Deposit_Id`, `Deposit_Name`) VALUES
(1, 'ВУ'),
(2, 'Паспорт'),
(3, 'ПУ'),
(4, 'ДЗ');

-- --------------------------------------------------------

--
-- Структура таблицы `Filial`
--

CREATE TABLE `Filial` (
  `Filial_Id` int(11) NOT NULL,
  `Filial_Name` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Filial_Adress` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Filial_Total` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Filial`
--

INSERT INTO `Filial` (`Filial_Id`, `Filial_Name`, `Filial_Adress`, `Filial_Total`) VALUES
(1, 'Набережная', 'Ул. Милиционная', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `Inventory`
--

CREATE TABLE `Inventory` (
  `Inventory_Id` int(11) NOT NULL,
  `Inventory_Name` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Inventory_Type_Id` int(11) DEFAULT NULL,
  `Inventory_Number` int(11) DEFAULT NULL,
  `Inventory_Rents_Count` int(11) DEFAULT NULL,
  `Inventory_Total` int(11) DEFAULT NULL,
  `Status` varchar(45) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT 'Свободен',
  `Filial_Id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Inventory`
--

INSERT INTO `Inventory` (`Inventory_Id`, `Inventory_Name`, `Inventory_Type_Id`, `Inventory_Number`, `Inventory_Rents_Count`, `Inventory_Total`, `Status`, `Filial_Id`) VALUES
(1, 'Forward', 1, 1, 0, 0, 'В аренде', 1),
(2, 'Forward', 1, 2, 0, 0, 'Забронирован', 1),
(3, 'Stels', 1, 3, 0, 0, 'Свободен', 1),
(4, 'Stels', 1, 4, 0, 0, 'Свободен', 1),
(5, 'Gt', 1, 5, 0, 0, 'Свободен', 1),
(6, 'Forward черный', 1, 6, 0, 0, 'Свободен', 1),
(7, 'Forward черный', 1, 7, 0, 0, 'Свободен', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `Inventory_Price`
--

CREATE TABLE `Inventory_Price` (
  `Inventory_Price_Id` int(11) NOT NULL,
  `Price_Id` int(11) DEFAULT NULL,
  `Time_Id` int(11) DEFAULT NULL,
  `Inventory_Id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Inventory_Price`
--

INSERT INTO `Inventory_Price` (`Inventory_Price_Id`, `Price_Id`, `Time_Id`, `Inventory_Id`) VALUES
(1, 1, 1, 1),
(2, 2, 2, 1),
(3, 3, 3, 1),
(4, 4, 4, 1),
(5, 5, 5, 1),
(6, 1, 1, 2),
(7, 2, 2, 2),
(8, 3, 3, 2),
(9, 4, 4, 2),
(10, 5, 5, 2),
(11, 1, 1, 3),
(12, 2, 2, 3),
(13, 3, 3, 3),
(14, 4, 4, 3),
(15, 5, 5, 3),
(16, 1, 1, 4),
(17, 2, 2, 4),
(18, 3, 3, 4),
(19, 4, 4, 4),
(20, 5, 5, 4),
(21, 1, 1, 5),
(22, 2, 2, 5),
(23, 3, 3, 5),
(24, 4, 4, 5),
(25, 5, 5, 5),
(26, 1, 1, 6),
(27, 2, 2, 6),
(28, 3, 3, 6),
(29, 4, 4, 6),
(30, 5, 5, 6),
(31, 1, 1, 7),
(32, 2, 2, 7),
(33, 3, 3, 7),
(34, 4, 4, 7),
(35, 5, 5, 7);

-- --------------------------------------------------------

--
-- Структура таблицы `Inventory_Type`
--

CREATE TABLE `Inventory_Type` (
  `Inventory_Type_Id` int(11) NOT NULL,
  `Inventory_Type_Name` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Inventory_Type`
--

INSERT INTO `Inventory_Type` (`Inventory_Type_Id`, `Inventory_Type_Name`) VALUES
(1, 'Горный');

-- --------------------------------------------------------

--
-- Структура таблицы `Price`
--

CREATE TABLE `Price` (
  `Price_Id` int(11) NOT NULL,
  `Amount` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Price`
--

INSERT INTO `Price` (`Price_Id`, `Amount`) VALUES
(1, '190.00'),
(2, '300.00'),
(3, '6.00'),
(4, '800.00'),
(5, '1000.00');

-- --------------------------------------------------------

--
-- Структура таблицы `Rent`
--

CREATE TABLE `Rent` (
  `Rent_Id` int(11) NOT NULL,
  `Filial_Id` int(11) DEFAULT NULL,
  `Client_Id` int(11) DEFAULT NULL,
  `Time_Start` datetime DEFAULT NULL,
  `Time_End` datetime DEFAULT NULL,
  `Total` int(11) DEFAULT NULL,
  `Status` varchar(63) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `User_Id` int(11) DEFAULT NULL,
  `Deposit_Id` int(11) DEFAULT NULL,
  `Created_At` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Rent`
--

INSERT INTO `Rent` (`Rent_Id`, `Filial_Id`, `Client_Id`, `Time_Start`, `Time_End`, `Total`, `Status`, `User_Id`, `Deposit_Id`, `Created_At`) VALUES
(26, 1, 1, '2025-05-06 22:08:29', '2025-05-06 23:08:29', 360, 'В процессе', 1, 1, '2025-05-06 21:09:11'),
(27, 1, 1, '2025-05-06 22:21:26', '2025-05-06 23:21:26', 300, 'В процессе', 1, 1, '2025-05-06 21:21:36'),
(28, 1, 1, '2025-05-06 22:57:35', '2025-05-06 23:57:35', 300, 'В процессе', 1, 1, '2025-05-06 21:57:49');

-- --------------------------------------------------------

--
-- Структура таблицы `Rent_has_Inventory`
--

CREATE TABLE `Rent_has_Inventory` (
  `Rent_Rent_Id` int(11) NOT NULL,
  `Inventory_Inventory_Id` int(11) NOT NULL,
  `Selected_Price_Id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Rent_has_Inventory`
--

INSERT INTO `Rent_has_Inventory` (`Rent_Rent_Id`, `Inventory_Inventory_Id`, `Selected_Price_Id`) VALUES
(26, 4, 18),
(27, 4, 17),
(28, 7, 32);

-- --------------------------------------------------------

--
-- Структура таблицы `Time`
--

CREATE TABLE `Time` (
  `Time_Id` int(11) NOT NULL,
  `Time_Label` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Time`
--

INSERT INTO `Time` (`Time_Id`, `Time_Label`) VALUES
(1, 'Горный 30 минут'),
(2, 'Горный 1 час'),
(3, 'Горный свыше часа'),
(4, 'Горный день/ночь'),
(5, 'Горный сутки');

-- --------------------------------------------------------

--
-- Структура таблицы `User`
--

CREATE TABLE `User` (
  `User_Id` int(11) NOT NULL,
  `User_Surname` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `User_Name` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `User_Patronymic` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `User_Telephone` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `User_Address` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `User_Role` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `User_Login` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `User_Password` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `User`
--

INSERT INTO `User` (`User_Id`, `User_Surname`, `User_Name`, `User_Patronymic`, `User_Telephone`, `User_Address`, `User_Role`, `User_Login`, `User_Password`) VALUES
(1, 'Admin', 'Admin', 'Admin', '89124665480', 'г. Ижевск', 'Администратор', '1', '1'),
(2, 'Валиуллин', 'Владислав', 'Анатольевич', '89124665480', 'г. Ижевск', 'Менеджер', '2', '2');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Client`
--
ALTER TABLE `Client`
  ADD PRIMARY KEY (`Client_Id`);

--
-- Индексы таблицы `Deposit`
--
ALTER TABLE `Deposit`
  ADD PRIMARY KEY (`Deposit_Id`);

--
-- Индексы таблицы `Filial`
--
ALTER TABLE `Filial`
  ADD PRIMARY KEY (`Filial_Id`);

--
-- Индексы таблицы `Inventory`
--
ALTER TABLE `Inventory`
  ADD PRIMARY KEY (`Inventory_Id`),
  ADD KEY `Inventory_Type_Id` (`Inventory_Type_Id`),
  ADD KEY `fk_inventory_filial` (`Filial_Id`);

--
-- Индексы таблицы `Inventory_Price`
--
ALTER TABLE `Inventory_Price`
  ADD PRIMARY KEY (`Inventory_Price_Id`),
  ADD KEY `Price_Id` (`Price_Id`),
  ADD KEY `Time_Id` (`Time_Id`),
  ADD KEY `fk_Inventory_Price_Inventory1_idx` (`Inventory_Id`);

--
-- Индексы таблицы `Inventory_Type`
--
ALTER TABLE `Inventory_Type`
  ADD PRIMARY KEY (`Inventory_Type_Id`);

--
-- Индексы таблицы `Price`
--
ALTER TABLE `Price`
  ADD PRIMARY KEY (`Price_Id`);

--
-- Индексы таблицы `Rent`
--
ALTER TABLE `Rent`
  ADD PRIMARY KEY (`Rent_Id`),
  ADD KEY `Filial_Id` (`Filial_Id`),
  ADD KEY `Client_Id` (`Client_Id`),
  ADD KEY `User_Id` (`User_Id`),
  ADD KEY `Deposit_Id` (`Deposit_Id`);

--
-- Индексы таблицы `Rent_has_Inventory`
--
ALTER TABLE `Rent_has_Inventory`
  ADD PRIMARY KEY (`Rent_Rent_Id`,`Inventory_Inventory_Id`),
  ADD KEY `fk_Rent_has_Inventory_Inventory1_idx` (`Inventory_Inventory_Id`),
  ADD KEY `fk_Rent_has_Inventory_Rent1_idx` (`Rent_Rent_Id`);

--
-- Индексы таблицы `Time`
--
ALTER TABLE `Time`
  ADD PRIMARY KEY (`Time_Id`);

--
-- Индексы таблицы `User`
--
ALTER TABLE `User`
  ADD PRIMARY KEY (`User_Id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Client`
--
ALTER TABLE `Client`
  MODIFY `Client_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=47;

--
-- AUTO_INCREMENT для таблицы `Deposit`
--
ALTER TABLE `Deposit`
  MODIFY `Deposit_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `Filial`
--
ALTER TABLE `Filial`
  MODIFY `Filial_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT для таблицы `Inventory`
--
ALTER TABLE `Inventory`
  MODIFY `Inventory_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT для таблицы `Inventory_Price`
--
ALTER TABLE `Inventory_Price`
  MODIFY `Inventory_Price_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT для таблицы `Inventory_Type`
--
ALTER TABLE `Inventory_Type`
  MODIFY `Inventory_Type_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT для таблицы `Price`
--
ALTER TABLE `Price`
  MODIFY `Price_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `Rent`
--
ALTER TABLE `Rent`
  MODIFY `Rent_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT для таблицы `Time`
--
ALTER TABLE `Time`
  MODIFY `Time_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `User`
--
ALTER TABLE `User`
  MODIFY `User_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `Inventory`
--
ALTER TABLE `Inventory`
  ADD CONSTRAINT `fk_inventory_filial` FOREIGN KEY (`Filial_Id`) REFERENCES `Filial` (`Filial_Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `inventory_ibfk_1` FOREIGN KEY (`Inventory_Type_Id`) REFERENCES `Inventory_Type` (`Inventory_Type_Id`);

--
-- Ограничения внешнего ключа таблицы `Inventory_Price`
--
ALTER TABLE `Inventory_Price`
  ADD CONSTRAINT `fk_Inventory_Price_Inventory1` FOREIGN KEY (`Inventory_Id`) REFERENCES `Inventory` (`Inventory_Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `inventory_price_ibfk_2` FOREIGN KEY (`Price_Id`) REFERENCES `Price` (`Price_Id`),
  ADD CONSTRAINT `inventory_price_ibfk_3` FOREIGN KEY (`Time_Id`) REFERENCES `Time` (`Time_Id`);

--
-- Ограничения внешнего ключа таблицы `Rent`
--
ALTER TABLE `Rent`
  ADD CONSTRAINT `rent_ibfk_1` FOREIGN KEY (`Filial_Id`) REFERENCES `Filial` (`Filial_Id`),
  ADD CONSTRAINT `rent_ibfk_2` FOREIGN KEY (`Client_Id`) REFERENCES `Client` (`Client_Id`),
  ADD CONSTRAINT `rent_ibfk_4` FOREIGN KEY (`User_Id`) REFERENCES `User` (`User_Id`),
  ADD CONSTRAINT `rent_ibfk_5` FOREIGN KEY (`Deposit_Id`) REFERENCES `Deposit` (`Deposit_Id`);

--
-- Ограничения внешнего ключа таблицы `Rent_has_Inventory`
--
ALTER TABLE `Rent_has_Inventory`
  ADD CONSTRAINT `fk_Rent_has_Inventory_Inventory1` FOREIGN KEY (`Inventory_Inventory_Id`) REFERENCES `Inventory` (`Inventory_Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Rent_has_Inventory_Rent1` FOREIGN KEY (`Rent_Rent_Id`) REFERENCES `Rent` (`Rent_Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
