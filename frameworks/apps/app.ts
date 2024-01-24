/// <reference path="../build/linq.d.ts" />

module apps {

    export function run() {
        Router.AddAppHandler(new pages.signup());
        Router.AddAppHandler(new pages.login());

        Router.AddAppHandler(new pages.upload());
        Router.AddAppHandler(new pages.play());
        Router.AddAppHandler(new pages.anime_play());

        Router.AddAppHandler(new pages.index_home());

        Router.RunApp();
    }
}

$ts.mode = Modes.debug;
$ts(apps.run);