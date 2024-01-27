<?php

class user_session {

    public static function user_id() {
        if (!empty($_SESSION)) {
            if (array_key_exists("user", $_SESSION)) {
                $user = $_SESSION["user"];
                $id = $user["id"];

                if (Utils::isDbNull($id)) {
                    return 0;
                } else {
                    return $id;
                }
            }
        }

        return 0;
    }
}