/// <reference path="linq.d.ts" />
declare module apps {
    function run(): void;
}
declare namespace pages {
    class signup extends Bootstrap {
        get appName(): string;
        protected init(): void;
    }
}
