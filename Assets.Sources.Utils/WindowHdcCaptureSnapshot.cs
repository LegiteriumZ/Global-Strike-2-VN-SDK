using System;
using System.Runtime.InteropServices;
using SSJJBase.Logger;
using SSJJBase.Singleton;

namespace Assets.Sources.Utils;

public class WindowHdcCaptureSnapshot : AbstractCaptureSnapshot
{
	private byte[] _pic = new byte[4194304];

	private int _picLen = 4194304;

	[DllImport("EyeRecall", CharSet = CharSet.Auto)]
	public static extern int ScreenShotJPEG(byte[] data, int len);

	[DllImport("EyeRecall", CharSet = CharSet.Auto)]
	public static extern int SetWindowResult();

	[DllImport("EyeRecall", CharSet = CharSet.Auto)]
	public static extern int GetWindowResult();

	[DllImport("EyeRecall", CharSet = CharSet.Auto)]
	public static extern void CheckEnumWindowPro(bool isForce);

	[DllImport("EyeRecall", CharSet = CharSet.Auto)]
	public static extern int GetErrorCode();

	public override void UpdateScreen()
	{
		if (!IsSendEaseing || !IsCaping)
		{
			return;
		}
		GetPath();
		bool num = IsOperatingSystemCanCapture();
		int arg = 0;
		if (num)
		{
			if (SpecailDebug.Instance.KillScreenSave || CheckIsLocalServer())
			{
				CheckEnumWindowPro(isForce: true);
			}
			else
			{
				CheckEnumWindowPro(isForce: false);
			}
			arg = GetWindowResult();
		}
		int num2 = ScreenShotJPEG(_pic, _picLen);
		if (num)
		{
			SetWindowResult();
			int errorCode = GetErrorCode();
			if (SpecailDebug.Instance.KillScreenSave || CheckIsLocalServer())
			{
				this.InfoFormat("ErrorCode {0}, result {1}", errorCode, arg);
			}
		}
		if (num2 > 10)
		{
			byte[] array = new byte[num2];
			Array.Copy(_pic, array, num2);
			MonoBehaviourSingleton<NetEaseCloudManager>.Instance.Send(array, 115);
		}
		ScreenOver();
	}

	public bool IsOperatingSystemCanCapture()
	{
		if (OperatingSystem.IndexOf("xp", StringComparison.OrdinalIgnoreCase) > -1)
		{
			return false;
		}
		return true;
	}
}
