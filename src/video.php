<?php

include __DIR__ . "/../.etc/bootstrap.php";

class App {

    function __construct() {
        
    }

    /**
     * Update video file in fragments
     * 
     * @method POST
    */
    public function upload() {
        include APP_PATH . "/frameworks/plugins/php-webuploader/src/Upload.php";

        $upload = APP_PATH . "/data/upload/video/";
        $upload_temp = sys_get_temp_dir() . "/yiliya/upload_temp/";

        //调用
        $demo = new Upload();
        $demo->uploadVideo($upload, $upload_temp);
    }

    /**
     * Get recent uploaded video list
     * 
     * @access *
     * @uses api
    */
    public function recent($n = 6) {
        $video = new Table("video");
        $list = $video->order_by("id", true)
            ->limit($n)
            ->select(["id as video_id","name","play_time as top","add_time","description"])
            ;

        controller::success($list);
    }

    /**
     * Save the video metadata into database
     * 
     * @method POST
    */
    public function save($file, $name, $size, $type) {
        include APP_PATH . "/scripts/video/video_metadata.php";

        $filepath = VIDEO_UPLOAD . "/" . $file;
        $data = video_data::metadata($filepath);
        $video = new Table("video");
        $video_id = $video->add([
            "name" => $name,
            "size" => $size,
            "add_time" => Utils::Now(),
            "mime" => $type,
            "user_id" => 1,
            "play_time" => 1,
            "description" => "",
            "filepath" => $file,
            "duration" => $data["duration"],
            "frame_number" => $data["frame_num"],
            "frame_rate" => $data["frame_rate"],
            "width" => $data["width"],
            "height" => $data["height"],
            "vcodec" => $data["vcodec"],
            "pixel_format" => $data["pixel_format"],
            "bit_rate" => $data["bit_rate"],
            "video_bitrate" => $data["video_bitrate"]
        ]);

        controller::success($video_id);
    }

    /**
     * get top views video list
     * 
     * @access *
     * @method GET
     * @uses api
    */
    public function top_views($type = "day", $n = 5) {
        include APP_PATH . "/scripts/video/play_time.php";

        if ($type == "day") {
            controller::success(video_play::top_day($n));
        } else if($type == "week") {
            controller::success(video_play::top_week($n));
        } else if ($type == "month") {
            controller::success(video_play::top_month($n));
        } else if ($type == "year") {
            controller::success(video_play::top_year($n));
        } else {
            controller::error("invalid time range type!");
        }
    }

    /**
     * get top play animate shows
     * 
     * @access *
     * @method GET
     * @uses api
    */
    public function popular_shows() {
        include APP_PATH . "/scripts/video/anime_play.php";

        controller::success(anime_play::popular_shows());
    }

    /**
     * video stream
     * 
     * @access *
    */
    public function stream($id) {
        include APP_PATH . "/frameworks/plugins/SeekableVideo.php";

        $video = new Table("video");
        $src = $video->where(["id" => $id])->find();

        if (Utils::isDbNull($src)) {
            RFC7231Error::err404(); 
        } else {
            include APP_PATH . "/scripts/video/play_time.php";

            $filepath = VIDEO_UPLOAD . "/" . $src["filepath"];
            $video->where(["id" => $id])->save([
                "play_time" => "~`play_time`+1"
            ]);

            video_play::count($id);

            /**
             * Common use of a video intermediary: make sure user is allowed to access this video.
             * <Code necessary checks here>
            */
            $video = new SeekableVideo($filepath, 'video/mp4', 'stream.mp4');
            $video->begin_stream();
        }        
    }

    /**
     * get video metadata
     * 
     * demo test only
     * 
     * @access *
    */
    public function metadata($id) {
        include APP_PATH . "/scripts/video/video_metadata.php";

        $video = new Table("video");
        $src = $video->where(["id" => $id])->find();

        if (Utils::isDbNull($src)) {
            RFC7231Error::err404(); 
        } else {
            $filepath = VIDEO_UPLOAD . "/" . $src["filepath"];
            $video    = video_data::metadata($filepath);
            $video["filepath"] = $src["filepath"];

            controller::success($video);
        }    
    }
}