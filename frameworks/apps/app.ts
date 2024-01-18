/// <reference path="../build/linq.d.ts" />

module apps {

    export function run() {
        Router.AddAppHandler(new pages.signup());

        Router.RunApp();
    }
}

$ts.mode = Modes.debug;
$ts(apps.run);