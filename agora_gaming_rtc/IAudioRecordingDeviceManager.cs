namespace agora_gaming_rtc;

public interface IAudioRecordingDeviceManager
{
	bool CreatAAudioRecordingDeviceManager();

	int ReleaseAAudioRecordingDeviceManager();

	int GetAudioRecordingDeviceCount();

	int GetAudioRecordingDevice(int index, ref string audioRecordingDeviceName, ref string audioRecordingDeviceId);

	int SetAudioRecordingDevice(string deviceId);

	int StartAudioRecordingDeviceTest(int indicationInterval);

	int StopAudioRecordingDeviceTest();
}
