/* This script makes it easy to manage the translators table for yammy
 * Pravin Paratey (February 18, 2007)
 *
 * For a demo of this script is action, check out 
 * http://www.dustyant.com/projects/yammy/translating-yammy
 *
 * This script is released under Creative Commons Attribution 2.5 Licence
 * http://creativecommons.org/licenses/by/2.5/
 */

var default_url = 'mailto:pravinp[at]gmail[dot]com?subject=Translate%20Yammy';
// This table is rendered by javascript
// Format: culture-code, culture-name, author, author-url, status (done/undone)
// We cheat when there is no author by calling the author 'Apply'
var lang_table = 
[
	['af', 'Afrikaans', 'Apply', default_url, 'undone'],
	['af-ZA', 'Afrikaans (South Africa)', 'Apply', default_url, 'undone'],
	['sq', 'Albanian', 'Apply', default_url, 'undone'],
	['sq-AL', 'Albanian (Albania)', 'Apply', default_url, 'undone'],
	['ar', 'Arabic', 'Apply', default_url, 'undone'],
	['ar-DZ', 'Arabic (Algeria)', 'Apply', default_url, 'undone'],
	['ar-BH', 'Arabic (Bahrain)', 'Apply', default_url, 'undone'],
	['ar-EG', 'Arabic (Egypt)', 'Apply', default_url, 'undone'],
	['ar-IQ', 'Arabic (Iraq)', 'Apply', default_url, 'undone'],
	['ar-JO', 'Arabic (Jordan)', 'Apply', default_url, 'undone'],
	['ar-KW', 'Arabic (Kuwait)', 'Apply', default_url, 'undone'],
	['ar-LB', 'Arabic (Lebanon)', 'Apply', default_url, 'undone'],
	['ar-LY', 'Arabic (Libya)', 'Apply', default_url, 'undone'],
	['ar-MA', 'Arabic (Morocco)', 'Apply', default_url, 'undone'],
	['ar-OM', 'Arabic (Oman)', 'Apply', default_url, 'undone'],
	['ar-QA', 'Arabic (Qatar)', 'Apply', default_url, 'undone'],
	['ar-SA', 'Arabic (Saudi Arabia)', 'Apply', default_url, 'undone'],
	['ar-SY', 'Arabic (Syria)', 'Apply', default_url, 'undone'],
	['ar-TN', 'Arabic (Tunisia)', 'Apply', default_url, 'undone'],
	['ar-AE', 'Arabic (U.A.E)', 'Apply', default_url, 'undone'],
	['ar-YE', 'Arabic (Yemen)', 'Apply', default_url, 'undone'],
	['hy', 'Armenian', 'Apply', default_url, 'undone'],
	['hy-AM', 'Armenian (Armenia)', 'Apply', default_url, 'undone'],
	['az', 'Azeri', 'Apply', default_url, 'undone'],
	['az-Cyrl-AZ', 'Azeri (Azerbaijan, Cyrillic)', 'Apply', default_url, 'undone'],
	['az-Latn-AZ', 'Azeri (Azerbaijan, Latin)', 'Apply', default_url, 'undone'],
	['eu', 'Basque', 'Aitor Gomez Goiri', 'http://www.twolf.eu', 'done'],
	['eu-ES', 'Basque (Basque)', 'Aitor Gomez Goiri', 'http://www.twolf.eu', 'done'],
	['be', 'Belarusian', 'Apply', default_url, 'undone'],
	['be-BY', 'Belarusian (Belarus)', 'Apply', default_url, 'undone'],
	['bg', 'Bulgarian', 'Apply', default_url, 'undone'],
	['bg-BG', 'Bulgarian (Bulgaria)', 'Apply', default_url, 'undone'],
	['ca', 'Catalan', 'Iñigo Goiri Presa', 'mailto:&#105;&#110;&#105;&#103;&#111;&#105;&#114;&#105;&#064;&#116;&#101;&#108;&#101;&#102;&#111;&#110;&#105;&#099;&#097;&#046;&#110;&#101;&#116;', 'done'],
	['ca-ES', 'Catalan (Catalan)', 'Iñigo Goiri Presa', 'mailto:&#105;&#110;&#105;&#103;&#111;&#105;&#114;&#105;&#064;&#116;&#101;&#108;&#101;&#102;&#111;&#110;&#105;&#099;&#097;&#046;&#110;&#101;&#116;', 'done'],
	['zh-HK', 'Chinese (Hong Kong SAR, PRC)', 'Apply', default_url, 'undone'],
	['zh-MO', 'Chinese (Macao SAR)', 'Apply', default_url, 'undone'],
	['zh-CN', 'Chinese (PRC)', 'Apply', default_url, 'undone'],
	['zh-Hans', 'Chinese (Simplified)', 'Apply', default_url, 'undone'],
	['zh-SG', 'Chinese (Singapore)', 'Apply', default_url, 'undone'],
	['zh-TW', 'Chinese (Taiwan)', 'hit1205', 'mailto:%68%69%74%31%32%30%35%40%75%73%65%72%73%2E%73%6F%75%72%63%65%66%6F%72%67%65%2E%6E%65%74', 'done'],
	['zh-Hant', 'Chinese (Traditional)', 'Apply', default_url, 'undone'],
	['hr', 'Croatian', 'Apply', default_url, 'undone'],
	['hr-HR', 'Croatian (Croatia)', 'Apply', default_url, 'undone'],
	['cs', 'Czech', 'Apply', default_url, 'undone'],
	['cs-CZ', 'Czech (Czech Republic)', 'Apply', default_url, 'undone'],
	['da', 'Danish', 'Apply', default_url, 'undone'],
	['da-DK', 'Danish (Denmark)', 'Apply', default_url, 'undone'],
	['dv', 'Divehi', 'Apply', default_url, 'undone'],
	['dv-MV', 'Divehi (Maldives)', 'Apply', default_url, 'undone'],
	['nl', 'Dutch', 'Apply', default_url, 'undone'],
	['nl-BE', 'Dutch (Belgium)', 'Apply', default_url, 'undone'],
	['nl-NL', 'Dutch (Netherlands)', 'Apply', default_url, 'undone'],
	['en', 'English', 'Pravin Paratey', 'http://pravin.insanitybegins.com', 'done'],
	['en-AU', 'English (Australia)', 'Apply', default_url, 'undone'],
	['en-BZ', 'English (Belize)', 'Apply', default_url, 'undone'],
	['en-CA', 'English (Canada)', 'Apply', default_url, 'undone'],
	['en-029', 'English (Caribbean)', 'Apply', default_url, 'undone'],
	['en-IE', 'English (Ireland)', 'Apply', default_url, 'undone'],
	['en-JM', 'English (Jamaica)', 'Apply', default_url, 'undone'],
	['en-NZ', 'English (New Zealand)', 'Apply', default_url, 'undone'],
	['en-PH', 'English (Philippines)', 'Apply', default_url, 'undone'],
	['en-ZA', 'English (South Africa)', 'Apply', default_url, 'undone'],
	['en-TT', 'English (Trinidad and Tobago)', 'Apply', default_url, 'undone'],
	['en-GB', 'English (United Kingdom)', 'Apply', default_url, 'undone'],
	['en-US', 'English (United States)', 'Pravin Paratey', 'http://pravin.insanitybegins.com', 'done'],
	['en-ZW', 'English (Zimbabwe)', 'Apply', default_url, 'undone'],
	['et', 'Estonian', 'Apply', default_url, 'undone'],
	['et-EE', 'Estonian (Estonia)', 'Apply', default_url, 'undone'],
	['fo', 'Faroese', 'Apply', default_url, 'undone'],
	['fo-FO', 'Faroese (Faroe Islands)', 'Apply', default_url, 'undone'],
	['fa', 'Farsi', 'Amin N.Karimi', 'mailto:%61%6D%69%6E%2E%6B%61%72%69%6D%69%40%67%6D%61%69%6C%2E%63%6F%6D', 'done'],
	['fa-IR', 'Farsi (Iran)', 'Amin N.Karimi', 'mailto:%61%6D%69%6E%2E%6B%61%72%69%6D%69%40%67%6D%61%69%6C%2E%63%6F%6D', 'done'],
	['fi', 'Finnish', 'Apply', default_url, 'undone'],
	['fi-FI', 'Finnish (Finland)', 'Apply', default_url, 'undone'],
	['fr', 'French', 'Apply', default_url, 'undone'],
	['fr-BE', 'French (Belgium)', 'Apply', default_url, 'undone'],
	['fr-CA', 'French (Canada)', 'Apply', default_url, 'undone'],
	['fr-FR', 'French (France)', 'Apply', default_url, 'undone'],
	['fr-LU', 'French (Luxembourg)', 'Apply', default_url, 'undone'],
	['fr-MC', 'French (Monaco)', 'Apply', default_url, 'undone'],
	['fr-CH', 'French (Switzerland)', 'Apply', default_url, 'undone'],
	['gl', 'Galician', 'Apply', default_url, 'undone'],
	['gl-ES', 'Galician (Spain)', 'Apply', default_url, 'undone'],
	['ka', 'Georgian', 'Apply', default_url, 'undone'],
	['ka-GE', 'Georgian (Georgia)', 'Apply', default_url, 'undone'],
	['de', 'German', 'Denis Scollie', 'mailto:densco[at]users[dot]sourceforge[dot]net', 'done'],
	['de-AT', 'German (Austria)', 'Apply', default_url, 'undone'],
	['de-DE', 'German (Germany)', 'Apply', default_url, 'undone'],
	['de-LI', 'German (Liechtenstein)', 'Apply', default_url, 'undone'],
	['de-LU', 'German (Luxembourg)', 'Apply', default_url, 'undone'],
	['de-CH', 'German (Switzerland)', 'Apply', default_url, 'undone'],
	['el', 'Greek', 'Apply', default_url, 'undone'],
	['el-GR', 'Greek (Greece)', 'Apply', default_url, 'undone'],
	['gu', 'Gujarati', 'Apply', default_url, 'undone'],
	['gu-IN', 'Gujarati (India)', 'Apply', default_url, 'undone'],
	['he', 'Hebrew', 'Nuvax', '', 'done'],
	['he-IL', 'Hebrew (Israel)', 'Nuvax', '', 'done'],
	['hi', 'Hindi', 'Apply', default_url, 'undone'],
	['hi-IN', 'Hindi (India)', 'Apply', default_url, 'undone'],
	['hu', 'Hungarian', 'Apply', default_url, 'undone'],
	['hu-HU', 'Hungarian (Hungary)', 'Apply', default_url, 'undone'],
	['is', 'Icelandic', 'Apply', default_url, 'undone'],
	['is-IS', 'Icelandic (Iceland)', 'Apply', default_url, 'undone'],
	['id', 'Indonesian', 'Gue!Shindu', '', 'done'],
	['id-ID', 'Indonesian (Indonesia)', 'Gue!Shindu', '', 'done'],
	['it', 'Italian', 'Apply', default_url, 'undone'],
	['it-IT', 'Italian (Italy)', 'Apply', default_url, 'undone'],
	['it-CH', 'Italian (Switzerland)', 'Apply', default_url, 'undone'],
	['ja', 'Japanese', 'Apply', default_url, 'undone'],
	['ja-JP', 'Japanese (Japan)', 'Apply', default_url, 'undone'],
	['kn', 'Kannada', 'Apply', default_url, 'undone'],
	['kn-IN', 'Kannada (India)', 'Apply', default_url, 'undone'],
	['kk', 'Kazakh', 'Apply', default_url, 'undone'],
	['kk-KZ', 'Kazakh (Kazakhstan)', 'Apply', default_url, 'undone'],
	['kok', 'Konkani', 'Apply', default_url, 'undone'],
	['kok-IN', 'Konkani (India)', 'Apply', default_url, 'undone'],
	['ko', 'Korean', 'Apply', default_url, 'undone'],
	['ko-KR', 'Korean (Korea)', 'Apply', default_url, 'undone'],
	['ky', 'Kyrgyz', 'Apply', default_url, 'undone'],
	['ky-KG', 'Kyrgyz (Kyrgyzstan)', 'Apply', default_url, 'undone'],
	['lv', 'Latvian', 'Apply', default_url, 'undone'],
	['lv-LV', 'Latvian (Latvia)', 'Apply', default_url, 'undone'],
	['lt', 'Lithuanian', 'Apply', default_url, 'undone'],
	['lt-LT', 'Lithuanian (Lithuania)', 'Apply', default_url, 'undone'],
	['mk', 'Macedonian', 'Apply', default_url, 'undone'],
	['mk-MK', 'Macedonian (Macedonia, FYROM)', 'Apply', default_url, 'undone'],
	['ms', 'Malay', 'Apply', default_url, 'undone'],
	['ms-BN', 'Malay (Brunei Darussalam)', 'Apply', default_url, 'undone'],
	['ms-MY', 'Malay (Malaysia)', 'Apply', default_url, 'undone'],
	['mr', 'Marathi', 'Apply', default_url, 'undone'],
	['mr-IN', 'Marathi (India)', 'Apply', default_url, 'undone'],
	['mn', 'Mongolian', 'Apply', default_url, 'undone'],
	['mn-MN', 'Mongolian (Mongolia)', 'Apply', default_url, 'undone'],
	['no', 'Norwegian', 'Apply', default_url, 'undone'],
	['nb-NO', 'Norwegian (Bokmål, Norway)', 'Apply', default_url, 'undone'],
	['nn-NO', 'Norwegian (Nynorsk, Norway)', 'Apply', default_url, 'undone'],
	['pl', 'Polish', 'Piotr Kwiliński', 'mailto:euvcp-at-hotmail-dot-com', 'done'],
	['pl-PL', 'Polish (Poland)', 'Piotr Kwiliński', 'mailto:euvcp-at-hotmail-dot-com', 'done'],
	['pt', 'Portuguese', 'Apply', default_url, 'undone'],
	['pt-BR', 'Portuguese (Brazil)', 'Vinicius Pinto', 'http://vinicius.biz/', 'done'],
	['pt-PT', 'Portuguese (Portugal)', 'Apply', default_url, 'undone'],
	['pa', 'Punjabi', 'Apply', default_url, 'undone'],
	['pa-IN', 'Punjabi (India)', 'Apply', default_url, 'undone'],
	['ro', 'Romanian', 'Andrei Virlan', 'mailto:%76%69%72%6C%61%6E%32%30%30%34%40%79%61%68%6F%6F%2E%63%6F%6D', 'done'],
	['ro-RO', 'Romanian (Romania)', 'Andrei Virlan', 'mailto:%76%69%72%6C%61%6E%32%30%30%34%40%79%61%68%6F%6F%2E%63%6F%6D', 'done'],
	['ru', 'Russian', 'Apply', default_url, 'undone'],
	['ru-RU', 'Russian (Russia)', 'Apply', default_url, 'undone'],
	['sa', 'Sanskrit', 'Apply', default_url, 'undone'],
	['sa-IN', 'Sanskrit (India)', 'Apply', default_url, 'undone'],
	['sr-Cyrl-CS', 'Serbian (Serbia, Cyrillic)', 'Apply', default_url, 'undone'],
	['sr-Latn-CS', 'Serbian (Serbia, Latin)', 'Apply', default_url, 'undone'],
	['sk', 'Slovak', 'Apply', default_url, 'undone'],
	['sk-SK', 'Slovak (Slovakia)', 'Apply', default_url, 'undone'],
	['sl', 'Slovenian', 'Apply', default_url, 'undone'],
	['sl-SI', 'Slovenian (Slovenia)', 'Apply', default_url, 'undone'],
	['es', 'Spanish', 'Iñigo Goiri Presa & Aitor Gomez Goiri', 'http://www.twolf.eu', 'done'],
	['es-AR', 'Spanish (Argentina)', 'Apply', default_url, 'undone'],
	['es-BO', 'Spanish (Bolivia)', 'Apply', default_url, 'undone'],
	['es-CL', 'Spanish (Chile)', 'Apply', default_url, 'undone'],
	['es-CO', 'Spanish (Colombia)', 'Apply', default_url, 'undone'],
	['es-CR', 'Spanish (Costa Rica)', 'Apply', default_url, 'undone'],
	['es-DO', 'Spanish (Dominican Republic)', 'Apply', default_url, 'undone'],
	['es-EC', 'Spanish (Ecuador)', 'Apply', default_url, 'undone'],
	['es-SV', 'Spanish (El Salvador)', 'Apply', default_url, 'undone'],
	['es-GT', 'Spanish (Guatemala)', 'Apply', default_url, 'undone'],
	['es-HN', 'Spanish (Honduras)', 'Apply', default_url, 'undone'],
	['es-MX', 'Spanish (Mexico)', 'Apply', default_url, 'undone'],
	['es-NI', 'Spanish (Nicaragua)', 'Apply', default_url, 'undone'],
	['es-PA', 'Spanish (Panama)', 'Apply', default_url, 'undone'],
	['es-PY', 'Spanish (Paraguay)', 'Apply', default_url, 'undone'],
	['es-PE', 'Spanish (Peru)', 'Apply', default_url, 'undone'],
	['es-PR', 'Spanish (Puerto Rico)', 'Apply', default_url, 'undone'],
	['es-ES', 'Spanish (Spain)', 'Apply', default_url, 'undone'],
	['es-UY', 'Spanish (Uruguay)', 'Apply', default_url, 'undone'],
	['es-VE', 'Spanish (Venezuela)', 'Apply', default_url, 'undone'],
	['sw', 'Swahili', 'Apply', default_url, 'undone'],
	['sw-KE', 'Swahili (Kenya)', 'Apply', default_url, 'undone'],
	['sv', 'Swedish', 'Apply', default_url, 'undone'],
	['sv-FI', 'Swedish (Finland)', 'Apply', default_url, 'undone'],
	['sv-SE', 'Swedish (Sweden)', 'Apply', default_url, 'undone'],
	['syr', 'Syriac', 'Apply', default_url, 'undone'],
	['syr-SY', 'Syriac (Syria)', 'Apply', default_url, 'undone'],
	['ta', 'Tamil', 'Apply', default_url, 'undone'],
	['ta-IN', 'Tamil (India)', 'Apply', default_url, 'undone'],
	['tt', 'Tatar', 'Apply', default_url, 'undone'],
	['tt-RU', 'Tatar (Russia)', 'Apply', default_url, 'undone'],
	['te', 'Telugu', 'Apply', default_url, 'undone'],
	['te-IN', 'Telugu (India)', 'Apply', default_url, 'undone'],
	['th', 'Thai', 'Apply', default_url, 'undone'],
	['th-TH', 'Thai (Thailand)', 'Apply', default_url, 'undone'],
	['tr', 'Turkish', 'Apply', default_url, 'undone'],
	['tr-TR', 'Turkish (Turkey)', 'Apply', default_url, 'undone'],
	['uk', 'Ukrainian', 'Apply', default_url, 'undone'],
	['uk-UA', 'Ukrainian (Ukraine)', 'Apply', default_url, 'undone'],
	['ur', 'Urdu', 'Apply', default_url, 'undone'],
	['ur-PK', 'Urdu (Pakistan)', 'Apply', default_url, 'undone'],
	['uz', 'Uzbek', 'Apply', default_url, 'undone'],
	['uz-Cyrl-UZ', 'Uzbek (Uzbekistan, Cyrillic)', 'Apply', default_url, 'undone'],
	['uz-Latn-UZ', 'Uzbek (Uzbekistan, Latin)', 'Apply', default_url, 'undone'],
	['vi', 'Vietnamese', 'Apply', default_url, 'undone'],
	['vi-VN', 'Vietnamese (Vietnam) ', 'Apply', default_url, 'undone']
];

// This function prints a table with language entries that
// tell if a translation exists for a language and who is handling
// the translation
//function print_translator_table()
//{
	document.writeln('<table cellpadding="4" border="1" style="font-family:Verdana;font-size:8pt;border-collapse:collapse;background-color:">');
	document.writeln('<tr style="background-color:#7aa054; font-weight:bold; color:#efe"><td>Language Code</td><td>Language</td><td>Translator</td></tr>');
	
	var current_root = '';
	for(i=0; i < lang_table.length; i++)
	{
		var lang_code = lang_table[i][0];
/*		
		var len = lang_code.indexOf('-');
		if(len != -1)
		{
			var tmp_root = lang_code.substring(0, len);
			if(tmp_root == current_root) {
				continue;
			}
			else {
				current_root = lang_code;
			}
		}
		else
		{
			current_root = lang_code;
		}
*/
		var translator_link = lang_table[i][2];
		if(lang_table[i][3] != '')
		{
			translator_link = '<a href="' + lang_table[i][3] + '">' + translator_link + '</a>';
		}
		var tr_style = ' ';
		if(lang_table[i][4] == 'done')
		{
			tr_style = ' style="background-color:#cde9a7;"';
		}
		document.writeln('<tr' + tr_style + '><td>' + lang_code + '</td><td>' + lang_table[i][1] + 
			'</td><td>' + translator_link + '</td></tr>');
	}
	document.writeln('</table>');
//}
