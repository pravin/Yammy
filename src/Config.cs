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
using Microsoft.Win32;
using System.Collections;
using System.Globalization;
using System.Collections.Specialized;

namespace Yammy
{
	/// <summary>
	/// Used to return archiving options for a user from the registry
	/// </summary>
	public sealed class UserArchiveFlag
	{
		/// <summary>
		/// Yahoo Id of the user
		/// </summary>
		public string YahooId;
		public bool EnableArchiving;
	}

	/// <summary>
	/// Handles Configuration and Settings for Yammy
	/// </summary>
	public sealed class Config
	{
		#region Member Variables
		private static Config _instance = new Config();
		private string m_strYammyAppData;
		private string m_strConfigFilePath;
		private string m_strTempIndexPath;
		private string m_strIndexPath;
		private string m_strYahooProfilesPath;
		private string m_strCachePath;
		private int m_iIndexUpdateFrequency;
		private DateTime m_dtIndexLastUpdated;
		private ArrayList m_arUserList;
		private string m_strLocale;
		#endregion

		const string ConstYahooProfilesPath = "YahooProfilesPath";
		const string ConstIndexLastUpdated = "IndexLastUpdated";
		const string ConstIndexUpdateFrequency = "IndexUpdateFrequency";
		const string ConstShowEmotes = "ShowEmotes";
		const string ConstShowLastXMonthsChatLogs = "ShowLastXMonthsChatLogs";
		const string ConstLocale = "Locale";

		/// <summary>
		/// Gets a singleton instance of the class
		/// </summary>
		public static Config Instance
		{
			get
			{
				return _instance;
			}
		}

		#region Constructor
		private Config()
		{
			try
			{
				m_strYammyAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Yammy");
				m_strConfigFilePath = Path.Combine(m_strYammyAppData, "config.ini");
				m_strTempIndexPath = Path.Combine(m_strYammyAppData, "TempIndex");
				m_strIndexPath = Path.Combine(m_strYammyAppData, "Index");
				m_strCachePath = Path.Combine(WebServer.Instance.WebRoot, "Cache");
				m_arUserList = new ArrayList(4);
				if (!Directory.Exists(m_strCachePath))
				{
					Directory.CreateDirectory(m_strCachePath);
				}
			}
			catch (IOException e)
			{
				throw e;
			}

			ReadConfig();
			LoadUserList();
		}
		#endregion

		/// <summary>
		/// Fills in variables from the config file
		/// Variables are:
		/// - IndexUpdateFreq
		/// - Language
		/// </summary>
		private void ReadConfig()
		{
			// Set default values
			m_iIndexUpdateFrequency = 24;
			m_strLocale = "en";

			if (!File.Exists(m_strConfigFilePath))
				return;

			StreamReader reader = null;
			try
			{
				reader = new StreamReader(m_strConfigFilePath, System.Text.Encoding.UTF8);
			}
			catch (IOException e)
			{
				Logger.Instance.LogException(e);
				return;
			}

			while (true)
			{
				string strLine = reader.ReadLine();
				if (strLine == null)
					break;

				string[] strNameValue = strLine.Split('=');
				if (strNameValue.Length != 2)
					continue;

				switch (strNameValue[0].Trim())
				{
					case ConstYahooProfilesPath:
						m_strYahooProfilesPath = strNameValue[1].Trim();
						break;
					case ConstIndexUpdateFrequency:
						try
						{
							m_iIndexUpdateFrequency = Int32.Parse(strNameValue[1].Trim());
						}
						catch
						{
							m_iIndexUpdateFrequency = 24;
						}
						break;
					case ConstIndexLastUpdated:
						try
						{
							m_dtIndexLastUpdated = DateTime.Parse(strNameValue[1].Trim());
						}
						catch
						{
							m_dtIndexLastUpdated = DateTime.MinValue;
						}
						break;
					case ConstLocale:
						try
						{
							m_strLocale = strNameValue[1].Trim();
						}
						catch
						{
							m_strLocale = "en";
						}
						break;
					default:
						Logger.Instance.LogError("ReadConfig: " + strNameValue[0]);
						break;
				}

			}
			reader.Close();
		}

		/// <summary>
		/// Saves configuration options to disk
		/// </summary>
		public void SaveConfig()
		{
			StreamWriter writer = null;

			try
			{
				writer = new StreamWriter(m_strConfigFilePath, false, System.Text.Encoding.UTF8);
			}
			catch (IOException e)
			{
				Logger.Instance.LogException(e);
				return;
			}
			writer.WriteLine(ConstYahooProfilesPath + "=" + m_strYahooProfilesPath);
			writer.WriteLine(ConstIndexLastUpdated + "=" + m_dtIndexLastUpdated);
			writer.WriteLine(ConstIndexUpdateFrequency + "=" + m_iIndexUpdateFrequency);
			writer.WriteLine(ConstLocale + "=" + m_strLocale);
			writer.Flush(); writer.Close(); writer = null;
		}

		/// <summary>
		/// Loads the list of yahoo messenger users from the registry
		/// </summary>
		private void LoadUserList()
		{
			// TODO: 
			// In registry, HKCU\Software\yahoo\pager\profiles\user,
			// presence of All Identities means the user is a user and not a bad key
			RegistryKey keyUserList = Registry.CurrentUser.OpenSubKey(@"Software\yahoo\pager\profiles");
			if (keyUserList == null) // Yahoo Messenger not installed
				return;
			string[] strUserList = keyUserList.GetSubKeyNames();

			byte[] iValue = new byte[8];

			foreach (string user in strUserList)
			{
				RegistryKey keySubKey = keyUserList.OpenSubKey(user, false);
				object o = keySubKey.GetValue("All Identities");
				if (o != null)
				{
					UserArchiveFlag u = new UserArchiveFlag();
					u.YahooId = user;
					RegistryKey keySubSubKey = keySubKey.OpenSubKey("Archive");
					u.EnableArchiving = false; // Set default value to false
					if (keySubSubKey != null)
					{
						try
						{
							iValue = (byte[])keySubSubKey.GetValue("ArchiveSettings1");
						}
						catch (Exception e)
						{
							Logger.Instance.LogException(e);
						}
						if (iValue != null && iValue[0] == 0xdf && iValue[1] == 0xff)
						{
							u.EnableArchiving = true;
						}
					}
					m_arUserList.Add(u);
				}
			}
		}

		/// <summary>
		/// Gets/Sets the path where Yahoo Profiles are kept
		/// </summary>
		public string YahooProfilesPath
		{
			get { return m_strYahooProfilesPath; }
			set { m_strYahooProfilesPath = value; }
		}
		/// <summary>
		/// Gets path for Application Data\Yammy
		/// </summary>
		public string YammyAppData
		{
			get { return m_strYammyAppData; }
		}
		/// <summary>
		/// Gets path of the temporary index
		/// </summary>
		public string TempIndexPath
		{
			get { return m_strTempIndexPath; }
		}
		/// <summary>
		/// Gets path of Index
		/// </summary>
		public string IndexPath
		{
			get { return m_strIndexPath; }
		}
		/// <summary>
		/// Gets/sets the last updated date/time of our index
		/// </summary>
		public DateTime IndexLastUpdated
		{
			get { return m_dtIndexLastUpdated; }
			set { m_dtIndexLastUpdated = value; }
		}
		/// <summary>
		/// This parameter gets/sets the frequency with which we should regenerate our index
		/// </summary>
		public int IndexUpdateFrequency
		{
			get { return m_iIndexUpdateFrequency; }
			set { m_iIndexUpdateFrequency = value; }
		}
		/// <summary>
		/// Gets/Sets the path where user avatars are cached
		/// </summary>
		public string CachePath
		{
			get { return m_strCachePath; }
			set { m_strCachePath = value; }
		}
		/// <summary>
		/// Gets a list of all yahoo messenger users from the windows registry.
		/// This helps turn on/off their archiving options
		/// </summary>
		public ArrayList UserList
		{
			get { return m_arUserList; }
		}

		/// <summary>
		/// Gets the Locale as specified by the user
		/// </summary>
		public string Locale
		{
			get { return m_strLocale; }
		}

		public string DoSettings(NameValueCollection queryString)
		{
			int updateFreq;

			string[] locales = Directory.GetFiles(@"Webroot", "*.js");

			if (queryString != null)
			{
				string updateFrequency = Uri.EscapeDataString(queryString["UpdateFreq"]);
				try
				{
					int freq = Int32.Parse(updateFrequency);
					m_iIndexUpdateFrequency = freq;
				}
				catch (Exception e)
				{
					Logger.Instance.LogDebug("Settings: " + e.Message);
				}
				string language = Uri.EscapeDataString(queryString["Language"]);
				if (language != m_strLocale)
				{
					Resources.Instance.LoadVars(Path.Combine(@"Webroot\", language + ".js"));
					m_strLocale = language;
				}
				SaveConfig();
			}

			updateFreq = m_iIndexUpdateFrequency;

			string languages = @"<select name=""Language"">";
			foreach (string locale in locales)
			{
				try
				{
					int start = locale.IndexOf(Path.DirectorySeparatorChar) + 1;
					int end = locale.IndexOf('.') - 1;
					string localeName = locale.Substring(start, end - start + 1);
					// TODO:? Add a try/catch block here so that if GetCultureInfo fails
					// we can still show the option
					CultureInfo culture = CultureInfo.GetCultureInfo(localeName);
					languages += "<option value='" + localeName +
						(localeName == m_strLocale ? "' selected='selected" : string.Empty) +
						"'>" + culture.NativeName + "</option>";
				}
				catch (Exception e)
				{
					Logger.Instance.LogException(e);
				}
			}

			languages += "</select>";

			string strOutput = "<h1>" + Resources.Instance.GetString("Settings") + "</h1>" +
				@"<form action=""/settings"" method=""GET"">" +
				@"<table border=""0"" cellspacing=""2"" cellpadding=""5"">" +
				"<tr><td>" + Resources.Instance.GetString("UpdateFreq") + "</td><td>" +
					@"<input type=""text"" name=""UpdateFreq"" size=""4"" value=""" + updateFreq.ToString() + @"""/> " +
						Resources.Instance.GetString("Hours") + "</td></tr>" +
				"<tr><td>" + Resources.Instance.GetString("Language") + "</td><td>" + languages + "</td></tr>" +
				@"</table><input type=""submit"" value=""" + Resources.Instance.GetString("SaveSettings") + @""" /></form>";
			return strOutput;
		}
	}
}
