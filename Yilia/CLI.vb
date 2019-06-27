﻿Imports System.ComponentModel
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Language.UnixBash
Imports Microsoft.VisualBasic.Net.Http

Module CLI

    <ExportAPI("/server")>
    Public Function RunServer(args As CommandLine) As Integer
        'Dim config As Configuration = ConfigAPI.LoadConfig
        'Dim mdOpts As MarkdownOptions = ConfigAPI.LoadMarkdownOptions
        'Dim engine As New MarkdownGenerate(mdOpts, config)

        'Using server As New Server(engine)
        '    Return server.Run
        'End Using
    End Function

    <ExportAPI("/build")>
    <Usage("/build [/wwwroot <directory, default=./> /post.folder <directoryName, default=articles> /publish <directory, default=./publish>]")>
    <Description("Generates the statics html document files for your website. And you can host your generated website on github page.")>
    <Argument("/wwwroot", True, CLITypes.Boolean,
              AcceptTypes:={GetType(Boolean)},
              Description:="The website content directory root. You can using the ``/init`` command for create the directories.")>
    Public Function Generate(args As CommandLine) As Integer
        Dim wwwroot$ = args("/wwwroot") Or App.CurrentDirectory
        Dim publish$ = args("/publish") Or $"{App.CurrentDirectory}/publish/"
        Dim postFolder$ = args("/post.folder") Or "articles"

        Return Website _
            .Build(
                wwwroot:=wwwroot.GetDirectoryFullPath,
                publish:=publish.GetDirectoryFullPath,
                postFolder:=postFolder
            ) _
            .CLICode
    End Function

    <ExportAPI("/init")>
    <Usage("/init [/wwwroot <directory, default=./>]")>
    Public Function Init(args As CommandLine) As Integer
        Dim wwwroot$ = args("/wwwroot") Or "./"
        Dim tmp$ = App.GetAppSysTempFile(".zip", sessionID:=App.PID)

        Call My.Resources._default.FlushStream(tmp)
        Call ZipLib.ImprovedExtractToDirectory(tmp, wwwroot, Overwrite.Always)

        Return 0
    End Function

    ''' <summary>
    ''' Scan all of the markdown and html file for create sitemap.xml
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("/sitemap")>
    <Usage("/sitemap [/wwwroot <default=./>]")>
    Public Function ScanSiteMap(args As CommandLine) As Integer
        Dim wwwroot$ = args("/wwwroot") Or "./"
        Dim files = (ls - l - r - {"*.html", "*.htm", "*.md"} <= wwwroot).ToArray

        With wwwroot.GetDirectoryFullPath
            Dim rels = files _
                .Select(Function(path) "/" & path.Replace(.ByRef, "").Trim("/"c)) _
                .Select(Function(rel)
                            Return New sitemap.url With {
                                .loc = rel,
                                .changefreq = "",
                                .lastmod = Now.ToString,
                                .priority = 0.7
                            }
                        End Function) _
                .ToArray
            Dim sitemap As New sitemap With {
                .urls = rels
            }

            Return sitemap.GetXml _
                .SaveTo($"{wwwroot}/sitemap.xml") _
                .CLICode
        End With
    End Function
End Module
