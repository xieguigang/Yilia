Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Language.UnixBash
Imports Microsoft.VisualBasic.MIME.text.yaml.Grammar
Imports Microsoft.VisualBasic.MIME.text.yaml.Syntax
Imports Microsoft.VisualBasic.Text
Imports SMRUCC.WebCloud.VBScript

Public Module Website

    ' + styles/     这个文件夹存放css文件内容
    ' + lib/vendor/ 这个文件夹存放vendor javascript文件内容
    ' + lib/        这个文件夹存放用户自己编写的javascript文件内容
    ' + images/     这个文件夹存放一些网站的图片附件
    ' + fonts/      这个文件夹存放网站的字体样式

    ' + includes/ 这个文件夹存放vbhtml模板的一些组件
    ' + pages/    这个文件夹存放vbhtml页面模板文件，同时在这里的模板中也定义了页面的layout信息
    ' + post/     这个文件夹中存放用户的文章原始的markdown文件和附件图片

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="wwwroot">网站源代码的文件夹路径</param>
    ''' <param name="publish">生成的静态网站html文件的保存发布路径</param>
    ''' <param name="doPostTricks">
    ''' 如果这个可选参数为真的话，会将文件名为post的页面单独放置在一个文件夹中
    ''' </param>
    ''' <returns></returns>
    <Extension> Public Function Build(wwwroot$, publish$, Optional postFolder$ = "articles", Optional doPostTricks As Boolean = False) As Boolean
        ' 首先进行文件的复制操作
        Dim directory As Value(Of String) = ""
        Dim path As Value(Of String) = ""

        For Each component As String In {"styles", "lib", "images", "fonts"}
            If (directory = $"{wwwroot}/{component}").DirectoryExists Then
                Call New Directory(directory).CopyTo(publish, includeSrc:=True)
            End If
        Next

        With wwwroot & "/yilia.yaml"
            If .FileExists Then
                Dim config As Dictionary(Of MappingEntry) = YamlParser _
                    .Load(wwwroot & "/yilia.yaml") _
                    .Enumerative _
                    .First

                For Each component In DirectCast(config!asserts.Value, Sequence).Enties
                    If (path = $"{wwwroot}/{component}").DirectoryExists Then
                        Call New Directory(path).CopyTo(publish, includeSrc:=True)
                    ElseIf path.Value.FileExists Then
                        Call path.Value.FileCopy(publish & "/")
                    Else
                        Call $"{component} is not avaliable!".Warning
                    End If
                Next
            End If
        End With

        For Each md As String In ls - l - r - "*.md" <= $"{wwwroot}/post"
            Call Markdown.SaveHTMLPage(
                markdown:=md,
                wwwroot:=wwwroot,
                saveTo:=$"{publish}/{postFolder}/"
            )
            Call md.__DEBUG_ECHO
        Next

        ' additional pages
        For Each page As String In ls - "*.vbhtml" <= $"{wwwroot}/pages"
            If InStr(page, ".resource.vbhtml") = 0 Then
                Dim html$ = vbhtml.ReadHTML(wwwroot, $"{wwwroot}/pages/{page}", New Dictionary(Of String, Object))
                Dim save$

                If page.BaseName.TextEquals("post") AndAlso doPostTricks Then
                    save = $"{publish}/post/index.html"
                Else
                    save = $"{publish}/{page.BaseName}.html"
                End If

                Call html.SaveTo(save, TextEncodings.UTF8WithoutBOM)
            End If
        Next

        Return True
    End Function
End Module
