                <article class="post">
                    <h2 class="title">
                        <a href="$post.url">$post.title</a>
                    </h2>
                    <time>$post.date</time>
                    <section class="content">
                        <p>
                            <a class="fancybox" href="$post.preview.large" data-fancybox-group="gallery" title="$post.title">
								<img src="$post.preview.small" alt="$post.sub_title">
							</a>
							<span class="caption">$post.preview.caption</span>
                        </p>
						<div>
						$post.content
						</div>
                        <div class="tags">
				<!-- Add tag links by for each loop -->
				
				<?vb
					For Each $post.tags As <%= ../includes/tag-link.vbhtml %>
				?>
                        </div>
                    </section>
                </article>
