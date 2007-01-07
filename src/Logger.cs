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
using System.Threading;
using System.Collections;

using Yammy.Properties;

namespace Yammy
{
	/// <summary>
	/// File logger to log messages
	/// </summary>
	class Logger : IDisposable
	{
		#region Private Vars
		private static Logger _instance = new Logger();
		private static object m_lock = new object();
		StreamWriter m_objStreamWriter;
		Queue m_logQueue;
		bool m_bAlternate;
		Timer m_timer;
		#endregion

		private Logger()
		{
			m_bAlternate = false;
			m_logQueue = new Queue(100, 10);
			string strLogPath = "YammyLog.html";

			if (Settings.Default.ApplicationPath != null && Settings.Default.ApplicationPath != string.Empty)
			{
				try
				{
					strLogPath = Path.Combine(Settings.Default.ApplicationPath, strLogPath);
				}
				catch { }
			}
			m_objStreamWriter = new StreamWriter(strLogPath, false, Encoding.UTF8);
			m_objStreamWriter.WriteLine("<html><head><title>Yammy Log file</title>");
			m_objStreamWriter.WriteLine("<link rel=\"stylesheet\" href=\"style.css\" />");
			m_objStreamWriter.WriteLine("</head><body>");
			m_objStreamWriter.WriteLine("<div class=\"header\"><a href=\"http://yammy.sf.net\">Website</a></div>");
			m_objStreamWriter.WriteLine("<div class=\"container\"><div class=\"content\">");
			m_objStreamWriter.WriteLine("<h1>Yammy log file [" + DateTime.Now.ToLongDateString() + "]</h1>");

			m_timer = new Timer(new TimerCallback(Flush), null, 0, 1000 * 60); // Once a minute, flush log
		}

		public void Dispose()
		{
			this.Flush(null);
			m_timer.Dispose();
			if (m_objStreamWriter != null)
			{
				m_objStreamWriter.WriteLine("<div class=\"footer\">Yammy &copy; 2005-2006, Pravin Paratey</div>");
				m_objStreamWriter.WriteLine("</div></div></body></html>");
				m_objStreamWriter.Flush();
				m_objStreamWriter.Close();
				m_objStreamWriter = null;
			}
		}

		public static Logger Instance
		{
			get
			{
				return _instance;
			}
		}

		public void LogDebug(string msg)
		{
			Log("Debug", msg);
		}

		public void LogError(string msg)
		{
			Log("Error", msg);
		}

		public void LogException(Exception e)
		{
			Log("Exception", e.ToString());
		}

		private void Log(string type, string msg)
		{
			lock (m_logQueue)
			{
				DateTime dt = DateTime.Now;
				string strTime = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
				m_logQueue.Enqueue(string.Format("<div{3}>{0} [{1}] {2}</div>", strTime, type, msg, (m_bAlternate ? " class=\"alt\"" : string.Empty)));
				m_bAlternate = !m_bAlternate;
			}
		}

		private void Flush(Object stateInfo)
		{
			for (int i = 0; i < m_logQueue.Count; i++)
			{
				string msg = m_logQueue.Dequeue() as string;
				m_objStreamWriter.WriteLine(msg);
			}
			m_objStreamWriter.Flush();
		}
	}
}
