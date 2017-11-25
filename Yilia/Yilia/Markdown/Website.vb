Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Language.UnixBash

Public Module Website

    ' + styles/ 这个文件夹存放css文件内容
    ' + lib/    这个文件夹存放vendor javascript文件内容
    ' + js/     这个文件夹存放用户自己编写的javascript文件内容
    ' + images/ 这个文件夹存放一些网站的图片附件
    ' + fonts/  这个文件夹存放网站的字体样式

    ' + includes/ 这个文件夹存放vbhtml模板的一些组件
    ' + pages/    这个文件夹存放vbhtml页面模板文件，同时在这里的模板中也定义了页面的layout信息
    ' + post/     这个文件夹中存放用户的文章原始的markdown文件和附件图片

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="wwwroot$">网站源代码的文件夹路径</param>
    ''' <param name="publish$">生成的静态网站html文件的保存发布路径</param>
    ''' <returns></returns>
    Public Function Build(wwwroot$, publish$) As Boolean
        ' 首先进行文件的复制操作
        Dim directory As Value(Of String) = ""

        For Each component As String In {"styles", "lib", "js", "images", "fonts"}
            If (directory = $"{wwwroot}/{component}").DirectoryExists Then
                Call New Directory(directory).CopyTo(publish & "/" & component)
            End If
        Next

        For Each md As String In ls - l - r - "*.md" <= $"{wwwroot}/post"
            Call Markdown.SaveHTMLPage(
                markdown:=md,
                wwwroot:=wwwroot,
                saveTo:=publish & "/articles/")
        Next

        Return True
    End Function


End Module
