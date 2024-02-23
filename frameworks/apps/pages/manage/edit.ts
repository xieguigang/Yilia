namespace pages {

    export class edit extends Bootstrap {

        public get appName(): string {
            return "edit";
        }

        private video_id: string;
        private collection_id: string = "-1";

        protected init(): void {
            this.video_id = <any>$ts("@video_id");
        }

        public collection_onchange(value: string[]) {
            const id = value[0];

            this.collection_id = id;
            console.log(`select a animate video collection: ${id}!`);
        }

        public save_onclick() {
            const name: string = $ts.value("#name");
            const desc: string = $ts.value("#description");
            const payload = {
                name: name,
                description: desc,
                collection: this.collection_id
            }

            page.show_spinner();

            $ts.post(`/video/update/?id=${this.video_id}`, payload, function (result) {
                page.hide_spinner();
            });
        }
    }
}