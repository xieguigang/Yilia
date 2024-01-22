<?php

include __DIR__ . "/../.etc/bootstrap.php";

class App {

    function __construct() {
        
    }

    /**
     * @access *
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
     * Save the video into database
     * 
     * @access *
     * @method POST
    */
    public function save($file, $name, $size, $type) {
        $video = new Table("video");
        $video_id = $video->add([
            "name" => $name,
            "size" => $size,
            "add_time" => Utils::Now(),
            "mime" => $type,
            "user_id" => 1,
            "play_time" => 1,
            "description" => "",
            "filepath" => $file
        ]);

        controller::success($video_id);
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
            $filepath = VIDEO_UPLOAD . "/" . $src["filepath"];
            /**
             * Common use of a video intermediary: make sure user is allowed to access this video.
             * <Code necessary checks here>
            */
            $video = new SeekableVideo($filepath, 'video/mp4', 'stream.mp4');
            $video->begin_stream();
        }        
    }
}