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


-- Exportování struktury databáze pro
CREATE DATABASE IF NOT EXISTS "TSTag3000";
;

-- Exportování struktury pro tabulka TSTag3000.album
CREATE TABLE IF NOT EXISTS "album"(
  "ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "name" VARCHAR(45)
, "password" VARCHAR(16) NULL DEFAULT NULL);

-- Exportování dat pro tabulku TSTag3000.album: -1 rows
/*!40000 ALTER TABLE "album" DISABLE KEYS */;
INSERT INTO "album" ("ID", "name", "password") VALUES
	(1, 'Obrazky', NULL),
	(2, 'Art', NULL);
/*!40000 ALTER TABLE "album" ENABLE KEYS */;

-- Exportování struktury pro tabulka TSTag3000.category
CREATE TABLE IF NOT EXISTS "category"(
  "ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "name" VARCHAR(45)
);

-- Exportování dat pro tabulku TSTag3000.category: -1 rows
/*!40000 ALTER TABLE "category" DISABLE KEYS */;
INSERT INTO "category" ("ID", "name") VALUES
	(1, 'Fotografie'),
	(2, 'Video'),
	(3, 'Meme'),
	(4, 'Art');
/*!40000 ALTER TABLE "category" ENABLE KEYS */;

-- Exportování struktury pro tabulka TSTag3000.FileMetadata
CREATE TABLE IF NOT EXISTS "FileMetadata"(
  "ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "dateIndexed" DATETIME,
  "path" VARCHAR(260),
  "size" INTEGER,
  "creationDate" DATETIME,
  "rating" INTEGER,
  "album_ID" INTEGER NOT NULL,
  "category_ID" INTEGER NOT NULL, "thumbnail" BLOB NULL,
  CONSTRAINT "ID_UNIQUE"
    UNIQUE("ID"),
  CONSTRAINT "fk_FileMetadata_album"
    FOREIGN KEY("album_ID")
    REFERENCES "album"("ID"),
  CONSTRAINT "fk_FileMetadata_category1"
    FOREIGN KEY("category_ID")
    REFERENCES "category"("ID")
);

-- Exportování dat pro tabulku TSTag3000.FileMetadata: -1 rows
/*!40000 ALTER TABLE "FileMetadata" DISABLE KEYS */;
INSERT INTO "FileMetadata" ("ID", "dateIndexed", "path", "size", "creationDate", "rating", "album_ID", "category_ID", "thumbnail") VALUES
	(1, '2024-10-09 01:22:03.7843437', 'C:\Users\user\Pictures\shadowovy okurky.jpeg', 655513, '2024-08-04 00:06:34', NULL, 1, 3, _binary 0x3f3f3f3f),
	(2, '2024-10-09 21:14:29.2633429', 'C:\Users\user\Pictures\___human_sonic_the_hedgehog____by_asteriskz-d4mtev6.png', 449809, '2024-03-10 22:26:56', NULL, 1, 3, _binary 0x3f3f3f3f),
	(3, '2024-10-09 21:15:46.1377909', 'C:\Users\user\Pictures\shadow_the_hedgehog_____i_use_arch__btw___by_susthehehgehog_dfqsqfn.jpg', 1661512, '2024-01-20 21:28:02', NULL, 1, 3, _binary 0x3f3f3f3f);
/*!40000 ALTER TABLE "FileMetadata" ENABLE KEYS */;

-- Exportování struktury pro tabulka TSTag3000.FileMetadata_has_tag
CREATE TABLE IF NOT EXISTS "FileMetadata_has_tag"(
  "FileMetadata_ID" INTEGER NOT NULL,
  "tag_ID" INTEGER NOT NULL,
  PRIMARY KEY("FileMetadata_ID","tag_ID"),
  CONSTRAINT "fk_FileMetadata_has_tag_FileMetadata1"
    FOREIGN KEY("FileMetadata_ID")
    REFERENCES "FileMetadata"("ID"),
  CONSTRAINT "fk_FileMetadata_has_tag_tag1"
    FOREIGN KEY("tag_ID")
    REFERENCES "tag"("ID")
);

-- Exportování dat pro tabulku TSTag3000.FileMetadata_has_tag: -1 rows
/*!40000 ALTER TABLE "FileMetadata_has_tag" DISABLE KEYS */;
INSERT INTO "FileMetadata_has_tag" ("FileMetadata_ID", "tag_ID") VALUES
	(1, 3),
	(2, 14),
	(3, 3);
/*!40000 ALTER TABLE "FileMetadata_has_tag" ENABLE KEYS */;

-- Exportování struktury pro tabulka TSTag3000.tag
CREATE TABLE IF NOT EXISTS "tag"(
  "ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "type" VARCHAR(45)
, "name" VARCHAR(45) NULL DEFAULT NULL);

-- Exportování dat pro tabulku TSTag3000.tag: -1 rows
/*!40000 ALTER TABLE "tag" DISABLE KEYS */;
INSERT INTO "tag" ("ID", "type", "name") VALUES
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
