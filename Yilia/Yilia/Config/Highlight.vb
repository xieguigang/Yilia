Imports Microsoft.VisualBasic.Serialization

Public Class Highlight
    Public Property enable As Boolean
    Public Property line_number As Boolean
    Public Property auto_detect As Boolean
    Public Property tab_replace As String

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function
End Class
