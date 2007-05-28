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
using System.IO;
using System.Collections.Specialized;
using System.Text;

namespace Yammy
{
	class Decode
	{
		public static string DoDecode(NameValueCollection queryString)
		{
			string localUser = queryString["localuser"];
			string type = queryString["type"];
			string remoteUser = queryString["remoteuser"];
			string fname = queryString["fname"];
			string page = queryString["page"];
			string highlight = queryString["hi"];
			const int PREVIEW_NUMBER = 5;

			string strDecode = string.Empty;
			if (fname == null)
			{
				try
				{
					// Show preview of 10
					StringBuilder sbDecode = new StringBuilder(
						"<div class='crumb'><a href='/'>Users</a> &raquo; <a href='/show?localuser=" +
						localUser + "'>" + localUser + "</a> &raquo; " + remoteUser + "</div>" +
						"<h1>Conversations between " + localUser + " and " + remoteUser + "</h1>");
					sbDecode.Append("<div class='tinyavatar'><img src='" + NetServices.GetUserIcon(remoteUser) +
						"' alt='" + remoteUser + "'/></div>");
					string dirName = Common.ConstructPath(localUser, type, remoteUser, string.Empty);
					string[] files = Directory.GetFiles(dirName);

					int start = 0;
					int end = PREVIEW_NUMBER;
					try
					{
						if (page != null)
						{
							start = Int32.Parse(page);
							end = start + PREVIEW_NUMBER;
						}
						if (end > files.Length)
							end = files.Length;
					}
					catch { }
					for (int i = start; i < end; i++)
					{
						string fileName = files[i];
						string strRawDate = Path.GetFileNameWithoutExtension(fileName).Split('-')[0];
						int iYear = Int32.Parse(strRawDate.Substring(0, 4));
						int iDay = Int32.Parse(strRawDate.Substring(6, 2));
						int iMonth = Int32.Parse(strRawDate.Substring(4, 2));
						DateTime dt = new DateTime(iYear, iMonth, iDay);
						string strPrettyDate = dt.ToLongDateString();

						sbDecode.Append("<div class=\"date\">" + strPrettyDate + "</div>");

						Decoder d = new Decoder(fileName);
						sbDecode.Append(d.Decode(false, true, null));
						sbDecode.AppendFormat("<p>[<a href=\"/decode?localuser={0}&type=i&remoteuser={1}&fname={2}\">{3}</a>]</p>",
							localUser, remoteUser, Path.GetFileNameWithoutExtension(fileName), Resources.Instance.GetString("More"));
					}
					sbDecode.Append("<div class=\"page-nav\">");

					if (start > 0)
					{
						sbDecode.AppendFormat("<a href=\"/decode?localuser={0}&type=i&remoteuser={1}&page={2}\" class=\"prev\">{3}</a>",
							localUser, remoteUser, start - PREVIEW_NUMBER, Resources.Instance.GetString("PrevPage"));
					}
					else
					{
						sbDecode.Append("<a class=\"prev\">" + Resources.Instance.GetString("PrevPage") + "</a>");
					}
					if (end < files.Length)
					{
						sbDecode.AppendFormat(" <a href=\"/decode?localuser={0}&type=i&remoteuser={1}&page={2}\" class=\"next\">{3}</a>",
							localUser, remoteUser, start + PREVIEW_NUMBER, Resources.Instance.GetString("NextPage"));
					}
					else
					{
						sbDecode.Append(" <a class=\"next\">" + Resources.Instance.GetString("NextPage") + "</a>");
					}
					//sbDecode.AppendFormat(" <span class=\"red-button\"><a href=\"/export?localuser={0}&type=i&remoteuser={1}\">{2}</a></span>",
					//        localUser, remoteUser, Resources.Instance.GetString("ExportConvos"));
					sbDecode.Append("</div>");
					strDecode = sbDecode.ToString();
				}
				catch (Exception e)
				{
					Logger.Instance.LogException(e);
				}
			}
			else
			{
				string fileName = Common.ConstructPath(localUser, type, remoteUser, fname);
				Decoder d = new Decoder(fileName + ".dat");
				strDecode = "<div class='crumb'><a href='/'>Users</a> &raquo; <a href='/show?localuser=" +
						localUser + "'>" + localUser + "</a> &raquo; <a href='/decode?localuser=" + localUser +
						"&remoteuser=" + remoteUser + "&type=i'>" + remoteUser + "</a> &raquo; " + 
						Common.GetDateTimeFromYYYYMMDD(fname.Substring(0,8)).ToShortDateString() + "</div>";
				
				if (highlight != null) // Highlight search term if we came from the search page
				{
					highlight = Uri.UnescapeDataString(highlight);
					highlight = highlight.Replace('+', ' '); // clean highlight
				}
				strDecode += d.Decode(false, false, highlight);
			}
			return strDecode;
		}
	}
}
