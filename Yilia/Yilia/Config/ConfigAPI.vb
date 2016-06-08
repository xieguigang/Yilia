Imports Microsoft.VisualBasic.MarkupLanguage
Imports Microsoft.VisualBasic.MarkupLanguage.YAML
Imports Microsoft.VisualBasic.MarkupLanguage.YAML.Grammar
Imports Microsoft.VisualBasic.MarkupLanguage.YAML.Syntax
Imports Microsoft.VisualBasic.Serialization

Namespace Config

    Module ConfigAPI

        Public Function LoadConfig(path As String) As Configuration
            Dim config As String = path.GetFullPath
            Return path.LoadYAML(Of Configuration)
        End Function

        ''' <summary>
        ''' 加载当前的工作目录之下的_config.yml配置文件
        ''' </summary>
        ''' <returns></returns>
        Public Function LoadConfig() As Configuration
            Return LoadConfig(App.CurrentDirectory & "/_config.yml")
        End Function

        Public ReadOnly Property MarkdownOptions As String
            Get
                Return App.CurrentDirectory & "/markdown_opts.json"
            End Get
        End Property

        Public Function LoadMarkdownOptions() As MarkdownOptions
            Dim path As String = MarkdownOptions
            Dim opt As MarkdownOptions

            If Not path.FileExists Then
__NEW:
                opt = New MarkdownOptions
                Call opt.GetJson.SaveTo(path)
            Else
                opt = path.ReadAllText.LoadObject(Of MarkdownOptions)
                If opt Is Nothing Then
                    GoTo __NEW
                End If
            End If

            Return opt
        End Function
    End Module
End Namespace