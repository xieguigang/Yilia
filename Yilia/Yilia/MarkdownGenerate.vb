Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.MarkupLanguage
Imports Microsoft.VisualBasic.MarkupLanguage.HTML.Head
Imports Microsoft.VisualBasic.MarkupLanguage.MarkDown
Imports Microsoft.VisualBasic.Serialization
Imports Yilia.Config
Imports Yilia.Db

Public Class MarkdownGenerate

    ReadOnly _config As Configuration
    ReadOnly _engine As MarkdownHTML
    ReadOnly _root As String = App.CurrentDirectory

    Sub New(opt As MarkdownOptions, config As Configuration)
        _engine = New MarkdownHTML(opt)
        _config = config

        Call My.Resources.marked.SaveTo(_root & $"/{_config.public_dir}/js/marked.js")
    End Sub

    Public Function ToHTML(path As String) As PostMeta
        Dim markdown As String = path.GET
        Dim meta As PostMeta = TryParseMeta(markdown)
        Dim body As String = _engine.Transform(markdown)
        Dim html As New StringBuilder(markdown.Length)
        Dim head As New HeadMeta With {
            .Title = meta.title,
            .Scripts = New Script() {
                New ScriptRef With {
                    .src = "/js/marked.js"
                }
            }
        }

        Call html.AppendLine("
<!DOCTYPE html>
<html>")
        Call html.AppendLine(head.ToString)
        Call html.AppendLine($"<body>
{body}
</body>")
        Call html.AppendLine("</html>")

        meta.content = html.ToString
        meta.link = GetPath(path, meta)

        Return meta
    End Function

    Const PostDIR As String = "_posts"

    Public Function GetPath(path As String, meta As PostMeta) As String
        Dim rel As String = path.Replace(_root & "\" & _config.source_dir & "\", "")
        Dim root As String = rel.Split("\"c).First
        Dim publish As String = $"{App.CurrentDirectory}/{_config.public_dir}"

        If String.Equals(root, PostDIR, StringComparison.OrdinalIgnoreCase) Then
            Dim [date] As Date = If(meta.date.IsBlank, Now, Date.Parse(meta.date))
            Dim parent As String = rel.ParentPath(False)
            parent = parent.Replace(PostDIR, "")
            Dim out As String = $"{publish}/{[date].Year}/{[date].Month}/{[date].Day}/{parent}/{path.BaseName}/index.html"
            Return out
        Else
            Dim out As String = $"{publish}/{rel.Replace(".md", "")}.html"
            Return out
        End If
    End Function

    Public Shared Function TryParseMeta(ByRef md As String) As PostMeta
        Dim head As String = Regex.Match(md, "---.+?\n---", RegexOptions.Singleline).Value
        md = Mid(md, Len(head) + 1).Trim
        Return New PostMeta(head)
    End Function
End Class

Public Structure PostMeta

    Public Property title As String
    Public Property [date] As String
    Public Property source As String
    Public Property raw As String
    Public Property slug As String
    Public Property layout As String
    Public Property photos As String

    ''' <summary>
    ''' HTML文件所保存的文件路径
    ''' </summary>
    ''' <returns></returns>
    Public Property link As String

    ''' <summary>
    ''' HTML of the generate document from markdown
    ''' </summary>
    ''' <returns></returns>
    Public Property content As String

    Sub New(s As String)
        Dim lines As String() = s.lTokens
        Dim hash As New Dictionary(Of String, String)

        For i As Integer = 1 To lines.Length - 2
            Dim line As String = lines(i)
            Dim value = line.GetTagValue(":")
            hash.Add(Trim(value.Name).ToLower, Trim(value.x))
        Next

        VBDebugger.Mute = True

        title = hash.TryGetValue(NameOf(title))
        [date] = hash.TryGetValue(NameOf([date]))
        source = hash.TryGetValue(NameOf(source))
        raw = hash.TryGetValue(NameOf(raw))
        slug = hash.TryGetValue(NameOf(slug))
        layout = hash.TryGetValue(NameOf(layout))
        photos = hash.TryGetValue(NameOf(photos))
        link = hash.TryGetValue(NameOf(link))

        VBDebugger.Mute = False
    End Sub

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function
End Structure
