<?php

require_once APP_PATH . "/ffmpeg/FFmpegAutoloader.class.php";

# this needs the ffmpeg installation environment path 
\Phpffmpeg\FFmpegAutoloader::register();

class video_data {

    /**
     * get video metadata via ffmpeg
     * 
     * @param string $file the video file path
    */
    public static function metadata($file) {
        $movie = new \Phpffmpeg\adapter\ffmpeg_movie($file, true);
        $data = [
            "duration"=>$movie->getDuration(),
            "framenum"=>$movie->getFrameCount(),            
            "width"=>$movie->getFrameWidth(),
            "height"=>$movie->getFrameHeight(),
            "vcodec"=>$movie->getVideoCodec()
        ];

        return $data;
    }
}