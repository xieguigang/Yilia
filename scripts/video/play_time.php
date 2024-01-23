<?php

class video_play {

    public static function count($video_id) {
        $count = new Table("video_play");
        $today = date('Y-m-d', time());
        $tomorrow = date("Y-m-d", strtotime('tomorrow'));
        $play_record = $count
            ->where(["video_id" => $video_id, "day" => between($today, $tomorrow)])
            ->find();

        if (Utils::isDbNull($play_record)) {
            # just add new
            $count->add([
                "video_id" => $video_id,
                "play_time" => 1,
                "day" => $today
            ]);
        } else {
            # make play_time counter update
            $count->where(["id" => $play_record["id"]])->save([
                "play_time" => "~ `play_time` + 1"
            ]);
        }
    }

    public static function top_views($from, $to, $n = 5) {
        $count = new Table("video_play");        
        $sql = "SELECT 
                    video_list.*, name, post_cover
                FROM
                    (SELECT 
                        video_id, SUM(play_time) AS top
                    FROM
                        yilia.video_play
                    WHERE
                        day BETWEEN '$from' AND '$to'
                    GROUP BY video_id
                    ORDER BY top DESC
                    LIMIT $n) video_list
                        LEFT JOIN
                    video ON video.id = video_list.video_id;"
        ;
        $q = $count->exec($sql);

        return [
            "size" => count($q),
            "data" => $q,
            "start" => $from,
            "ends" => $to 
        ];
    }

    public static function top_day($n = 5) {
        $today = date('Y-m-d', time());
        $yesterday = date("Y-m-d", strtotime('yesterday'));

        return self::top_views($yesterday, $today, $n);
    }

    public static function top_week($n = 5) {
        $today = date('Y-m-d', time());
        $week_ago = date('Y-m-d', strtotime('-1 week'));

        return self::top_views($week_ago, $today, $n);
    }

    public static function top_month($n = 5) {
        $today = date('Y-m-d', time());
        $month_ago = date("Y-m-d", strtotime("-1 month"));

        return self::top_views($month_ago, $today, $n);
    }

    public static function top_year($n = 5) {
        $today = date('Y-m-d', time());
        $year_ago = date('Y-m-d', strtotime('-1 year'));

        return self::top_views($year_ago, $today, $n);
    }
}