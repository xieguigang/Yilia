namespace pages {

    export class edit extends Bootstrap {

        public get appName(): string {
            return "edit";
        }

        protected init(): void {

        }

        public save_onclick() {
            const name: string = $ts.value("#name");
            const desc: string = $ts.value("#description");
            const payload = {
                name: name,
                description: desc
            }

            page.show_spinner();

            $ts.post("", payload, function (result) {
                page.hide_spinner();
            });
        }
    }
}