<?php

imports("MVC.controller");
imports("RFC7231.logger");
imports("RFC7231.index");

/**
 * 用户访问权限控制器
*/
class accessController extends controller {

    /**
     * @var usageLogger
    */
    private $logger;

    function __construct() {
        parent::__construct();

        # set callback handler
        \RFC7231Error::$logger = $this->logger = new usageLogger();
    }

    public function accessControl() {       
        if ($this->AccessByEveryOne()) {
            return $this->logger->log(200, true);
        }

        if (!empty($_SESSION)) {
            if (array_key_exists("user", $_SESSION)) {
                return $this->logger->log(200, true);
            }
        }

        return $this->logger->log(403, false);
    }

    /**
     * 假若没有权限的话，会执行这个函数进行重定向
    */
    public function Redirect($code) {
        $url = urlencode(Utils::URL());
        $url = "{<platform>passport/portal}&goto=$url";

        \Redirect($url);
    }   
}