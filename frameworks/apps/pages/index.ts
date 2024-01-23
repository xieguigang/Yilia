namespace pages {

    export interface video_topview {
        size: number;
        start: string;
        ends: string;
        data: video_data[]
    }

    export interface video_data {
        name: string;
        post_cover: string;
        top: string;
        video_id: string;

        add_time?: string;
        description?: string;
    }

    export class index_home extends Bootstrap {

        get appName(): string {
            return "index_home"
        }

        protected init(): void {
            $ts("#topviews-gallery").clear();
            $ts("#recent-list").clear();

            $ts.get("/video/top_views/?type=day", result => this.loadList(result, "day"));
            $ts.get("/video/recent/", result => this.show_recents(result));
        }

        private show_recents(data: IMsg<any>) {
            let list: video_data[] = data.info;
            let recents = $ts("#recent-list").clear();

            for (let video of list) {
                let card = $ts("<div>", {
                    class: ["col-lg-4", "col-md-6", "col-sm-6"]
                }).display(`   
                    <div class="product__item">
                        <div class="product__item__pic set-bg" data-setbg="resources/img/recent/recent-1.jpg">
                            <div class="ep">18 / 18</div>
                            <div class="comment"><i class="fa fa-comments"></i> 11</div>
                            <div class="view"><i class="fa fa-eye"></i> ${video.top}</div>
                        </div>
                        <div class="product__item__text">
                            <ul>
                                <li>Active</li>
                                <li>Movie</li>
                            </ul>
                            <h5><a href="/play?id=${video.video_id}">${video.name}</a></h5>
                        </div>
                    </div>
                `);
                card.setAttribute("data-setbg", "/resources/img/recent/recent-1.jpg");
                card.style.backgroundImage = `url("/resources/img/recent/recent-1.jpg")`;

                recents.append(card);
            }
        }

        private loadList(data: IMsg<any>, type: string = "day") {
            let list: video_topview = data.info;
            let gallery = $ts("#topviews-gallery").clear();

            for (let video of list.data) {
                var post = $ts("<div>", {
                    class: [
                        "product__sidebar__view__item",
                        "set-bg", "mix",
                        "day", "week", "month", "years"
                    ]
                }).display(`

                <div class="ep">18 / ?</div>
                <div class="view"><i class="fa fa-eye"></i> ${video.top}</div>
                <h5><a href="/play?id=${video.video_id}">${video.name.replace(/\.mp4/ig, "").trim()}</a></h5>
                
                `);

                post.setAttribute("data-setbg", "/resources/img/sidebar/tv-1.jpg");
                post.style.backgroundImage = `url("/resources/img/sidebar/tv-1.jpg")`;
                gallery.append(post);
            }

            (<any>window).mixitup(gallery);
        }

        public topDay_onclick() {
            $ts.get("/video/top_views/?type=day", result => this.loadList(result, "day"));
        }

        public topWeek_onclick() {
            $ts.get("/video/top_views/?type=week", result => this.loadList(result, "week"));
        }

        public topMonth_onclick() {
            $ts.get("/video/top_views/?type=month", result => this.loadList(result, "month"));
        }

        public topYear_onclick() {
            $ts.get("/video/top_views/?type=year", result => this.loadList(result, "year"));
        }
    }
}