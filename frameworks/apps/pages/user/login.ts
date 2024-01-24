namespace pages {

    export class login extends Bootstrap {

        public get appName(): string {
            return "login";
        }

        protected init(): void {

        }

        public login_onclick() {
            const email: string = $ts.value("#email");
            const password: string = $ts.value("#password");

            page.show_spinner();

            $ts.post("/user/login/", {
                email: email,
                password: md5(password)
            }, function (result) {
                if (result.code == 0) {
                    $goto("/my");
                } else {

                }

                page.hide_spinner();
            });
        }
    }
}