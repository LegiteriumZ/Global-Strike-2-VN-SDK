using System;

namespace agora_gaming_rtc;

public interface IVideoDeviceManager
{
	bool CreateAVideoDeviceManager();

	int ReleaseAVideoDeviceManager();

	int StartVideoDeviceTest(IntPtr hwnd);

	int StopVideoDeviceTest();

	int GetVideoDeviceCollectionCount();

	int GetVideoDeviceCollectionDevice(int index, ref string deviceName, ref string deviceId);

	int SetVideoDeviceCollectionDevice(string deviceId);
}
