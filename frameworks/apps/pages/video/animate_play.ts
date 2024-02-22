namespace pages {

    export interface Player {
        source: PlaySource;

        on(evt: string, process: (event: EventData) => void);
        play();
    }

    export interface EventData {
        detail: { plyr: Player };
    }

    export interface PlaySource {

    }

    /**
     * page for play video collection
     * 
     * video collection by id
    */
    export class anime_play extends Bootstrap {

        get appName(): string {
            return "animate_play";
        }

        private i: number = 0;

        protected init(): void {
            const play_list: video_data[] = JSON.parse($ts.text("#video_list"));
            const ep_list = $ts("#ep_list").clear();
            const player: Player = (<any>window).plyr;

            console.log("view of the video play list:");
            console.table(play_list);

            let i: number = 0;
            let vm = this;

            for (let play of play_list) {
                ep_list.append(this.build_eplink(play, i++));
            }

            anime_play.play_video(play_list[0], false);

            player.on("ended", function (evt) {
                const instance = evt.detail.plyr;
                const next_video = play_list[++vm.i];

                anime_play.play_video(next_video, true);
            });
        }

        private build_eplink(video: video_data, i: number): HTMLElement {
            let link = $ts("<a>", { href: "#" });
            let vm = this;

            link.display(video.name);
            link.onclick = function () {
                vm.i = i;
                anime_play.play_video(video, true);
            };

            return link;
        }

        private static size(video: video_data): string {
            let size: number = 0;

            if (typeof video.size === "string") {
                size = parseInt(video.size);
            } else {
                size = <any>video.size;
            }

            return Strings.Lanudry(size);
        }

        private static play_video(video: video_data, auto_play: boolean) {
            const player: Player = (<any>window).plyr;
            const play: HTMLSourceElement = <any>$ts("#video_play");
            const name = $ts("#video_name");
            const stream = $ts("#stream_info");

            player.source = {
                type: 'video',
                title: video.name,
                sources: [
                    {
                        src: `/video/stream/?id=${video.video_id}`,
                        type: 'video/mp4',
                        size: 1080
                    }
                ],
                poster: ''
            };

            if (auto_play) {
                player.play();
            }

            play.src = `/video/stream/?id=${video.video_id}`;
            name.display(video.name);
            stream.display(`
                video play times:&nbsp;&nbsp;<i class="fa fa-eye"></i>&nbsp;${video.top}, 
                stream size: ${anime_play.size(video)}
            `);
        }
    }
}