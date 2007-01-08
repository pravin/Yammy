<?php get_header(); ?>
<div class="post">
<?php if (have_posts()) : while (have_posts()) : the_post(); ?>

	<div class="date"><?php the_time('l, F j, Y') ?></div>
	<h1><?php the_title(); ?></h1>
	
	<div>
	<?php if (is_home()) { ?>
		<?php the_content(__('[more]')); ?>
	<?php } else { ?>
		<?php the_content(); ?>
	<?php } ?>
		
	</div>
	<div class="byline">
			<a href="<?php the_permalink() ?>" rel="bookmark" title="Permalink">
			<img src="/images/icon-post.gif" width="14" height="14" /></a>
			Posted by <?php the_author() ?> | 
            <?php wp_link_pages(); ?>
            <?php comments_popup_link(__('0 Comments'), __('1 Comment'), __('% Comments')); ?>
			<!-- <?php trackback_rdf(); ?> -->
	</div>
	<?php comments_template(); ?>

<?php endwhile; else: ?>
<p><?php _e('Sorry, no posts matched your criteria.'); ?></p>
<?php endif; ?>

<?php posts_nav_link(' &#8212; ', __('&laquo; Previous Page'), __('Next Page &raquo;')); ?>

</div>

<?php get_footer(); ?>