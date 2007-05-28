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
using System.Threading;
using System.Collections;
using System.Windows.Forms;

namespace Yammy
{
	static class Program
	{
		static object m_firstTimeUserLock = new object();

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			if (AppIsRunning())
			{
				return;
			}
			Logger LOG = null;
			try
			{
				LOG = Logger.Instance;
			}
			catch
			{
				// For some reason the named mutex way to determine
				// if this app is already running, is not working
				// This causes the Logger.Instance call to fail.
				// Hence we are quitting ASSUMING Yammy is running already
				return;
			}
			LOG.LogDebug("Starting Yammy");
			LOG.LogDebug("Bringing up Webserver");
			WebServer.Instance.Start();
			LOG.LogDebug("Displaying NotifyIcon");
			TrayIcon trayIcon = new TrayIcon();

			FileExplorer fileExplorer = null;
			//IndexProgressHandler dlgtIndexProgressHandler = null;

			fileExplorer = new FileExplorer();
			fileExplorer.Run(false); // Dont be aggressive

			MemoryManagement.Start();

			// Start the remoteuser icon caching process
			Thread t = new Thread(new ThreadStart(NetServices.FetchIcons));
			t.Name = "Remote Avatarizer";
			t.Start();

			Application.Run();

			t.Abort();
			fileExplorer.Stop();
			WebServer.Instance.Stop();
			MemoryManagement.KillThread();
			LOG.LogDebug("Exiting Yammy");
			Logger.Instance.Dispose();
		}

		/// <summary>
		/// Creates a named mutex and tries to gain ownership. If successful,
		/// it means it is the only app running. Else another app is running.
		/// </summary>
		/// <returns>True if another instance is running</returns>
		static bool AppIsRunning()
		{
			bool bCreatedNew;
			System.Threading.Mutex m = new System.Threading.Mutex(true, "YammyMutex", out bCreatedNew);
			//if (bCreatedNew)
			//    m.ReleaseMutex();
			return !bCreatedNew;
		}
	}
}
