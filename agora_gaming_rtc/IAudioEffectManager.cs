namespace agora_gaming_rtc;

public interface IAudioEffectManager
{
	double GetEffectsVolume();

	int SetEffectsVolume(int volume);

	int PlayEffect(int soundId, string filePath, int loopCount, double pitch = 1.0, double pan = 0.0, int gain = 100, bool publish = false);

	int StopEffect(int soundId);

	int StopAllEffects();

	int PreloadEffect(int soundId, string filePath);

	int UnloadEffect(int soundId);

	int PauseEffect(int soundId);

	int PauseAllEffects();

	int ResumeEffect(int soundId);

	int ResumeAllEffects();

	int SetVoiceOnlyMode(bool enable);

	int SetRemoteVoicePosition(uint uid, double pan, double gain);

	int SetLocalVoicePitch(double pitch);
}
