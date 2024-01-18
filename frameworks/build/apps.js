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
        Router.RunApp();
    }
    apps.run = run;
})(apps || (apps = {}));
$ts.mode = Modes.debug;
$ts(apps.run);
var page;
(function (page) {
    function show_spinner() {
        $ts("#preloder").style.background = "#000000c7";
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
//# sourceMappingURL=apps.js.map