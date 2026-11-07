using System;

namespace agora_gaming_rtc;

public class VideoDeviceManager : IVideoDeviceManager
{
	private IRtcEngine mEngine;

	public VideoDeviceManager(IRtcEngine rtcEngine)
	{
		mEngine = rtcEngine;
	}

	public void SetEngine(IRtcEngine engine)
	{
		mEngine = engine;
	}

	public bool CreateAVideoDeviceManager()
	{
		if (mEngine == null)
		{
			return false;
		}
		return mEngine.CreateAVideoDeviceManager();
	}

	public int ReleaseAVideoDeviceManager()
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.ReleaseAVideoDeviceManager();
	}

	public int StartVideoDeviceTest(IntPtr hwnd)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.StartVideoDeviceTest(hwnd);
	}

	public int StopVideoDeviceTest()
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.StopVideoDeviceTest();
	}

	public int GetVideoDeviceCollectionCount()
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.GetVideoDeviceCollectionCount();
	}

	public int GetVideoDeviceCollectionDevice(int index, ref string deviceName, ref string deviceId)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.GetVideoDeviceCollectionDevice(index, ref deviceName, ref deviceId);
	}

	public int SetVideoDeviceCollectionDevice(string deviceId)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.SetVideoDeviceCollectionDevice(deviceId);
	}
}
