-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: winter14_11_2026
-- ------------------------------------------------------
-- Server version	26.10.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
SET @MYSQLDUMP_TEMP_LOG_BIN = @@SESSION.SQL_LOG_BIN;
SET @@SESSION.SQL_LOG_BIN= 0;

--
-- GTID state at the beginning of the backup 
--

SET @@GLOBAL.GTID_PURGED=/*!80000 '+'*/ '7b2dfca4-d791-11f1-a9de-08bfb89f53ff:1-325';

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clients` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `birth_date` date NOT NULL,
  `season_ticket` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `clients_season_tickets_FK` (`season_ticket`),
  KEY `clients_users_FK` (`user_id`),
  CONSTRAINT `clients_season_tickets_FK` FOREIGN KEY (`season_ticket`) REFERENCES `season_tickets` (`id`),
  CONSTRAINT `clients_users_FK` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (1,2,'1999-02-22',3),(2,3,'1980-12-02',1),(3,4,'2007-07-19',2);
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `role` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Администратор'),(2,'Клиент'),(3,'Тренер');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `season_tickets`
--

DROP TABLE IF EXISTS `season_tickets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `season_tickets` (
  `id` int NOT NULL AUTO_INCREMENT,
  `type` int NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `season_tickets_season_tickets_types_FK` (`type`),
  CONSTRAINT `season_tickets_season_tickets_types_FK` FOREIGN KEY (`type`) REFERENCES `season_tickets_types` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `season_tickets`
--

LOCK TABLES `season_tickets` WRITE;
/*!40000 ALTER TABLE `season_tickets` DISABLE KEYS */;
INSERT INTO `season_tickets` VALUES (1,3,'2020-07-26','2020-01-27'),(2,4,'2025-09-26','2025-09-27'),(3,2,'2019-09-26','2019-12-26');
/*!40000 ALTER TABLE `season_tickets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `season_tickets_types`
--

DROP TABLE IF EXISTS `season_tickets_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `season_tickets_types` (
  `id` int NOT NULL AUTO_INCREMENT,
  `type` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `price` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `season_tickets_types`
--

LOCK TABLES `season_tickets_types` WRITE;
/*!40000 ALTER TABLE `season_tickets_types` DISABLE KEYS */;
INSERT INTO `season_tickets_types` VALUES (1,'Месчный',5000),(2,'Трёхмесячный',12000),(3,'Полугодовой',20000),(4,'Годовой',35000),(5,'Двухгодовой',68000);
/*!40000 ALTER TABLE `season_tickets_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `training_lists`
--

DROP TABLE IF EXISTS `training_lists`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `training_lists` (
  `id` int NOT NULL AUTO_INCREMENT,
  `client` int NOT NULL,
  `training` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `training_lists_trainings_FK` (`training`),
  KEY `training_lists_clients_FK` (`client`),
  CONSTRAINT `training_lists_clients_FK` FOREIGN KEY (`client`) REFERENCES `clients` (`id`),
  CONSTRAINT `training_lists_trainings_FK` FOREIGN KEY (`training`) REFERENCES `trainings` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `training_lists`
--

LOCK TABLES `training_lists` WRITE;
/*!40000 ALTER TABLE `training_lists` DISABLE KEYS */;
INSERT INTO `training_lists` VALUES (1,1,1),(2,1,4),(3,1,7),(4,2,2),(5,2,5),(6,2,8),(7,3,3),(8,3,6);
/*!40000 ALTER TABLE `training_lists` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trainings`
--

DROP TABLE IF EXISTS `trainings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `trainings` (
  `id` int NOT NULL AUTO_INCREMENT,
  `date` date NOT NULL,
  `time` time NOT NULL,
  `trainer` int NOT NULL,
  `is_visited` tinyint(1) NOT NULL,
  `hall` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `trainings_users_FK` (`trainer`),
  CONSTRAINT `trainings_users_FK` FOREIGN KEY (`trainer`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trainings`
--

LOCK TABLES `trainings` WRITE;
/*!40000 ALTER TABLE `trainings` DISABLE KEYS */;
INSERT INTO `trainings` VALUES (1,'2001-10-26','20:00:00',5,1,0),(2,'2002-10-26','21:00:00',5,1,0),(3,'2025-10-26','12:00:00',5,1,0),(4,'2013-11-26','11:30:00',5,1,0),(5,'2022-11-26','08:30:00',5,0,0),(6,'2001-12-26','14:00:00',5,0,0),(7,'2005-12-26','15:00:00',5,0,0),(8,'2012-12-26','08:00:00',5,0,0);
/*!40000 ALTER TABLE `trainings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `login` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `password` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `surname` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `name` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `patronymic` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `phone` varchar(13) DEFAULT NULL,
  `role` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `users_roles_FK` (`role`),
  CONSTRAINT `users_roles_FK` FOREIGN KEY (`role`) REFERENCES `roles` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'admin','admin123','Павлов','Сергей','Викторович',NULL,1),(2,'client','client123','Петрова','Анна','Сергеевна','799594436542',2),(3,'client2','natasha123','Симонова','Наталья','Маратовна','79159197227',2),(4,'client3','Kilexognat148','Жеребов','Даниил','Артемович','79371646775',2),(5,'trainer','trainer123','Нечаев','Петр','Андреевич','79872271449',3);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'winter14_11_2026'
--
SET @@SESSION.SQL_LOG_BIN = @MYSQLDUMP_TEMP_LOG_BIN;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-11-15 17:20:43
