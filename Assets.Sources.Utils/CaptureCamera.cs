using System;
using System.IO;
using SSJJBase.Utility;
using UnityEngine;

namespace Assets.Sources.Utils;

public class CaptureCamera
{
	private static string _timeStr;

	private static string TimeStr
	{
		get
		{
			if (string.IsNullOrEmpty(_timeStr))
			{
				_timeStr = DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day;
			}
			return _timeStr;
		}
	}

	public static void Capture2(string name)
	{
		string text = PathEx.Combine(Application.persistentDataPath + "/ScreenShotForTest/" + TimeStr, name + ".png");
		string directoryName = Path.GetDirectoryName(text);
		if (!Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		ScreenCapture.CaptureScreenshot(text);
	}

	public static Texture2D Capture(Camera camera, string name)
	{
		Rect source = new Rect(0f, 0f, Screen.width, Screen.height);
		RenderTexture renderTexture = new RenderTexture((int)source.width, (int)source.height, 0);
		camera.targetTexture = renderTexture;
		camera.Render();
		RenderTexture.active = renderTexture;
		Texture2D texture2D = new Texture2D((int)source.width, (int)source.height, TextureFormat.RGB24, mipChain: false);
		texture2D.ReadPixels(source, 0, 0);
		texture2D.Apply();
		camera.targetTexture = null;
		UnityEngine.Object.Destroy(renderTexture);
		RenderTexture.active = null;
		byte[] bytes = texture2D.EncodeToPNG();
		string path = Application.persistentDataPath + "/ScreenShotForTest/Screenshot_" + name + ".png";
		string directoryName = Path.GetDirectoryName(path);
		if (!Directory.Exists(directoryName) && directoryName != null)
		{
			Directory.CreateDirectory(directoryName);
		}
		File.WriteAllBytes(path, bytes);
		return texture2D;
	}
}
