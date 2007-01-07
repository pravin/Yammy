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
using System.Text;
using System.Threading;
using System.Collections;
using System.Collections.Specialized;

namespace Yammy
{
	#region Public Delegates
	/// <summary>
	/// Public delegate which tells how many documents have been indexed
	/// </summary>
	/// <param name="filePath">Document currently indexing</param>
	/// <param name="numDocs">number of documents already indexed</param>
	public delegate void IndexProgressHandler(string filePath, int numDocs);
	public delegate void FileExplorerDoneHandler();
	public delegate void FileExplorerProgressHandler(string filePath);
	#endregion

	class FileExplorer : IDisposable
	{
		#region Private Vars
		private Thread m_objThread;
		private bool _quit;
		Indexer m_indexer;
		private bool m_bAgressive = false; // true = dont sleep between documents
		#endregion

		#region Public Events
		public event IndexProgressHandler IndexProgress;
		private void OnIndexProgress(string filePath, int numDocs)
		{
			if (IndexProgress != null)
			{
				IndexProgress(filePath, numDocs);
			}
		}

		public event FileExplorerProgressHandler FileExplorerProgress;
		private void OnFileExplorerProgress(string filePath)
		{
			if (FileExplorerProgress != null)
			{
				FileExplorerProgress(filePath);
			}
		}

		public event FileExplorerDoneHandler FileExplorerDone;
		private void OnFileExplorerDone()
		{
			if (FileExplorerDone != null)
			{
				FileExplorerDone();
			}
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public FileExplorer()
		{
			_quit = false;
			m_indexer = new Indexer(Config.Instance.TempIndexPath, IndexMode.CREATE);
		}

		/// <summary>
		/// Responsible for disposing objects.
		/// </summary>
		public void Dispose()
		{
			if (m_objThread != null)
			{
				m_objThread.Abort();
			}
			if (m_indexer != null)
			{
				m_indexer.Close();
			}
		}
		#endregion

		#region Run/Stop/Pause/Resume
		/// <summary>
		/// Starts the FileExploring process
		/// </summary>
		/// <param name="aggressive">
		/// If true, thread priority isnt set to low and there is no delay after
		/// each file addition
		/// </param>
		public void Run(bool aggressive)
		{
			m_bAgressive = aggressive;

			// Check if an update of the index is due
			TimeSpan objUpdateFrequency = new TimeSpan(Config.Instance.IndexUpdateFrequency, 0, 0);
			if (DateTime.Now.Subtract(Config.Instance.IndexLastUpdated) < objUpdateFrequency)
			{
				Logger.Instance.LogDebug("Update time not elapsed. Exiting FileExplorer");
				return;
			}

			m_objThread = new Thread(new ThreadStart(Explore));
			m_objThread.Name = "FileExplorer";
			try
			{
				m_objThread.Start();
			}
			catch (Exception e)
			{
				Logger.Instance.LogException(e);
			}
		}
		/*
				public void Pause()
				{
					if (m_objThread != null && m_objThread.ThreadState == ThreadState.Running)
					{
						m_objThread.Suspend();
					}
				}

				public void Resume()
				{
					if (m_objThread != null && m_objThread.ThreadState == ThreadState.Suspended)
					{
						m_objThread.Resume();
					}
				}
		*/
		public void Stop()
		{
			Logger.Instance.LogDebug("FileExplorer stop requested");
			_quit = true;
		}
		#endregion

		#region Explore
		private void Explore()
		{
			string strProfilesPath = Path.Combine(Common.GetYahooPath(), "Profiles");
			if (!Directory.Exists(strProfilesPath))
				return;

			string[] dirs = null;
			try
			{
				dirs = Directory.GetDirectories(strProfilesPath);
			}
			catch
			{
				return;
			}

			foreach (string dir in dirs)
			{
				string strUser = Path.GetFileNameWithoutExtension(dir);

				string strSubPath = Path.Combine(dir, "Archive");
				if (Directory.Exists(strSubPath))
				{
					string[] subdirs = null;
					try
					{
						subdirs = Directory.GetDirectories(strSubPath);
					}
					catch
					{
						continue;
					}
					foreach (string subdir in subdirs)
					{
						string strMessageType = Path.GetFileNameWithoutExtension(subdir);
						if (string.Compare(strMessageType, "Conferences", true) == 0)
							continue;

						string[] subsubdirs = null;
						try
						{
							subsubdirs = Directory.GetDirectories(subdir);
						}
						catch
						{
							continue;
						}
						foreach (string subsubdir in subsubdirs)
						{
							OnFileExplorerProgress(subsubdir);
							string[] archiveFiles = Directory.GetFiles(subsubdir);
							foreach (string archive in archiveFiles)
							{
								Logger.Instance.LogDebug("Indexing: " + archive);
								Decoder d = new Decoder(archive);
								string strMessage = d.Decode(true, false);
								IndexInfo info = new IndexInfo(d.LocalID, d.RemoteID, strMessage, archive);
								m_indexer.AddDocument(info);
								if (!m_bAgressive)
								{
									Thread.Sleep(100);
								}
							}
						}
					}
				}
			}

			if (!_quit) // If the exit was natural
			{
				Logger.Instance.LogDebug("Moving index from " +
					Config.Instance.IndexPath + " to " +
					Config.Instance.TempIndexPath);
				// Close index and move it 
				m_indexer.Close(); m_indexer = null;

				// Lock the index as we are going to be moving it
				Synchronizer.Instance.LockIndex(this);
				try
				{
					if (Directory.Exists(Config.Instance.IndexPath))
					{
						Directory.Delete(Config.Instance.IndexPath, true);
					}
					Directory.Move(Config.Instance.TempIndexPath,
						Config.Instance.IndexPath);

					Config.Instance.IndexLastUpdated = DateTime.Now;
					Config.Instance.SaveConfig();
				}
				catch (Exception e)
				{
					Logger.Instance.LogException(e);
				}
				Synchronizer.Instance.ReleaseIndex(this);
			}
			OnFileExplorerDone(); // Signal we are done
		}
		#endregion
	}
}
