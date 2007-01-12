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
using System.Collections.Specialized;
using System.Text.RegularExpressions;

using Yammy.Properties;

namespace Yammy
{
	class Search
	{
		public static string DoSearch(NameValueCollection queryString)
		{
			StringBuilder sb = new StringBuilder(Resources.SearchBoxHTMLSnippet);
			const int SEARCHRESULTS_PER_PAGE = 10;
			if (queryString != null)
			{
				string searchTerm = queryString["query"];
				int offset = 0;
				try
				{
					string pageNumber = queryString["page"];
					if (pageNumber != null)
					{
						offset = Int32.Parse(pageNumber) * SEARCHRESULTS_PER_PAGE; 
					}
				}
				catch { }
				Indexer search = new Indexer(Config.Instance.IndexPath, IndexMode.SEARCH);
				IndexInfo[] searchResults = search.Search(searchTerm, offset);
				if (searchResults == null)
				{
					return "No Index found";
				}
				sb.Append("<h1>Searching for " + searchTerm + "</h1>");
				if (searchResults.Length < 1)
				{
					sb.Append("No results found");
					return sb.ToString();
				}
				
				sb.Append("<div style=\"text-align:center;font-style:italic\">" +
						  string.Format(Resources.NumSearchResults, offset + 1, offset + searchResults.Length) + "</div>");
				sb.Append("<ol>");
				foreach (IndexInfo result in searchResults)
				{
					sb.Append("<li><a href=\"/decode?localuser=" + result.LocalUser +
						"&remoteuser=" + result.RemoteUser + 
						"&type=i&fname=" + System.IO.Path.GetFileNameWithoutExtension(result.Location) + "\">" +
						string.Format(Resources.ConversationBetween, result.LocalUser, result.RemoteUser) +
						"</a><br />" + GetExcerpt(result.Message, searchTerm) + "</li>");
				}
				sb.Append("</ol>");

				bool moreResults = false;
				string strNext = string.Empty;
				if (searchResults.Length == SEARCHRESULTS_PER_PAGE)
				{
					strNext = string.Format("<a href=\"yammy:search?query={0}&offset={1}\">{2}</a>", searchTerm, offset + SEARCHRESULTS_PER_PAGE, "Next");
					moreResults = true;
				}

				string strPrev = string.Empty;
				if (offset > SEARCHRESULTS_PER_PAGE-1)
				{
					strPrev = string.Format("<a href=\"yammy:search?query={0}&offset={1}\">{2}</a>", searchTerm, offset + SEARCHRESULTS_PER_PAGE, "Prev");
					moreResults = true;
				}

				if (moreResults)
				{
					sb.Append("<div>" + strPrev + " | " + strNext + "</div>");
				}
			}
			else // Advanced search
			{
				sb.Append("advancedS");
			}
			return sb.ToString();
		}

		/// <summary>
		/// Gets a small paragraph of the text to display on the search results page
		/// </summary>
		/// <param name="text">The text gotten from the index</param>
		/// <param name="searchTerm"></param>
		/// <returns>small paragraph of text</returns>
		public static string GetExcerpt(string text, string searchTerm)
		{
			const int textWindow = 100;
			string[] searchTerms = searchTerm.Split('+');
			int iStart = 0;
			int iEnd = text.Length;

			// Get the position of the first term
			foreach (string term in searchTerms)
			{
				int position = text.IndexOf(term, StringComparison.InvariantCultureIgnoreCase);
				if (position >= 0)
				{
					if (position > textWindow)
					{
						iStart = position - textWindow;
					}

					if (position + textWindow < text.Length)
					{
						iEnd = position + textWindow;
					}

					break; // if atleast one term is present
				}
			}
			string strExcerpt = text.Substring(iStart, iEnd - iStart);
			MatchEvaluator matchBoldify = new MatchEvaluator(Boldify);
			// Make all search terms bold
			foreach (string term in searchTerms)
			{
				strExcerpt = Regex.Replace(strExcerpt, term, matchBoldify, RegexOptions.IgnoreCase);
			}

			return strExcerpt;
		}
		/// <summary>
		/// Highlights the search terms in the search results page by making them bold
		/// </summary>
		/// <param name="m">RegEx Match</param>
		/// <returns>string with the search terms in bold</returns>
		public static string Boldify(Match m)
		{
			return "<b style='background:#ff6'>" + m.Value + "</b>";
		}
	}
}
