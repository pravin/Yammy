<h1>Help</h1>
<h2>What's new?</h2>
<ol>
	<li>New, more intuitive UI.</li>
	<li>Ability to search through all conversations.</li>
	<li>Emoticon support.</li>
	<li>Reduced average memory consumption from 20-30mb to less than 3mb (from 0.8 beta).</li>
	<li>Moved to .NET 2.0</li>
	<li>Different stylesheets for printing and viewing.</li>
</ol> 

<h2>FAQ</h2>
<dl>
<dt>1. What's with the new UI?</dt>
	<dd><p><b>Reason 1:</b> I wanted to do something different and cool. The Web-UI is in. Windows GUI is out. w00t!</p>
	<p><b>Reason 2:</b> This is more practical. My job involves writing backend stuff. I have written more libraries than done GUI. Windows programming, or for that matter, GUI programming doesn't make it easy to separate logic from presentation. For a <i>very</i> long time, I was trying to figure out a way of tackling this problem. End result? This. It isn't quite there yet, but it's getting there.</p></dd>
<dt>2. Hey why do I have to use my browser? Is my data safe?</dt>
	<dd><p>You are not accessing the internet. Everything is being done locally. Yammy runs a tiny webserver. So your data is localized to your pc only. Users <b>can not</b> access Yammy from a remote machine.</p>
	<p>And the browser? It is used to render (display) the data. If you are really paranoid, you can delete your browsing history and cached files.</p></dd>
<dt>3. Can I hack into another account?</dt>
	<dd><p>Um, no. But you can view the archived conversations on your PC. This means you can use Yammy (in a way) to monitor your kids by turning on archiving for them.</p>
	<p>See, you asked for cake and I gave you bread. Like Calvin's dad would say, it helps build character. But if you are really looking to monitor conversations on your network, take a look at <a href="http://imsniffer.sourceforge.net/" title="im sniffer">Im-Sniffer</a>.</p></dd>
<dt>4. When I try to start Yammy I get, 'The application failed to initialize properly'.</dt>
	<dd><p>You'll have to download and install the <a href="http://www.microsoft.com/downloads/details.aspx?FamilyID=0856eacb-4362-4b0d-8edd-aab15c5e04f5&displaylang=en" title=".net 2.0 runtime">.NET 2.0 Runtime</a>.</p></dd>
<dt>5. When I try to search, I get "No Index Found" error.</dt>
	<dd><p>Your index hasn't been created yet. Try after some time. If it still occurs, then there's a problem. Visit the <a href="http://yammy.sf.net/forums" title="visit forums">forums</a> or <a href="mailto:pravinp@gmail.com" title="email me">mail me</a>.</p></dd>
<dt>6. When I print, it looks different.</dt>
	<dd><p>I have a different stylesheet for printing. So the fancy colors and the background is gone. If for some reason, you do want to print all the fancy colors, copy the contents of <code>display.css</code> to <code>print.css</code>.</p></dd>
<dt>7. Why do all the remote user icons look the same?</dt>
	<dd><p>I haven't figured out how to get the icon for the remote users yet. So for now, all of them look like so:<br /><img src="/images/generic.png"width="48" height="48" /></p></dd>
<dt>8. I'm not a remote user. My icon also looks the same!</dt>
	<dd><p>That is because you haven't set a picture avatar. Set it and try again.</p></dd>
</dl>

<p>If that didn't help you, <a href="http://yammy.sf.net/forums" title="visit forums">visit the forums</a> and post your queries.</p> 

<h2>Thank you</h2>
A project isn't just about a bunch of coders. It's the users that take it out into the world and inspire us to do more. I would like to thank a few people who made a difference to this project,
<dl>
<dt>Andrei Virlan</dt>
	<dd>For giving this project the initial push. He is the reason I support multiple languages.</dd>
<dt>Laurentiu Nicola (GrayShade)</dt>
	<dd>For being there. I really mean that. And for helping users troubleshoot their issues when I wasn't around.</dd>
<dt>HeyItsMe</dt>
	<dd>For constantly prodding me to get off my bottom and release the next version already. I would've quit at 0.7 if it weren't for him. And also for his really neat ideas and feature-requests. He has been, without doubt, the most active user.</dd>
</dl>

<em>(Translated into English by Pravin Paratey)</em>