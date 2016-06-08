﻿Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.MarkupLanguage
Imports Microsoft.VisualBasic.MarkupLanguage.MarkDown
Imports Microsoft.VisualBasic.Serialization
Imports Yilia.Config
Imports Yilia.Db

Public Class MarkdownGenerate

    ReadOnly _config As Configuration
    ReadOnly _engine As MarkdownHTML

    Sub New(opt As MarkdownOptions, config As Configuration)
        _engine = New MarkdownHTML(opt)
        _config = config
    End Sub

    Public Function ToHTML(markdown As String) As String
        Dim meta As PostMeta = TryParseMeta(markdown)
        Dim body As String = _engine.Transform(markdown)
        Dim html As New StringBuilder(markdown.Length)

        Call html.AppendLine($"<body>
{body}
</body>")

        Return html.ToString
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
    Public Property link As String

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
