interface video_data {
    name: string;
    post_cover: string;
    top: string;
    video_id: string;

    add_time?: string;
    description?: string;
    ep_num?: string;
    size?: string;
}

interface videoshow_data {
    id: string;
    top: string | number;
    name: string;
    description: string;
    post_cover: string;
}