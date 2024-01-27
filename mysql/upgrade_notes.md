# Schema update report

Update report for schema of ``yilia_current.sql`` updates to new model ``yilia.sql``
### Updates for ``animate``

Field data attribute of current table ``episodes`` has been updated:

```sql
ALTER TABLE `yilia`.`animate` CHANGE COLUMN `episodes` `episodes` int (11) UNSIGNED NOT NULL DEFAULT 1 COMMENT '' ;
```

Add a new data field ``post_cover``:

```sql
ALTER TABLE `yilia`.`animate` ADD COLUMN `post_cover` varchar (1024) COMMENT '' ;
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

Add a new data field ``duration``:

```sql
ALTER TABLE `yilia`.`video` ADD COLUMN `duration` double UNSIGNED NOT NULL DEFAULT 0 COMMENT '' ;
```

Add a new data field ``frame_number``:

```sql
ALTER TABLE `yilia`.`video` ADD COLUMN `frame_number` int (11) UNSIGNED NOT NULL DEFAULT 0 COMMENT '' ;
```

Add a new data field ``frame_rate``:

```sql
ALTER TABLE `yilia`.`video` ADD COLUMN `frame_rate` double UNSIGNED NOT NULL DEFAULT 0 COMMENT '' ;
```

Add a new data field ``width``:

```sql
ALTER TABLE `yilia`.`video` ADD COLUMN `width` int (11) UNSIGNED NOT NULL DEFAULT 0 COMMENT '' ;
```

Add a new data field ``height``:

```sql
ALTER TABLE `yilia`.`video` ADD COLUMN `height` int (11) UNSIGNED NOT NULL DEFAULT 0 COMMENT '' ;
```

Add a new data field ``vcodec``:

```sql
ALTER TABLE `yilia`.`video` ADD COLUMN `vcodec` varchar (256) COMMENT '' ;
```

Add a new data field ``pixel_format``:

```sql
ALTER TABLE `yilia`.`video` ADD COLUMN `pixel_format` varchar (512) COMMENT '' ;
```

Add a new data field ``bit_rate``:

```sql
ALTER TABLE `yilia`.`video` ADD COLUMN `bit_rate` double UNSIGNED NOT NULL DEFAULT 0 COMMENT '' ;
```

Add a new data field ``video_bitrate``:

```sql
ALTER TABLE `yilia`.`video` ADD COLUMN `video_bitrate` double UNSIGNED NOT NULL DEFAULT 0 COMMENT '' ;
```

### Updates for ``video_comments``

### Updates for ``video_play``

### Updates for ``video_rating``

Field data attribute of current table ``score`` has been updated:

```sql
ALTER TABLE `yilia`.`video_rating` CHANGE COLUMN `score` `score` int (11) UNSIGNED NOT NULL DEFAULT 1 COMMENT '' ;
```

### Updates for ``video_tags``

