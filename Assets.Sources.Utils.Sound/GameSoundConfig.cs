namespace Assets.Sources.Utils.Sound;

public struct GameSoundConfig
{
	public float WeaponVolume;

	public float EnvironmentVolume;

	public float AsideVolume;

	public float StepVolume;

	public float VoiceListenVolume;

	public float VoiceSpeakVolume;

	public float BgmSpeakVolume;

	public GameSoundConfig(float wv, float ev, float av, float sv, float vlv, float vsv, float bgmv)
	{
		WeaponVolume = wv;
		EnvironmentVolume = ev;
		AsideVolume = av;
		StepVolume = sv;
		VoiceListenVolume = vlv;
		VoiceSpeakVolume = vsv;
		BgmSpeakVolume = bgmv;
	}

	public void SetDefualt()
	{
		WeaponVolume = 1f;
		EnvironmentVolume = 1f;
		AsideVolume = 1f;
		StepVolume = 1f;
		VoiceListenVolume = 0.6f;
		VoiceSpeakVolume = 0.6f;
		BgmSpeakVolume = 1f;
	}

	public override string ToString()
	{
		return $"WeaponVolume:{WeaponVolume} EnvironmentVolume:{EnvironmentVolume} AsideVolume:{AsideVolume} StepVolume:{StepVolume} VoiceListenVolume:{VoiceListenVolume} VoiceSpeakVolume:{VoiceSpeakVolume}";
	}
}
