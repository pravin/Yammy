// Yammy - Yahoo Messenger Archives Decoder
// Copyright (C) 2005-2006, Pravin Paratey (pravinp at gmail dot com)
// http://yammy.sf.net
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
		private int m_iSplitterWidth;
		private int m_iIndexUpdateFrequency;
		private DateTime m_dtIndexLastUpdated;
		private ArrayList m_arUserList;
		private string m_strDisplayHtml;
		#endregion
		
		const string ConstYahooProfilesPath = "YahooProfilesPath";
		const string ConstSplitterWidth = "SplitterWidth";
		const string ConstIndexLastUpdated = "IndexLastUpdated";
		const string ConstIndexUpdateFrequency = "IndexUpdateFrequency";
		const string ConstShowEmotes = "ShowEmotes";
		const string ConstShowLastXMonthsChatLogs = "ShowLastXMonthsChatLogs";
		
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
		
		private Config()
		{
			try
			{
				m_strYammyAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Yammy");
				m_strConfigFilePath = Path.Combine(m_strYammyAppData, "config.ini");
				m_strTempIndexPath = Path.Combine(m_strYammyAppData, "TempIndex");
				m_strIndexPath = Path.Combine(m_strYammyAppData, "Index");
				m_arUserList = new ArrayList(4);

				string strFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "default.html");
				m_strDisplayHtml = string.Empty;
				StreamReader sr = null;
				if (File.Exists(strFilename))
				{
					sr = new StreamReader(strFilename);
					m_strDisplayHtml = sr.ReadToEnd();
					sr.Close();
				}

				strFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dark.css");
				string strCSS = string.Empty;
				if (File.Exists(strFilename))
				{
					sr = new StreamReader(strFilename);
					strCSS = sr.ReadToEnd();
					sr.Close();
				}

				m_strDisplayHtml = m_strDisplayHtml.Replace("<$ReplaceByStyleSheet$>", strCSS);
			}
			catch(IOException e)
			{
				throw e;
			}
			
			ReadConfig();
			LoadUserList();
		}
		
		/// <summary>
		/// Fills in variables from the config file
		/// </summary>
		private void ReadConfig()
		{
			// Set default values
			GetYahooProfilesPath();
			m_iSplitterWidth = 150;
			m_iIndexUpdateFrequency = 24;
			
			if(!File.Exists(m_strConfigFilePath))
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
			
			while(true)
			{
				string strLine = reader.ReadLine();
				if(strLine == null)
					break;
				
				string []strNameValue = strLine.Split('=');
				if(strNameValue.Length != 2)
					continue;
				
				switch(strNameValue[0].Trim())
				{
					case ConstYahooProfilesPath:
						m_strYahooProfilesPath = strNameValue[1].Trim();
						break;
					case ConstSplitterWidth:
						try
						{
							m_iSplitterWidth = Int32.Parse(strNameValue[1].Trim());
						}
						catch
						{
							m_iSplitterWidth = 150;
						}
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
					default:
						Logger.Instance.LogError("ReadConfig: " + strNameValue[0]);
						break;
				}
				
			}
			reader.Close();
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
			string []strUserList = keyUserList.GetSubKeyNames();
			
			byte []iValue = new byte[8];
			
			foreach(string user in strUserList)
			{
				RegistryKey keySubKey = keyUserList.OpenSubKey(user, false);
				object o = keySubKey.GetValue("All Identities");
				if(o != null)
				{
					UserArchiveFlag u = new UserArchiveFlag();
					u.YahooId = user;
					RegistryKey keySubSubKey = keySubKey.OpenSubKey("Archive");
					u.EnableArchiving = false; // Set default value to false
					if(keySubSubKey != null)
					{
						try
						{
							iValue = (byte []) keySubSubKey.GetValue("ArchiveSettings1");
						}
						catch (Exception e)
						{
							Logger.Instance.LogException(e);
						}
						if(iValue != null && iValue[0] == 0xdf && iValue[1] == 0xff)
						{
							u.EnableArchiving = true;
						}
					}
					m_arUserList.Add(u);
				}
			}
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
			writer.WriteLine(ConstSplitterWidth + "=" + m_iSplitterWidth);
			writer.WriteLine(ConstIndexLastUpdated + "=" + m_dtIndexLastUpdated);
			writer.WriteLine(ConstIndexUpdateFrequency + "=" + m_iIndexUpdateFrequency);
			writer.Close(); writer = null;
		}
		
		/// <summary>
		/// Tries to get the path to the Archives folder by scanning the registry key
		/// </summary>
		private void GetYahooProfilesPath()
		{
			m_strYahooProfilesPath = string.Empty;
			RegistryKey keyYahooPagerLocation = Registry.ClassesRoot.OpenSubKey(@"ymsgr\shell\open\command");
			if (keyYahooPagerLocation != null)
			{
				m_strYahooProfilesPath = keyYahooPagerLocation.GetValue(String.Empty) as string; // Get default string
			}
			if (m_strYahooProfilesPath != null && m_strYahooProfilesPath.Length > 0)
			{
				m_strYahooProfilesPath = m_strYahooProfilesPath.Substring(m_strYahooProfilesPath.IndexOf("\"")+1, m_strYahooProfilesPath.LastIndexOf('\\'));
			}
		}
		/// <summary>
		/// Gets/Sets width of the splitter
		/// </summary>
		public int SplitterWidth
		{
			get { return m_iSplitterWidth; }
			set { m_iSplitterWidth = value; }
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
		/// Gets a list of all yahoo messenger users from the windows registry.
		/// This helps turn on/off their archiving options
		/// </summary>
		public ArrayList UserList
		{
			get { return m_arUserList; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string DisplayHtml
		{
			get
			{
				return m_strDisplayHtml;
			}
		}
	}
}
