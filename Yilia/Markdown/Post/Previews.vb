Imports Microsoft.VisualBasic.MIME.text.yaml.Syntax

Namespace Markdown

    Public Class Previews

        Public Property small As String
        Public Property large As String
        Public Property caption As String

        Public Overrides Function ToString() As String
            Return caption
        End Function

        ''' <summary>
        ''' previews可以有两种模式：
        ''' 
        ''' + 只有一个url
        ''' + fancybox模式
        ''' </summary>
        ''' <param name="yaml"></param>
        ''' <returns></returns>
        Public Shared Function FromYAML(yaml As DataItem) As Previews
            If yaml Is Nothing Then
                Return New Previews
            ElseIf TypeOf yaml Is Scalar Then
                Dim url$ = DirectCast(yaml, Scalar).Text

                Return New Previews With {
                    .caption = "",
                    .large = url,
                    .small = url
                }
            Else
                Dim data = DirectCast(yaml, Mapping).Enties.ToDictionary
                Dim getValue = Function(key As String)
                                   Return TryCast(data.TryGetValue(key)?.Value, Scalar)?.Text
                               End Function

                Return New Previews With {
                    .caption = getValue(NameOf(caption)),
                    .large = getValue(NameOf(large)),
                    .small = getValue(NameOf(small))
                }
            End If
        End Function
    End Class
End Namespace