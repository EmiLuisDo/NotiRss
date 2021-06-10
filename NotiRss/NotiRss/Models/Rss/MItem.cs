using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace NotiRss.Models.Rss
{
	[XmlRoot(ElementName = "item")]
	public class MItem
	{

		[XmlElement(ElementName = "enclosure")]
		public MEnclosure Enclosure { get; set; }

		[XmlElement(ElementName = "title")]
		public string Title { get; set; }

		[XmlElement(ElementName = "pubDate")]
		public string PubDate { get; set; }

		[XmlElement(ElementName = "author")]
		public string Author { get; set; }

		[XmlElement(ElementName = "link")]
		public string Link { get; set; }
	}


	[XmlRoot(ElementName = "enclosure")]
	public class MEnclosure
	{

		[XmlAttribute(AttributeName = "url")]
		public string Url { get; set; }

		[XmlAttribute(AttributeName = "length")]
		public int Length { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
	}
}
