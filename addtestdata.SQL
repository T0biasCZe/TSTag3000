-- --------------------------------------------------------
-- Hostitel:                     C:\Users\user\AppData\Roaming\TSTag3000\TSTag3000.db
-- Verze serveru:                3.45.3
-- OS serveru:                   
-- HeidiSQL Verze:               12.8.0.6908
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES  */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Exportování dat pro tabulku TSTag3000.album: 2 rows
/*!40000 ALTER TABLE "album" DISABLE KEYS */;
INSERT IGNORE INTO "album" ("ID", "name", "password") VALUES
	(1, 'Obrazky', NULL),
	(2, 'Art', NULL);
/*!40000 ALTER TABLE "album" ENABLE KEYS */;

-- Exportování dat pro tabulku TSTag3000.category: 4 rows
/*!40000 ALTER TABLE "category" DISABLE KEYS */;
INSERT IGNORE INTO "category" ("ID", "name") VALUES
	(1, 'Fotografie'),
	(2, 'Video'),
	(3, 'Meme'),
	(4, 'Art');
/*!40000 ALTER TABLE "category" ENABLE KEYS */;

-- Exportování dat pro tabulku TSTag3000.tag: 14 rows
/*!40000 ALTER TABLE "tag" DISABLE KEYS */;
INSERT IGNORE INTO "tag" ("ID", "type", "name") VALUES
	(1, 'artist', 'BenjojoGV'),
	(2, 'artist', 'Neo'),
	(3, 'character', 'Shadow the Hedgehog'),
	(4, 'character', 'Meggy Splatzer'),
	(5, 'general', 'hedgehog'),
	(6, 'general', 'Inkling Girl'),
	(7, 'meta', 'animated'),
	(8, 'meta', 'sound'),
	(9, 'meta', 'meme'),
	(10, 'meta', '2d'),
	(11, 'meta', '3d'),
	(12, 'copyright', 'sega'),
	(13, 'copyright', 'nintendo'),
	(14, 'character', 'Sonic the Hedgehog');
/*!40000 ALTER TABLE "tag" ENABLE KEYS */;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
