<h1>Pomoc</h1>
<h2>Co nowego?</h2>
<ol>
	<li>Nowy, bardziej intuicyjny interfejs u¿ytkownika (UI).</li>
	<li>Mo¿liwoœæ przeszukiwania wszystkich rozmów.</li>
	<li>Obs³uga emotikonek.</li>
	<li>Zredukowano œrednie zu¿ycie pamiêci z 20-30mb do mniej ni¿ 3mb (z 0.8 beta).</li>
	<li>Przeniesiono na .NET 2.0</li>
	<li>Ró¿ne arkusze stylów dla druku i podgl¹du.</li>
</ol> 

<h2>FAQ</h2>
<dl>
<dt>1. Co jest z nowym interfejsem u¿ytkownika (UI)?</dt>
	<dd><p><b>Powód 1:</b> Chcia³em zrobiæ coœ odmiennego i fajnego. Pojawi³ siê UI-strony. Znikn¹³ GUI Windows. w00t!</p>
	<p><b>Powód 2:</b> To jest bardziej praktyczne. Moje zadanie koncentruje siê na pisaniu back-endu. Pisa³am wiêcej bibliotek ni¿ zajmowa³em siê GUI. Programowanie Windows lub w tym przypadku programowanie GUI nie daje ³atwej mo¿liwoœci oddzielenia logiki od sposobu prezentacji. Od <i>bardzo</i> d³ugiego czasu, próbowa³em wymyœliæ sposób obejœcia tego problemu. A wynik? To. Nie jest to jeszcze do koñca to o co chodzi ale znacz¹cy krok w tym kierunku.</p></dd>

<dt>2. Hej dlaczego muszê u¿ywaæ mojej przegl¹darki? Czy moje dane s¹ bezpieczne?</dt>
	<dd><p>Nie wchodzisz do Internetu. Wszystko odbywa siê lokalnie. Yammy uruchamia (tiny) serwer stron. Wiêc twoje dane s¹ zlokalizowane wy³¹cznie na twoim pc. U¿ytkownicy <b>nie mog¹</b> zdalnie uzyskaæ dostêpu do Yammy.</p>
	<p>A przegl¹darka? Jest u¿ywana do reenderowania (wyœwietlania) danych. Jeœli jesteœ paranoikiem mo¿esz usun¹æ historiê przegl¹dania i pliki tymczasowe.</p></dd>

<dt>3. Czy mogê w³amaæ siê na inne konta?</dt>
	<dd><p>Um, nie. Ale mo¿esz przegl¹daæ rozmowy zarchiwizowane na twoim PC. Oznacza to, ¿e mo¿esz (w pewien sposób) u¿yæ Yammy do monitorowania swoich dzieci poprzez w³¹czenie archiwizowania rozmów.</p>
	<p>Widzisz, prosi³eœ o ciastko a ja da³em ci chleb. Jak by powiedzia³ ojciec Kalvina - to pomaga budowaæ charakter. Ale jeœli szukasz programu do monitorowania rozmów w swojej sieci zobacz na <a href="http://imsniffer.sourceforge.net/" title="im sniffer">Im-Sniffer</a>.</p></dd>

<dt>4. Gdy uruchomi³em Yammy uzyska³em komunikat 'The application failed to initialize properly'.</dt>
	<dd><p>Musisz pobraæ i zainstalowaæ <a href="http://www.microsoft.com/downloads/details.aspx?FamilyID=0856eacb-4362-4b0d-8edd-aab15c5e04f5&displaylang=en" title=".net 2.0 runtime">.NET 2.0 Runtime</a>.</p></dd>

<dt>5. Gdy chcia³em czegoœ poszukaæ uzyska³em komunikat b³êdu "No Index Found".</dt>
	<dd><p>Twój indeks nie zosta³ jeszcze utworzony. Spróbuj po jakimœ czasie. Jeœ³i problem bêdzie nadal wystêpowa³ - to jest problem. OdwiedŸ <a href="http://yammy.sf.net/forums" title="visit forums">forum</a> lub <a href="mailto:pravinp@gmail.com" title="email me">wyœlij do mnie E-mail</a>.</p></dd>

<dt>6. Kiedy drukujê, wygl¹da to inaczej.</dt>
	<dd><p>Do drukowania s¹ ró¿ne arkusze stylów. Wiêc kolory obramowañ i t³a zniknê³y. Jeœli z jakiegoœ powodu chcesz wydrukowaæ wszystkie kolory to skopiuj zawartoœæ <code>display.css</code> do <code>print.css</code>.</p></dd>

<dt>7. Dlaczego wszystkie ikony zdalnych u¿ytkowników wygladaj¹ tak samo?</dt>
	<dd><p>Jeszcze nie wymyœli³em jak uzyskaæ ikony dla zdalnych u¿ytkowników. Wiêc póki co wszystkie wygl¹daj¹ tak:<br /><img src="/images/generic.png"width="48" height="48" /></p></dd>
	
<dt>8. Ja nie jestem zdalnym u¿ytkownikiem. A moja ikona równie¿ wygl¹da tak samo!</dt>
	<dd><p>Jest tak poniewa¿ nie wstawi³eœ avatara. Wstaw avatar i spróbuj ponownie.</p></dd>
</dl>

<p>Jeœli to ci nie pomog³o, <a href="http://yammy.sf.net/forums" title="visit forums">odwiedŸ forum</a> i umieœæ post z zapytaniem.</p> 

<h2>Dziêkujemy</h2>
Projekt jest realizowany przez garstkê koderów. S¹ to u¿ytkownicy, którzy inspiruj¹ nas do robienia wiêcej. Chcia³bym podziêkowaæ kilku osobom, które mia³y znacz¹cy wp³yw na projekt:
<dl>
<dt>Andrei Virlan</dt>
	<dd>Za nadanie pocz¹tkowego rozpêdu. On jest powodem, dla którego wprowadzi³em obs³ugê wielu jêzyków.</dd>
<dt>Laurentiu Nicola (GrayShade)</dt>
	<dd>Za bycie na posterunku. Naprawdê. I za pomoc dla u¿ytkowników z problemami kiedy mnie nie by³o w pobli¿u.</dd>
<dt>HejItsMe</dt>
	<dd>Za sta³e dopingowanie siebie do ruszenia siê i wypuszczenia kolejnej wersji. Zakoñczy³bym na wersji 0.7 gdyby nie by³o to dla niego. I równie¿ za wiele pomys³ów i próœb o funkcje. On by³, bez w¹tpliwoœci, najaktywniejszym u¿ytkownikiem.</dd>
</dl>

<em>(T³umaczenie na jêzyk polski Piotr Kwiliñski)</em>
