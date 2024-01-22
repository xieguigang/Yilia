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
        //调用
        $demo = new Upload();
        $demo->uploadVideo();
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