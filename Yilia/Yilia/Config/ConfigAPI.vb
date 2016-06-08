Imports Microsoft.VisualBasic.MarkupLanguage.YAML
Imports Microsoft.VisualBasic.MarkupLanguage.YAML.Grammar
Imports Microsoft.VisualBasic.MarkupLanguage.YAML.Syntax

Module ConfigAPI

    Public Function LoadConfig(path As String) As Config
        Dim config As String = path.GetFullPath
        Return path.LoadYAML(Of Config)
    End Function

    ''' <summary>
    ''' 加载当前的工作目录之下的_config.yml配置文件
    ''' </summary>
    ''' <returns></returns>
    Public Function LoadConfig() As Config
        Return LoadConfig(App.CurrentDirectory & "/_config.yml")
    End Function
End Module
