namespace agora_gaming_rtc;

public class AudioPlaybackDeviceManager : IAudioPlaybackDeviceManager
{
	private IRtcEngine mEngine;

	public AudioPlaybackDeviceManager(IRtcEngine rtcEngine)
	{
		mEngine = rtcEngine;
	}

	public void SetEngine(IRtcEngine engine)
	{
		mEngine = engine;
	}

	public bool CreatAAudioPlaybackDeviceManager()
	{
		if (mEngine == null)
		{
			return false;
		}
		return mEngine.CreatAAudioPlaybackDeviceManager();
	}

	public int ReleaseAAudioPlaybackDeviceManager()
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.ReleaseAAudioPlaybackDeviceManager();
	}

	public int GetAudioPlaybackDeviceCount()
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.GetAudioPlaybackDeviceCount();
	}

	public int GetAudioPlaybackDevice(int index, ref string deviceName, ref string deviceId)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.GetAudioPlaybackDevice(index, ref deviceName, ref deviceId);
	}

	public int SetAudioPlaybackDevice(string deviceId)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.SetAudioPlaybackDevice(deviceId);
	}

	public int SetAudioPlaybackDeviceVolume(int volume)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.SetAudioPlaybackDeviceVolume(volume);
	}

	public int GetAudioPlaybackDeviceVolume()
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.GetAudioPlaybackDeviceVolume();
	}

	public int SetAudioPlaybackDeviceMute(bool mute)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.SetAudioPlaybackDeviceMute(mute);
	}

	public bool IsAudioPlaybackDeviceMute()
	{
		if (mEngine == null)
		{
			return false;
		}
		return mEngine.IsAudioPlaybackDeviceMute();
	}

	public int StartAudioPlaybackDeviceTest(string testAudioFilePath)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.StartAudioPlaybackDeviceTest(testAudioFilePath);
	}

	public int StopAudioPlaybackDeviceTest()
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.StopAudioPlaybackDeviceTest();
	}
}
