Imports SMRUCC.WebCloud.VBScript

Module test

    Sub Main()

        Dim test222222 = PostMeta.FromMarkdownFile("C:\Users\Evia\source\repos\scibasic-website\post\Microsoft\VisualBasic\Text\TextEncodings.md")

        Pause()
        pathtest()

        Call Markdown.SaveHTMLPage("G:\repo\Yilia\Yilia\wwwroot\post\hello_world.md", "G:\repo\Yilia\Yilia\wwwroot", "G:\repo\Yilia\Yilia\Yilia\bin\Debug\test")



        Pause()

        Dim post As PostMeta = PostMeta.FromMarkdownFile("G:\repo\Yilia\Yilia\site_demo\post\hello_world.md")



        Dim html$ = vbhtml.ReadHTML("G:\repo\Yilia\Yilia\site_demo", "G:\repo\Yilia\Yilia\site_demo\pages\index.vbhtml", New Dictionary(Of String, Object) From {{"post", {post}}})
        Call html.SaveTo("./test.html")
    End Sub

    Sub pathtest()
        Dim file$ = "C:/Users/Evia/source/repos/scibasic-website/post/Microsoft/VisualBasic/MIME/Markup/MarkDown/url &quot;optional title&quot;"
        Dim yes = file.PathIllegal

        Pause()
    End Sub
End Module
