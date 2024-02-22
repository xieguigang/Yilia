/// <reference path="linq.d.ts" />
declare module apps {
    function run(): void;
}
declare module page {
    function show_spinner(mask?: string): void;
    function hide_spinner(): void;
}
interface video_data {
    name: string;
    post_cover: string;
    top: string;
    video_id: string;
    add_time?: string;
    description?: string;
    ep_num?: string;
    size?: string;
    duration?: string;
    width?: number;
    height?: number;
    bit_rate?: number;
}
interface videoshow_data {
    id: string;
    top: string | number;
    name: string;
    description: string;
    post_cover: string;
}
declare namespace pages {
    interface video_topview {
        size: number;
        start: string;
        ends: string;
        data: video_data[];
    }
    interface video_shows {
        size: number;
        data: videoshow_data[];
    }
    class index_home extends Bootstrap {
        get appName(): string;
        protected init(): void;
        private show_topshows;
        private show_recents;
        private loadList;
        topDay_onclick(): void;
        topWeek_onclick(): void;
        topMonth_onclick(): void;
        topYear_onclick(): void;
    }
}
declare namespace pages {
    class edit extends Bootstrap {
        get appName(): string;
        private video_id;
        protected init(): void;
        save_onclick(): void;
    }
}
declare namespace pages {
    class user_center extends Bootstrap {
        get appName(): string;
        protected init(): void;
        private showVideoList;
    }
}
declare namespace pages {
    class login extends Bootstrap {
        get appName(): string;
        protected init(): void;
        login_onclick(): void;
    }
}
declare namespace pages {
    class signup extends Bootstrap {
        get appName(): string;
        protected init(): void;
        signup_onclick(): void;
    }
}
declare namespace pages {
    interface Player {
        source: PlaySource;
        on(evt: string, process: (event: EventData) => void): any;
        play(): any;
    }
    interface EventData {
        detail: {
            plyr: Player;
        };
    }
    interface PlaySource {
    }
    /**
     * page for play video collection
     *
     * video collection by id
    */
    class anime_play extends Bootstrap {
        get appName(): string;
        private i;
        protected init(): void;
        private build_eplink;
        private static size;
        private static play_video;
    }
}
declare namespace pages {
    /**
     * page for play a single video
     *
     * video play by given id
    */
    class play extends Bootstrap {
        get appName(): string;
        protected init(): void;
    }
}
declare namespace pages {
    const $: any;
    interface WebUploader {
        upload(): unknown;
        on(evt: string, arg1: (file: UploadFile, arg2?: any) => void): unknown;
    }
    interface UploadFile {
        size: number;
        name: string;
        id: string;
        type: string;
    }
    class upload extends Bootstrap {
        get appName(): string;
        private uploader;
        private create;
        private showFileInfo;
        private on_progress;
        private on_success;
        private on_complete;
        private on_error;
        protected init(): void;
        uploadbtn_onclick(): boolean;
    }
}
