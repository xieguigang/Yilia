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
        View::Display();
    }

    /**
     * Upload
     * 
     * @access *
    */
    public function upload() {
        View::Display();
    }
}