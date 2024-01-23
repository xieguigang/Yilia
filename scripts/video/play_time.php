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
}