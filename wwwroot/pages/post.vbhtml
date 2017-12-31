<!DOCTYPE html>

<html class="wf-inconsolata-n5-active wf-futurapt-n5-active wf-futurapt-n7-active wf-futurapt-n4-active wf-futurapt-i4-active wf-active">

<head>
    <%= ../includes/head.vbhtml %>
</head>

<body>
    <div id="loading-bar-wrapper" style="display: none;">
        <div id="loading-bar" style="width: 100%;"></div>
    </div>
    <script>setLoadingBarProgress(20)</script>
    <div id="site-wrapper">
		
		<%= ../includes/header.vbhtml %>
        
		<script>setLoadingBarProgress(40)</script>
        <main id="main" role="main" class="loaded">
                   
			<%= ../includes/article.vbhtml %>
					            
            <nav id="page-nav">
                <a class="next" rel="next" href="$next.url">
                    <span class="text">Next</span>
                    <span class="icon icon-chevron-right"></span>
                </a>
            </nav>
            <script>setLoadingBarProgress(60)</script>
        </main>
		
        <%= ../includes/footer.vbhtml %>
		
        <div class="overlay"></div>
		<script>setLoadingBarProgress(100)</script>
    </div>   
</body>

</html>