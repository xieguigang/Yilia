Imports System.IO
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.Ranges
Imports Microsoft.VisualBasic.Language.UnixBash
Imports Microsoft.VisualBasic.Net.Protocols
Imports Microsoft.VisualBasic.Net.Protocols.ContentTypes
Imports SMRUCC.WebCloud.HTTPInternal.AppEngine
Imports SMRUCC.WebCloud.HTTPInternal.AppEngine.APIMethods
Imports SMRUCC.WebCloud.HTTPInternal.AppEngine.APIMethods.Arguments
Imports SMRUCC.WebCloud.HTTPInternal.Platform

<[Namespace]("stream")> Public Class VideoStream
    Inherits WebApp

    ''' <summary>
    ''' The media source directory
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property src As String
    Public ReadOnly Property bufferSize As Integer

    Public Sub New(main As PlatformEngine)
        MyBase.New(main)

        src = App.GetVariable("DIR")

        For Each file As String In ls - l - r - "*.*" <= src
            Call file.__DEBUG_ECHO
        Next

        bufferSize = App.GetVariable("buffer_size")

        If bufferSize <= 0 Then
            bufferSize = 4096 * 1024 * 16  ' 默认是64MB缓存
        End If

        Call main.AppManager.Join("/player.html", New [GET](GetType(String)), GetType(VideoStream).GetMethod(NameOf(LoadPlayer)), Me)
    End Sub

    <ExportAPI("/stream/player.vbs")>
    <[GET](GetType(Byte()))>
    Public Function Read(request As HttpRequest, response As HttpResponse) As Boolean
        Dim name$ = request.URLParameters("name")
        Dim path As String = src & "/" & name
        Dim ext As String = IO.Path.GetExtension(path).ToLower
        Dim type As ContentType = ContentTypes.ExtDict(ext)
        Dim buffer As Byte() = New Byte(bufferSize) {}
        Dim range As String() = request.HttpHeaders.TryGetValue("Range").Split("="c).Last.Split("-"c)
        Dim start As Long = Val(range(0))

        Using reader As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
            Call response.WriteHeader(type.MIMEType, reader.Length)
            Call reader.Seek(start, SeekOrigin.Begin)

            Do While reader.Position <= reader.Length
                Call reader.Read(buffer, Scan0, buffer.Length)
                Call response.Write(buffer)
            Loop
        End Using

        Return True
    End Function

    Public Function LoadPlayer(request As HttpRequest, response As HttpResponse) As Boolean
        Dim path$ = PlatformEngine.MapPath("player.html")
        Dim html$ = path.ReadAllText
        Dim name$ = request.URLParameters("file")

        Call response.WriteHTML(html.Replace("$file", name))

        Return True
    End Function

    Public Overrides Function Page404() As String
        Return ""
    End Function
End Class
