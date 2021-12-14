

DROP TABLE IF EXISTS `bandas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bandas` (
  `idbandas` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `genero` varchar(45) NOT NULL,
  `integrantes` int DEFAULT NULL,
  `ranking` int DEFAULT NULL,
  PRIMARY KEY (`idbandas`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bandas`
--

LOCK TABLES `bandas` WRITE;
/*!40000 ALTER TABLE `bandas` DISABLE KEYS */;
INSERT INTO `bandas` VALUES (1,'ACDC','Rock',5,1),(2,'Molejo','Pagode',100,5),(3,'Titans','Rock',5,1),(4,'Skank','Rock',4,2),(5,'Nirvana','Rock',3,1),(6,'Melin','Pop',3,2),(7,'Metallica','Rock',4,1),(8,'Turma do Pagode','Pagode',10,3);
/*!40000 ALTER TABLE `bandas` ENABLE KEYS */;
UNLOCK TABLES;


CREATE DEFINER=`root`@`localhost` PROCEDURE `insere_banda`(nome varchar(50), 
     genero varchar(50), integrantes int, ranking int)
BEGIN
INSERT INTO siscadastro.bandas
(`nome`,
`genero`,
`integrantes`,
`ranking`)
VALUES
(nome,
genero,
integrantes,
ranking);
END ;;

CREATE DEFINER=`root`@`localhost` PROCEDURE `lista_bandas`()
BEGIN
    SELECT * FROM siscadastro.bandas;
END ;;

CREATE DEFINER=`root`@`localhost` PROCEDURE `deleta_banda`(idbanda integer)
BEGIN
DELETE FROM `siscadastro`.`bandas`
WHERE bandas.idbandas = idbanda;
END


CREATE DEFINER=`root`@`localhost` PROCEDURE `insere_banda`(nome varchar(50), 
     genero varchar(50), integrantes int, ranking int)
BEGIN
INSERT INTO siscadastro.bandas
(`nome`,
`genero`,
`integrantes`,
`ranking`)
VALUES
(nome,
genero,
integrantes,
ranking);
END
