namespace pages {

    export class anime_play extends Bootstrap {

        get appName(): string {
            return "animate_play";
        }

        protected init(): void {
            const play_list: video_data[] = JSON.parse($ts.text("#video_list"));
            const ep_list = $ts("#ep_list").clear();

            console.log("view of the video play list:");
            console.table(play_list);

            for (let play of play_list) {
                ep_list.append(this.build_eplink(play));
            }

            (<HTMLElement>ep_list.childNodes[0]).onclick(null);
        }

        private build_eplink(video: video_data): HTMLElement {
            let link = $ts("<a>", { href: "#" });
            let play: HTMLSourceElement = <any>$ts("#video_play");
            let name = $ts("#video_name");
            let stream = $ts("#stream_info");
            let size: number = 0;

            if (typeof video.size === "string") {
                size = parseInt(video.size);
            } else {
                size = <any>video.size;
            }

            link.display(video.name);
            link.onclick = function () {
                play.src = `/video/stream/?id=${video.video_id}`;
                name.display(video.name);
                stream.display(`
                    video play times:&nbsp;&nbsp;<i class="fa fa-eye"></i>&nbsp;${video.top}, 
                    stream size: ${Strings.Lanudry(size)}
                `);
            }

            return link;
        }
    }
}