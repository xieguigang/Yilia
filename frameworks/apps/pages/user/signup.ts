namespace pages {

    export class signup extends Bootstrap {

        get appName(): string {
            return "signup";
        }

        protected init(): void {

        }

        public signup_onclick() {
            const email = $ts.value("#email");
            const name = $ts.value("#username");
            const password = $ts.value("#password");
            const payload = {
                email: email,
                name: name,
                password: md5(password)
            };

            page.show_spinner();

            console.log(payload);

            $ts.post("/user/signup/", payload, function(result) {
                if (result.code == 0) {
                    
                } else {

                }

                page.hide_spinner();
            });
        }
    }
}