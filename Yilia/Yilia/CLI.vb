Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.MarkupLanguage
Imports Microsoft.VisualBasic.Language.UnixBash
Imports Yilia.Config

Module CLI

    <ExportAPI("/server")>
    Public Function RunServer(args As CommandLine) As Integer

    End Function

    <ExportAPI("/generate")>
    Public Function Generate(args As CommandLine) As Integer
        Dim config As Configuration = ConfigAPI.LoadConfig
        Dim mdOpts As MarkdownOptions = ConfigAPI.LoadMarkdownOptions
        Dim engine As New MarkdownGenerate(mdOpts, config)

        For Each file As String In ls - l - r - wildcards("*.md") <= (App.CurrentDirectory & "/" & config.source_dir)
            Dim md As String = file.GET()
            Dim html As String = engine.HTML(md)
            Dim rel As String = ProgramPathSearchTool.RelativePath(file, App.CurrentDirectory)
            Dim out As String = $"{App.CurrentDirectory}/{config.public_dir}/{file.ParentPath}/index.html"
            Call html.SaveTo(out)
        Next

        Return 0
    End Function
End Module
