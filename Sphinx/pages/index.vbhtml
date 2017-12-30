<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">

<head>
 

</head>

<body style="">
  <div class="pageheader">
    <ul>
      <li>
        <a href="http://www.sphinx-doc.org/en/stable/index.html#">Home</a>
      </li>
      <li>
        <a href="http://www.sphinx-doc.org/en/stable/install.html">Get it</a>
      </li>
      <li>
        <a href="http://www.sphinx-doc.org/en/stable/contents.html">Docs</a>
      </li>
      <li>
        <a href="http://www.sphinx-doc.org/en/stable/develop.html">Extend/Develop</a>
      </li>
    </ul>
    <div>
      <a href="http://www.sphinx-doc.org/en/stable/index.html#">
        <img src="images/sphinxheader.png" alt="SPHINX">
      </a>
    </div>
  </div>

  <div class="related" role="navigation" aria-label="related navigation">
    <h3>Navigation</h3>
    <ul>
      <li class="right" style="margin-right: 10px">
        <a href="http://www.sphinx-doc.org/en/stable/genindex.html" title="General Index" accesskey="I">index</a>
      </li>
      <li class="right">
        <a href="http://www.sphinx-doc.org/en/stable/py-modindex.html" title="Python Module Index">modules</a> |</li>
      <li>
        <a href="http://www.sphinx-doc.org/en/stable/index.html#">Sphinx home</a>&nbsp;|</li>
      <li>
        <a href="http://www.sphinx-doc.org/en/stable/contents.html">Documentation</a> »</li>

    </ul>
  </div>
  <div class="sphinxsidebar" role="navigation" aria-label="main navigation">
    <div class="sphinxsidebarwrapper" style="top: 0px;">
      <p class="logo">A
        <a href="http://pocoo.org/">
          <img src="images/pocoo.png" alt="Pocoo">
        </a>
        project</p>

      <h3>Download</h3>

      <p>This documentation is for version
        <b>
          <a href="http://www.sphinx-doc.org/en/stable/changes.html">1.6.6+</a>
        </b>, which is not released yet.</p>
      <p>You can use it from the
        <a href="https://github.com/sphinx-doc/sphinx/">Git repo</a> or look for released versions in the
        <a href="https://pypi.python.org/pypi/Sphinx">Python Package Index</a>.</p>


      <h3>Questions? Suggestions?</h3>

      <p>Join the
        <a href="http://groups.google.com/group/sphinx-users">sphinx-users</a> mailing list on Google Groups:</p>
      <form action="http://groups.google.com/group/sphinx-users/boxsubscribe" style="padding-left: 0.5em">
        <input type="text" name="email" value="your@email" style="font-size: 90%; width: 120px" onfocus="$(this).val(&#39;&#39;);">
        <input type="submit" name="sub" value="Subscribe" style="font-size: 90%; width: 70px">
      </form>
      <p>or come to the
        <tt>#sphinx-doc</tt> channel on FreeNode.</p>
      <p>You can also open an issue at the
        <a href="https://github.com/sphinx-doc/sphinx/issues">tracker</a>.</p>
      <div id="searchbox" style="" role="search">
        <h3>Quick search</h3>
        <form class="search" action="http://www.sphinx-doc.org/en/stable/search.html" method="get">
          <div>
            <input type="text" name="q">
          </div>
          <div>
            <input type="submit" value="Go">
          </div>
          <input type="hidden" name="check_keywords" value="yes">
          <input type="hidden" name="area" value="default">
        </form>
      </div>
      <script type="text/javascript">$('#searchbox').show(0);</script>
    </div>
  </div>

  <div class="document">
    <div class="documentwrapper">
      <div class="bodywrapper">
        <div class="body" role="main">

          <h1>Welcome</h1>

          <div class="quotebar">
            <p>
              <em>What users say:</em>
            </p>
            <p>“Cheers for a great tool that actually makes programmers
              <b>want</b>
              to write documentation!“</p>
          </div>

          <p>
            Sphinx is a tool that makes it easy to create intelligent and beautiful documentation, written by Georg Brandl and licensed
            under the BSD license.</p>
          <p>It was originally created for
            <a href="https://docs.python.org/">the Python documentation</a>, and it has excellent facilities for the documentation of software projects in a
            range of languages. Of course, this site is also created from reStructuredText sources using Sphinx! The following
            features should be highlighted:
          </p>
          <ul>
            <li>
              <b>Output formats:</b> HTML (including Windows HTML Help), LaTeX (for printable PDF versions), ePub, Texinfo,
              manual pages, plain text</li>
            <li>
              <b>Extensive cross-references:</b> semantic markup and automatic links for functions, classes, citations, glossary
              terms and similar pieces of information
            </li>
            <li>
              <b>Hierarchical structure:</b> easy definition of a document tree, with automatic links to siblings, parents and
              children
            </li>
            <li>
              <b>Automatic indices:</b> general index as well as a language-specific module indices</li>
            <li>
              <b>Code handling:</b> automatic highlighting using the
              <a href="http://pygments.org/">Pygments</a> highlighter</li>
            <li>
              <b>Extensions:</b> automatic testing of code snippets, inclusion of docstrings from Python modules (API docs),
              and
              <a href="http://www.sphinx-doc.org/en/stable/ext/builtins.html#builtin-sphinx-extensions">more</a>
            </li>
            <li>
              <b>Contributed extensions:</b> more than 50 extensions
              <a href="http://www.sphinx-doc.org/en/stable/develop.html#extensions">contributed by users</a>
              in a second repository; most of them installable from PyPI</li>
          </ul>
          <p>
            Sphinx uses
            <a href="http://docutils.sourceforge.net/rst.html">reStructuredText</a>
            as its markup language, and many of its strengths come from the power and straightforwardness of reStructuredText and its
            parsing and translating suite, the
            <a href="http://docutils.sourceforge.net/">Docutils</a>.
          </p>

          <h2 style="margin-bottom: 0">Documentation</h2>

          <table class="contentstable">
            <tbody>
              <tr>
                <td>
                  <p class="biglink">
                    <a class="biglink" href="http://www.sphinx-doc.org/en/stable/tutorial.html">First steps with Sphinx</a>
                    <br>
                    <span class="linkdescr">overview of basic tasks</span>
                  </p>
                </td>
                <td>
                  <p class="biglink">
                    <a class="biglink" href="http://www.sphinx-doc.org/en/stable/search.html">Search page</a>
                    <br>
                    <span class="linkdescr">search the documentation</span>
                  </p>
                </td>
              </tr>
              <tr>
                <td>
                  <p class="biglink">
                    <a class="biglink" href="http://www.sphinx-doc.org/en/stable/contents.html">Contents</a>
                    <br>
                    <span class="linkdescr">for a complete overview</span>
                  </p>
                </td>
                <td>
                  <p class="biglink">
                    <a class="biglink" href="http://www.sphinx-doc.org/en/stable/genindex.html">General Index</a>
                    <br>
                    <span class="linkdescr">all functions, classes, terms</span>
                  </p>
                </td>
              </tr>
              <tr>
                <td>
                  <p class="biglink">
                    <a class="biglink" href="http://www.sphinx-doc.org/en/stable/changes.html">Changes</a>
                    <br>
                    <span class="linkdescr">release history</span>
                  </p>
                </td>
                <td>
                </td>
              </tr>
            </tbody>
          </table>

          <p>
            You can also download PDF/EPUB versions of the Sphinx documentation: a
            <a href="http://readthedocs.org/projects/sphinx/downloads/pdf/stable/">PDF version</a> generated from the LaTeX Sphinx produces, and a
            <a href="http://readthedocs.org/projects/sphinx/downloads/epub/stable/">EPUB version</a>.

          </p>

          <h2>Examples</h2>
          <p>Links to documentation generated with Sphinx can be found on the
            <a href="http://www.sphinx-doc.org/en/stable/examples.html">Projects using Sphinx</a> page.
          </p>
          <p>
            For examples of how Sphinx source files look, use the “Show source” links on all pages of the documentation apart from this
            welcome page.
          </p>

          <p>You may also be interested in the very nice
            <a href="http://matplotlib.sourceforge.net/sampledoc/">tutorial</a> on how to create a customized documentation using Sphinx written by the matplotlib developers.
          </p>

          <p>There is a
            <a href="http://docs.sphinx-users.jp/">Japanese translation</a>
            of this documentation, thanks to the Japanese Sphinx user group.</p>
          <p>A Japanese book about Sphinx has been published by O'Reilly:
            <a href="http://www.oreilly.co.jp/books/9784873116488/">Sphinxをはじめよう / Learning Sphinx</a>.</p>
          <!-- <p><img src="_static/bookcover.png"/></p> -->


          <h2>Hosting</h2>

          <p>Need a place to host your Sphinx docs?
            <a href="http://readthedocs.org/">readthedocs.org</a> hosts a lot of Sphinx docs already, and integrates well with projects' source control. It
            also features a powerful built-in search that exceeds the possibilities of Sphinx' JavaScript-based offline search.</p>

          <h2>Contributor Guide</h2>

          <p>If you want to contribute to the project, this part of the documentation is for you.</p>

          <ul>
            <li>
              <a href="http://www.sphinx-doc.org/en/stable/devguide.html">Sphinx Developer’s Guide</a>
            </li>
            <li>
              <a href="http://www.sphinx-doc.org/en/stable/authors.html">Sphinx Authors</a>
            </li>
          </ul>


        </div>
      </div>
    </div>
    <div class="clearer"></div>
  </div>
  <div class="related" role="navigation" aria-label="related navigation">
    <h3>Navigation</h3>
    <ul>
      <li class="right" style="margin-right: 10px">
        <a href="http://www.sphinx-doc.org/en/stable/genindex.html" title="General Index">index</a>
      </li>
      <li class="right">
        <a href="http://www.sphinx-doc.org/en/stable/py-modindex.html" title="Python Module Index">modules</a> |</li>
      <li>
        <a href="http://www.sphinx-doc.org/en/stable/index.html#">Sphinx home</a>&nbsp;|</li>
      <li>
        <a href="http://www.sphinx-doc.org/en/stable/contents.html">Documentation</a> »</li>

    </ul>
  </div>
  <div class="footer" role="contentinfo">
    © Copyright 2007-2017, Georg Brandl and the Sphinx team. Created using
    <a href="http://sphinx-doc.org/">Sphinx</a> 1.6.6+.
  </div>
</body>

</html>