// OpenDesktop - A search tool for the Windows desktop
// Copyright (C) 2005-2006, Pravin Paratey (pravinp at gmail dot com)
// http://opendesktop.berlios.de
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

namespace Yammy
{
	/// <summary>
	/// This will be a common class to synchronize events like
	/// 1. Obtaining a lock before moving a index-dir and releasing it after done.
	/// Question: What happens if an object acquires a lock and dies before releasing it?
	/// </summary>
	class Synchronizer
	{
		#region Member Vars
		private static Synchronizer _instance;
		private static object m_lock = new object();
		private object m_indexerLock;
		private object m_objThatHoldsLock;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		private Synchronizer()
		{
			m_indexerLock = new object();
		}
		#endregion

		#region Standard Singleton Implementation
		/// <summary>
		/// Standard Singleton Implementation
		/// </summary>
		public static Synchronizer Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (m_lock)
					{
						if (_instance == null)
						{
							_instance = new Synchronizer();
						}
					}
				}
				return _instance;
			}
		}
		#endregion

		#region Index Synchronization
		/// <summary>
		/// Lock the index to tell everybody that index is going to change
		/// </summary>
		public void LockIndex(object obj)
		{
			Monitor.Enter(m_indexerLock);
			Logger.Instance.LogDebug("Acquired Index lock");
			// TODO: This function should be blocking. Should return only when the lock is acquired
			m_objThatHoldsLock = obj;
		}

		/// <summary>
		/// Release the lock
		/// </summary>
		public void ReleaseIndex(object obj)
		{
			if (m_objThatHoldsLock != obj)
			{
				return;
				//throw new Exception("Different object trying to release lock");
			}
			Monitor.Exit(m_indexerLock);
			Logger.Instance.LogDebug("Released Index lock");
		}
		#endregion
	}
}
