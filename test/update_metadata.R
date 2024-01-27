imports "http" from "Webkit";

for(id in 1:60) {
    sprintf("http://localhost/video/update_metadata/?id=%s", id)
    |> http::requests.get()
    |> http::content()
    |> str()
    ;
}