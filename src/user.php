<?php

include __DIR__ . "/../.etc/bootstrap.php";

class App {

    /**
     * create a new user
     * 
     * @param string $password the md5 value of user account password string
     * 
     * @uses api
     * @access *
     * @method POST
    */
    public function signup($email, $name, $password) {
        # add salt to user password
        $salt = DotNetRegistry::Read("AUTHCODE", "AAAAA");
        $password = md5("$salt-$password");
        $user = new Table("user");
        $result = $user->add([
            "username" => $email,
            "passwd" => $password,
            "display_name" => $name,
            "add_time" => Utils::Now()
        ]);

        if (Utils::isDbNull($result)) {
            controller::error("create user error: an email is existed or display name contains invalid character!");
        } else {
            controller::success($result);
        }
    }
}