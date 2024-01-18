module page {

    export function show_spinner() {
        $ts("#preloder").style.background = "#000000c7";
        $ts("#preloder").show();
        $ts("#spinner").show();
    }

    export function hide_spinner() {
        $ts("#preloder").hide();
        $ts("#spinner").hide();
    }
}