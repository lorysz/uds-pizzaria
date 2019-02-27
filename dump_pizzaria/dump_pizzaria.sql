CREATE DATABASE  IF NOT EXISTS `db_pizzaria` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `db_pizzaria`;
-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: db_pizzaria
-- ------------------------------------------------------
-- Server version	8.0.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `detalhe_pizza`
--

DROP TABLE IF EXISTS `detalhe_pizza`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `detalhe_pizza` (
  `iddetalhe_pizza` int(11) NOT NULL AUTO_INCREMENT,
  `tamanho` char(1) NOT NULL COMMENT 'P- pequena\nM- media\nG- grande',
  `valor` decimal(10,2) NOT NULL,
  `tempo_preparo` int(11) NOT NULL COMMENT 'valor em minutos',
  PRIMARY KEY (`iddetalhe_pizza`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalhe_pizza`
--

LOCK TABLES `detalhe_pizza` WRITE;
/*!40000 ALTER TABLE `detalhe_pizza` DISABLE KEYS */;
INSERT INTO `detalhe_pizza` VALUES (1,'P',20.00,15),(2,'M',30.00,20),(3,'G',40.00,25);
/*!40000 ALTER TABLE `detalhe_pizza` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pedido`
--

DROP TABLE IF EXISTS `pedido`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `pedido` (
  `idpedido` int(11) NOT NULL AUTO_INCREMENT,
  `idpizza` int(11) NOT NULL,
  `valor_total` decimal(10,2) NOT NULL,
  `tempo_preparo` int(11) NOT NULL,
  PRIMARY KEY (`idpedido`),
  KEY `fk_pedido_pizza_idx` (`idpizza`),
  CONSTRAINT `fk_pedido_pizza` FOREIGN KEY (`idpizza`) REFERENCES `pizza` (`idpizza`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pedido`
--

LOCK TABLES `pedido` WRITE;
/*!40000 ALTER TABLE `pedido` DISABLE KEYS */;
INSERT INTO `pedido` VALUES (1,8,40.00,30),(2,9,43.00,30),(3,10,40.00,30),(4,11,43.00,30),(5,12,33.00,20),(6,13,33.00,20),(7,14,33.00,20);
/*!40000 ALTER TABLE `pedido` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personalizacao`
--

DROP TABLE IF EXISTS `personalizacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `personalizacao` (
  `idpersonalizacao` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) NOT NULL,
  `valor_adicional` decimal(10,2) NOT NULL,
  `tempo_adicional` int(11) NOT NULL DEFAULT '0' COMMENT 'valor em minutos',
  PRIMARY KEY (`idpersonalizacao`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personalizacao`
--

LOCK TABLES `personalizacao` WRITE;
/*!40000 ALTER TABLE `personalizacao` DISABLE KEYS */;
INSERT INTO `personalizacao` VALUES (1,'Extra bacon',3.00,0),(2,'Sem cebola',0.00,0),(3,'Borda recheada',5.00,5);
/*!40000 ALTER TABLE `personalizacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pizza`
--

DROP TABLE IF EXISTS `pizza`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `pizza` (
  `idpizza` int(11) NOT NULL AUTO_INCREMENT,
  `iddetalhe_pizza` int(11) NOT NULL,
  `idsabor` int(11) NOT NULL,
  PRIMARY KEY (`idpizza`),
  KEY `fk_pizza_detalhe_pizza1_idx` (`iddetalhe_pizza`),
  KEY `fk_pizza_sabor1_idx` (`idsabor`),
  CONSTRAINT `fk_pizza_detalhe_pizza1` FOREIGN KEY (`iddetalhe_pizza`) REFERENCES `detalhe_pizza` (`iddetalhe_pizza`),
  CONSTRAINT `fk_pizza_sabor1` FOREIGN KEY (`idsabor`) REFERENCES `sabor` (`idsabor`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pizza`
--

LOCK TABLES `pizza` WRITE;
/*!40000 ALTER TABLE `pizza` DISABLE KEYS */;
INSERT INTO `pizza` VALUES (1,1,1),(2,1,1),(3,1,1),(4,1,1),(5,3,3),(6,3,3),(7,3,3),(8,3,3),(9,3,3),(10,3,3),(11,3,3),(12,2,2),(13,2,2),(14,2,2);
/*!40000 ALTER TABLE `pizza` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pizza_personalizada`
--

DROP TABLE IF EXISTS `pizza_personalizada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `pizza_personalizada` (
  `idpizza_personalizada` int(11) NOT NULL AUTO_INCREMENT,
  `idpizza` int(11) NOT NULL,
  `idpersonalizacao` int(11) NOT NULL,
  PRIMARY KEY (`idpizza_personalizada`),
  KEY `fk_pizza_personalizada_pizza1_idx` (`idpizza`),
  KEY `fk_pizza_personalizada_personalizacao1_idx` (`idpersonalizacao`),
  CONSTRAINT `fk_pizza_personalizada_personalizacao1` FOREIGN KEY (`idpersonalizacao`) REFERENCES `personalizacao` (`idpersonalizacao`),
  CONSTRAINT `fk_pizza_personalizada_pizza1` FOREIGN KEY (`idpizza`) REFERENCES `pizza` (`idpizza`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pizza_personalizada`
--

LOCK TABLES `pizza_personalizada` WRITE;
/*!40000 ALTER TABLE `pizza_personalizada` DISABLE KEYS */;
INSERT INTO `pizza_personalizada` VALUES (1,1,3),(2,9,1),(3,11,1),(4,12,1),(5,13,1),(6,14,1);
/*!40000 ALTER TABLE `pizza_personalizada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sabor`
--

DROP TABLE IF EXISTS `sabor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sabor` (
  `idsabor` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(80) NOT NULL,
  `adicional_tempo` int(11) NOT NULL DEFAULT '0' COMMENT 'valor em minutos',
  PRIMARY KEY (`idsabor`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sabor`
--

LOCK TABLES `sabor` WRITE;
/*!40000 ALTER TABLE `sabor` DISABLE KEYS */;
INSERT INTO `sabor` VALUES (1,'Calabresa',0),(2,'Marguerita',0),(3,'Portuguesa',5);
/*!40000 ALTER TABLE `sabor` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-02-27 19:04:11
