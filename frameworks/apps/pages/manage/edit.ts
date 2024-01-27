namespace pages {

    export class edit extends Bootstrap {

        public get appName(): string {
            return "edit";
        }

        private video_id: string;

        protected init(): void {
            this.video_id = <any>$ts("@video_id");
        }

        public save_onclick() {
            const name: string = $ts.value("#name");
            const desc: string = $ts.value("#description");
            const payload = {
                name: name,
                description: desc
            }

            page.show_spinner();

            $ts.post(`/video/update/?id=${this.video_id}`, payload, function (result) {
                page.hide_spinner();
            });
        }
    }
}