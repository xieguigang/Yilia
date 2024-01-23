# Schema update report

Update report for schema of ``yilia_current.sql`` updates to new model ``yilia.sql``
### Updates for ``animate``

Field data attribute of current table ``episodes`` has been updated:

```sql
ALTER TABLE `yilia`.`animate` CHANGE COLUMN `episodes` `episodes` int (11) UNSIGNED NOT NULL DEFAULT 1 COMMENT '' ;
```

### Updates for ``animate_rating``

### Updates for ``animate_tags``

### Updates for ``animate_video``

Field data attribute of current table ``ep_num`` has been updated:

```sql
ALTER TABLE `yilia`.`animate_video` CHANGE COLUMN `ep_num` `ep_num` int (11) UNSIGNED NOT NULL DEFAULT 1 COMMENT '' ;
```

### Updates for ``tags``

### Updates for ``user``

### Updates for ``user_log``

### Updates for ``video``

Field data attribute of current table ``size`` has been updated:

```sql
ALTER TABLE `yilia`.`video` CHANGE COLUMN `size` `size` double NOT NULL DEFAULT 0 COMMENT '' ;
```

Add a new data field ``post_cover``:

```sql
ALTER TABLE `yilia`.`video` ADD COLUMN `post_cover` text COMMENT 'the file path to the video cover image file' ;
```

### Updates for ``video_comments``

### Updates for ``video_play``

Current database schema didn't has this table, a new table will be created:

```sql
CREATE TABLE IF NOT EXISTS `yilia`.`video_play` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `video_id` INT UNSIGNED NOT NULL,
  `play_time` INT UNSIGNED NOT NULL,
  `day` DATETIME NOT NULL DEFAULT now(),
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  CONSTRAINT `video_data`
    FOREIGN KEY (`video_id`)
    REFERENCES `yilia`.`video` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

```

### Updates for ``video_rating``

Field data attribute of current table ``score`` has been updated:

```sql
ALTER TABLE `yilia`.`video_rating` CHANGE COLUMN `score` `score` int (11) UNSIGNED NOT NULL DEFAULT 1 COMMENT '' ;
```

### Updates for ``video_tags``

