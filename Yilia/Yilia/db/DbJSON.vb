Imports Microsoft.VisualBasic.Serialization.JSON

Namespace Db

    Public Class DbJSON
        Public Property meta As meta
        Public Property models As models

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Class

    Public Structure meta
        Public Property version As String
        Public Property warehouse As String

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Structure

    Public Class asset : Inherits Item

        Public Property path As String
        Public Property modified As String
        Public Property renderable As String

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Class

    Public MustInherit Class Item
        Public Property _id As String
    End Class

    Public Class cache : Inherits Item
        Public Property hash As String
        Public Property modified As String
    End Class

    Public Class models
        Public Property Asset As asset()
        Public Property Cache As cache()
        Public Property Page As Page()
        Public Property Post As Post()
        Public Property PostTag As PostTag()
        Public Property Tag As Tag()

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Class

    Public Class Tag : Inherits Item
        Public Property name As String

    End Class

    Public Class PostTag : Inherits Item

        Public Property post_id As String
        Public Property tag_id As String

    End Class

    Public Class Post : Inherits Item
        Public Property title As String
        Public Property [date] As String
        Public Property _content As String
        Public Property source As String
        Public Property raw As String
        Public Property slug As String
        Public Property published As String
        Public Property updated As String
        Public Property comments As String
        Public Property layout As String
        Public Property photos As String
        Public Property link As String
        Public Property content As String
            Get
                Return _cstr
            End Get
            Set(value As String)
                _cstr = value
            End Set
        End Property
        Public Property excerpt As String
        Public Property more As String

        Dim _cstr As String

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Class

    Public Class Page : Inherits Item
        Public Property title As String
        Public Property [date] As String
        Public Property _content As String
        Public Property source As String
        Public Property raw As String
        Public Property updated As String
        Public Property path As String
        Public Property comments As String
        Public Property layout As String
        Public Property content As String
            Get
                Return _cstr
            End Get
            Set(value As String)
                _cstr = value
            End Set
        End Property
        Public Property excerpt As String
        Public Property more As String

        Dim _cstr As String

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Class
End Namespace