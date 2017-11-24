Imports Microsoft.VisualBasic.MIME.text.yaml.Grammar
Imports Microsoft.VisualBasic.Serialization.JSON

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
    Public Property preview As String
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
        Dim meta As New Dictionary(Of String, String)

        With Strings.Split(postMarkdown, "---")
            Dim YAML = YamlParser.Load(.First)

            content = Mid(postMarkdown, .First.Length + 1).Trim

            With meta
                title = .TryGetValue(NameOf(title))
                [date] = .TryGetValue(NameOf([date]))
                updated = .TryGetValue(NameOf(updated))
                source = .TryGetValue(NameOf(source))
                categories = .TryGetValue(NameOf(categories)).StringSplit(";\s*")
                tags = .TryGetValue(NameOf(tags)).StringSplit(";\s*")
                preview = .TryGetValue(NameOf(preview))
            End With
        End With
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="md">The file path of the ``*.md`` markdown source file.</param>
    ''' <returns></returns>
    Public Shared Function FromMarkdownFile(md As String) As PostMeta
        Return New PostMeta(md.ReadAllText)
    End Function

    Public Overrides Function ToString() As String
        Return title
    End Function
End Structure
