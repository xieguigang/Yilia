Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection

Module CLI

    <ExportAPI("/server")>
    Public Function RunServer(args As CommandLine) As Integer

    End Function

    <ExportAPI("/generate")>
    Public Function Generate(args As CommandLine) As Integer
        Dim config As Config = ConfigAPI.LoadConfig
    End Function
End Module
