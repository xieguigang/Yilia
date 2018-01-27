Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.MIME.Markup
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.ComponentModel.Algorithm.base

Namespace Markdown

    Public Class PostMeta

#Region "Front-matter"

        ''' <summary>
        ''' 文章的标题
        ''' </summary>
        ''' <returns></returns>
        Public Property title As String
        ''' <summary>
        ''' 文章的发布日期
        ''' </summary>
        ''' <returns></returns>
        Public Property [date] As Date
        ''' <summary>
        ''' 文章的更新日期
        ''' </summary>
        ''' <returns></returns>
        Public Property updated As Date
        ''' <summary>
        ''' 如果这篇文章是转载的话，原链接是哪里？
        ''' </summary>
        ''' <returns></returns>
        Public Property source As String

        ''' <summary>
        ''' 文章的分类列表，由层次分类的
        ''' </summary>
        ''' <returns></returns>
        Public Property categories As CategoryTag()
        ''' <summary>
        ''' 文章的标签列表，使用分号进行分割
        ''' </summary>
        ''' <returns></returns>
        Public Property tags As Tag()

        ''' <summary>
        ''' 在列表中的预览图的文件路径
        ''' </summary>
        ''' <returns></returns>
        Public Property preview As Previews

        Public Property URLTemplate As URLTemplate
#End Region

        ''' <summary>
        ''' Markdown content for generates html documents
        ''' </summary>
        ''' <returns></returns>
        Public Property content As String

        Sub New(meta As Yilia.PostMeta)
            With meta
                title = .title
                [date] = DateHelper(.date)
                updated = DateHelper(.updated)
                source = .source
                preview = .preview
                content = .content.Markdown2HTML
                URLTemplate = New URLTemplate With {
                    .text = meta.urlBuilder,
                    .method = meta.urlBuilder.GetMethod,
                    .fileName = meta.fileName
                }

                tags = .tags _
                       .SafeQuery _
                       .Select(Function(t) New Tag(t)) _
                       .ToArray
                categories = ("ALL" + .categories.SafeQuery.AsList) _
                    .CreateSlideWindows(slideWindowSize:=2) _
                    .Select(Function(t)
                                Return New CategoryTag(t.Last, t.First)
                            End Function) _
                    .ToArray
            End With
        End Sub

        Public Overrides Function ToString() As String
            Return $"[{[date]}] {title}"
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Private Shared Function DateHelper(s As String) As Date
            If s.StringEmpty Then
                Return Now
            Else
                Return Date.Parse(s)
            End If
        End Function
    End Class
End Namespace