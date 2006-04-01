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
using System.Windows.Forms;

namespace Yammy
{
	/// <summary>
	/// Delegate is used to load the treeview in another thread
	/// </summary>
	public delegate void dlgtLoadTreeView();
	
	enum TreeViewIcon : int
	{
		LocalUser 	= 0,
		MessageType = 1,
		RemoteUser	= 2,
	}
	/// <summary>
	/// Manages the treeview control
	/// </summary>
	public class TreeViewManager
	{
		private TreeView m_treeView;
		private WebBrowser m_webBrowser;
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="treeView">control to load into</param>
		/// <param name="webBrowser">associated web browser control</param>
		/// <returns></returns>
		public TreeViewManager(TreeView treeView, WebBrowser webBrowser)
		{
			m_treeView = treeView;
			m_webBrowser = webBrowser;
			//TODO: Add Treeview events m_treeView.
			m_treeView.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(OnDoubleClick);
			m_treeView.NodeMouseClick += new TreeNodeMouseClickEventHandler(OnClick);
		}

		void OnClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				m_treeView.SelectedNode = e.Node;
			}
			OnDoubleClick(sender, e);
		}
		
		/// <summary>
		/// Loads the treeView with initial elements
		/// </summary>
		public void LoadTreeView()
		{
			m_treeView.Nodes.Clear();
			
			string strProfilesPath = Path.Combine(Config.Instance.YahooProfilesPath, "Profiles");
			if(!Directory.Exists(strProfilesPath))
				return;
			
			string []dirs = null;
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
				TreeNode tn = new TreeNode(strUser, (int)TreeViewIcon.LocalUser, (int)TreeViewIcon.LocalUser);
				m_treeView.Nodes.Add(tn);
				
				string strSubPath = Path.Combine(dir, "Archive");
				if(Directory.Exists(strSubPath))
				{
					string []subdirs = null;
					try
					{
						subdirs = Directory.GetDirectories(strSubPath);
					}
					catch
					{
						continue;
					}
					foreach(string subdir in subdirs)
					{
						string strMessageType = Path.GetFileNameWithoutExtension(subdir);
						if(string.Compare(strMessageType, "Conferences", true) == 0)
							continue;
						TreeNode tnChild = new TreeNode(strMessageType, (int)TreeViewIcon.MessageType, (int)TreeViewIcon.MessageType);
						tn.Nodes.Add(tnChild);
						
						string []subsubdirs = null;
						try
						{
							subsubdirs = Directory.GetDirectories(subdir);
						}
						catch
						{
							continue;
						}
						foreach(string subsubdir in subsubdirs)
						{
							string strRemote = Path.GetFileNameWithoutExtension(subsubdir);
							TreeNode tnSubChild = new TreeNode(strRemote, (int)TreeViewIcon.RemoteUser, (int)TreeViewIcon.RemoteUser);
							tnSubChild.Tag = subsubdir;
							tnChild.Nodes.Add(tnSubChild);
						}
					}
				}
			}
			
			//m_treeView.ExpandAll();
		}
		
		/// <summary>
		/// Handles the OnDoubleClick event. Shows the list of conversations
		/// between the two users
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			TreeNode node = e.Node;
			
			if(node == null || node.Tag == null) // Node is not a RemoteUser
				return;
			
			string strDir = node.Tag as string;
			if(strDir == null)
				return;
			string []fileList= null;
			try
			{
				fileList = Directory.GetFiles(strDir);
			}
			catch (IOException ex)
			{
				Logger.Instance.LogException(ex);
				return;
			}

			string strOutput = Resources.Instance.DisplayHtml;
			strOutput = strOutput.Replace("<$ReplaceTitle$>", 
			                              string.Format(Resources.Instance.ConversationBetween,
			                                            node.Parent.Parent.Text, node.Text));
			
			StringBuilder sb = new StringBuilder();
			foreach(string file in fileList)
			{
				Decoder d = new Decoder(file);
				string strDecodedPreview = d.Decode(false, true);
				sb.Append("<div class=\"title\">" + Path.GetFileNameWithoutExtension(file) + "</div>");
				sb.Append(strDecodedPreview);
				sb.Append("<a href=\"yammy:decode?" + file + "\">Read full conversation</a>");
				sb.Append("<hr size=1>");
			}
			
			strOutput = strOutput.Replace("<$ReplaceBody$>", sb.ToString());
			
			m_webBrowser.DocumentText = strOutput;
		}
	}
}
