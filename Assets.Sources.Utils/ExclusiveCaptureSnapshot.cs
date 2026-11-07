using System.IO;
using System.Threading;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using UnityEngine;

namespace Assets.Sources.Utils;

public class ExclusiveCaptureSnapshot : AbstractCaptureSnapshot
{
	public override void UpdateScreen()
	{
		if (!IsCaping || !IsSendEaseing)
		{
			return;
		}
		if (string.IsNullOrEmpty(ScreenFilePath))
		{
			string filePath = GetPath();
			string directoryName = Path.GetDirectoryName(filePath);
			if (!Directory.Exists(directoryName) && directoryName != null)
			{
				Directory.CreateDirectory(directoryName);
			}
			UnityMainThreadDispatcher.Enqueue(delegate
			{
				ScreenCapture.CaptureScreenshot(filePath);
				ScreenFilePath = filePath;
			});
			return;
		}
		int num = 1;
		while (num++ <= 12)
		{
			Thread.Sleep(500);
			if (!File.Exists(ScreenFilePath))
			{
				continue;
			}
			string text = ScreenFilePath.Replace(".jpg", "_output.jpg");
			byte[] array = null;
			if (GetPicThumbnail(ScreenFilePath, text))
			{
				array = File.ReadAllBytes(text);
				if (SpecailDebug.Instance.KillScreenSave)
				{
					this.Info("outFilePath > " + (float)array.Length / 1024f);
				}
			}
			else
			{
				array = File.ReadAllBytes(ScreenFilePath);
				if (SpecailDebug.Instance.KillScreenSave)
				{
					this.Info("ScreenFilePath > " + (float)array.Length / 1024f);
				}
			}
			MonoBehaviourSingleton<NetEaseCloudManager>.Instance.Send(array, 115);
			File.Delete(ScreenFilePath);
			File.Delete(text);
			break;
		}
		ScreenOver();
	}
}
