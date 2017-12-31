Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.MIME.Markup
Imports Microsoft.VisualBasic.MIME.text.yaml.Grammar
Imports Microsoft.VisualBasic.MIME.text.yaml.Syntax
Imports Yilia.Markdown

''' <summary>
''' https://hexo.io/zh-cn/docs/front-matter.html
''' </summary>
Public Structure PostMeta

#Region "Front-matter"

    ''' <summary>
    ''' 文章的标题
    ''' </summary>
    ''' <returns></returns>
    Public Property title As String
    ''' <summary>
    ''' 文章的发布日期
    ''' </summary>
    ''' <returns></returns>
    Public Property [date] As String
    ''' <summary>
    ''' 文章的更新日期
    ''' </summary>
    ''' <returns></returns>
    Public Property updated As String
    ''' <summary>
    ''' 如果这篇文章是转载的话，原链接是哪里？
    ''' </summary>
    ''' <returns></returns>
    Public Property source As String

    ''' <summary>
    ''' 文章的分类列表，由层次分类的
    ''' </summary>
    ''' <returns></returns>
    Public Property categories As String()
    ''' <summary>
    ''' 文章的标签列表，使用分号进行分割
    ''' </summary>
    ''' <returns></returns>
    Public Property tags As String()

    ''' <summary>
    ''' 在列表中的预览图的文件路径
    ''' </summary>
    ''' <returns></returns>
    Public Property preview As Previews
#End Region

    ''' <summary>
    ''' Markdown content for generates html documents
    ''' </summary>
    ''' <returns></returns>
    Public Property content As String

    ''' <summary>
    ''' 从文章的源markdown文本内容之中创建文章的模型
    ''' </summary>
    ''' <param name="postMarkdown"></param>
    Sub New(postMarkdown As String)
        With Strings.Split(postMarkdown, "---")
            Dim meta As Dictionary(Of MappingEntry) = YamlParser _
                .Load(.First) _
                .Enumerative _
                .First
            Dim getText = Function(key As String)
                              Return DirectCast(meta.TryGetValue(key).Value, Scalar).Text
                          End Function

            content = Mid(postMarkdown, .First.Length + 4).Trim

            title = getText(NameOf(title))
            [date] = getText(NameOf([date]))
            updated = getText(NameOf(updated))
            source = getText(NameOf(source))
            preview = Previews.FromYAML(meta.TryGetValue(NameOf(preview)).Value)
            tags = getText(NameOf(tags)).StringSplit(";\s*")

            With meta _
                .TryGetValue(NameOf(categories)) _
                .Value

                categories = DirectCast(.ref, Sequence) _
                    .Enties _
                    .Select(Function(t)
                                Return DirectCast(t, Scalar).Text
                            End Function) _
                    .ToArray
            End With
        End With
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="md">The file path of the ``*.md`` markdown source file.</param>
    ''' <returns></returns>
    ''' 
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Shared Function FromMarkdownFile(md As String) As PostMeta
        Return New PostMeta(md.ReadAllText)
    End Function

    Public Overrides Function ToString() As String
        Return title
    End Function
End Structure
