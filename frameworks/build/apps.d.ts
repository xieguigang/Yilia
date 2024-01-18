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
