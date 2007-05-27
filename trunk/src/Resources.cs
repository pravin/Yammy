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
using System.Collections;
using System.Text.RegularExpressions;

namespace Yammy
{
	public class Resources
	{
		private static Resources _instance = new Resources();
		private Hashtable m_htMap; // stores the translation map

		public static Resources Instance
		{
			get { return _instance; }
		}

		/// <summary>
		/// Constructor
		/// Will call a function to load all variables
		/// </summary>
		private Resources()
		{
			string resFile = Path.Combine(@"Webroot\", Config.Instance.Locale + ".js");
			if (!File.Exists(resFile))
			{
				resFile = @"Webroot\en.js";
			}
			m_htMap = new Hashtable(100);
			LoadVars(resFile);
		}

		/// <summary>
		/// This function reads the javascript file specified by fileName and loads its variables
		/// </summary>
		/// <param name="fileName"></param>
		public void LoadVars(string fileName)
		{
			m_htMap.Clear(); // clear hashmap
			StreamReader sr = null;
			try
			{
				sr = new StreamReader(fileName);
				while (true)
				{
					string line = sr.ReadLine();
					if (line == null)
						break;
					line = line.Trim();
					if (line.StartsWith("var")) // Valid variable
					{
						string []value = Regex.Split(line, @"var\s*(\w*)\s*=\s*""(.*)""");
						if (value.Length == 4)
						{
							if (!m_htMap.ContainsKey(value[1]))
							{
								m_htMap.Add(value[1], value[2]);
							}
						}
					}
				}
			}
			catch (Exception e)
			{
				Logger.Instance.LogException(e);
				return;
			}
			finally
			{
				if (sr != null)
				{
					sr.Close(); sr = null;
				}
			}
		}

		/// <summary>
		/// Call this with key to get its translation
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public string GetString(string key)
		{
			string translation = m_htMap[key] as string;
			if(translation == null)
			{
				translation = "ERROR-STRING-NOT-FOUND:" + key;
			}
			return translation;
		}
	}
}
