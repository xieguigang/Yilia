<?php

define("APP_PATH", dirname(__DIR__));
define("APP_UPLOAD", APP_PATH . "/data/upload");
define("VIDEO_UPLOAD", APP_UPLOAD . "/video");
define("APP_DEBUG", true);
define("YEAR", date("Y"));

session_start();

include APP_PATH . "/frameworks/php.NET/package.php";
include APP_PATH . "/.etc/accessController.php";

dotnet::AutoLoad(APP_PATH . "/.etc/config.php");
dotnet::HandleRequest(new App(), new accessController());