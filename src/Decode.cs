// Yammy - Yahoo Messenger Archives Decoder
// Copyright (C) 2005-2006, Pravin Paratey (pravinp at gmail dot com)
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

using Yammy.Properties;

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
			const int PREVIEW_NUMBER = 5;

			string strDecode = string.Empty;
			if (fname == null)
			{
				try
				{
					// Show preview of 10
					StringBuilder sbDecode = new StringBuilder();
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
						sbDecode.Append(d.Decode(false, true));
						sbDecode.AppendFormat("<p>[<a href=\"/decode?localuser={0}&type=i&remoteuser={1}&fname={2}\">{3}</a>]</p>",
							localUser, remoteUser, Path.GetFileNameWithoutExtension(fileName), Resources.More);
					}
					sbDecode.Append("<div class=\"page-nav\">");

					if (start > 0)
					{
						sbDecode.AppendFormat("<a href=\"/decode?localuser={0}&type=i&remoteuser={1}&page={2}\">{3}</a>",
							localUser, remoteUser, start - PREVIEW_NUMBER, Resources.PrevPage);
					}
					else
					{
						sbDecode.Append("<span class=\"disabled-button\">" + Resources.PrevPage + "</span>");
					}
					if (end < files.Length)
					{
						sbDecode.AppendFormat(" <a href=\"/decode?localuser={0}&type=i&remoteuser={1}&page={2}\">{3}</a>",
							localUser, remoteUser, start + PREVIEW_NUMBER, Resources.NextPage);
					}
					else
					{
						sbDecode.Append(" <span class=\"disabled-button\">" + Resources.NextPage + "</span>");
					}
					sbDecode.AppendFormat(" <span class=\"red-button\"><a href=\"/export?localuser={0}&type=i&remoteuser={1}\">{2}</a></span>",
							localUser, remoteUser, Resources.ExportConvos);
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
				strDecode = d.Decode(false, false);
			}
			return strDecode;
		}
	}
}
