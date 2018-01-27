Imports System.ComponentModel

Public Enum URLTemplates As Integer

    Specific = 0

    ''' <summary>
    ''' ``year/month/day/title/index.html``
    ''' </summary>
    <Description("date/title")> DateTitle
    ''' <summary>
    ''' ``folder/file.md`` -> ``folder/file.html``
    ''' </summary>
    <Description("folder/file")> SourceLink

End Enum

Public Structure URLTemplate

    Dim method As URLTemplates
    Dim text As String
    Dim fileName As String

End Structure