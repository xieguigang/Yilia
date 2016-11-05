Imports System.Text
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Language.UnixBash
Imports Microsoft.VisualBasic.MIME.Markup.MarkDown
Imports Yilia.Config

Module CLI

    <ExportAPI("/server")>
    Public Function RunServer(args As CommandLine) As Integer
        Dim config As Configuration = ConfigAPI.LoadConfig
        Dim mdOpts As MarkdownOptions = ConfigAPI.LoadMarkdownOptions
        Dim engine As New MarkdownGenerate(mdOpts, config)

        Using server As New Server(engine)
            Return server.Run
        End Using
    End Function

    <ExportAPI("/generate")>
    Public Function Generate(args As CommandLine) As Integer
        Dim config As Configuration = ConfigAPI.LoadConfig
        Dim mdOpts As MarkdownOptions = ConfigAPI.LoadMarkdownOptions
        Dim engine As New MarkdownGenerate(mdOpts, config)

        For Each file As String In ls - l - r - wildcards("*.md") <= (App.CurrentDirectory & "/" & config.source_dir)
            Dim html As PostMeta = engine.ToHTML(file)
            Call html.content.SaveTo(html.link, Encoding.UTF8)
        Next

        Return 0
    End Function
End Module
