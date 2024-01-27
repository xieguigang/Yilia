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
        
        View::Display(["video_id" => $id]);
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
        View::Display();
    }
}