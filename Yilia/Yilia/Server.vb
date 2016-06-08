Imports System.IO
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports SMRUCC.HTTPInternal.Platform

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
        httpd = New PlatformEngine(__cache)
    End Sub

    Public Function Run() As Integer Implements IObjectModel_Driver.Run
        Return httpd.Run()
    End Function

    Private Sub fs_Changed(sender As Object, e As FileSystemEventArgs) Handles fs.Changed

    End Sub

    Private Sub fs_Created(sender As Object, e As FileSystemEventArgs) Handles fs.Created

    End Sub

    Private Sub fs_Deleted(sender As Object, e As FileSystemEventArgs) Handles fs.Deleted

    End Sub

    Private Sub fs_Disposed(sender As Object, e As EventArgs) Handles fs.Disposed

    End Sub

    Private Sub fs_Error(sender As Object, e As ErrorEventArgs) Handles fs.[Error]

    End Sub

    Private Sub fs_Renamed(sender As Object, e As RenamedEventArgs) Handles fs.Renamed

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
