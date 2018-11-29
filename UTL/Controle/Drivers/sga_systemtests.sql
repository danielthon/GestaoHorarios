-- MySQL dump 10.13  Distrib 5.6.24, for Win32 (x86)
--
-- Host: localhost    Database: sga_systemtests
-- ------------------------------------------------------
-- Server version	5.6.29

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `administrador`
--

DROP DATABASE IF EXISTS SGA_SYSTEMTESTS;
CREATE DATABASE SGA_SYSTEMTESTS;
USE SGA_SYSTEMTESTS;

DROP TABLE IF EXISTS `administrador`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `administrador` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Id_Usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Usuario` (`Id_Usuario`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `administrador`
--

LOCK TABLES `administrador` WRITE;
/*!40000 ALTER TABLE `administrador` DISABLE KEYS */;
INSERT INTO `administrador` VALUES (1,1),(2,2),(3,3);
/*!40000 ALTER TABLE `administrador` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `alocacao`
--

DROP TABLE IF EXISTS `alocacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `alocacao` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Id_Disciplina` int(11) DEFAULT NULL,
  `Id_Horario` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Disciplina` (`Id_Disciplina`),
  KEY `Id_Horario` (`Id_Horario`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alocacao`
--

LOCK TABLES `alocacao` WRITE;
/*!40000 ALTER TABLE `alocacao` DISABLE KEYS */;
INSERT INTO `alocacao` VALUES (1,7,1),(2,12,2),(3,8,3),(4,9,4);
/*!40000 ALTER TABLE `alocacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aptidao`
--

DROP TABLE IF EXISTS `aptidao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aptidao` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Id_Disciplina` int(11) DEFAULT NULL,
  `Id_Professor` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Disciplina` (`Id_Disciplina`),
  KEY `Id_Professor` (`Id_Professor`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aptidao`
--

LOCK TABLES `aptidao` WRITE;
/*!40000 ALTER TABLE `aptidao` DISABLE KEYS */;
/*!40000 ALTER TABLE `aptidao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `disciplina`
--

DROP TABLE IF EXISTS `disciplina`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `disciplina` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Periodo` int(11) DEFAULT NULL,
  `Nome` varchar(255) DEFAULT NULL,
  `Id_Professor` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Professor` (`Id_Professor`)
) ENGINE=MyISAM AUTO_INCREMENT=47 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `disciplina`
--

LOCK TABLES `disciplina` WRITE;
/*!40000 ALTER TABLE `disciplina` DISABLE KEYS */;
INSERT INTO `disciplina` VALUES (1,1,'ATP',2),(2,1,'FMC',2),(3,1,'Introducao_Admin',3),(4,1,'Filosofia_1',1),(5,1,'Introducao_Computacao',5),(6,1,'Lab_ATP',6),(7,2,'Arquitetura',7),(8,2,'POO',8),(9,2,'Lab_POO',9),(10,2,'FSI',10),(11,2,'Filosofia_2',1),(12,2,'Calculo_1',11),(13,3,'Calculo_2',11),(14,3,'Cultura_1',12),(15,3,'SO',7),(16,3,'AED',8),(17,3,'Lab_AED',9),(18,3,'Modelagem',13),(19,4,'Eng_Requisitos',5),(20,4,'Grafos',14),(21,4,'Redes',6),(22,4,'BD',9),(23,4,'Introducao_Pesquisa',5),(24,4,'Politicas_Negociacao',15),(25,5,'Projeto_Redes',14),(26,5,'Estatistica',16),(27,5,'IHC',17),(28,5,'TAP',18),(29,5,'Fundamentos_Teste',9),(30,5,'Computador_Sociedade',19),(31,6,'Fundamentos_Marketing',3),(32,6,'Gerencia',5),(33,6,'PSI',20),(34,6,'Estagio',13),(35,6,'Tecnologias_Descoberta_Conhecimento',17),(36,6,'TEC_Web',21),(37,7,'Desenv_Aplicacoes_Distribuidas',22),(38,7,'Processo_Qualidade_Software',22),(39,7,'Tec_BD',23),(40,7,'Otimizacao',2),(41,7,'Empreendedorismo',3),(42,7,'Planejamento_Capacidade',24),(43,8,'TIC',13),(44,8,'Seguranca',6),(45,8,'Sistemas_Integrados',24),(46,8,'Gestao_TI',5);
/*!40000 ALTER TABLE `disciplina` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `horario`
--

DROP TABLE IF EXISTS `horario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `horario` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `HoraInicio` time DEFAULT NULL,
  `HoraTermino` time DEFAULT NULL,
  `DiaSemana` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `horario`
--

LOCK TABLES `horario` WRITE;
/*!40000 ALTER TABLE `horario` DISABLE KEYS */;
INSERT INTO `horario` VALUES (1,'19:00:00','20:40:00',2),(2,'20:50:00','22:30:00',2),(3,'19:00:00','20:40:00',3),(4,'20:50:00','22:30:00',3),(5,'19:00:00','20:40:00',4),(6,'20:50:00','22:30:00',4),(7,'19:00:00','20:40:00',5),(8,'20:50:00','22:30:00',5),(9,'19:00:00','20:40:00',6),(10,'20:50:00','22:30:00',6);
/*!40000 ALTER TABLE `horario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `log`
--

DROP TABLE IF EXISTS `log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `log` (
  `Id` int(11) NOT NULL,
  `Hora` datetime DEFAULT NULL,
  `Operacao` varchar(255) DEFAULT NULL,
  `Id_Usuario` int(11) DEFAULT NULL,
  `Id_Alocacao` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Usuario` (`Id_Usuario`),
  KEY `Id_Alocacao` (`Id_Alocacao`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log`
--

LOCK TABLES `log` WRITE;
/*!40000 ALTER TABLE `log` DISABLE KEYS */;
/*!40000 ALTER TABLE `log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professor`
--

DROP TABLE IF EXISTS `professor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professor` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Id_Usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Usuario` (`Id_Usuario`)
) ENGINE=MyISAM AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professor`
--

LOCK TABLES `professor` WRITE;
/*!40000 ALTER TABLE `professor` DISABLE KEYS */;
INSERT INTO `professor` VALUES (1,4),(2,2),(3,3),(4,4),(5,5),(6,6),(7,7),(8,8),(9,9),(10,10),(11,11),(12,12),(13,13),(14,14),(15,15),(16,16),(17,17),(18,18),(19,19),(20,20),(21,21),(22,22),(23,23),(24,24);
/*!40000 ALTER TABLE `professor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(255) DEFAULT NULL,
  `Login` varchar(20) DEFAULT NULL,
  `Senha` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Robot','automacao','automacao'),(2,'Soraia','soraia',NULL),(3,'Helvio','helvio',NULL),(4,'Marina','marina',NULL),(5,'Sandra','sandra',NULL),(6,'Ezequiel','ezequiel',NULL),(7,'Paulo','paulo',NULL),(8,'Caram','caram',NULL),(9,'Claudiney','claudiney',NULL),(10,'Marconi','marconi',NULL),(11,'Francisco','francisco',NULL),(12,'Ariela','ariela',NULL),(13,'Adriane','adriane',NULL),(14,'Michelle','michelle',NULL),(15,'Adriano','adriano',NULL),(16,'Marilene','marilene',NULL),(17,'Cristiane','cristiane',NULL),(18,'Kleber','kleber',NULL),(19,'Juliana','juliana',NULL),(20,'Tadeu','tadeu',NULL),(21,'Marcos','marcos',NULL),(22,'Pedro','pedro',NULL),(23,'Wladmir','wladmir',NULL),(24,'Dorirley','dorirley',NULL);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-11-29  1:28:24
