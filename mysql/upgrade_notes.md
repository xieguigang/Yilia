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

Add a new data field ``avatar``:

```sql
ALTER TABLE `yilia`.`user` ADD COLUMN `avatar` varchar (2048) COMMENT 'avatar image url' ;
```

### Updates for ``user_log``

### Updates for ``video``

Field data attribute of current table ``size`` has been updated:

```sql
ALTER TABLE `yilia`.`video` CHANGE COLUMN `size` `size` double NOT NULL DEFAULT 0 COMMENT '' ;
```

### Updates for ``video_comments``

### Updates for ``video_play``

### Updates for ``video_rating``

Field data attribute of current table ``score`` has been updated:

```sql
ALTER TABLE `yilia`.`video_rating` CHANGE COLUMN `score` `score` int (11) UNSIGNED NOT NULL DEFAULT 1 COMMENT '' ;
```

### Updates for ``video_tags``

