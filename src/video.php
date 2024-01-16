<?php

include __DIR__ . "/../.etc/bootstrap.php";

class App {

    function __construct() {
        include APP_PATH . "/frameworks/plugins/SeekableVideo.php";
    }

    /**
     * video stream
     * 
     * @access *
    */
    public function stream($id) {
        $filepath = VIDEO_UPLOAD . "/Evangelion.2.22.You.Can.(Not).Advance.2010.mp4";
        /**
         * Common use of a video intermediary: make sure user is allowed to access this video.
         * <Code necessary checks here>
        */
        $video = new SeekableVideo($filepath, 'video/mp4', 'stream.mp4');
        $video->begin_stream();
    }
}