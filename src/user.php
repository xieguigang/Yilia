<?php

include __DIR__ . "/../.etc/bootstrap.php";

class App {

    /**
     * the user table
     * 
     * @var Table
    */
    private $user;

    function __construct() {
        $this->user = new Table("user");
    }

    private static function salt_passwd($password) {
        # add salt to user password
        $salt = DotNetRegistry::Read("AUTHCODE", "AAAAA");
        $password = md5("$salt-$password");

        return $password;
    }

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
        $result = $this->user->add([
            "username" => $email,
            "passwd" => self::salt_passwd($password),
            "display_name" => $name,
            "add_time" => Utils::Now()
        ]);

        if (Utils::isDbNull($result)) {
            controller::error("create user error: an email is existed or display name contains invalid character!");
        } else {
            controller::success($result);
        }
    }

    /**
     * user login
     * 
     * @uses api
     * @access *
     * @method POST
    */
    public function login($email, $password) {
        $result = $this->user->where([
            "username" => $email,
            "passwd" => self::salt_passwd($password)
        ])->find();

        if (Utils::isDbNull($result)) {
            controller::error("the given user name is not exists or password incorrect!");
        } else {
            controller::success($result);
        }
    }
}