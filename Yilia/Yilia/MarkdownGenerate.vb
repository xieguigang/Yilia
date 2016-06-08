Imports Microsoft.VisualBasic.MarkupLanguage
Imports Microsoft.VisualBasic.MarkupLanguage.MarkDown
Imports Yilia.Config

Public Class MarkdownGenerate

    ReadOnly _config As Configuration
    ReadOnly _engine As MarkdownHTML

    Sub New(opt As MarkdownOptions, config As Configuration)
        _engine = New MarkdownHTML(opt)
        _config = config
    End Sub

    Public Function HTML(markdown As String) As String

    End Function
End Class
