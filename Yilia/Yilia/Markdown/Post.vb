Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.MIME.Markup.MarkDown

Namespace Markdown

    Public Module PostExtensions

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="markdown$">post的markdown文档的文档路径</param>
        ''' <param name="template$">vbhtml模板文件</param>
        ''' <param name="saveTo$">所生成的html文件的保存路径</param>
        ''' <returns></returns>
        <Extension>
        Public Function SaveHTMLPage(markdown$, template$, saveTo$) As Boolean
            Dim post As PostMeta = PostMeta.FromMarkdownFile(md:=markdown)
            Dim source$ = markdown.ParentPath ' 得到markdown文件所在的文件夹路径，方便获取post之中的图片资源文件等

            ' 生成脚本的变量准备插入vbhtml模板之中


            Call saveTo.MkDIR

        End Function
    End Module
End Namespace