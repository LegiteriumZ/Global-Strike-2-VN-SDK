using Assets.Sources.Config;
using Assets.Sources.Utils.EventLogger;
using NotifyEvent;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Scripts.Effect.Level;

public class ParticleEffectListener : MonoBehaviourSingleton<ParticleEffectListener>
{
	private bool _isStart;

	private float _startTime;

	private int _frameCount;

	private const string Key = "EPLLS";

	private int _caculateAllTime = 10;

	private int _allowMinFrame = 100;

	private const int MaxSetEffectLevelCount = 2;

	private const string AutoSetLevelKey = "AUTO_SET_EFFECT";

	private int EffectParticleLevelSet
	{
		get
		{
			return PlayerPrefs.GetInt("EPLLS", 0);
		}
		set
		{
			PlayerPrefs.SetInt("EPLLS", value);
			PlayerPrefs.Save();
		}
	}

	private void Clear()
	{
		EffectParticleLevelSet = 0;
	}

	private void AutoSetParticleEffect()
	{
		if (SystemInfo.graphicsDeviceVendorID == 32902 && PlayerPrefs.GetInt("AUTO_SET_EFFECT", 0) == 0)
		{
			PlayerPrefs.SetInt("AUTO_SET_EFFECT", 1);
			PlayerPrefs.Save();
			if (GameSetting.Config.EffectParticleLevel > 2)
			{
				GameSetting.Config.EffectParticleLevel = 2;
				GameSetting.Save(GameSetting.Config);
			}
		}
	}

	public void StartListen()
	{
		AutoSetParticleEffect();
		this.InfoFormat("Start Check Listener, EffectParticleLevelSet {0}, GameSetting.Config.ParticleLevel {1}", EffectParticleLevelSet, GameSetting.Config.EffectParticleLevel);
		if (MonoBehaviourSingleton<ParticleEffectManager>.Instance.IsOpen && EffectParticleLevelSet != 2)
		{
			GlobalProperties.Instance.Properties["ParticleEffectAutoSet0"] = 0;
			EventLogger.Instance.StageLogger("Start Check Particle Level ", StartStageEnum.ParticleEffectListener);
			GlobalProperties.Instance.Properties.Remove("ParticleEffectAutoSet0");
			ResetCaculate();
			_caculateAllTime = 100;
			_allowMinFrame = 51;
		}
	}

	private void StopCaculate()
	{
		_isStart = false;
	}

	private void ResetCaculate()
	{
		_isStart = true;
		_frameCount = 0;
		_startTime = Time.realtimeSinceStartup;
	}

	private void Update()
	{
		if (!_isStart)
		{
			return;
		}
		_frameCount++;
		if (!(Time.realtimeSinceStartup - _startTime >= (float)_caculateAllTime))
		{
			return;
		}
		_startTime = Time.realtimeSinceStartup;
		int num = _frameCount / _caculateAllTime;
		if (num < _allowMinFrame)
		{
			EffectParticleLevelSet++;
			if (EffectParticleLevelSet <= 2)
			{
				GlobalProperties.Instance.Properties["ParticleEffectAutoSet0"] = EffectParticleLevelSet;
				EventLogger.Instance.StageLogger("Avg Frame " + num + "  EffectParticleLevelSet " + EffectParticleLevelSet, StartStageEnum.ParticleEffectListener);
				GlobalProperties.Instance.Properties.Remove("ParticleEffectAutoSet0");
				if (EffectParticleLevelSet == 1)
				{
					GameSetting.Config.EffectParticleLevel = 2;
					Contexts.sharedInstance.message.gameMessageData.ParticleEffectLevelChanged = true;
					NotifyManager.ForceInvoke(87);
					ResetCaculate();
				}
				else if (EffectParticleLevelSet == 2)
				{
					GameSetting.Config.EffectParticleLevel = 0;
					Contexts.sharedInstance.message.gameMessageData.ParticleEffectLevelChanged = true;
					NotifyManager.ForceInvoke(87);
					StopCaculate();
				}
				GameSetting.Save(GameSetting.Config);
				MonoBehaviourSingleton<ParticleEffectManager>.Instance.RefreshParticleLevel();
			}
			else
			{
				StopCaculate();
			}
		}
		else
		{
			ResetCaculate();
		}
	}
}
