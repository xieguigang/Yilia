<?php

class user_log {

    /**
     * write user login log to database
     * 
     * @param array $user the user data inside the database, 
     *    maybe null value if login error.
     * @param boolean $success the user login success or error?
    */
    public static function log($email, $user, $success) {
        $user_id = $success ? $user["id"] : 0;
        $error_code = $success ? 200 : 404;
        $dblog = new Table("user_log");
        $dblog->add([
            "user_id" => $user_id,
            "error_code" => $error_code,
            "log_time" => Utils::Now(),
            "ip" => Utils::UserIPAddress(),
            "user_agent" => $_SERVER['HTTP_USER_AGENT']
        ]);

        if ($success) {
            # write session
            $_SESSION["user"] = $user;
        }
    }
}