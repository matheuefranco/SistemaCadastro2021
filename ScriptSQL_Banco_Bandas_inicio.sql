
DROP TABLE IF EXISTS `bandas`;

CREATE TABLE `bandas` (
  `idbandas` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `genero` varchar(45) NOT NULL,
  `integrantes` int(11) DEFAULT NULL,
  `ranking` int(11) DEFAULT NULL,
  PRIMARY KEY (`idbandas`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;


LOCK TABLES `bandas` WRITE;
/*!40000 ALTER TABLE `bandas` DISABLE KEYS */;
INSERT INTO `bandas` VALUES (1,'ACDC','Rock',5,1),(2,'Molejo','Pagode',100,5),(3,'Titans','Rock',5,1),(4,'Skank','Rock',4,2),(5,'Nirvana','Rock',3,1),(6,'Melin','Pop',3,2);



