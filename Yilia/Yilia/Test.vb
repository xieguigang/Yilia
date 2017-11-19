Imports SMRUCC.WebCloud.VBScript

Module Test

    Sub Main()
        Dim post As New PostMeta
        Dim html$ = vbhtml.ReadHTML("G:\repo\Yilia\Yilia\site_demo", "G:\repo\Yilia\Yilia\site_demo\pages\index.vbhtml", New Dictionary(Of String, Object) From {{"post", {post}}})
        Call html.SaveTo("./test.html")
    End Sub
End Module
