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
using System.Resources;

namespace Yammy
{
	/// <summary>
	/// Returns culture-specific resource entities
	/// </summary>
	public sealed class Resources
	{
		private static Resources _instance = new Resources();
		ResourceManager m_resourceManager;
		
		public static Resources Instance 
		{
			get { return _instance; }
		}
		
		private Resources()
		{
			//TODO: When you need to internationalize, add culture
			m_resourceManager = new ResourceManager("Yammy.Yammy", typeof(Resources).Assembly);
		}
		
		public string UnableToLoadConfig
		{
			get
			{
				return m_resourceManager.GetString("UnableToLoadConfig");
			}
		}
		public string DisplayHtml
		{
			get
			{
				return m_resourceManager.GetString("DisplayHtml");
			}
		}
		public string YammyOptionsTitle
		{
			get
			{
				return m_resourceManager.GetString("YammyOptionsTitle");
			}
		}
		public string ConversationBetween
		{
			get
			{
				return m_resourceManager.GetString("ConversationBetween");
			}
		}
		public string IndexingFrequency
		{
			get
			{
				return m_resourceManager.GetString("IndexingFrequency");
			}
		}
		public string EnableArchivingFor
		{
			get
			{
				return m_resourceManager.GetString("EnableArchivingFor");
			}
		}
		public string SearchResultsFor
		{
			get
			{
				return m_resourceManager.GetString("SearchResultsFor");
			}
		}
		public string NumSearchResults
		{
			get
			{
				return m_resourceManager.GetString("NumSearchResults");
			}
		}
		public string Error
		{
			get { return m_resourceManager.GetString("Error"); }
		}
		public string AboutYammyHtml
		{
			get { return m_resourceManager.GetString("AboutYammyHtml"); }
		}
		public string OptionsYahooProfilesPath
		{
			get { return m_resourceManager.GetString("OptionsYahooProfilesPath"); }
		}
		public string SetArchivingFor
		{
			get { return m_resourceManager.GetString("SetArchivingFor"); }
		}
		public string SaveSettings
		{
			get { return m_resourceManager.GetString("SaveSettings"); }
		}
	}
}
