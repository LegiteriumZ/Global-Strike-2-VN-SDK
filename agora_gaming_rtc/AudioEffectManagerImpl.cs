namespace agora_gaming_rtc;

internal class AudioEffectManagerImpl : IAudioEffectManager
{
	private IRtcEngine mEngine;

	public AudioEffectManagerImpl(IRtcEngine rtcEngine)
	{
		mEngine = rtcEngine;
	}

	public void SetEngine(IRtcEngine engine)
	{
		mEngine = engine;
	}

	public double GetEffectsVolume()
	{
		_ = mEngine;
		return 0.0;
	}

	public int SetEffectsVolume(int volume)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.SetEffectsVolume(volume);
	}

	public int PlayEffect(int soundId, string filePath, int loopCount, double pitch = 1.0, double pan = 0.0, int gain = 100, bool publish = false)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.PlayEffect(soundId, filePath, loopCount, pitch, pan, gain, publish);
	}

	public int StopEffect(int soundId)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.StopEffect(soundId);
	}

	public int StopAllEffects()
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.StopAllEffects();
	}

	public int PreloadEffect(int soundId, string filePath)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.PreloadEffect(soundId, filePath);
	}

	public int UnloadEffect(int soundId)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.UnloadEffect(soundId);
	}

	public int PauseEffect(int soundId)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.PauseEffect(soundId);
	}

	public int PauseAllEffects()
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.PauseAllEffects();
	}

	public int ResumeEffect(int soundId)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.ResumeEffect(soundId);
	}

	public int ResumeAllEffects()
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.ResumeAllEffects();
	}

	public int SetVoiceOnlyMode(bool enable)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.SetVoiceOnlyMode(enable);
	}

	public int SetRemoteVoicePosition(uint uid, double pan, double gain)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.SetRemoteVoicePosition(uid, pan, gain);
	}

	public int SetLocalVoicePitch(double pitch)
	{
		if (mEngine == null)
		{
			return 0;
		}
		return mEngine.SetLocalVoicePitch(pitch);
	}
}
