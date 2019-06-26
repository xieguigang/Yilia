Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Text
Imports Microsoft.VisualBasic.Text.Parser.HtmlParser
Imports SMRUCC.WebCloud.VBScript

Namespace Markdown

    Public Module PostExtensions

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <Extension>
        Public Function DataModel(meta As Yilia.PostMeta) As PostMeta
            Return New PostMeta(meta)
        End Function

        <Extension>
        Public Function GetMethod(text As String) As URLTemplates
            If text.TextEquals(URLTemplates.DateTitle.Description) Then
                Return URLTemplates.DateTitle
            ElseIf text.TextEquals(URLTemplates.SourceLink.Description) Then
                Return URLTemplates.SourceLink
            Else
                Return URLTemplates.Specific
            End If
        End Function

        ''' <summary>
        ''' 使用这个函数必须要存在``/pages/post.vbhtml``模板文件
        ''' </summary>
        ''' <param name="markdown$">post的markdown文档的文档路径</param>
        ''' <param name="wwwroot">vbhtml模板文件的文件夹</param>
        ''' <param name="saveTo$">所生成的html文件的保存路径</param>
        <Extension> Public Sub SaveHTMLPage(markdown$, wwwroot$, saveTo$)
            Dim post As PostMeta = Yilia.PostMeta _
                .FromMarkdownFile(md:=markdown) _
                .DataModel

            ' 生成脚本的变量准备插入vbhtml模板之中
            Dim vars As New Dictionary(Of String, Object) From {
                {"post", post},
                {"post.tags", post.tags},
                {"post.categories", post.categories},
                {"post.preview", post.preview},
                {"title", post.title}
            }
            Dim html$ = vbhtml.ReadHTML(wwwroot, $"{wwwroot}/pages/post.vbhtml", vars)
            Dim path = saveTo & "/" & post.GetURL(wwwroot:=wwwroot & "/post/")

            Call saveTo.MkDIR
            Call html.SaveTo(path, TextEncodings.UTF8WithoutBOM)

            ' 从html文本之中解析出图片文件路径等资源信息，开始进行文件的复制操作
            ' 得到markdown文件所在的文件夹路径，方便获取post之中的图片资源文件等
            Dim source$ = markdown.ParentPath
            ' 进行文件复制操作的目标文件夹
            Dim target$ = path.ParentPath
            Dim images = post.content.GetImageLinks

            For Each url As String In images
                Dim src$ = $"{source}/{url}".GetFullPath
                Dim tar$ = $"{target}/{url}".GetFullPath

                If src.PathIllegal Then
                    Call url.PrintException
                Else
                    Call tar.ParentPath.MkDIR
                    Call FileSystem.FileCopy(src, tar)
                End If
            Next
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="post"></param>
        ''' <param name="wwwroot$"></param>
        ''' <returns></returns>
        <Extension> Public Function GetURL(post As PostMeta, wwwroot$) As String
            Dim path$

            Select Case post.URLTemplate.method
                Case URLTemplates.DateTitle

                    Dim [date] As Date = post.date
                    Dim name$ = post.title.NormalizePathString.Replace(" ", "-")

                    path = $"/{[date].Year}/{[date].Month}/{[date].Day}/{name}/index.html"

                Case URLTemplates.SourceLink

                    wwwroot = wwwroot.GetDirectoryFullPath
                    path = post.URLTemplate.fileName.GetFullPath.ChangeSuffix("html")
                    path = path.GetFullPath.Replace(wwwroot, "")

                Case Else

                    path = post.URLTemplate.text

            End Select

            Return path
        End Function
    End Module
End Namespace