using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Yammy
{
	class NetServices
	{
		/// <summary>
		/// Contains a list of user avatars to download
		/// </summary>
		static Queue<string> m_queue = new Queue<string>();
		/// <summary>
		/// Used by Monitor to Pulse
		/// </summary>
		static object objMon = new object();

		/// <summary>
		/// Checks if I can connect to the internet. EXPENSIVE OPERATION!
		/// </summary>
		/// <returns></returns>
		public static bool IsConnectionAvailable()
		{
			bool retVal = false;
			WebRequest request = WebRequest.Create("http://yammy.sourceforge.net");
			try
			{
				WebResponse response = request.GetResponse();
				response.Close();
				retVal = true;
			}
			catch
			{
				Logger.Instance.LogDebug("Internet connection not available");
			}
			return retVal;
		}

		/// <summary>
		/// Gets the filename 
		/// </summary>
		/// <param name="remoteUser"></param>
		/// <returns></returns>
		public static string GetUserIcon(string remoteUser)
		{
			string userIconPath = "/images/generic.png";
			try
			{
				string fileName = Path.Combine(Config.Instance.CachePath, remoteUser + ".png");
				if (File.Exists(fileName))
				{
					userIconPath = "/cache/" + remoteUser + ".png";
				}
				else
				{
					// Push icon into queue
					lock (m_queue)
					{
						m_queue.Enqueue(remoteUser);
					}
					lock (objMon)
					{
						Monitor.Pulse(objMon);
					}
				}
			}
			catch { }
			return userIconPath;
		}

		/// <summary>
		/// Returns md5 hash of the input string
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		private static string GetMD5Hash(string input)
		{
			MD5 md5 = MD5.Create();
			byte[] b = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
			return BitConverter.ToString(b);
		}

		/// <summary>
		/// Runs in a thread and fetches user avatars from the net in the background
		/// </summary>
		public static void FetchIcons()
		{
			//TODO: Catch Thread Abort Exception + IOException
			try
			{
				while (true)
				{
					string remoteUser = null;
					lock (m_queue)
					{
						if (m_queue.Count > 0)
						{
							remoteUser = m_queue.Dequeue();
						}
					}
					if (remoteUser == null)
					{
						// Wait for the next enqueue
						lock (objMon)
						{
							Monitor.Wait(objMon);
						}
					}
					try
					{
						if (remoteUser != null)
						{
							WebRequest request = WebRequest.Create("http://lookup.avatars.yahoo.com/wimages?yid=" +
								remoteUser + "&size=medium&type=png");
							WebResponse response = request.GetResponse();
							Stream instream = response.GetResponseStream();

							// Read and Write
							Stream outstream = File.OpenWrite(Path.Combine(Config.Instance.CachePath, remoteUser + ".png"));
							BinaryWriter bwriter = new BinaryWriter(outstream);
							while (true)
							{
								int data = instream.ReadByte();
								if (data == -1)
									break;
								bwriter.Write((byte)data);
							}
							bwriter.Close(); bwriter = null;
							response.Close(); response = null;
						}
					}
					catch (Exception e)
					{
						Logger.Instance.LogException(e);
					}
				}
			}
			catch (ThreadAbortException e) 
			{
				Logger.Instance.LogException(e);
			}
		}
	}
}
