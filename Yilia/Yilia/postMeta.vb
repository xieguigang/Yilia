Imports Microsoft.VisualBasic.Serialization.JSON

Public Structure PostMeta

    Public Property title As String
    Public Property [date] As String
    Public Property source As String
    Public Property raw As String
    Public Property slug As String
    Public Property layout As String
    Public Property photos As String

    ''' <summary>
    ''' HTML文件所保存的文件路径
    ''' </summary>
    ''' <returns></returns>
    Public Property link As String

    ''' <summary>
    ''' HTML of the generate document from markdown
    ''' </summary>
    ''' <returns></returns>
    Public Property content As String

    Sub New(s As String)
        Dim lines As String() = s.lTokens
        Dim hash As New Dictionary(Of String, String)

        For i As Integer = 1 To lines.Length - 2
            Dim line As String = lines(i)
            Dim value = line.GetTagValue(":")
            hash.Add(Trim(value.Name).ToLower, Trim(value.x))
        Next

        VBDebugger.Mute = True

        title = hash.TryGetValue(NameOf(title))
        [date] = hash.TryGetValue(NameOf([date]))
        source = hash.TryGetValue(NameOf(source))
        raw = hash.TryGetValue(NameOf(raw))
        slug = hash.TryGetValue(NameOf(slug))
        layout = hash.TryGetValue(NameOf(layout))
        photos = hash.TryGetValue(NameOf(photos))
        link = hash.TryGetValue(NameOf(link))

        VBDebugger.Mute = False
    End Sub

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function
End Structure
