using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace NotiRss.Models.Rss
{
	[XmlRoot(ElementName = "rss")]
	public class MRss
	{

		[XmlElement(ElementName = "channel")]
		public MChannel Channel { get; set; }

		[XmlAttribute(AttributeName = "version")]
		public double Version { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "channel")]
	public class MChannel
	{

		[XmlElement(ElementName = "title")]
		public string Title { get; set; }

		[XmlElement(ElementName = "link")]
		public string Link { get; set; }

		[XmlElement(ElementName = "item")]
		public List<MItem> Items { get; set; }
	}
}
