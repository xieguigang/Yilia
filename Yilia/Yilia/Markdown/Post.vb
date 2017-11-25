Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.MIME.Markup.MarkDown
Imports Microsoft.VisualBasic.Text
Imports SMRUCC.WebCloud.VBScript

Namespace Markdown

    Public Module PostExtensions

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="markdown$">post的markdown文档的文档路径</param>
        ''' <param name="wwwroot">vbhtml模板文件的文件夹</param>
        ''' <param name="saveTo$">所生成的html文件的保存路径</param>
        ''' <returns></returns>
        <Extension>
        Public Function SaveHTMLPage(markdown$, wwwroot$, saveTo$) As Boolean
            Dim post As PostMeta = PostMeta.FromMarkdownFile(md:=markdown)
            Dim source$ = markdown.ParentPath ' 得到markdown文件所在的文件夹路径，方便获取post之中的图片资源文件等

            ' 生成脚本的变量准备插入vbhtml模板之中
            Dim vars As New Dictionary(Of String, Object) From {
                {"post", post}
            }
            Dim html$ = vbhtml.ReadHTML(wwwroot, $"{wwwroot}/pages/post.vbhtml", vars)
            Dim [date] As Date = Date.Parse(post.date)
            Dim path$ = $"{saveTo}/{[date].Year}/{[date].Month}/{[date].Day}/{post.title.NormalizePathString}/index.html"

            Call saveTo.MkDIR
            Call html.SaveTo(path, TextEncodings.UTF8WithoutBOM)

            ' 从html文本之中解析出图片文件路径等资源信息，开始进行文件的复制操作

        End Function
    End Module
End Namespace