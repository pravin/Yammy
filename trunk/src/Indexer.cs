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
using System.Text;

using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.QueryParsers;
using Lucene.Net.Analysis.Standard;

namespace Yammy
{
	enum IndexMode : int
	{
		CREATE,
		APPEND,
		SEARCH
	}

	class IndexInfo
	{
		private string m_strLocalUser;
		private string m_strRemoteUser;
		private string m_strMessage;
		private string m_strLocation;

		public IndexInfo(string localUser, string remoteUser, string message, string location)
		{
			m_strLocalUser = localUser;
			m_strRemoteUser = remoteUser;
			m_strMessage = message;
			m_strLocation = location;
		}
		public string LocalUser
		{
			get { return m_strLocalUser; }
		}
		public string RemoteUser
		{
			get { return m_strRemoteUser; }
		}
		public string Message
		{
			get { return m_strMessage; }
		}
		public string Location
		{
			get { return m_strLocation; }
		}
	}

	class Indexer
	{
		#region Member Vars
		IndexWriter m_indexWriter;
		IndexSearcher m_indexSearcher;
		IndexMode m_indexMode;
		Analyzer m_analyzer;
		bool m_bSucess;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="indexPath">Path where you wish to create the index</param>
		/// <param name="mode">One of Create, Append or Search</param>
		public Indexer(string indexPath, IndexMode mode)
		{
			m_indexMode = mode;
			m_bSucess = false;
			m_analyzer = new StandardAnalyzer();
			Logger.Instance.LogDebug("Loading Indexer in " + mode.ToString() + " mode");

			if (mode == IndexMode.CREATE)
			{
				try
				{
					m_indexWriter = new IndexWriter(indexPath, m_analyzer, true);
					m_indexWriter.SetUseCompoundFile(true);
					m_bSucess = true;
				}
				catch (Exception e)
				{
					Logger.Instance.LogException(e);
					m_bSucess = false;
				}
			}
			else if (mode == IndexMode.APPEND)
			{
				try
				{
					m_indexWriter = new IndexWriter(indexPath, m_analyzer, false);
					m_indexWriter.SetUseCompoundFile(true);
					m_bSucess = true;
				}
				catch (Exception e)
				{
					Logger.Instance.LogException(e);
					m_bSucess = false;
				}
			}
			else if (mode == IndexMode.SEARCH)
			{
				try
				{
					m_indexSearcher = new IndexSearcher(indexPath);
					m_bSucess = true;
				}
				catch (Exception e)
				{
					Logger.Instance.LogException(e);
					m_bSucess = false;
				}
			}
		}

		/// <summary>
		/// Close the index
		/// </summary>
		public void Close()
		{
			if ((m_indexMode == IndexMode.CREATE || m_indexMode == IndexMode.APPEND)
				&& m_indexWriter != null)
			{
				m_indexWriter.Close();
				m_indexWriter = null;
			}
			else if (m_indexMode == IndexMode.SEARCH && m_indexSearcher != null)
			{
				m_indexSearcher.Close();
				m_indexSearcher = null;
			}
		}

		/// <summary>
		/// Adds a document to the index
		/// </summary>
		/// <param name="info">Document to add</param>
		/// <returns>true if successful, false otherwise</returns>
		public bool AddDocument(IndexInfo info)
		{
			bool retVal = false;
			if (m_bSucess && (m_indexMode == IndexMode.CREATE || m_indexMode == IndexMode.APPEND))
			{
				// README: This is so that < and > don't interfere with existing
				// tags in the browser
				string strText = info.Message.Replace("<", "&lt;").Replace(">", "&gt;");

				Document doc = new Document();
				doc.Add(Field.UnIndexed("localuser", info.LocalUser));
				doc.Add(Field.UnIndexed("remoteuser", info.RemoteUser));
				doc.Add(Field.Text("message", strText));
				doc.Add(Field.UnIndexed("location", info.Location));
				m_indexWriter.AddDocument(doc);
				retVal = true;
			}
			return retVal;
		}

		/// <summary>
		/// Searches an index opened in search mode for the search term(s)
		/// Returns 10 results
		/// </summary>
		/// <param name="searchTerm">Term to search for. Multiple terms are separated by + </param>
		/// <param name="offset">returns 10 results from this offset</param>
		/// <returns>An array of search results</returns>
		public IndexInfo[] Search(string searchTerm, int offset)
		{
			IndexInfo[] retVal = null;
			Logger.Instance.LogDebug("Searching index for: " + searchTerm);

			if (m_bSucess && m_indexMode == IndexMode.SEARCH && searchTerm != null)
			{
				// TODO: Needs more work. haha
				searchTerm = searchTerm.Replace("+", " + ");

				Query query = QueryParser.Parse(searchTerm, "message", m_analyzer);
				Hits hits = m_indexSearcher.Search(query);
				int len = hits.Length();
				int start = offset;
				int end = len > start + 10 ? start + 10 : len - start;
				if (len > 0)
				{
					retVal = new IndexInfo[end - start];
					for (int i = start; i < end; i++)
					{
						retVal[i] = new IndexInfo(hits.Doc(i).Get("localuser"), hits.Doc(i).Get("remoteuser"),
												  hits.Doc(i).Get("message"), hits.Doc(i).Get("location"));
					}
				}
				else
				{
					retVal = new IndexInfo[0];
				}
			}
			return retVal;
		}
	}
}
