<?php

include __DIR__ . "/../.etc/bootstrap.php";

class App {

    /**
     * Anime 
     * 
     * @access *
    */
    public function index() {
        View::Display();
    }

    /**
     * edit video information
    */
    public function edit($id) {
        include_once APP_PATH . "/scripts/user/session.php";

        $video = new Table("video");
        $user_id = user_session::user_id();
        $src = $video->where(["id" => $id, "user_id" => $user_id])->find();
        $animes = new Table("animate");
        $animes = $animes->where(["creator_id" => $user_id])->select();
        $src["animes"] = $animes;

        if (Utils::isDbNull($src)) {
            RFC7231Error::err404("The specific video is not exists or not under control of current user domain!"); 
        } else {
            View::Display($src);
        }        
    }

    /**
     * Login
     * 
     * @access *
    */
    public function login() {
        View::Display();
    }
    
    /**
     * Signup
     * 
     * @access *
    */
    public function signup() {
        View::Display();
    }

    /**
     * User Center
     * 
    */
    public function my() {
        $user = $_SESSION["user"];
        $user["title"] = "User center - " . $user["display_name"];

        View::Display($user);
    }

    /**
     * Categories
     * 
     * @access *
    */
    public function categories() {
        View::Display();
    }

    /**
     * Play
     * 
     * @access * 
    */
    public function play($id) {  
        $video = new Table("video");
        $video = $video->where(["id" => $id])->find();

        if (Utils::isDbNull($video)) {
            RFC7231Error::err404(); 
        } else {
            $video["title"] = $video["name"];
            $video["size"] = Utils::UnitSize($video["size"]);

            View::Display($video);
        }
    }

    /**
     * Animate Details
     * 
     * @access *
    */
    public function animate($id) {
        $anime = new Table("animate");
        $anime = $anime->where(["id" => $id])->find();

        if (Utils::isDbNull($anime)) {
            RFC7231Error::err404(); 
        } else {
            $anime["title"] = $anime["name"];
        }

        View::Display($anime);
    }

    /**
     * Play Animate Album
     * 
     * @access *
    */
    public function animate_play($id) {
        $anime = new Table("animate");
        $anime = $anime->where(["id" => $id])->find();

        if (Utils::isDbNull($anime)) {
            RFC7231Error::err404(); 
        } else {
            $anime["title"] = $anime["name"];
            $anime["anime_name"] = $anime["name"];
            $anime["video"] = (new Table("animate_video"))
                ->left_join("video")
                ->on(["video" => "id", "animate_video" => "video_id"])
                ->where(["animate_id" => $anime["id"]])
                ->order_by("ep_num")
                ->select(["video.id as video_id", "video.name", "video.size", "video.play_time as top", "ep_num"])
            ;
            $anime["video"] = json_encode($anime["video"]);
        }

        View::Display($anime);
    }

    /**
     * Upload
     * 
    */
    public function upload() {
        include_once APP_PATH . "/scripts/user/session.php";

        $user_id = user_session::user_id();
        $animes = new Table("animate");
        $animes = $animes->where(["creator_id" => $user_id])->select();

        View::Display(["animes" => $animes]);
    }
}