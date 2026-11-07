using System;
using System.Collections.Generic;
using System.Xml;

public class TextStyleConfigParser
{
	public class TextStyle
	{
		public int Id;

		public string FontName;

		public int FontSize;

		public int Color;

		public bool Bold;

		public string UnityRichColor;
	}

	public static Dictionary<int, TextStyle> TextStyleDictionary = new Dictionary<int, TextStyle>();

	public static void ParseConfig(string xml)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		foreach (XmlElement childNode in xmlDocument.SelectSingleNode("config").ChildNodes)
		{
			TextStyle textStyle = new TextStyle();
			foreach (XmlAttribute attribute in childNode.Attributes)
			{
				switch (attribute.Name)
				{
				case "id":
					textStyle.Id = int.Parse(attribute.Value);
					break;
				case "fontName":
					textStyle.FontName = attribute.Value;
					break;
				case "fontSize":
					textStyle.FontSize = int.Parse(attribute.Value);
					break;
				case "color":
					textStyle.Color = int.Parse(attribute.Value);
					break;
				case "bold":
					textStyle.Bold = bool.Parse(attribute.Value);
					break;
				}
			}
			string text = Convert.ToString((textStyle.Color << 8) | 0xFF, 16);
			while (text.Length < 8)
			{
				text = "0" + text;
			}
			textStyle.UnityRichColor = "#" + text;
			TextStyleDictionary[textStyle.Id] = textStyle;
		}
	}
}
