<?php

class anime_play {

    public static function popular_shows() {
        $sql = "SELECT 
                    id, top, name, description, post_cover
                FROM
                    (SELECT 
                        animate_id, SUM(play_time) AS top
                    FROM
                        yilia.animate_video
                    LEFT JOIN video ON video.id = video_id
                    GROUP BY animate_id
                    ORDER BY top DESC) trending
                        LEFT JOIN
                    animate ON animate_id = animate.id;
        ";
        $count = new Table("animate_video");
        $count = $count->exec($sql);

        return [
            "size" => count($count),
            "data" => $count
        ];
    }
}