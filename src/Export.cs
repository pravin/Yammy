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

using System.Windows.Forms;

using Yammy.Properties;

namespace Yammy
{
	public class ExportParams
	{
		private string m_strLocalUser;
		private string m_strRemoteUser;
		private string m_strFormat;
		private string m_strFileName;
		
		public ExportParams(string localUser, string remoteUser, string format, string fileName)
		{
			m_strLocalUser = localUser;
			m_strRemoteUser = remoteUser;
			m_strFormat = format;
			m_strFileName = fileName;
		}

		public string LocalUser
		{
			get
			{
				return m_strLocalUser;
			}
		}
		public string RemoteUser
		{
			get
			{
				return m_strRemoteUser;
			}
		}
		public string Format
		{
			get
			{
				return m_strFormat;
			}
		}
		public string FileName
		{
			get
			{
				return m_strFileName;
			}
		}
	}

	public static class Export
	{
		private static string m_strHeader =
@"<html>
	<head>
	<title><$PageTitle$></title>
	<link href=""/screen.css"" rel=""stylesheet"" type=""text/css"" media=""screen"" />
	<link href=""/print.css"" rel=""stylesheet"" type=""text/css"" media=""print"" />
	</head>
	<body>
";
		private static string m_strFooter = @"</body></html>";

		/// <summary>
		/// Exports messages to html file
		/// </summary>
		/// <param name="o"></param>
		public static void ExportMe(object o)
		{
			ExportParams e = o as ExportParams;
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.CheckPathExists = true;
			dialog.DefaultExt = "*.htm";
			dialog.Filter = "Html file|*.htm";
			dialog.ValidateNames = true;
			dialog.OverwritePrompt = true;
			DialogResult result = dialog.ShowDialog();
			MessageBox.Show("Test");
			if (result == DialogResult.OK)
			{
				string outputFileName = dialog.FileName;
				if (e.FileName != null)
				{
					StreamWriter sw = null;
					string path = Common.ConstructPath(e.LocalUser, "i", e.RemoteUser, e.FileName);
					if (Directory.Exists(path))
					{
						try
						{
							sw = new StreamWriter(outputFileName);
							sw.WriteLine(m_strHeader);
							string[] files = Directory.GetFiles(path);
							foreach (string file in files)
							{
								Decoder d = new Decoder(file);
								sw.WriteLine(d.Decode(false, false));
							}
							sw.WriteLine(m_strFooter);
						}
						catch (Exception ex)
						{
							Logger.Instance.LogException(ex);
						}
						finally
						{
							if (sw != null)
							{
								sw.Close(); sw = null;
							}
						}
					}
					else
					{
						try
						{
							sw = new StreamWriter(outputFileName);
							Decoder d = new Decoder(path);
							sw.Write(m_strHeader.Replace("<$PageTitle$>", "TODO"));
							sw.Write(d.Decode(false, false));
							sw.Write(m_strFooter);
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, Resources.Error);
						}
						finally
						{
							if (sw != null)
							{
								sw.Close(); sw = null;
							}
						}
					}
				}
			}
		}
	}
}
