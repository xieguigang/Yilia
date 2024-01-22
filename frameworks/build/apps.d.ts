/// <reference path="linq.d.ts" />
declare module apps {
    function run(): void;
}
declare module page {
    function show_spinner(): void;
    function hide_spinner(): void;
}
declare namespace pages {
    class signup extends Bootstrap {
        get appName(): string;
        protected init(): void;
        signup_onclick(): void;
    }
}
declare namespace pages {
    interface WebUploader {
        upload(): unknown;
        on(evt: string, arg1: (file: UploadFile, arg2?: any) => void): unknown;
    }
    interface UploadFile {
        size: number;
        name: string;
        id: string;
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
