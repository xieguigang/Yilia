Imports System.Text.RegularExpressions

Module SyntaxHighlight

    Public Function Marked(md As String) As String
        Dim synx As String() = Regex.Matches(md, "```.+?```").ToArray
        Return md
    End Function
End Module
