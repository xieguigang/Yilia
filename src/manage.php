<?php

include __DIR__ . "/../.etc/bootstrap.php";

class App {
    
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

    /**
     * update video metadata
     * 
     * demo debug test only
     * 
     * @access *
    */
    public function update_metadata($id) {
        include APP_PATH . "/scripts/video/video_metadata.php";

        $video = new Table("video");
        $src = $video->where(["id" => $id])->find();

        if (Utils::isDbNull($src)) {
            RFC7231Error::err404(); 
        } else {
            $filepath = VIDEO_UPLOAD . "/" . $src["filepath"];
            $data    = video_data::metadata($filepath);
            $video->where(["id" => $id])
                ->save([
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

            controller::success($data);
        }  
    }
}