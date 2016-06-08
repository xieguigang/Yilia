Imports System.IO

Public Class FileSystem

    Dim WithEvents fs As FileSystemWatcher

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="source">*.md</param>
    Sub New(source As String)
        fs = New FileSystemWatcher(source, "*.*")
    End Sub

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
End Class
