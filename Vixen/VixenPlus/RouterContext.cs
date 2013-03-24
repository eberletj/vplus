﻿using System;
using System.Collections.Generic;
using System.Xml;

namespace Vixen
{
	internal class RouterContext : ITickSource
	{
		public byte[] EngineBuffer;
		public IExecutable ExecutableObject;
		public List<MappedOutputPlugIn> OutputPluginList;
		public SetupData PluginData;
		public ITickSource TickSource;
		public bool m_initialized = false;

		public RouterContext(byte[] engineBuffer, SetupData pluginData, IExecutable executableObject, ITickSource tickSource)
		{
			EngineBuffer = engineBuffer;
			PluginData = pluginData;
			ExecutableObject = executableObject;
			OutputPluginList = new List<MappedOutputPlugIn>();
			if (tickSource == null)
			{
				TickSource = this;
			}
			else
			{
				TickSource = tickSource;
			}
			foreach (XmlNode node in PluginData.GetAllPluginData(SetupData.PluginType.Output, true))
			{
				var item = new MappedOutputPlugIn((IOutputPlugIn) OutputPlugins.FindPlugin(node.Attributes["name"].Value, true),
				                                  Convert.ToInt32(node.Attributes["from"].Value),
				                                  Convert.ToInt32(node.Attributes["to"].Value), true, node);
				OutputPluginList.Add(item);
			}
		}

		public bool Initialized
		{
			get { return m_initialized; }
			set
			{
				m_initialized = value;
				foreach (MappedOutputPlugIn @in in OutputPluginList)
				{
					@in.ContextInitialized = value;
				}
			}
		}

		public int Milliseconds
		{
			get { return 0; }
		}
	}
}