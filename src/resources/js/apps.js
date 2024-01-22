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
        Router.AddAppHandler(new pages.upload());
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
                password: password
            };
            page.show_spinner();
            console.log(payload);
        };
        return signup;
    }(Bootstrap));
    pages.signup = signup;
})(pages || (pages = {}));
var pages;
(function (pages) {
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
            var $li = $('#' + file.id);
            var $percent = $li.find('.progress .progress-bar');
            // 避免重复创建
            if (!$percent.length) {
                $percent = $('<div class="progress progress-striped active">' +
                    '<div class="progress-bar" role="progressbar" style="width: 0%">' +
                    '</div>' +
                    '</div>').appendTo($li).find('.progress-bar');
            }
            $li.find('p.state').text("Upload ... ".concat(Strings.round(percentage * 100, 2), "%"));
            $percent.css('width', percentage * 100 + '%');
        };
        upload.prototype.on_success = function (file, response) {
            var urls = response.data;
            $('#' + file.id).addClass('upload-state-done');
            console.log(urls);
            page.hide_spinner();
        };
        upload.prototype.on_complete = function (file) {
            // alert(file.id)
            // alert(file);
            $('#' + file.id).find('.progress').remove();
            $('#' + file.id).find('p.state').text('已上传');
            // // $('.layui-video-box').html(Help.videoHtml(url, key));
            // Help.video_read();
            // location.href="http://www.xiaosan.com/tp5/public/index.php/index/backstage/vioshow";
            page.hide_spinner();
        };
        upload.prototype.on_error = function (file) {
            $('#' + file.id).find('p.state').text('上传出错');
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