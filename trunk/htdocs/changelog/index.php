<?php
	$PageTitle = 'Yammy Changelog';
	require('../header.php'); 
?>

<h1>Changelog</h1>

<h2>Yammy 0.7</h2>
<ul>
	<li>Full support for utf-8. Messages containing non-latin characters are correctly displayed.</li>
	<li>Yammy available in English, Basque, Catalan, Dutch, French, Japanese, Norwegian, Romanian, Spanish, Swedish, Tamil and Turkish.</li>
</ul>
<h2>Yammy 0.6</h2>

<ul>
<li>Support for multiple profiles : If you have multiple profiles, they'll be decoded correctly.</li>
<li>Set Archiving for users better: This feature works everytime (hopefully :P) and is more resilient.</li>
<li>Localization is back! Now you can use Yammy in your own language, yet again. Yammy currently supports English, Romanian and German (somewhat functional).</li>
<li>Remembers settings: Yammy will remember settings like language, Yahoo Profiles directory, etc so you don't have to set it up everytime.</li>
<li>HTML save and export added: Export entire folders in HTML or save the current decoded file as an html document.</li>
<li>Visual Output tweaked: Now, the output colors and fonts match Yahoo Messenger 7 (beta).</li>
<li>RTF save and export better: RTF save and export fixed for certain users who had trouble opening these in MS Word.</li>
<li>Fixed a couple of startup errors: Now Yammy doesn't assume things about the location of Yahoo Messenger. This fixes an error dialog that would appear at startup for users with Yahoo Messenger installed in non standard locations.</li>

<li>Find feature: The find feature has been better integrated with Yammy.</li>
</ul>
<h2>Yammy 0.5</h2>
<ul>
	<li>Moved to .NET framework.</li>
	<li>UI Revamped and XP look added.</li>
	<li>Usability changes.</li>
	<li>Control archiving of individual users.</li>

	<li>Basic search feature added.</li>
	<li>Refresh button to monitor live conversations.</li>
	<li>User can specify target directory while exporting.</li>
</ul>

<h2>Yammy 0.4</h2>
<ul>
	<li>Internationalization support added. Romanian, German translations added.</li>

	<li>Menus tweaked. Accelerator keys like <em>Ctrl+O</em> work.</li>
</ul>

<h2>Yammy 0.3</h2>
<ul>
	<li>Ability to export entire directories. Now you dont have to individually save each file.</li>
	<li>Evil flag introduced. It lets you control archiving options for all users on your computer. Handy isnt it? ;)</li>

	<li>I understand the dat file format better and a few other glitches have been ironed out.</li>
	<li>Executable file size further reduced to 21.5kb (from 44kb). This makes the zip file (without installer) a light 8.46kb! Heck, the entire download is smaller than its screenshot.</li>

</ul>
<h2>Yammy 0.2</h2>
<ul>
	<li>Rewritten the code in Win32. File size has reduced to 48.2kb and extra files not required.</li>
	<li>Added timestamps.</li>

	<li>Added a "Conversation Started" tag to denote when different conversations started on that day.</li>
	<li>Cleaned more html tags.</li>
	<li>Fixed a bug which caused messages to be truncated.</li>
</ul>
<h2>Yammy 0.1</h2>
<ul><li>First public version made available</li></ul>

<?php require_once('../footer.php'); ?>
