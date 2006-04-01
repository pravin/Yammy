<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head profile="http://gmpg.org/xfn/11">
	<meta http-equiv="Content-Type" content="<?php bloginfo('html_type'); ?>; charset=<?php bloginfo('charset'); ?>" />

	<title><?php bloginfo('name'); ?> <?php if ( is_single() ) { ?> &raquo; Archive <?php } ?> <?php wp_title(); ?></title>

	<!-- leave this for stats -->
	<meta name="generator" content="WordPress <?php bloginfo('version'); ?>" />
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="description" content="Yammy - Yahoo Messenger Archives Decoder" />
	<meta name="keywords" content="yammy, yahoo, messenger, archives, decoder, articles, writing, tutorials, Pravin, Paratey" />
	<meta name="author" content="Pravin Paratey" />
	<link rel=stylesheet type="text/css" href="<?php bloginfo('stylesheet_directory'); ?>/style.css">
	<link rel="alternate" type="application/rss+xml" title="RSS 2.0" href="<?php bloginfo('rss2_url'); ?>" />
	<link rel="alternate" type="text/xml" title="RSS .92" href="<?php bloginfo('rss_url'); ?>" />
	<link rel="alternate" type="application/atom+xml" title="Atom 0.3" href="<?php bloginfo('atom_url'); ?>" />
	<link rel="pingback" href="<?php bloginfo('pingback_url'); ?>" />
	<?php wp_get_archives('type=monthly&format=link'); ?>
	<?php comments_popup_script(400, 500); ?>
	<?php wp_head(); ?>
</head>
<body><div class="container">
<!-- TOP -->
<div class="header-nav">
<a href="http://yammy.sourceforge.net/">Home</a> |
<a href="mailto:pravinp[at]gmail[dot]com?subject=Yammy">Email</a>
</div>

<div class="header" OnClick="javascript:top.location.href='http://yammy.sourceforge.net/';"></div>
<!-- TOP -->
<div class="subheader">
	<ul>
		<!-- List of Wordpress generated static pages -->
		<?php wp_list_pages('title_li='); ?>
	</ul>
</div>

<div class="content">
<div class="post">
<!-- Display this only in the home page -->
<?php if (is_home()) { ?>
	<?php include("blurb.html"); ?>
<?php } ?>