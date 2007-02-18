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
using System.Net;
using System.Text;
using System.Threading;
using System.Collections;
using System.Net.Sockets;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace Yammy
{
	enum HttpResponseCode : int
	{
		Ok = 200,
		InvalidRequest = 400,
		FileNotFound = 404,
		Conflict = 409,
		Unsupported = 415
	}

	#region Class ContentType
	public sealed class ContentType
	{
		/// <summary>
		/// returns text/html
		/// </summary>
		public static string HTML
		{
			get { return "text/html;charset=utf-8"; }
		}
		/// <summary>
		/// returns text/css
		/// </summary>
		public static string CSS
		{
			get { return "text/css"; }
		}
		/// <summary>
		/// returns image/jpg
		/// </summary>
		public static string IMAGE_JPEG
		{
			get { return "image/jpg"; }
		}
		/// <summary>
		/// returns image/gif
		/// </summary>
		public static string IMAGE_GIF
		{
			get { return "image/gif"; }
		}
		/// <summary>
		/// returns image/png
		/// </summary>
		public static string IMAGE_PNG
		{
			get { return "image/png"; }
		}
		/// <summary>
		/// returns image/icon
		/// </summary>
		public static string IMAGE_ICO
		{
			get { return "image/icon"; }
		}

		public static string JAVASCRIPT
		{
			get { return "text/javascript"; }
		}
	}
	#endregion

	/// <summary>
	/// WebServer class. This class is responsible for:
	/// 1. Creating a server and listening for connections.
	/// 2. On connect, extract GET or POST string.
	/// 3. Open target page and parse it.
	/// 4. While parsing, call appropriate functions and create output page.
	/// 5. Display output page.
	/// </summary>
	class WebServer
	{
		#region Member Variables
		private TcpListener m_tcpListener;
		private static WebServer _self;
		private static object m_lock = new object();
		private bool m_bDie;
		private Thread m_objListenThread;
		private string m_strLocalAddress;
		private bool m_bIsRunning;
		private string m_strWebRoot;
		private string m_fileHeader;
		private string m_fileMain;
		private string m_fileFooter;
		#endregion

		#region Constructor
		private WebServer()
		{
			try
			{
				m_strWebRoot = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"WebRoot");
			}
			catch
			{
				m_strWebRoot = string.Empty;
			}
		}

		public static WebServer Instance
		{
			get
			{
				lock (m_lock)
				{
					if (_self == null)
					{
						_self = new WebServer();
					}
				}
				return _self;
			}
		}
		#endregion

		#region Start/Stop Server
		public void Start()
		{
			lock (m_lock)
			{
				if (m_bIsRunning)
					return;
				m_bIsRunning = true;
			}

			ReadCommonFiles();

			m_tcpListener = new TcpListener(IPAddress.Loopback, 2007); // port 2007
			m_tcpListener.Start();
			m_strLocalAddress = string.Format("http://{0}/", m_tcpListener.LocalEndpoint.ToString());

			m_objListenThread = new Thread(new ThreadStart(ListenThread));
			m_objListenThread.Start();
		}

		public void Stop()
		{
			if (!m_bIsRunning)
				return;

			m_bDie = true;
			m_tcpListener.Stop();

			lock (m_lock)
			{
				m_bIsRunning = false;
			}
		}
		#endregion

		#region Properties
		public string LocalAddress
		{
			get
			{
				return m_strLocalAddress;
			}
		}

		public bool IsRunning
		{
			get
			{
				return m_bIsRunning;
			}
		}
		public string HtmlMain
		{
			get
			{
				return m_fileMain;
			}
		}
		public string WebRoot
		{
			get
			{
				return m_strWebRoot;
			}
		}
		#endregion

		/// <summary>
		/// Reads frequently accessed files so that we dont have to read them from disk everytime
		/// </summary>
		void ReadCommonFiles()
		{
			m_fileHeader = Common.ReadTextFile(Path.Combine(m_strWebRoot, "header.php"));
			m_fileMain = Common.ReadTextFile(Path.Combine(m_strWebRoot, "index.php"));
			m_fileFooter = Common.ReadTextFile(Path.Combine(m_strWebRoot, "footer.php"));
		}

		void ListenThread()
		{
			m_bDie = false;
			while (!m_bDie)
			{
				Socket theClient;
				try
				{
					theClient = m_tcpListener.AcceptSocket();
					if (theClient.Connected)
					{
						ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessRequest), theClient);
					}
				}
				catch (SocketException e)
				{
					if (e.SocketErrorCode != SocketError.Interrupted)
					{
						Logger.Instance.LogError("Client interrupted while handling request");
					}
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="socket"></param>
		void ProcessRequest(object socket)
		{
			Socket sock = socket as Socket;
			if (sock == null)
				return;
			byte[] inbuf = new byte[512]; // README: If Webserver fails with "server busy", increase this size
			sock.Receive(inbuf);

			string strRequest = Encoding.ASCII.GetString(inbuf);
			NameValueCollection queryString = null;
			Uri uriRequest = ValidateRequest(strRequest);
			
			Logger.Instance.LogDebug(uriRequest.ToString());

			if (uriRequest == null)
			{
				Logger.Instance.LogDebug("Invalid Request:" + strRequest);
				SendErrorResponse(ref sock, HttpResponseCode.InvalidRequest, "Invalid request:\r\n" + strRequest);
				return;
			}

			Logger.Instance.LogDebug("Processing Request: " + uriRequest.ToString());

			if (uriRequest.Query.Length > 0)
			{
				queryString = MakeQueryString(uriRequest.Query);
			}
			
			string strPathFragment = uriRequest.LocalPath;
			string strContentType = ContentType.HTML;
			byte[] responseData;

			switch (strPathFragment)
			{
				case "/":
				case "/main":
					responseData = Encoding.UTF8.GetBytes(
						ConstructHTML(Resources.Instance.GetString("Home"), Common.GetIndexPage()));
					break;
				case "/show":
					responseData = Encoding.UTF8.GetBytes(
						ConstructHTML(
							string.Format(Resources.Instance.GetString("ShowingConvoFor"), queryString["localuser"]), 
							Common.GetLocalUserFriends(queryString["localuser"])));
					break;
				case "/search": // /search?query=[]&page=[]
					string query = queryString["query"] as string;
					if(query == null)
					{
						query = string.Empty;
					}
					query = Uri.EscapeDataString(query).Trim();

					string strTitle = string.Format(Resources.Instance.GetString("SearchingFor"), query);
					responseData = Encoding.UTF8.GetBytes(
						ConstructHTML(strTitle, Search.DoSearch(queryString)));
					break;
				case "/decode": // /decode?localuser=[]&type=[c|i|m]&remoteuser=[]&fname=[]&page=[]
					string strDecode = Decode.DoDecode(queryString);
					string localUser = queryString["localuser"];
					string remoteUser = queryString["remoteuser"];

					responseData = Encoding.UTF8.GetBytes(
						ConstructHTML(string.Format(Resources.Instance.GetString("ConversationBetween"), localUser, remoteUser), strDecode));
					break;
				case "/settings":
					string strOutput = Config.Instance.DoSettings(queryString);
					ReadCommonFiles();
					responseData = Encoding.UTF8.GetBytes(
						ConstructHTML(Resources.Instance.GetString("Settings"), strOutput)
					);
					break;
				case "/export":
					//localUser = queryString["localuser"];
					//type = queryString["type"];
					//remoteUser = queryString["remoteuser"];
					//fname = queryString["fname"];
					//ExportParams exportParams = new ExportParams(localUser, remoteUser, type, fname);
					//Thread t = new Thread(new ParameterizedThreadStart(Export.ExportMe));
					//t.SetApartmentState(ApartmentState.STA);
					//t.Start(exportParams);
					responseData = Encoding.UTF8.GetBytes(
						ConstructHTML(Resources.Instance.GetString("Export"), "ToDo")
					);
					break;
				case "/help":
					string helpfname = Path.Combine(m_strWebRoot, "help_" + Config.Instance.Locale + ".php");
					if(!File.Exists(helpfname))
					{
						helpfname = Path.Combine(m_strWebRoot, "help_en.php");
					}
					responseData = Encoding.UTF8.GetBytes(
						ConstructHTML(Resources.Instance.GetString("Help"), Common.ReadTextFile(helpfname))
					);
					break;
				case "/log":
					responseData = Encoding.UTF8.GetBytes(
						ConstructHTML("Yammy Log", Common.ReadTextFile(Path.Combine(m_strWebRoot, "log.html")))
					);
					break;
				case "/enablearchiving":
					localUser = queryString["localuser"];
					YahooInfo.SetArchiveStatus(localUser, true);
					responseData = Encoding.UTF8.GetBytes(
						ConstructHTML(Resources.Instance.GetString("Home"), Common.GetIndexPage()));
					break;
				case "/disablearchiving":
					localUser = queryString["localuser"];
					YahooInfo.SetArchiveStatus(localUser, false);
					responseData = Encoding.UTF8.GetBytes(
						ConstructHTML(Resources.Instance.GetString("Home"), Common.GetIndexPage()));
					break;
				default:
					#region Other file
					strPathFragment = strPathFragment.Replace('/', '\\').Substring(1);

					string strFilePath = string.Empty;
					// Getfile hack. cause mozilla doesn't show file:/// stuff from a http:// 
					if (strPathFragment.StartsWith("getfile")) 
					{
						strFilePath = Uri.UnescapeDataString(queryString["path"]);
					}
					else
					{
						strFilePath = Path.Combine(m_strWebRoot, strPathFragment);
					}
					if (!File.Exists(strFilePath))
					{
						SendErrorResponse(ref sock, HttpResponseCode.FileNotFound, Resources.Instance.GetString("FileNotFound"));
						return;
					}

					BinaryReader reader = null;
					try
					{
						FileInfo finfo = new FileInfo(strFilePath);
						reader = new BinaryReader(finfo.OpenRead());
						responseData = reader.ReadBytes((int)finfo.Length);
						reader.Close();
					}
					catch (IOException e)
					{
						Logger.Instance.LogException(e);
						if (reader != null)
						{
							reader.Close();
							reader = null;
						}
						SendErrorResponse(ref sock, HttpResponseCode.Conflict, e.ToString());
						return;
					}

					int pos = strFilePath.IndexOf('.');
					string strExtention = strFilePath.Substring(pos);

					if (strExtention.Equals(".jpg", StringComparison.InvariantCultureIgnoreCase)
						|| strExtention.Equals(".jpeg", StringComparison.InvariantCultureIgnoreCase))
					{
						strContentType = ContentType.IMAGE_JPEG;
					}
					else if (strExtention.Equals(".png", StringComparison.InvariantCultureIgnoreCase))
					{
						strContentType = ContentType.IMAGE_PNG;
					}
					else if (strExtention.Equals(".gif", StringComparison.InvariantCultureIgnoreCase))
					{
						strContentType = ContentType.IMAGE_GIF;
					}
					else if (strExtention.Equals(".css", StringComparison.InvariantCultureIgnoreCase))
					{
						strContentType = ContentType.CSS;
					}
					else if (strExtention.Equals(".ico", StringComparison.InvariantCultureIgnoreCase))
					{
						strContentType = ContentType.IMAGE_ICO;
					}
					else if (strExtention.Equals(".js", StringComparison.InvariantCultureIgnoreCase))
					{
						strContentType = ContentType.JAVASCRIPT;
					}
					else
					{
						Logger.Instance.LogError("Unsupported file type");
					}
					#endregion
					break;
			}
			
			SendResponse(ref sock, responseData, strContentType, responseData.Length);
		}

		/// <summary>
		/// Creates a HTTP 1.1 header string to return to browsers
		/// </summary>
		/// <param name="status">Status Number ex. 200 for OK, 404 for file not found</param>
		/// <param name="contentType">content type of the response body</param>
		/// <param name="contentLength">length of response body</param>
		/// <returns>header string</returns>
		string CreateHeader(HttpResponseCode status, string contentType, int contentLength)
		{
			const string CRLF = "\r\n";
			string strHeader =
				"HTTP/1.1 " + ((int)status).ToString() + CRLF +
				"Server: " + Resources.Instance.GetString("AppName") + CRLF +
				"Content-Type: " + contentType + CRLF +
				"Accept-Ranges: bytes" + CRLF +
				"Content-Length: " + contentLength + CRLF + CRLF;
			return strHeader;
		}

		void SendResponse(ref Socket sock, byte[] content, string contentType, int contentLength)
		{
			string strHeader = CreateHeader(HttpResponseCode.Ok, contentType, contentLength);
			try
			{
				sock.Send(Encoding.ASCII.GetBytes(strHeader));
				sock.Send(content, contentLength, SocketFlags.None);
			}
			catch { }
			// FIXME: The sleep has been added so that the data reaches the browser before
			// we shutdown the socket. What is strange is Send is a sync call and so the
			// control should sock.Shutdown only after the Send sends data to the browser
			// But this is not what happens. Hence this Sleep hack.
			Thread.Sleep(100);
			sock.Shutdown(SocketShutdown.Both);
			sock.Close(); sock = null;
		}

		/// <summary>
		/// Sends an error response on the socket. Also closes the socket
		/// </summary>
		/// <param name="sock">socket to send response to</param>
		/// <param name="status">Error Code</param>
		/// <param name="errMessage">Message</param>
		void SendErrorResponse(ref Socket sock, HttpResponseCode status, string errMessage)
		{
			string strErrorPage;
			try
			{
				strErrorPage = ConstructHTML(Resources.Instance.GetString("Error"), "<b>" + status.ToString() + "</b>" + errMessage);
			}
			catch
			{
				strErrorPage = errMessage;
			}

			byte[] outbuf = Encoding.UTF8.GetBytes(strErrorPage);
			string strHeader = CreateHeader(status, "text/html;charset=utf-8", outbuf.Length);
			// Header is always in ASCII encoding
			try
			{
				sock.Send(Encoding.ASCII.GetBytes(strHeader));
				sock.Send(outbuf, outbuf.Length, SocketFlags.None);
			}
			catch { }
			sock.Shutdown(SocketShutdown.Both);
			sock.Close(); sock = null;
		}

		NameValueCollection MakeQueryString(string queryString)
		{
			if (queryString.StartsWith("?"))
				queryString = queryString.Substring(1);
			string[] strQueryTerms = queryString.Split('&');
			if (strQueryTerms.Length < 1)
				return null;
			NameValueCollection objQueryString = new NameValueCollection(strQueryTerms.Length);
			foreach (string strTerm in strQueryTerms)
			{
				string[] strValuePair = strTerm.Split('=');
				if (strValuePair.Length > 0)
				{
					objQueryString.Add(strValuePair[0], strValuePair[1]);
				}
			}
			return objQueryString;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="request"></param>
		/// <returns>Returns uri object on success else null</returns>
		Uri ValidateRequest(string request)
		{
			string strUrl = null;
			if (request.StartsWith("GET", StringComparison.OrdinalIgnoreCase))
			{
				// Do Get
				// Get the url and parse it
				int iStart = request.IndexOf(' ') + 1;
				int iEnd = request.IndexOf(' ', iStart);

				strUrl = request.Substring(iStart, iEnd - iStart);
			}
			else if (request.StartsWith("POST", StringComparison.OrdinalIgnoreCase))
			{
				// Do Post
				// TODO: Content-Type field is ignored for now.
				// Later, you'd want to use the content-type to determine if the data
				// that follows is of type text, else flag an error
				int iStart = request.IndexOf("\r\n\r\n") + 4;
				if (iStart > 4)
				{
					strUrl = request.Substring(iStart);
				}
			}

			if (strUrl == null)
			{
				return null;
			}

			Uri uriRequest = null;
			try
			{
				uriRequest = new Uri(new Uri(m_strLocalAddress), strUrl);
			}
			catch
			{
				return null;
			}
			return uriRequest;
		}
		
		private string ConstructHTML(string title, string content)
		{
			StringBuilder sb = new StringBuilder((m_fileHeader.Length + m_fileMain.Length + m_fileFooter.Length) * 2);
			// Header
			sb.Append(m_fileHeader.Replace("<$PageTitle$>", title).Replace("<$LocaleString$>",Config.Instance.Locale));
			// Body
			string strHtml = m_fileMain;
			strHtml = strHtml.Replace("<$Content$>", content);
			sb.Append(strHtml);
			// Footer
			sb.Append(m_fileFooter);

			return sb.ToString();
		}
	}
}
