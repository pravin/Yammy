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
using System.Runtime.InteropServices;

namespace Yammy
{
	public class MemoryManagement
	{
		static Thread m_staticThread;
		[DllImport("kernel32.dll")]
		public static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

		/// <summary>
		/// Infinite loop that calls SetProcessWorkingSetSize every 5 mins.
		/// Run this in a different thread
		/// </summary>
		public static void FlushMemory()
		{
			try
			{
				while (true)
				{
					GC.Collect();
					GC.WaitForPendingFinalizers();
					if (Environment.OSVersion.Platform == PlatformID.Win32NT)
					{
						SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
					}
					Thread.Sleep(1000 * 60 * 5); // Reclaim memory every 5 mins
				}
			}
			catch (ThreadAbortException) { }
		}

		public static void Start()
		{
			m_staticThread = new Thread(new ThreadStart(FlushMemory));
			m_staticThread.Name = "MemoryCollect";
			m_staticThread.Start();
		}

		public static void KillThread()
		{
			m_staticThread.Abort();
		}
	}
}
