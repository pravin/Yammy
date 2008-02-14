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
using System.Text;
using System.Text.RegularExpressions;

namespace Yammy
{
	/// <summary>
	/// Responsible for decoding a yahoo archive
	/// </summary>
	class Decoder
	{
		#region Member Variables
		bool m_bSucceeded;
		string m_strFilePath;
		string m_strLocalID, m_strRemoteID, m_strEncryptID;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="filePath">File path of the Yahoo Archive</param>
		public Decoder(string filePath)
		{
			m_bSucceeded = false;
			m_strFilePath = filePath;
			if (!File.Exists(m_strFilePath))
			{
				Logger.Instance.LogError(filePath + " does not exist. Cannot decode.");
				return;
			}
			if (ParsePath())
			{
				m_bSucceeded = true;
			}
			else
			{
				Logger.Instance.LogError("Couldn't parse " + filePath + ". Cannot decode.");
			}
		}

		#region Properties
		public string LocalID
		{
			get { return m_strLocalID; }
		}

		public string RemoteID
		{
			get { return m_strRemoteID; }
		}
		#endregion

		/// <summary>
		/// Responsible for parsing the filePath to extract localID, remoteID and encryptID
		/// </summary>
		/// <returns>true, if successful</returns>
		bool ParsePath()
		{
			const string PROFILES = @"Profiles\";
			const string ARCHIVE = @"Archive\";
			const string MESSAGES = @"Messages\";
			int iStart, iEnd;

			#region GetEncryptID
			iStart = m_strFilePath.IndexOf(PROFILES);
			if (iStart < 0)
				return false;
			iStart += PROFILES.Length;

			iEnd = m_strFilePath.IndexOf(ARCHIVE, iStart);
			if (iEnd < 0)
				return false;

			m_strEncryptID = m_strFilePath.Substring(iStart, iEnd - iStart - 1);
			#endregion

			#region GetRemoteID
			iStart = m_strFilePath.IndexOf(MESSAGES, iEnd);
			if (iStart < 0)
				return false;
			iStart += MESSAGES.Length;
			iEnd = m_strFilePath.IndexOf('\\', iStart);
			if (iEnd < 0)
				return false;

			m_strRemoteID = m_strFilePath.Substring(iStart, iEnd - iStart);
			#endregion

			#region GetLocalID
			iStart = m_strFilePath.IndexOf('-', iEnd);
			if (iStart < 0)
				return false;
			iStart += 1;
			iEnd = m_strFilePath.IndexOf('.', iStart);
			if (iEnd < 0)
				return false;

			m_strLocalID = m_strFilePath.Substring(iStart, iEnd - iStart);
			#endregion

			return true;
		}

		/// <summary>
		/// Decodes the yahoo archive
		/// </summary>
		/// <param name="raw">If true, format for output for Indexing, else for Display</param>
		/// <param name="preview">If true, only first 3 lines are returned</param>
		/// <param name="highlight">Terms to highlight</param>
		/// <returns>Decoded string if successful, else null</returns>
		public string Decode(bool raw, bool preview, string highlight)
		{
			if (!m_bSucceeded)
				return null;

			FileStream fs;
			BinaryReader br;
			StringBuilder sb = new StringBuilder();

			try
			{
				fs = File.OpenRead(m_strFilePath);
				br = new BinaryReader(fs);
			}
			catch
			{
				return null;
			}

			byte[] buffer = new byte[512];

			int lineCount = 0;
			bool searchAnchorAdded = false; // will be set to true when #anchor is added
			while (true)
			{
				Int32 endMarker;
				Int32 timeStamp; 
				Int32 unknown;
				Int32 user;
				Int32 dataLength;

				try
				{
					timeStamp = br.ReadInt32();
					unknown = br.ReadInt32();
					user = br.ReadInt32();
					dataLength = br.ReadInt32();
				}
				catch
				{
					break;
				}

				if (dataLength <= 0)
				{
					if (!raw && !preview)
					{
						WriteConvoStarted(sb, timeStamp);
					}
					endMarker = br.ReadInt32();
					continue;
				}
				else if (user == 6)
				{
					if (!raw && !preview)
						WriteConvoStarted(sb, timeStamp);
				}
				// Check if we have a big enough buffer
                //if (dataLength > buffer.Length)
                //{
                //    buffer = new byte[dataLength];
                //}

                try
                {
                    buffer = br.ReadBytes(dataLength);
                }
                catch (EndOfStreamException e)
                {
                    Logger.Instance.LogException(e);
                    return string.Empty;
                }

				// Decode
				int pointer = 0;
				for (int i = 0; i < buffer.Length; i++)
				{
					buffer[i] = (byte)(buffer[i] ^ m_strEncryptID[pointer]);
					pointer++;
					if (pointer == m_strEncryptID.Length)
						pointer = 0;
				}

				string strCleanData = CleanData(buffer);
				if (!raw)
					strCleanData = Emote.Instance.Emotify(strCleanData);
				if (highlight != null)
				{
					string tmpCleanData = strCleanData.Replace(highlight, "<span class='hi'>" + highlight + "</span>");
					if (!searchAnchorAdded && strCleanData.Length != tmpCleanData.Length) // strings have changed
					{
						tmpCleanData = tmpCleanData.Replace(highlight, "<a name='anchor'>" + highlight + "</a>");
						searchAnchorAdded = true;
					}
					strCleanData = tmpCleanData;
				}
				string strTime = MakeDTFromCTime(timeStamp).ToLongTimeString();

				if (!raw)
				{
					sb.Append("<div><span class=\"date\">(" + strTime);
					if (user != 0)
					{
						// Remote User
						sb.Append(")</span> <span class=\"remote\">" + m_strRemoteID);
					}
					else
					{
						sb.Append(")</span> <span class=\"local\">" + m_strLocalID);
					}
					sb.Append(": </span><span class=\"msg\">" + strCleanData + "</span></div>");
				}
				else
				{
					sb.Append(strCleanData + " ");
				}

				endMarker = br.ReadInt32();

				lineCount++;
				if (preview && lineCount > 3)
					break;
			}
			br.Close();
			return sb.ToString();
		}

		/// <summary>
		/// Converts ctime to C# DateTime format
		/// </summary>
		/// <param name="ctime">ctime to convert</param>
		/// <returns>DateTime object</returns>
		private DateTime MakeDTFromCTime(int ctime)
		{
			long win32FileTime = 10000000 * (long)ctime + 116444736000000000;
			DateTime dt = DateTime.FromFileTime(win32FileTime);
			return dt;
		}

		private void WriteConvoStarted(StringBuilder sb, int timeStamp)
		{
			string date = MakeDTFromCTime(timeStamp).ToLongDateString();

			sb.Append("<div class=\"convo-started\">");
			sb.AppendFormat(Resources.Instance.GetString("ConversationStarted"), date); 
			sb.Append("</div>");
		}

		private string CleanData(byte[] data)
		{
			string strData = string.Empty;
			try
			{
				strData = Encoding.UTF8.GetString(data);
				MatchEvaluator matchEval = new MatchEvaluator(CleanDataMatchEval);
				strData = Regex.Replace(strData, "<([^>]+)>", matchEval);
			}
			catch { }
			return strData;
		}

		private string CleanDataMatchEval(Match m)
		{
			string strTag = m.Groups[1].Value;
			if (strTag.Equals("ding"))
			{
				return @"<span class=""buzz"">Buzz!</span>";
			}
			else
			{
				return string.Empty;
			}
		}
	}
}
