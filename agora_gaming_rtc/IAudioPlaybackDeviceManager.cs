namespace agora_gaming_rtc;

public interface IAudioPlaybackDeviceManager
{
	bool CreatAAudioPlaybackDeviceManager();

	int ReleaseAAudioPlaybackDeviceManager();

	int GetAudioPlaybackDeviceCount();

	int GetAudioPlaybackDevice(int index, ref string deviceName, ref string deviceId);

	int SetAudioPlaybackDevice(string deviceId);

	int SetAudioPlaybackDeviceVolume(int volume);

	int GetAudioPlaybackDeviceVolume();

	int SetAudioPlaybackDeviceMute(bool mute);

	bool IsAudioPlaybackDeviceMute();

	int StartAudioPlaybackDeviceTest(string testAudioFilePath);

	int StopAudioPlaybackDeviceTest();
}
