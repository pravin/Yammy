<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<html>
<head>
<title><?php echo $PageTitle ?></title>
<link rel="shortcut icon" href="/favicon.ico" type="image/x-icon">
<meta http-equiv="content-type" content="text/html;charset=utf-8" />
<style type="text/css" media="screen">@import url("/style.css");</style>
<?php
//	require_once('geshi/syntax.php');
//	require_once('common.php');
	if(!is_null($AdditionalHeaders)) {
		echo $AdditionalHeaders;
	}
?>
<!-- Email Protector from http://www.jracademy.com/~jtucek/email/ -->
<script language="javascript" src="/js/emailProtector.js"></script>
<script language=javascript>
if(!addresses) var addresses = new Array();
addresses.push("5461 2117 3113 5133 5362 1544 1001 5270 4639 5292 3230 5133 1403 5362 4829 5292 4 4340 3113 5133 5362 1544 1361 418 5270 3113");
</script>
<!-- End Email Protector -->
</head>
<body>
<div id="topbar">
	<a href="/" title="Yammy Home"><img src="/img/logo.gif" alt="logo" /></a>
	<a href="/download/" title="Download Yammy">Download</a>
	<a href="http://sourceforge.net/project/screenshots.php?group_id=135391" title="Yammy Screenshots">Screenshots</a>
	<a href="/dev/" title="Yammy Development">Dev</a>
	<a href="http://sourceforge.net/forum/?group_id=135391" title="Yammy Forums">Forums</a>
	<a href="javascript:decrypt_and_email(0);" title="Contact">Contact</a>
</div>
<div id="wrapper">
<div id="hdr"><a href="http://yammy.sourceforge.net"><img src="/img/hdr.gif" alt="logo"/></a></div>
