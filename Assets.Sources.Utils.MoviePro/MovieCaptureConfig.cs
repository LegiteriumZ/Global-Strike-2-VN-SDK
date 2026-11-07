using System;
using System.IO;
using System.Xml;
using SSJJBase.Extensions;
using SSJJBase.Logger;

namespace Assets.Sources.Utils.MoviePro;

public class MovieCaptureConfig
{
	public bool IsAddAudio = true;

	public bool VideoCompress;

	public int DownScale = 2;

	public int FrameRate = 20;

	public bool IsDestoryAutoSave;

	public int AllowFps = 30;

	public int MinimumDiskSpaceMb = 1000;

	public bool LostIsPauseVideo;

	public override string ToString()
	{
		return $"IsAddAudio:{IsAddAudio}, DownScale:{DownScale}, FrameCount:{FrameRate}, AllowFps:{AllowFps}, MinimumDiskSpaceMb:{MinimumDiskSpaceMb}, LostIsPauseVideo:{LostIsPauseVideo}, VideoCompress:{VideoCompress}";
	}

	public void ReadConfig()
	{
		if (File.Exists("OpenAvi.txt"))
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load("OpenAvi.txt");
				XmlNode firstChild = xmlDocument.FirstChild;
				DownScale = firstChild.Read("DownScale", 2);
				FrameRate = firstChild.Read("FrameRate", 20);
				AllowFps = firstChild.Read("AllowFps", 30);
				IsAddAudio = firstChild.Read("IsAddAudio", defaultval: false);
				LostIsPauseVideo = firstChild.Read("LostIsPauseVideo", defaultval: false);
				VideoCompress = firstChild.Read("VideoCompress", defaultval: false);
				MinimumDiskSpaceMb = firstChild.Read("MinimumDiskSpaceMb", 1000);
				this.InfoFormat("MovieConfig >>  {0}", ToString());
			}
			catch (Exception ex)
			{
				this.LogError("read config " + ex);
			}
		}
	}
}
