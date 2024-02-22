var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
/// <reference path="../build/linq.d.ts" />
var apps;
(function (apps) {
    function run() {
        Router.AddAppHandler(new pages.signup());
        Router.AddAppHandler(new pages.login());
        Router.AddAppHandler(new pages.user_center());
        Router.AddAppHandler(new pages.edit());
        Router.AddAppHandler(new pages.upload());
        Router.AddAppHandler(new pages.play());
        Router.AddAppHandler(new pages.anime_play());
        Router.AddAppHandler(new pages.index_home());
        Router.RunApp();
    }
    apps.run = run;
})(apps || (apps = {}));
$ts.mode = Modes.debug;
$ts(apps.run);
var page;
(function (page) {
    function show_spinner(mask) {
        if (mask === void 0) { mask = "#000000c7"; }
        $ts("#preloder").style.background = mask;
        $ts("#preloder").show();
        $ts("#spinner").show();
    }
    page.show_spinner = show_spinner;
    function hide_spinner() {
        $ts("#preloder").hide();
        $ts("#spinner").hide();
    }
    page.hide_spinner = hide_spinner;
})(page || (page = {}));
var pages;
(function (pages) {
    var index_home = /** @class */ (function (_super) {
        __extends(index_home, _super);
        function index_home() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        Object.defineProperty(index_home.prototype, "appName", {
            get: function () {
                return "index_home";
            },
            enumerable: false,
            configurable: true
        });
        index_home.prototype.init = function () {
            var _this = this;
            $ts("#topviews-gallery").clear();
            $ts("#recent-list").clear();
            $ts("#top_shows").clear();
            $ts.get("/video/top_views/?type=day", function (result) { return _this.loadList(result, "day"); });
            $ts.get("/video/recent/", function (result) { return _this.show_recents(result); });
            $ts.get("/video/popular_shows/", function (result) { return _this.show_topshows(result); });
        };
        index_home.prototype.show_topshows = function (data) {
            var list = data.info;
            var top_shows = $ts("#top_shows").clear();
            for (var _i = 0, _a = list.data; _i < _a.length; _i++) {
                var show = _a[_i];
                var card = $ts("<div>", {
                    class: ["col-lg-4", "col-md-6", "col-sm-6"]
                }).display("   \n                    <div class=\"product__item\">\n                        <div id=\"videoshow_".concat(show.id, "\" class=\"product__item__pic set-bg\" data-setbg=\"resources/img/recent/recent-1.jpg\">\n                            <div class=\"ep\">18 / 18</div>\n                            <div class=\"comment\"><i class=\"fa fa-comments\"></i> 11</div>\n                            <div class=\"view\"><i class=\"fa fa-eye\"></i> ").concat(show.top, "</div>\n                        </div>\n                        <div class=\"product__item__text\">\n                            <ul>\n                                <li>Active</li>\n                                <li>Movie</li>\n                            </ul>\n                            <h5><a href=\"/animate?id=").concat(show.id, "\">").concat(show.name, "</a></h5>\n                        </div>\n                    </div>\n                "));
                //card.setAttribute("data-setbg", "/resources/img/recent/recent-1.jpg");
                //card.style.backgroundImage = `url("/resources/img/recent/recent-1.jpg")`;
                top_shows.append(card);
            }
            for (var _b = 0, _c = list.data; _b < _c.length; _b++) {
                var show = _c[_b];
                $ts("#videoshow_".concat(show.id)).style.backgroundImage = "url(\"/resources/img/recent/recent-1.jpg\")";
            }
        };
        index_home.prototype.show_recents = function (data) {
            var list = data.info;
            var recents = $ts("#recent-list").clear();
            for (var _i = 0, list_1 = list; _i < list_1.length; _i++) {
                var video = list_1[_i];
                var card = $ts("<div>", {
                    class: ["col-lg-4", "col-md-6", "col-sm-6"]
                }).display("   \n                    <div class=\"product__item\">\n                        <div id=\"video_".concat(video.video_id, "\" class=\"product__item__pic set-bg\" data-setbg=\"resources/img/recent/recent-1.jpg\">\n                            <div class=\"ep\">18 / 18</div>\n                            <div class=\"comment\"><i class=\"fa fa-comments\"></i> 11</div>\n                            <div class=\"view\"><i class=\"fa fa-eye\"></i> ").concat(video.top, "</div>\n                        </div>\n                        <div class=\"product__item__text\">\n                            <ul>\n                                <li>Active</li>\n                                <li>Movie</li>\n                            </ul>\n                            <h5><a href=\"/play?id=").concat(video.video_id, "\">").concat(video.name, "</a></h5>\n                        </div>\n                    </div>\n                "));
                //card.setAttribute("data-setbg", "/resources/img/recent/recent-1.jpg");
                //card.style.backgroundImage = `url("/resources/img/recent/recent-1.jpg")`;
                recents.append(card);
            }
            for (var _a = 0, list_2 = list; _a < list_2.length; _a++) {
                var video = list_2[_a];
                $ts("#video_".concat(video.video_id)).style.backgroundImage = "url(\"/resources/img/recent/recent-1.jpg\")";
            }
        };
        index_home.prototype.loadList = function (data, type) {
            if (type === void 0) { type = "day"; }
            var list = data.info;
            var gallery = $ts("#topviews-gallery").clear();
            for (var _i = 0, _a = list.data; _i < _a.length; _i++) {
                var video = _a[_i];
                var post = $ts("<div>", {
                    class: [
                        "product__sidebar__view__item",
                        "set-bg", "mix",
                        "day", "week", "month", "years"
                    ]
                }).display("\n\n                <div class=\"ep\">18 / ?</div>\n                <div class=\"view\"><i class=\"fa fa-eye\"></i> ".concat(video.top, "</div>\n                <h5><a href=\"/play?id=").concat(video.video_id, "\">").concat(video.name.replace(/\.mp4/ig, "").trim(), "</a></h5>\n                \n                "));
                post.setAttribute("data-setbg", "/resources/img/sidebar/tv-1.jpg");
                post.style.backgroundImage = "url(\"/resources/img/sidebar/tv-1.jpg\")";
                gallery.append(post);
            }
            window.mixitup(gallery);
        };
        index_home.prototype.topDay_onclick = function () {
            var _this = this;
            $ts.get("/video/top_views/?type=day", function (result) { return _this.loadList(result, "day"); });
        };
        index_home.prototype.topWeek_onclick = function () {
            var _this = this;
            $ts.get("/video/top_views/?type=week", function (result) { return _this.loadList(result, "week"); });
        };
        index_home.prototype.topMonth_onclick = function () {
            var _this = this;
            $ts.get("/video/top_views/?type=month", function (result) { return _this.loadList(result, "month"); });
        };
        index_home.prototype.topYear_onclick = function () {
            var _this = this;
            $ts.get("/video/top_views/?type=year", function (result) { return _this.loadList(result, "year"); });
        };
        return index_home;
    }(Bootstrap));
    pages.index_home = index_home;
})(pages || (pages = {}));
var pages;
(function (pages) {
    var edit = /** @class */ (function (_super) {
        __extends(edit, _super);
        function edit() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        Object.defineProperty(edit.prototype, "appName", {
            get: function () {
                return "edit";
            },
            enumerable: false,
            configurable: true
        });
        edit.prototype.init = function () {
            this.video_id = $ts("@video_id");
        };
        edit.prototype.save_onclick = function () {
            var name = $ts.value("#name");
            var desc = $ts.value("#description");
            var payload = {
                name: name,
                description: desc
            };
            page.show_spinner();
            $ts.post("/video/update/?id=".concat(this.video_id), payload, function (result) {
                page.hide_spinner();
            });
        };
        return edit;
    }(Bootstrap));
    pages.edit = edit;
})(pages || (pages = {}));
var pages;
(function (pages) {
    var user_center = /** @class */ (function (_super) {
        __extends(user_center, _super);
        function user_center() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        Object.defineProperty(user_center.prototype, "appName", {
            get: function () {
                return "user_center";
            },
            enumerable: false,
            configurable: true
        });
        user_center.prototype.init = function () {
            var _this = this;
            $ts.get("/manage/list_video/", function (result) { return _this.showVideoList(result); });
        };
        user_center.prototype.showVideoList = function (result) {
            var list = result.info;
            var my = $ts("#upload_videos").clear();
            console.log("get video list page:");
            console.table(list.data);
            for (var _i = 0, _a = list.data; _i < _a.length; _i++) {
                var video = _a[_i];
                var card = $ts("<div>", { class: ["product__sidebar__comment__item"] });
                card.display("     \n\n                    <div class=\"product__sidebar__comment__item__pic\">\n                        <img src=\"resources/img/sidebar/comment-1.jpg\" alt=\"\">\n                    </div>\n                    <div class=\"product__sidebar__comment__item__text\">\n                        <ul>\n                            <li>Active</li>\n                            <li>Movie</li>\n                        </ul>\n                        <h5><a href=\"/play?id=".concat(video.video_id, "\">").concat(video.name, "</a></h5>\n                        <span><i class=\"fa fa-eye\"></i> ").concat(video.top, " Viewes, upload time: ").concat(video.add_time, "</span>\n                        <span><i class=\"fa fa-eye\"></i> time duration: ").concat(video.duration, ", ").concat(video.width, "x").concat(video.height, ", ").concat(video.bit_rate / 1024, " kbit/s</span>\n                        <span><a href=\"/edit?id=").concat(video.video_id, "\">Edit</a>, <a href=\"/delete?id=").concat(video.video_id, "\">Delete</a></span>\n                    </div>\n\n                "));
                my.append(card);
            }
        };
        return user_center;
    }(Bootstrap));
    pages.user_center = user_center;
})(pages || (pages = {}));
var pages;
(function (pages) {
    var login = /** @class */ (function (_super) {
        __extends(login, _super);
        function login() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        Object.defineProperty(login.prototype, "appName", {
            get: function () {
                return "login";
            },
            enumerable: false,
            configurable: true
        });
        login.prototype.init = function () {
        };
        login.prototype.login_onclick = function () {
            var email = $ts.value("#email");
            var password = $ts.value("#password");
            page.show_spinner();
            $ts.post("/user/login/", {
                email: email,
                password: md5(password)
            }, function (result) {
                if (result.code == 0) {
                    $goto("/my");
                }
                else {
                }
                page.hide_spinner();
            });
        };
        return login;
    }(Bootstrap));
    pages.login = login;
})(pages || (pages = {}));
var pages;
(function (pages) {
    var signup = /** @class */ (function (_super) {
        __extends(signup, _super);
        function signup() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        Object.defineProperty(signup.prototype, "appName", {
            get: function () {
                return "signup";
            },
            enumerable: false,
            configurable: true
        });
        signup.prototype.init = function () {
        };
        signup.prototype.signup_onclick = function () {
            var email = $ts.value("#email");
            var name = $ts.value("#username");
            var password = $ts.value("#password");
            var payload = {
                email: email,
                name: name,
                password: md5(password)
            };
            page.show_spinner();
            console.log(payload);
            $ts.post("/user/signup/", payload, function (result) {
                if (result.code == 0) {
                }
                else {
                }
                page.hide_spinner();
            });
        };
        return signup;
    }(Bootstrap));
    pages.signup = signup;
})(pages || (pages = {}));
var pages;
(function (pages) {
    /**
     * page for play video collection
     *
     * video collection by id
    */
    var anime_play = /** @class */ (function (_super) {
        __extends(anime_play, _super);
        function anime_play() {
            var _this = _super !== null && _super.apply(this, arguments) || this;
            _this.i = 0;
            return _this;
        }
        Object.defineProperty(anime_play.prototype, "appName", {
            get: function () {
                return "animate_play";
            },
            enumerable: false,
            configurable: true
        });
        anime_play.prototype.init = function () {
            var play_list = JSON.parse($ts.text("#video_list"));
            var ep_list = $ts("#ep_list").clear();
            var player = window.plyr;
            console.log("view of the video play list:");
            console.table(play_list);
            var i = 0;
            var vm = this;
            for (var _i = 0, play_list_1 = play_list; _i < play_list_1.length; _i++) {
                var play_1 = play_list_1[_i];
                ep_list.append(this.build_eplink(play_1, i++));
            }
            anime_play.play_video(play_list[0], false);
            player.on("ended", function (evt) {
                var instance = evt.detail.plyr;
                var next_video = play_list[++vm.i];
                anime_play.play_video(next_video, true);
            });
        };
        anime_play.prototype.build_eplink = function (video, i) {
            var link = $ts("<a>", { href: "#" });
            var vm = this;
            link.display(video.name);
            link.onclick = function () {
                vm.i = i;
                anime_play.play_video(video, true);
            };
            return link;
        };
        anime_play.size = function (video) {
            var size = 0;
            if (typeof video.size === "string") {
                size = parseInt(video.size);
            }
            else {
                size = video.size;
            }
            return Strings.Lanudry(size);
        };
        anime_play.play_video = function (video, auto_play) {
            var player = window.plyr;
            var play = $ts("#video_play");
            var name = $ts("#video_name");
            var stream = $ts("#stream_info");
            player.source = {
                type: 'video',
                title: video.name,
                sources: [
                    {
                        src: "/video/stream/?id=".concat(video.video_id),
                        type: 'video/mp4',
                        size: 1080
                    }
                ],
                poster: ''
            };
            if (auto_play) {
                player.play();
            }
            play.src = "/video/stream/?id=".concat(video.video_id);
            name.display(video.name);
            stream.display("\n                video play times:&nbsp;&nbsp;<i class=\"fa fa-eye\"></i>&nbsp;".concat(video.top, ", \n                stream size: ").concat(anime_play.size(video), "\n            "));
        };
        return anime_play;
    }(Bootstrap));
    pages.anime_play = anime_play;
})(pages || (pages = {}));
var pages;
(function (pages) {
    /**
     * page for play a single video
     *
     * video play by given id
    */
    var play = /** @class */ (function (_super) {
        __extends(play, _super);
        function play() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        Object.defineProperty(play.prototype, "appName", {
            get: function () {
                return "video_play";
            },
            enumerable: false,
            configurable: true
        });
        play.prototype.init = function () {
        };
        return play;
    }(Bootstrap));
    pages.play = play;
})(pages || (pages = {}));
var pages;
(function (pages) {
    pages.$ = window.$;
    var upload = /** @class */ (function (_super) {
        __extends(upload, _super);
        function upload() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        Object.defineProperty(upload.prototype, "appName", {
            get: function () {
                return "upload";
            },
            enumerable: false,
            configurable: true
        });
        upload.prototype.create = function () {
            return window.WebUploader.create({
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
                chunked: true,
                chunkSize: 2 * 1024 * 1024,
                threads: 3,
                method: 'POST',
            });
        };
        upload.prototype.showFileInfo = function (file) {
            var $list = $ts("#thelist");
            var info_str = "\n                <div id=\"".concat(file.id, "\" class=\"item\">\n                    <h4 class=\"info\">").concat(file.name, "</h4>\n                    <p class=\"info\">FileSize: ").concat(Strings.Lanudry(file.size), "</p>\n                    <p class=\"state\">Pending Upload ...</p>\n                </div>");
            console.log(file);
            // webuploader事件.当选择文件后，文件被加载到文件队列中，触发该事件。
            // 等效于 uploader.onFileueued = function(file){...} ，类似js的事件定义。
            $list.appendElement($ts("<div>").display(info_str));
        };
        upload.prototype.on_progress = function (file, percentage) {
            var $li = pages.$('#' + file.id);
            var $percent = $li.find('.progress .progress-bar');
            // 避免重复创建
            if (!$percent.length) {
                $percent = pages.$('<div class="progress progress-striped active">' +
                    '<div class="progress-bar" role="progressbar" style="width: 0%">' +
                    '</div>' +
                    '</div>').appendTo($li).find('.progress-bar');
            }
            $li.find('p.state').text("Upload ... ".concat(Strings.round(percentage * 100, 2), "%"));
            $percent.css('width', percentage * 100 + '%');
        };
        upload.prototype.on_success = function (file, response) {
            var urls = response.data;
            var info = {
                file: "".concat(urls.dir, "/").concat(urls.name),
                name: $ts.baseName(file.name),
                size: file.size,
                type: file.type
            };
            pages.$('#' + file.id).addClass('upload-state-done');
            console.log("video file upload success:");
            console.log(urls);
            // write database
            $ts.post("/video/save/", info, function () {
                page.hide_spinner();
            });
        };
        upload.prototype.on_complete = function (file) {
            // alert(file.id)
            // alert(file);
            pages.$('#' + file.id).find('.progress').remove();
            pages.$('#' + file.id).find('p.state').text('已上传');
            // // $('.layui-video-box').html(Help.videoHtml(url, key));
            // Help.video_read();
            // location.href="http://www.xiaosan.com/tp5/public/index.php/index/backstage/vioshow";
            page.hide_spinner();
        };
        upload.prototype.on_error = function (file) {
            pages.$('#' + file.id).find('p.state').text('上传出错');
            page.hide_spinner();
        };
        upload.prototype.init = function () {
            var _this = this;
            this.uploader = this.create();
            // 当有文件添加进来的时候
            this.uploader.on('fileQueued', function (file) { return _this.showFileInfo(file); });
            // 文件上传过程中创建进度条实时显示。
            this.uploader.on('uploadProgress', function (file, percentage) { return _this.on_progress(file, percentage); });
            // 文件上传成功，给item添加成功class, 用样式标记上传成功。
            this.uploader.on('uploadSuccess', function (file, response) { return _this.on_success(file, response); });
            // 文件上传失败，显示上传出错。
            this.uploader.on('uploadError', function (file) { return _this.on_error(file); });
            // 完成上传完了，成功或者失败，先删除进度条。
            this.uploader.on('uploadComplete', function (file) { return _this.on_complete(file); });
        };
        upload.prototype.uploadbtn_onclick = function () {
            if ($ts("#uploadbtn").hasClass('disabled')) {
                return false;
            }
            else {
                page.show_spinner("rgb(0 0 0 / 42%)");
                this.uploader.upload();
            }
        };
        return upload;
    }(Bootstrap));
    pages.upload = upload;
})(pages || (pages = {}));
//# sourceMappingURL=apps.js.map