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
            "frame_num"=>$movie->getFrameCount(),
            "frame_rate" => $movie->getFrameRate(),             
            "width"=>$movie->getFrameWidth(),
            "height"=>$movie->getFrameHeight(),
            "vcodec"=>$movie->getVideoCodec(),
            "pixel_format" => $movie->getPixelFormat(),
            "bit_rate" => $movie->getBitRate(),
            "video_bitrate" => $movie->getVideoBitRate(),
            "size" => $movie->getSize()
        ];

        return $data;
    }

    public static function video_keyframe($file, $savefile) {
        $movie = new \Phpffmpeg\adapter\ffmpeg_movie($file, true);
        $frame = null;

        for($i = 0; $i < 6; $i++) {
            $img = $movie->getNextKeyFrame();

            if (!($img === false)) {
                $frame = $img;
            }
        }

        if (!Utils::isDbNull($frame)) {
            $img = $frame->toGDImage();
            imagejpeg($img, $savefile);
            imagedestroy($img);

            return file_exists($savefile);
        } else {
            return false;
        }
    }
}