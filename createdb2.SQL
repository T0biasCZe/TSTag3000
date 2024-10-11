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

-- Exportování struktury pro tabulka TSTag3000.album
DROP TABLE IF EXISTS "album";
CREATE TABLE IF NOT EXISTS "album"(
  "ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "name" VARCHAR(45)
, "password" VARCHAR(16) NULL DEFAULT NULL);

-- Export dat nebyl vybrán.

-- Exportování struktury pro tabulka TSTag3000.category
DROP TABLE IF EXISTS "category";
CREATE TABLE IF NOT EXISTS "category"(
  "ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "name" VARCHAR(45)
);

-- Export dat nebyl vybrán.

-- Exportování struktury pro tabulka TSTag3000.FileMetadata
DROP TABLE IF EXISTS "FileMetadata";
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

-- Export dat nebyl vybrán.

-- Exportování struktury pro tabulka TSTag3000.FileMetadata_has_tag
DROP TABLE IF EXISTS "FileMetadata_has_tag";
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

-- Export dat nebyl vybrán.

-- Exportování struktury pro tabulka TSTag3000.tag
DROP TABLE IF EXISTS "tag";
CREATE TABLE IF NOT EXISTS "tag"(
  "ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "type" VARCHAR(45)
, "name" VARCHAR(45) NULL DEFAULT NULL);

-- Export dat nebyl vybrán.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
