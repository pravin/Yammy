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
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Yammy
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private TreeViewManager m_treeviewManager;
		private string m_strImagePath = "file://" + AppDomain.CurrentDomain.BaseDirectory + "images";

		/// <summary>
		/// Constructor
		/// </summary>
		public MainForm()
		{
			try
			{
				Config test = Config.Instance;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString(), Resources.Instance.UnableToLoadConfig);
				Application.Exit();
				return;			
			}
			
			InitializeComponent();
			Control.CheckForIllegalCrossThreadCalls = false;
			
			splitContainer.SplitterDistance = Config.Instance.SplitterWidth;
			webBrowser.Navigating += new WebBrowserNavigatingEventHandler(HandleNavigateStart);
			webBrowser.Navigated += new WebBrowserNavigatedEventHandler(HandleNavigateDone);
			webBrowser.ProgressChanged += new WebBrowserProgressChangedEventHandler(HandleNavigateProgress);
		}
		/// <summary>
		/// Entry point
		/// </summary>
		/// <param name="args">Command line arguments</param>
		[STAThread]
		public static void Main(string[] args)
		{
			FileExplorer explorer = new FileExplorer();
			explorer.Run(false);
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileSep1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuToolsOptions = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.tbOpen = new System.Windows.Forms.ToolStripButton();
			this.tbSave = new System.Windows.Forms.ToolStripButton();
			this.btnExport = new System.Windows.Forms.ToolStripSplitButton();
			this.exportAsHTML = new System.Windows.Forms.ToolStripMenuItem();
			this.exportAsPlainText = new System.Windows.Forms.ToolStripMenuItem();
			this.exportAsCombined = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnHome = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.lblFind = new System.Windows.Forms.ToolStripLabel();
			this.txtFind = new System.Windows.Forms.ToolStripTextBox();
			this.btnFind = new System.Windows.Forms.ToolStripButton();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.treeView = new System.Windows.Forms.TreeView();
			this.webBrowser = new System.Windows.Forms.WebBrowser();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.menuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuTools,
            this.mnuHelp});
			this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.menuStrip.Size = new System.Drawing.Size(492, 24);
			this.menuStrip.TabIndex = 0;
			// 
			// mnuFile
			// 
			this.mnuFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuFileSave,
            this.mnuFileSep1,
            this.mnuFileExit});
			this.mnuFile.Name = "mnuFile";
			this.mnuFile.Size = new System.Drawing.Size(35, 20);
			this.mnuFile.Text = "&File";
			// 
			// mnuOpen
			// 
			this.mnuOpen.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpen.Image")));
			this.mnuOpen.Name = "mnuOpen";
			this.mnuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.mnuOpen.Size = new System.Drawing.Size(140, 22);
			this.mnuOpen.Text = "&Open";
			this.mnuOpen.Click += new System.EventHandler(this.MnuOpenClick);
			// 
			// mnuFileSave
			// 
			this.mnuFileSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileSave.Image")));
			this.mnuFileSave.Name = "mnuFileSave";
			this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.mnuFileSave.Size = new System.Drawing.Size(140, 22);
			this.mnuFileSave.Text = "&Save";
			this.mnuFileSave.Click += new System.EventHandler(this.MnuFileSaveClick);
			// 
			// mnuFileSep1
			// 
			this.mnuFileSep1.Name = "mnuFileSep1";
			this.mnuFileSep1.Size = new System.Drawing.Size(137, 6);
			// 
			// mnuFileExit
			// 
			this.mnuFileExit.Name = "mnuFileExit";
			this.mnuFileExit.Size = new System.Drawing.Size(140, 22);
			this.mnuFileExit.Text = "&Exit";
			this.mnuFileExit.Click += new System.EventHandler(this.MnuFileExitClick);
			// 
			// mnuTools
			// 
			this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsOptions});
			this.mnuTools.Name = "mnuTools";
			this.mnuTools.Size = new System.Drawing.Size(44, 20);
			this.mnuTools.Text = "&Tools";
			// 
			// mnuToolsOptions
			// 
			this.mnuToolsOptions.Image = ((System.Drawing.Image)(resources.GetObject("mnuToolsOptions.Image")));
			this.mnuToolsOptions.Name = "mnuToolsOptions";
			this.mnuToolsOptions.Size = new System.Drawing.Size(111, 22);
			this.mnuToolsOptions.Text = "&Options";
			this.mnuToolsOptions.Click += new System.EventHandler(this.MnuToolsOptionsClick);
			// 
			// mnuHelp
			// 
			this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpAbout});
			this.mnuHelp.Name = "mnuHelp";
			this.mnuHelp.Size = new System.Drawing.Size(40, 20);
			this.mnuHelp.Text = "&Help";
			// 
			// mnuHelpAbout
			// 
			this.mnuHelpAbout.Name = "mnuHelpAbout";
			this.mnuHelpAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.mnuHelpAbout.Size = new System.Drawing.Size(122, 22);
			this.mnuHelpAbout.Text = "&About";
			this.mnuHelpAbout.Click += new System.EventHandler(this.MnuHelpAboutClick);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
			this.statusStrip.Location = new System.Drawing.Point(0, 351);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(492, 22);
			this.statusStrip.TabIndex = 1;
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(375, 17);
			this.toolStripStatusLabel.Spring = true;
			// 
			// toolStripProgressBar
			// 
			this.toolStripProgressBar.Name = "toolStripProgressBar";
			this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
			// 
			// toolStrip
			// 
			this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbOpen,
            this.tbSave,
            this.btnExport,
            this.toolStripSeparator1,
            this.btnHome,
            this.toolStripSeparator2,
            this.lblFind,
            this.txtFind,
            this.btnFind});
			this.toolStrip.Location = new System.Drawing.Point(0, 24);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip.Size = new System.Drawing.Size(492, 31);
			this.toolStrip.TabIndex = 2;
			// 
			// tbOpen
			// 
			this.tbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tbOpen.Image")));
			this.tbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbOpen.Name = "tbOpen";
			this.tbOpen.Size = new System.Drawing.Size(28, 28);
			this.tbOpen.Text = "Open";
			this.tbOpen.Click += new System.EventHandler(this.TbOpenClick);
			// 
			// tbSave
			// 
			this.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tbSave.Image = ((System.Drawing.Image)(resources.GetObject("tbSave.Image")));
			this.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbSave.Name = "tbSave";
			this.tbSave.Size = new System.Drawing.Size(28, 28);
			this.tbSave.Text = "Save";
			this.tbSave.Click += new System.EventHandler(this.TbSaveClick);
			// 
			// btnExport
			// 
			this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAsHTML,
            this.exportAsPlainText,
            this.exportAsCombined});
			this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
			this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(40, 28);
			this.btnExport.Text = "Export";
			this.btnExport.ButtonClick += new System.EventHandler(this.BtnExportButtonClick);
			// 
			// exportAsHTML
			// 
			this.exportAsHTML.Name = "exportAsHTML";
			this.exportAsHTML.Size = new System.Drawing.Size(156, 22);
			this.exportAsHTML.Text = "Export &HTML";
			this.exportAsHTML.Click += new System.EventHandler(this.ExportAsHTMLClick);
			// 
			// exportAsPlainText
			// 
			this.exportAsPlainText.Name = "exportAsPlainText";
			this.exportAsPlainText.Size = new System.Drawing.Size(156, 22);
			this.exportAsPlainText.Text = "Export &Plain Text";
			// 
			// exportAsCombined
			// 
			this.exportAsCombined.Name = "exportAsCombined";
			this.exportAsCombined.Size = new System.Drawing.Size(156, 22);
			this.exportAsCombined.Text = "Export &Combined";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
			// 
			// btnHome
			// 
			this.btnHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
			this.btnHome.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnHome.Name = "btnHome";
			this.btnHome.Size = new System.Drawing.Size(28, 28);
			this.btnHome.Text = "Home";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
			// 
			// lblFind
			// 
			this.lblFind.Name = "lblFind";
			this.lblFind.Size = new System.Drawing.Size(31, 28);
			this.lblFind.Text = "Find:";
			// 
			// txtFind
			// 
			this.txtFind.Name = "txtFind";
			this.txtFind.Size = new System.Drawing.Size(100, 31);
			this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFindKeyPress);
			// 
			// btnFind
			// 
			this.btnFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
			this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFind.Name = "btnFind";
			this.btnFind.Size = new System.Drawing.Size(28, 28);
			this.btnFind.Text = "Find";
			this.btnFind.Click += new System.EventHandler(this.BtnFindClick);
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "logo.ico");
			this.imageList.Images.SetKeyName(1, "folder_closed16.gif");
			this.imageList.Images.SetKeyName(2, "mail16.gif");
			// 
			// splitContainer
			// 
			this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer.Location = new System.Drawing.Point(0, 55);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.treeView);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.webBrowser);
			this.splitContainer.Size = new System.Drawing.Size(492, 296);
			this.splitContainer.SplitterDistance = 162;
			this.splitContainer.TabIndex = 3;
			// 
			// treeView
			// 
			this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView.FullRowSelect = true;
			this.treeView.ImageIndex = 0;
			this.treeView.ImageList = this.imageList;
			this.treeView.Location = new System.Drawing.Point(0, 0);
			this.treeView.Name = "treeView";
			this.treeView.SelectedImageIndex = 0;
			this.treeView.ShowLines = false;
			this.treeView.Size = new System.Drawing.Size(158, 292);
			this.treeView.TabIndex = 0;
			// 
			// webBrowser
			// 
			this.webBrowser.AllowWebBrowserDrop = false;
			this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser.Location = new System.Drawing.Point(0, 0);
			this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new System.Drawing.Size(322, 292);
			this.webBrowser.TabIndex = 0;
			this.webBrowser.Url = new System.Uri("", System.UriKind.Relative);
			// 
			// folderBrowserDialog
			// 
			this.folderBrowserDialog.ShowNewFolderButton = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(492, 373);
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MainForm";
			this.Text = "Yammy v0.8";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripMenuItem exportAsHTML;
		private System.Windows.Forms.ToolStripMenuItem exportAsPlainText;
		private System.Windows.Forms.ToolStripMenuItem exportAsCombined;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ToolStripMenuItem mnuToolsOptions;
		private System.Windows.Forms.ToolStripSeparator mnuFileSep1;
		private System.Windows.Forms.ToolStripMenuItem mnuOpen;
		private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
		private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
		private System.Windows.Forms.ToolStripMenuItem mnuHelp;
		private System.Windows.Forms.ToolStripMenuItem mnuTools;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnHome;
		private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.ToolStripLabel lblFind;
		private System.Windows.Forms.ToolStripTextBox txtFind;
		private System.Windows.Forms.ToolStripButton btnFind;
		private System.Windows.Forms.ToolStripSplitButton btnExport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tbSave;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolStripButton tbOpen;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
		private System.Windows.Forms.ToolStripMenuItem mnuFile;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.MenuStrip menuStrip;
		#endregion
	
		private void HandleNavigateStart(object sender, WebBrowserNavigatingEventArgs e)
		{			
			if(e.Url.AbsoluteUri.StartsWith("yammy:"))
			{
				//README: The uri can contain ONLY one ?
				string []strParts = e.Url.AbsoluteUri.Split('?');
				if(strParts[0].Contains("decode"))
				{
					string strDecodeFilePath = Uri.UnescapeDataString(strParts[1]).Replace('/','\\');
					if(File.Exists(strDecodeFilePath))
					{
						
						Decoder d = new Decoder(strDecodeFilePath);
						string strDecode = d.Decode(false, false);
						strDecode = strDecode.Replace("YAMMY_IMAGE_PATH", m_strImagePath);
						string strOutput = Resources.Instance.DisplayHtml.Replace("<$ReplaceBody$>", strDecode);
						strOutput = strOutput.Replace("<$ReplaceTitle$>", string.Format(Resources.Instance.ConversationBetween,
			                                            d.LocalID, d.RemoteID));

						webBrowser.DocumentText = strOutput;
					}
					e.Cancel = true;
				}
			}
		}
		
		private void HandleNavigateProgress(object sender, WebBrowserProgressChangedEventArgs e)
		{
			//FIXME: This will fail for really really large files
			toolStripProgressBar.Maximum = (int)e.MaximumProgress;
			toolStripProgressBar.Value = (int)e.CurrentProgress;
		}
		
		private void HandleNavigateDone(object sender, WebBrowserNavigatedEventArgs e)
		{
			toolStripProgressBar.Value = 0;
		}
		
		void MainFormFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			e.Cancel = false;
			Config.Instance.SplitterWidth = splitContainer.SplitterDistance;
			Config.Instance.SaveConfig();
		}
		
		void MnuFileExitClick(object sender, System.EventArgs e)
		{
			Application.Exit();
		}
		
		#region Search
		void TxtFindKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				BtnFindClick(sender, e);
			}
		}
		
		void BtnFindClick(object sender, System.EventArgs e)
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(Search), null);
		}
		
		/// <summary>
		/// Searches the index for the search terms
		/// </summary>
		/// <param name="stateInfo">Parameter required by ThreadPool, not used</param>
		void Search(object stateInfo)
		{
			string strSearchTerm = txtFind.Text.Trim();
			if(strSearchTerm.Length == 0)
				return;
			Indexer search = new Indexer(Config.Instance.IndexPath, IndexMode.SEARCH);
			IndexInfo []searchResults = search.Search(strSearchTerm);
			if(searchResults == null)
			{
				MessageBox.Show("No index found");
				return;
			}
			StringBuilder sb = new StringBuilder();
			string strOutput = Resources.Instance.DisplayHtml;
			strOutput = strOutput.Replace("<$ReplaceTitle$>", string.Format(Resources.Instance.SearchResultsFor, strSearchTerm));
			sb.Append("<div style=\"text-align:center;font-style:italic\">" + 
			          string.Format(Resources.Instance.NumSearchResults, searchResults.Length) + "</div>");
			sb.Append("<ol>");
			foreach (IndexInfo result in searchResults)
			{
				sb.Append("<li><a href=\"" + "yammy:decode?" + 
				          Uri.EscapeDataString(result.Location) + "\">" +
				          string.Format(Resources.Instance.ConversationBetween, result.LocalUser, result.RemoteUser) +
				          "</a><br />" + GetExcerpt(result.Message, strSearchTerm) + "</li>");
			}
			sb.Append("</ol>");
			strOutput = strOutput.Replace("<$ReplaceBody$>", sb.ToString());
			webBrowser.DocumentText = strOutput;
		}
		
		/// <summary>
		/// Gets a small paragraph of the text to display on the search results page
		/// </summary>
		/// <param name="text">The text gotten from the index</param>
		/// <param name="searchTerm"></param>
		/// <returns>small paragraph of text</returns>
		string GetExcerpt(string text, string searchTerm)
		{
			const int textWindow = 100;
			string[] searchTerms = searchTerm.Split('+');
			int iStart = 0;
			int iEnd = text.Length;

			// Get the position of the first term
			foreach (string term in searchTerms)
			{
				int position = text.IndexOf(term, StringComparison.InvariantCultureIgnoreCase);
				if (position >= 0)
				{
					if (position > textWindow)
					{
						iStart = position - textWindow;
					}

					if (position + textWindow < text.Length)
					{
						iEnd = position + textWindow;
					}

					break; // if atleast one term is present
				}
            }
			string strExcerpt = text.Substring(iStart, iEnd - iStart);
			MatchEvaluator matchBoldify = new MatchEvaluator(Boldify);
			// Make all search terms bold
			foreach (string term in searchTerms)
			{
				strExcerpt = Regex.Replace(strExcerpt, term, matchBoldify, RegexOptions.IgnoreCase);
			}

			return strExcerpt;
        }
		
        /// <summary>
        /// Highlights the search terms in the search results page by making them bold
        /// </summary>
        /// <param name="m">RegEx Match</param>
        /// <returns>string with the search terms in bold</returns>
        private string Boldify(Match m)
        {
            return "<b>" + m.Value + "</b>";
        }
        #endregion
		
		void MnuToolsOptionsClick(object sender, System.EventArgs e)
		{
			string strOutput = Resources.Instance.DisplayHtml.Replace("<$ReplaceTitle$>", 
									Resources.Instance.YammyOptionsTitle);
			
			StringBuilder sb = new StringBuilder();
			sb.Append("<form action=\"yammy:config\">");
			sb.Append("<table cellspacing=\"0\" cellpadding=\"0\">");
			sb.Append("<tr><td>" + Resources.Instance.OptionsYahooProfilesPath + 
			          "</td><td><input type=\"text\" name=\"YahooProfilesPath\" value=\"" +
			          Config.Instance.YahooProfilesPath + "\"/></td></tr>");
			sb.Append("<tr><td colspan=\"2\">" + Resources.Instance.SetArchivingFor + "</td></tr>");
			sb.Append("<tr><td></td><td>");
			foreach(UserArchiveFlag user in Config.Instance.UserList)
			{
				sb.Append("<input type=\"checkbox\" name=\"" + user.YahooId + "\" " +
				          (user.EnableArchiving ? "checked" : "") + ">" + user.YahooId + "<br />");
			}
			sb.Append("</td></tr>");
			sb.Append("<tr><td colspan=\"2\"><input type=\"submit\" value=\"" + 
			          Resources.Instance.SaveSettings + "\" /></td></tr>");
			sb.Append("</table>");
			sb.Append("</form>");
			strOutput = strOutput.Replace("<$ReplaceBody$>", sb.ToString());
			webBrowser.DocumentText = strOutput;
		}
		
		void MainFormLoad(object sender, System.EventArgs e)
		{
			m_treeviewManager = new TreeViewManager(treeView, webBrowser);
			this.BeginInvoke(new dlgtLoadTreeView(m_treeviewManager.LoadTreeView));
		}
		
		void TbSaveClick(object sender, System.EventArgs e)
		{
			MnuFileSaveClick(sender, e);
		}
		
		void MnuFileSaveClick(object sender, System.EventArgs e)
		{
			this.saveFileDialog.DefaultExt = "*.htm";
			this.saveFileDialog.Filter = "Html file|*.htm";
			if(this.saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamWriter writer = null;
				try
				{
					writer = new StreamWriter(this.saveFileDialog.FileName, false, System.Text.Encoding.UTF8);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString(), Resources.Instance.Error);
					return;
				}
				writer.Write(webBrowser.DocumentText);
				writer.Close(); writer = null;
			}
		}
		
		void MnuOpenClick(object sender, System.EventArgs e)
		{
			this.openFileDialog.Filter = "Yahoo Archives|*.dat";
			if(this.openFileDialog.ShowDialog() == DialogResult.OK)
			{
				Decoder d = new Decoder(this.openFileDialog.FileName);
				string strDecode = d.Decode(false, false);
				if(strDecode == null)
				{
					MessageBox.Show("Error in Decoding", Resources.Instance.Error);
					return;
				}
				string strOutput = Resources.Instance.DisplayHtml.Replace("<$ReplaceBody$>", strDecode);
				strOutput = strOutput.Replace("<$ReplaceTitle$>", string.Format(Resources.Instance.ConversationBetween,
			                                            d.LocalID, d.RemoteID));
				webBrowser.DocumentText = strOutput;
			}
		}
		
		void TbOpenClick(object sender, System.EventArgs e)
		{
			MnuOpenClick(sender, e);
		}
		/// <summary>
		/// Down in the crowded bars,
		/// 	out for a good time,
		/// Can't wait to tell you all,
		/// 	what it's like up there
		///	And they called it paradise
		/// 	I don't know why
		/// Somebody laid the mountains low
		/// 	while the town got high.
		/// -- The Eagles (The last resort)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MnuHelpAboutClick(object sender, EventArgs e)
		{
			webBrowser.DocumentText = Resources.Instance.AboutYammyHtml;
		}
		
		void BtnExportButtonClick(object sender, EventArgs e)
		{

		}

		string GetExportFolderName()
		{
			folderBrowserDialog.ShowNewFolderButton = true;
			if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				return folderBrowserDialog.SelectedPath;
			}
			return null;
		}
		
		void ExportAsHTMLClick(object sender, EventArgs e)
		{
			TreeNode node = treeView.SelectedNode;
			if (node == null)
				return;
			string strDir = node.Tag as string;
			if (strDir == null)
				return;

			string strOutDir = GetExportFolderName();
			if (strOutDir == null)
				return;

			string[] fileList = null;
			try
			{
				fileList = Directory.GetFiles(strDir);
			}
			catch (IOException ex)
			{
				Logger.Instance.LogException(ex);
				return;
			}

			foreach (string file in fileList)
			{
				try
				{
					Decoder d = new Decoder(file);
					string strDecode = d.Decode(false, false);
					string strOutput = Resources.Instance.DisplayHtml.Replace("<$ReplaceBody$>", strDecode);
					strOutput = strOutput.Replace("<$ReplaceTitle$>", string.Format(Resources.Instance.ConversationBetween,
													d.LocalID, d.RemoteID));

					string strOutputFile = Path.Combine(strOutDir, Path.GetFileNameWithoutExtension(file) + ".html");
					StreamWriter writer = new StreamWriter(strOutputFile);
					writer.Write(strOutput);
					writer.Flush(); writer.Close(); writer = null;
				}
				catch (Exception ex)
				{
					Logger.Instance.LogException(ex);
				}
			}
		}
	}
}
