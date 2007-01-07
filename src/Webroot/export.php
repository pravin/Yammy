<?php include('header.php'); ?>

<div class="content">
	<h1>Export Conversations</h1>
	Select export format:
	<form action="#" method="GET">
	<dl>
	<dt><input type="radio" name="format" value="classic" checked="true" /><b>Classic</b></dt>
	<dd>Every conversation is saved in a different file.
<pre>Jane
  |- Bob
  |   |- 2006-03-27.html
  |   |- 2006-03-28.html
  |   |- 2006-03-29.html
  |- Tom
      |- 2006-04-17.html
      |- 2006-05-21.html
      |- 2006-06-29.html
</pre>
	</dd>
	
	<dt><input type="radio" name="format" value="modern"/><b>Modern</b></dt>
	<dd>Conversation is saved in a monthly format.
<pre>Jane
  |- Bob
  |   |- March-2006.html
  |   |- April-2006.html
  |- Tom
      |- April-2006.html
      |- May-2006.html
      |- June-2006.html
</pre>
	</dd>
	
	<dt><input type="radio" name="format" value="combined"/><b>Combined</b></dt>
	<dd>Conversation with a person is saved in one single file.
<pre>Jane
  |- Bob.html
  |- Tom.html</pre>
	</dd>
	</dl>
	<div style="text-align:center"><input type="button" name="submit" value="Export" /></div>
	</form>
	<div class="todo">This can be made to look a lot better. I don't know how yet.<br /><br />Do you need more export formats?</div>
</div>

<?php include('footer.php'); ?>