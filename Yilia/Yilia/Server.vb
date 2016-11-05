Imports System.IO
Imports System.Text
Imports System.Threading
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Language.UnixBash
Imports Microsoft.VisualBasic.Serialization.JSON
Imports SMRUCC.WebCloud.HTTPInternal.Platform

Public Class Server : Implements IDisposable
    Implements IObjectModel_Driver

    Dim WithEvents fs As FileSystemWatcher
    Dim _engine As MarkdownGenerate
    Dim httpd As PlatformEngine

    ''' <summary>
    ''' httpd的html缓存文件夹
    ''' </summary>
    ReadOnly __cache As String = App.GetAppSysTempFile

    ''' <summary>
    ''' 
    ''' </summary>
    Sub New(engine As MarkdownGenerate)
        _engine = engine
        httpd = New PlatformEngine(__cache, nullExists:=True)
        fs = New FileSystemWatcher(_engine.MarkdownDIR)
        fs.IncludeSubdirectories = True
        fs.Filter = "*.*"
        fs.NotifyFilter = NotifyFilters.FileName Or NotifyFilters.Size Or NotifyFilters.DirectoryName
        fs.EnableRaisingEvents = True
    End Sub

    Public Function Run() As Integer Implements IObjectModel_Driver.Run
        Call My.Resources.marked.SaveTo(__cache & "/js/marked.js")

        For Each file As String In ls - l - r - "*.md" <= _engine.MarkdownDIR
            Call Update(file)
        Next

        Return httpd.Run()
    End Function

    Private Sub Update(mdFile As Value(Of String))
        Dim post As PostMeta = _engine.ToHTML(mdFile = (+mdFile).GetFullPath)
        Dim path As String = _engine.GetPath(mdFile, post, __cache)
        Call post.content.SaveTo(path, Encoding.UTF8)
        paths((+mdFile).GetFullPath) = path
    End Sub

    Private Sub fs_Changed(sender As Object, e As FileSystemEventArgs) Handles fs.Changed
        Call Thread.Sleep(1000)
        Call Update(e.FullPath)
    End Sub

    Private Sub fs_Created(sender As Object, e As FileSystemEventArgs) Handles fs.Created
        Call Thread.Sleep(1000)
        Call Update(e.FullPath)
    End Sub

    ''' <summary>
    ''' {source, cache}
    ''' </summary>
    Dim paths As New Dictionary(Of String, String)

    Private Sub fs_Deleted(sender As Object, e As FileSystemEventArgs) Handles fs.Deleted
        Dim path As String = e.FullPath.GetFullPath

        If paths.ContainsKey(path) Then
            Dim s As String = paths(path)
            path = s
        Else
            Return
        End If

        Try
            Call FileIO.FileSystem.DeleteFile(path)
        Catch ex As Exception
            ex = New Exception(path, ex)
            ex = New Exception(e.GetJson, ex)
            Call App.LogException(ex)
        End Try
    End Sub

    Private Sub fs_Error(sender As Object, e As ErrorEventArgs) Handles fs.[Error]
        Call App.LogException(e.GetException)
    End Sub

    Private Sub fs_Renamed(sender As Object, e As RenamedEventArgs) Handles fs.Renamed
        Call Thread.Sleep(1000)

        Dim post As PostMeta = MarkdownGenerate.TryParseMeta(e.FullPath.ReadAllText)
        Dim path As String = _engine.GetPath(e.OldFullPath, post)

        Try
            Call Update(e.FullPath)
            Call FileIO.FileSystem.DeleteFile(path)
        Catch ex As Exception
            ex = New Exception(path, ex)
            ex = New Exception(e.FullPath, ex)
            ex = New Exception(e.OldFullPath, ex)
            Call App.LogException(ex)
        End Try
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                Call httpd.Dispose()
                Call fs.Dispose()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
