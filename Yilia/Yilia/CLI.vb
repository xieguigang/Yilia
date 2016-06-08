Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Yilia.Config

Module CLI

    <ExportAPI("/server")>
    Public Function RunServer(args As CommandLine) As Integer

    End Function

    <ExportAPI("/generate")>
    Public Function Generate(args As CommandLine) As Integer
        Dim config As Configuration = ConfigAPI.LoadConfig
    End Function
End Module
