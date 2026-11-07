namespace agora_gaming_rtc;

public class AudioRecordingoDeviceManager : IAudioRecordingDeviceManager
{
	private IRtcEngine mEngine;

	public AudioRecordingoDeviceManager(IRtcEngine rtcEngine)
	{
		mEngine = rtcEngine;
	}

	public void SetEngine(IRtcEngine engine)
	{
		mEngine = engine;
	}

	public bool CreatAAudioRecordingDeviceManager()
	{
		if (mEngine == null)
		{
			return false;
		}
		return mEngine.CreatAAudioRecordingDeviceManager();
	}

	public int ReleaseAAudioRecordingDeviceManager()
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.ReleaseAAudioRecordingDeviceManager();
	}

	public int GetAudioRecordingDeviceCount()
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.GetAudioRecordingDeviceCount();
	}

	public int GetAudioRecordingDevice(int index, ref string audioRecordingDeviceName, ref string audioRecordingDeviceId)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.GetAudioRecordingDevice(index, ref audioRecordingDeviceName, ref audioRecordingDeviceId);
	}

	public int SetAudioRecordingDevice(string deviceId)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.SetAudioRecordingDevice(deviceId);
	}

	public int StartAudioRecordingDeviceTest(int indicationInterval)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.StartAudioRecordingDeviceTest(indicationInterval);
	}

	public int StopAudioRecordingDeviceTest()
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.StopAudioRecordingDeviceTest();
	}
}
