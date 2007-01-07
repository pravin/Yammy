using System;
using System.IO;
using Microsoft.Win32;

namespace Yammy
{
	class LocalUserInfo
	{
		public string LocalUser;
		public int TotalConvos;
		public DateTime LastConvoAt;
		public string IconPath;
		public bool ArchivingEnabled;
	}

	class YahooInfo
	{
		public static LocalUserInfo[] GetLocalUsers()
		{
			LocalUserInfo[] retVal = null;
			string strPath = Common.GetYahooPath();
			if (strPath != string.Empty)
			{
				strPath += @"\Profiles";
			}
			string[] localUsers = null;
			try
			{
				localUsers = Directory.GetDirectories(strPath);
				retVal = new LocalUserInfo[localUsers.Length];
			}
			catch (Exception e)
			{
				Logger.Instance.LogException(e);
			}

			if (localUsers == null)
				return null;

			for (int i=0; i < localUsers.Length; i++)
			{
				string localUser = localUsers[i];

				retVal[i] = new LocalUserInfo();
				// Get user icon
				retVal[i].IconPath = GetUserIconPath(localUser + @"\My Icons");

				string strRemotePath = localUser + @"\Archive\Messages";
				string[] remoteUsers = null;
				string strLocalUser = Path.GetFileName(localUser);
				if (strLocalUser == "Archive")
					continue;

				retVal[i].LocalUser = strLocalUser;

				if (Directory.Exists(strRemotePath))
				{
					remoteUsers = Directory.GetDirectories(strRemotePath);
				}

				if (remoteUsers != null)
				{
					int totalConversations = 0;
					if (remoteUsers.Length == 0)
					{
						//no messages
					}
					int lastConvoDate = 0;
					foreach (string remoteUser in remoteUsers)
					{
						string []files = Directory.GetFiles(remoteUser);
						foreach (string file in files)
						{
							try
							{
								int iDate = Int32.Parse(Path.GetFileNameWithoutExtension(file).Substring(0, 8));
								if (iDate > lastConvoDate)
									lastConvoDate = iDate;
							}
							catch{}
						}
						totalConversations += files.Length;
					}
					retVal[i].TotalConvos = totalConversations;
					string strLastConvoDate = lastConvoDate.ToString();

					retVal[i].LastConvoAt = Common.GetDateTimeFromYYYYMMDD(strLastConvoDate);

					bool archivingEnabled = false;
					try
					{
						string strKey = @"Software\Yahoo\pager\profiles\" + strLocalUser + @"\Archive";
						RegistryKey key = Registry.CurrentUser.OpenSubKey(strKey, false);
						if (key != null)
						{
							bool autoDelete = Convert.ToBoolean(key.GetValue("AutoDelete"));
							bool enabled = Convert.ToBoolean(key.GetValue("Enabled"));
							bool initialized = Convert.ToBoolean(key.GetValue("Initialized"));

							archivingEnabled = (!autoDelete) && enabled && initialized;
							key.Close();
						}
					}
					catch (Exception e)
					{
						Logger.Instance.LogException(e);
					}
					retVal[i].ArchivingEnabled = archivingEnabled;
				}
			}
			
			return retVal;
		}

		/// <summary>
		/// Parses fname to get the user icon
		/// Returns a generic icon path if not found
		/// </summary>
		/// <param name="fname">
		/// of the form:
		/// C:\Program Files\Yahoo!\Messenger\Profiles\{username}\My Icons
		/// </param>
		/// <returns></returns>
		public static string GetUserIconPath(string fname)
		{
			string retval = "/images/generic.png";
			try
			{
				StreamReader sr = new StreamReader(Path.Combine(fname, "Index.ini"));
				bool done = false;
				do
				{
					string line = sr.ReadLine();
					if (line == null)
					{
						done = true;
					}
					else
					{
						if (line.StartsWith("Icon1"))
						{
							try
							{
								int start = line.IndexOf('=');
								int end = line.IndexOf(',');
								retval = "getfile?path=" + line.Substring(start + 1, end - start - 1);
								done = true;
							}
							catch (Exception e)
							{
								Logger.Instance.LogException(e);
							}
						}
					}
				} while (!done);
				sr.Close(); sr = null;
			}
			catch (Exception e)
			{
				Logger.Instance.LogException(e);
			}
			return retval;
		}
	}
}