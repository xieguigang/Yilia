module page {

    export function show_spinner(mask: string = "#000000c7") {
        $ts("#preloder").style.background = mask;
        $ts("#preloder").show();
        $ts("#spinner").show();
    }

    export function hide_spinner() {
        $ts("#preloder").hide();
        $ts("#spinner").hide();
    }
}