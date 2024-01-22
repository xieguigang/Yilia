<?php

include __DIR__ . "/../.etc/bootstrap.php";

class App {

    function __construct() {
        include APP_PATH . "/frameworks/plugins/SeekableVideo.php";
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
        $video_id = $video->save([
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
    */
    public function stream($id) {
        $filepath = VIDEO_UPLOAD . "/Laputa.Castle.in.the.Sky_1.mp4";
        /**
         * Common use of a video intermediary: make sure user is allowed to access this video.
         * <Code necessary checks here>
        */
        $video = new SeekableVideo($filepath, 'video/mp4', 'stream.mp4');
        $video->begin_stream();
    }
}