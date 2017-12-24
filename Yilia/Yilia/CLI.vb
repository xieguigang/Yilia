Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection

Module CLI

    <ExportAPI("/server")>
    Public Function RunServer(args As CommandLine) As Integer
        'Dim config As Configuration = ConfigAPI.LoadConfig
        'Dim mdOpts As MarkdownOptions = ConfigAPI.LoadMarkdownOptions
        'Dim engine As New MarkdownGenerate(mdOpts, config)

        'Using server As New Server(engine)
        '    Return server.Run
        'End Using
    End Function

    <ExportAPI("/generate")>
    <Usage("/generate [/wwwroot <directory> /publish <directory>]")>
    Public Function Generate(args As CommandLine) As Integer
        Dim wwwroot$ = args("/wwwroot") Or App.CurrentDirectory
        Dim publish$ = args("/publish") Or $"{App.CurrentDirectory}/publish/"

        Return Website.Build(wwwroot, publish).CLICode
    End Function
End Module
