namespace pages {

    export class user_center extends Bootstrap {

        public get appName(): string {
            return "user_center";
        }

        protected init(): void {
            $ts.get("/manage/list_video/", result => this.showVideoList(result));
        }

        private showVideoList(result: IMsg<any>) {
            let list: video_topview = result.info;
            let my = $ts("#upload_videos").clear();

            console.log("get video list page:");
            console.table(list.data);

            for (let video of list.data) {
                let card = $ts("<div>", { class: ["product__sidebar__comment__item"] });
                card.display(`     

                    <div class="product__sidebar__comment__item__pic">
                        <img src="resources/img/sidebar/comment-1.jpg" alt="">
                    </div>
                    <div class="product__sidebar__comment__item__text">
                        <ul>
                            <li>Active</li>
                            <li>Movie</li>
                        </ul>
                        <h5><a href="/play?id=${video.video_id}">${video.name}</a></h5>
                        <span><i class="fa fa-eye"></i> ${video.top} Viewes, upload time: ${video.add_time}</span>
                        <span><i class="fa fa-eye"></i> time duration: ${video.duration}, ${video.width}x${video.height}, ${video.bit_rate / 1024} kbit/s</span>
                        <span><a href="/edit?id=${video.video_id}">Edit</a>, <a href="/delete?id=${video.video_id}">Delete</a></span>
                    </div>

                `);

                my.append(card);
            }
        }
    }
}