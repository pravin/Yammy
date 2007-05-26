<?php
	$PageTitle = 'Translating Yammy';
	require('../header.php'); 
?>
<h1>Translating Yammy</h1>
<p>Would you like to translate Yammy? Sweet! You just earned yourself a cookie. And that warm fuzzy feeling that you feel deep down when you do the right thing.</p>

<p>So how do you begin? It's simple. And it's fun. In fact, I've even composed a song that you can sing along while you translate:</p>

<blockquote>
Translation is easy,<br>
Translation is fun!<br>

Let's all sing along,<br>
Tra-la-lump-pum-pun!
</blockquote>

<p>Just follow the instructions for the version that you want to translate. Also listed is a table of languages which have been translated and which need to be done.</p> 

<p>If you think something is unclear, do get in <a href="javascript:decrypt_and_email(0);" title="contact">touch</a>.</p>

<h2>v0.9 (current version)</h2>
<ol>
<li>Download the <a href="http://downloads.sourceforge.net/yammy/yammy-0.9-translation.zip" title="translation files">translation files</a>.</li>

<li>Edit<br>
- <code>en.js</code> <br>
- <code>help_en.php</code> (optional)  <br>
and save it them with your language code. You can look up your language code in the table below. For example, if you translated the files into Simplified Chinese, save them as <code>zh-Hans.js</code> and <code>help_zh-Hans.php</code>.</li>

<li>This done, email the files to me. Or if you have check in rights, check them into <code>https://yammy.svn.sourceforge.net/svnroot/yammy/trunk/src/Webroot</code> (svn).</li>
</ol>

<h3>Translation Table</h3>
<script src="/js/translating.js" type="text/javascript"></script>

<h2>Saving a file in utf-8</h2>
<p>You'll need an editor that allows you to save your file in utf-8 encoding. I use <a href="http://notepad-plus.sourceforge.net" title="Notepad++">Notepad++</a>. In Notepad++, you can change the encoding by selecting <code>Format &gt; Encode in UTF-8</code> in the menu.</p>

<?php require_once('../footer.php'); ?>
