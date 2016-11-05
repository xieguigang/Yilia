Imports Microsoft.VisualBasic.Serialization.JSON

Namespace Config

    ''' <summary>
    ''' _config.yml
    ''' </summary>
    Public Class Configuration

        Public Property title As String
        Public Property subtitle As String
        Public Property description As String
        Public Property author As String
        Public Property language As String
        Public Property timezone As String
        Public Property disqus_shortname As String

        ' # URL
        ' ## If your site Is put In a subdirectory, Set url As 'http://yoursite.com/child' and root as '/child/'
        Public Property url As String
        Public Property root As String
        Public Property permalink As String
        Public Property permalink_defaults As String

        ' # Directory
        Public Property source_dir As String
        Public Property public_dir As String
        Public Property tag_dir As String
        Public Property archive_dir As String
        Public Property category_dir As String
        Public Property code_dir As String
        Public Property i18n_dir As String
        Public Property skip_render As String

        ' # Writing
        Public Property new_post_name As String
        Public Property default_layout As String
        Public Property titlecase As Boolean
        Public Property external_link As Boolean
        Public Property filename_case As Integer
        Public Property render_drafts As Boolean
        Public Property post_asset_folder As Boolean
        Public Property relative_link As Boolean
        Public Property future As Boolean
        Public Property highlight As Highlight

        ' # Category & Tag
        Public Property default_category As String
        Public Property category_map As String
        Public Property tag_map As String

        ' # Date / Time format
        ' ## Hexo uses Moment.js To parse And display Date
        ' ## You can customize the Date format As defined In
        ' ## http://momentjs.com/docs/#/displaying/format/
        Public Property date_format As String
        Public Property time_format As String

        ' # Pagination
        ' ## Set per_page To 0 To disable pagination
        Public Property per_page As String
        Public Property pagination_dir As String

        ' # Extensions
        ' ## Plugins: https://hexo.io/plugins/
        ' ## Themes: https://hexo.io/themes/
        Public Property theme As String

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Class
End Namespace