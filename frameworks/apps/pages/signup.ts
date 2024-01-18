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
                password: password
            };

            console.log(payload);
        }
    }
}