<?php

include __DIR__ . "/../.etc/bootstrap.php";

class App {
    
    public function list_collection($id = null) {
        if (Utils::isDbNull($id)) {
            include_once APP_PATH . "/scripts/user/session.php";
            $id = user_session::user_id();
        }

        if ($id == 0) {
            controller::error("invalid user_id!");
        }

        $anime = new Table("animate");
        $list = $anime->where(["creator_id" => $id])->select();

        controller::success(["size" => count($list), "data" => $list]);
    }

    /**
     * list videos by user id
     * 
     * @param integer $id the user id, leaves empty will use the user id in current session
    */
    public function list_video($id = null, $page = 1, $page_size = 30) {
        if (Utils::isDbNull($id)) {
            include_once APP_PATH . "/scripts/user/session.php";
            $id = user_session::user_id();
        }

        if ($id == 0) {
            controller::error("invalid user_id!");
        } else {
            $video = new Table("video");
            $start = ($page - 1) * $page_size + 1;
            $list = $video
                ->where(["user_id" => $id])
                ->limit($start, $page_size)
                ->select([
                    "id as video_id","name","size","play_time as top",
                    "add_time","post_cover","duration","width","height",
                    "vcodec","video_bitrate as bit_rate"
                ])
                ;

            controller::success([
                "size" => count($list),
                "data" => $list
            ]);
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