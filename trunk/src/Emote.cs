// Yammy - Yahoo Messenger Archives Decoder
// Copyright (C) 2005-2007, Pravin Paratey (pravinp at gmail dot com)
// http://yammy.sourceforge.net
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
using System;
using System.Text;

namespace Yammy
{
	internal class Emote
	{
		private static Emote _instance = new Emote();
		private System.Collections.Hashtable htEmotes;
		private Emote()
		{
			// Path is of the form C:\Program Files\Yahoo!\Messenger\Media\Smileys\XXX.gif
			htEmotes = new System.Collections.Hashtable(100);
			htEmotes.Add(":))", "21");
			htEmotes.Add(":)>-", "67");
			htEmotes.Add(":)", "1");
			htEmotes.Add(":-)", "1");
			htEmotes.Add(":((", "20");
			htEmotes.Add(":(", "2");
			htEmotes.Add(":-(", "2");
			htEmotes.Add(";))", "71");
			htEmotes.Add(";)", "3");
			htEmotes.Add(";-)", "3");
			htEmotes.Add(":D", "4");
			htEmotes.Add(":-D", "4");
			htEmotes.Add(";;)", "5");
			htEmotes.Add(">:D<", "6");
			htEmotes.Add(":-/", "7");
			htEmotes.Add(":x", "8");
			htEmotes.Add(":\">", "9");
			htEmotes.Add(":P", "10");
			htEmotes.Add(":-P", "10");
			htEmotes.Add(":-*", "11");
			htEmotes.Add(":*", "11");
			htEmotes.Add("=((", "12");
			htEmotes.Add(":-O", "13");
			htEmotes.Add(":O", "13");
			htEmotes.Add("X(", "14");
			htEmotes.Add(":>", "15");
			htEmotes.Add("B-)", "16");
			htEmotes.Add(":-S", "17");
			htEmotes.Add("#:-S", "18");
			htEmotes.Add(">:)", "19");
			htEmotes.Add(":|", "22");
			htEmotes.Add("/:)", "23");
			htEmotes.Add("=))", "24");
			htEmotes.Add("O:)", "25");
			htEmotes.Add(":-B", "26");
			htEmotes.Add("=;", "27");
			htEmotes.Add("I-|", "28");
			htEmotes.Add("8-|", "29");
			htEmotes.Add("L-)", "30");
			htEmotes.Add(":-&", "31");
			htEmotes.Add(":&", "31");
			htEmotes.Add(":-$", "32");
			htEmotes.Add("[-(", "33");
			htEmotes.Add(":o)", "34");
			htEmotes.Add("8-}", "35");
			htEmotes.Add("<:-P", "36");
			htEmotes.Add("(:|", "37");
			htEmotes.Add("=P~", "38");
			htEmotes.Add(":-?", "39");
			htEmotes.Add("#-o", "40");
			htEmotes.Add("=D>", "41");
			htEmotes.Add(":-SS", "42");
			htEmotes.Add("@-)", "43");
			htEmotes.Add(":^o", "44");
			htEmotes.Add(":-w", "45");
			htEmotes.Add(":-<", "46");
			htEmotes.Add(">:P", "47");
			htEmotes.Add("<):)", "48");
			htEmotes.Add(":@)", "49");
			htEmotes.Add("3:-O", "50");
			htEmotes.Add(":(|)", "51");
			htEmotes.Add("~:>", "52");
			htEmotes.Add("@};-", "53");
			htEmotes.Add("%%-", "54");
			htEmotes.Add("**==", "55");
			htEmotes.Add("(~~)", "56");
			htEmotes.Add("~O)", "57");
			htEmotes.Add("*-:", "58");
			htEmotes.Add("8-X", "59");
			htEmotes.Add("=:)", "60");
			htEmotes.Add(">-)", "61");
			htEmotes.Add(":-L", "62");
			htEmotes.Add("[-O<", "63");
			htEmotes.Add("$-)", "64");
			htEmotes.Add(":-\"", "65");
			htEmotes.Add("b-(", "66");
			htEmotes.Add("[-X", "68");
			htEmotes.Add("\\:D/", "69");
			htEmotes.Add(">:/", "70");
			htEmotes.Add("o->", "72");
			htEmotes.Add("0=>", "73");
			htEmotes.Add("o-+", "74");
			htEmotes.Add("(%)", "75");
			htEmotes.Add(":-@", "76");
			htEmotes.Add("^:)^", "77");
			htEmotes.Add(":-j", "78");
			htEmotes.Add("(*)", "79");
			htEmotes.Add(":)]", "100");
			htEmotes.Add(":-C", "101");
			htEmotes.Add("~X(", "102");
			htEmotes.Add(":-h", "103");
			htEmotes.Add(":-t", "104");
			htEmotes.Add("8->", "105");
			htEmotes.Add(":-??", "106");
			htEmotes.Add("%-(", "107");
		}

		public static Emote Instance
		{
			get
			{
				return _instance;
			}
		}

		public string Emotify(string inputText)
		{
			StringBuilder sb = new StringBuilder(inputText.Length);
			for (int i = 0; i < inputText.Length; i++)
			{
				string strEmote = string.Empty;
				foreach (string emote in htEmotes.Keys)
				{
					if (inputText.Length - i >= emote.Length &&
						emote.Equals(inputText.Substring(i, emote.Length), StringComparison.InvariantCultureIgnoreCase))
					{
						strEmote = emote;
						break;
					}
				}

				if (strEmote.Length != 0)
				{
					sb.Append("<img src=\"/images/" + htEmotes[strEmote] + ".gif" + "\" alt='" + strEmote + "'/>");
					i += strEmote.Length - 1;
				}
				else
				{
					sb.Append(inputText[i]);
				}
			}
			return sb.ToString();
		}
	}
}
