setwd(@dir);

let build = "./build";
let release = "../src/resources/js";

let release_file = function(name) {
    file.copy(`${build}/${name}`, `${release}/${name}`);
}

release_file("linq.js");
release_file("apps.js");