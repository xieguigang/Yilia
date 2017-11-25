Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.Repository

Namespace Markdown

    Public Class Tag : Implements INamedValue

        Public Property name As String Implements IKeyedEntity(Of String).Key
        Public Property url As String

        Sub New(name As String)
            Me.name = name
            Me.url = $"/tags/{name}/"
        End Sub

        Public Overrides Function ToString() As String
            Return $"{name}: {url}"
        End Function
    End Class

    Public Class CategoryTag : Inherits Tag

        Public Property Parent As String

        Sub New(tag$, parent$)
            Call MyBase.New(tag)

            Me.url = $"/category/{tag}"
            Me.Parent = parent
        End Sub
    End Class
End Namespace