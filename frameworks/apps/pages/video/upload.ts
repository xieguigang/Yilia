namespace pages {

    export const $ = (<any>window).$;

    export interface WebUploader {
        upload(): unknown;
        on(evt: string, arg1: (file: UploadFile, arg2?: any) => void): unknown;
    }

    export interface UploadFile {
        size: number;
        name: string;
        id: string;
        type: string;
    }

    export interface animate {
        id: string;
        name: string;
        description: string;
        add_time: string;
        episodes: number;
        creator_id: string;
        post_cover: string;
    }

    export interface animate_collection extends collection<animate> { }

    export class upload extends Bootstrap {

        get appName(): string {
            return "upload";
        }

        private uploader: WebUploader;
        private collection_id: string = "-1";

        private create() {
            return (<any>window).WebUploader.create({
                // 选完文件后，是否自动上传。
                auto: false,

                // swf文件路径
                swf: "/resources/js/webuploader/Uploader.swf",

                // 文件接收服务端。
                server: "/video/upload/",
                accept: {
                    title: "Video Files",
                    // extensions: "dat,asf,rm,ram,3gp,mov,m4v,dvix,dv,qt,divx,cpk,fli,flc,mod,mp4,wmv,flv,avi,mkv,vob,mpg,rmvb,mpeg,mov,mts",
                },

                // 选择文件的按钮。可选。
                // 内部根据当前运行是创建，可能是input元素，也可能是flash.
                pick: '#picker',
                // mulitple:true,//选择多个
                chunked: true,//开启分片上传
                chunkSize: 2 * 1024 * 1024,//分片大小，建议2M，其他可能需要设置
                threads: 3,//上传并发数

                method: 'POST',
            });
        }

        private showFileInfo(file: UploadFile) {
            var $list = $ts("#thelist");
            var info_str: string = `
                <div id="${file.id}" class="item">
                    <h4 class="info">${file.name}</h4>
                    <p class="info">FileSize: ${Strings.Lanudry(file.size)}</p>
                    <p class="state">Pending Upload ...</p>
                </div>`;

            console.log(file);

            // webuploader事件.当选择文件后，文件被加载到文件队列中，触发该事件。
            // 等效于 uploader.onFileueued = function(file){...} ，类似js的事件定义。
            $list.appendElement($ts("<div>").display(info_str));
        }

        private on_progress(file: UploadFile, percentage: number) {
            var $li = $('#' + file.id);
            var $percent = $li.find('.progress .progress-bar');

            // 避免重复创建
            if (!$percent.length) {
                $percent = $('<div class="progress progress-striped active">' +
                    '<div class="progress-bar" role="progressbar" style="width: 0%">' +
                    '</div>' +
                    '</div>').appendTo($li).find('.progress-bar');
            }

            $li.find('p.state').text(`Upload ... ${Strings.round(percentage * 100, 2)}%`);
            $percent.css('width', percentage * 100 + '%');
        }

        private on_success(file: UploadFile, response: any) {
            let urls: { dir: string, name: string } = response.data;
            let info = {
                file: `${urls.dir}/${urls.name}`,
                name: $ts.baseName(file.name),
                size: file.size,
                type: file.type,
                collection: this.collection_id
            };

            $('#' + file.id).addClass('upload-state-done');

            console.log("video file upload success:");
            console.log(urls);

            // write database
            $ts.post("/video/save/", info, function () {
                page.hide_spinner();
            });
        }

        private on_complete(file: UploadFile) {
            // alert(file.id)
            // alert(file);
            $('#' + file.id).find('.progress').remove();
            $('#' + file.id).find('p.state').text('已上传');

            // // $('.layui-video-box').html(Help.videoHtml(url, key));
            // Help.video_read();

            // location.href="http://www.xiaosan.com/tp5/public/index.php/index/backstage/vioshow";
            page.hide_spinner();
        }

        private on_error(file: UploadFile) {
            $('#' + file.id).find('p.state').text('上传出错');
            page.hide_spinner();
        }

        protected init(): void {
            let vm = this;

            this.uploader = this.create();

            // 当有文件添加进来的时候
            this.uploader.on('fileQueued', file => this.showFileInfo(file));
            // 文件上传过程中创建进度条实时显示。
            this.uploader.on('uploadProgress', (file, percentage) => this.on_progress(file, percentage));
            // 文件上传成功，给item添加成功class, 用样式标记上传成功。
            this.uploader.on('uploadSuccess', (file, response) => this.on_success(file, response));
            // 文件上传失败，显示上传出错。
            this.uploader.on('uploadError', file => this.on_error(file));
            // 完成上传完了，成功或者失败，先删除进度条。
            this.uploader.on('uploadComplete', file => this.on_complete(file));

            // $ts.get("/manage/list_collection/", function (result) {
            //     if (result.code == 0) {
            //         vm.load_my_collection(<any>result.info)
            //     }
            // });
        }

        public collection_onchange(value: string[]) {
            const id = value[0];

            this.collection_id = id;
            console.log(`select a animate video collection: ${id}!`);
        }

        // private load_my_collection(collection: animate_collection) {
        //     const opts = $ts("#collection");

        //     for (let anime of collection.data) {
        //         opts.appendElement($ts("<option>", { value: anime.id }).display(anime.name));
        //     }
        // }

        public uploadbtn_onclick() {
            console.log(`animate video will be upload to collection: ${this.collection_id}!`);

            if ($ts("#uploadbtn").hasClass('disabled')) {
                return false;
            } else {
                page.show_spinner("rgb(0 0 0 / 42%)");
                $ts("#collection").interactive(false);
                this.uploader.upload();
            }
        }
    }
}