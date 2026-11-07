using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Free.Data;
using NetData;

namespace Assets.Sources.Modules.SceneObject.Shake;

public class ShakePlaybackSystem : IPlaybackSystem
{
	private SceneObjectContext _sceneObjectContext;

	private SnapshotContext _snapshotContext;

	private TimeComponent _time;

	public const int Define = 0;

	public const int Grenade = 1;

	public const int ThrowFlybomb = 2;

	public const int IntelligenceFlybomb = 3;

	public const int XpShifang = 4;

	public const int XpMingzhong = 5;

	public const int Grenadetime = 250;

	public const float Grenadshakedistance = 0.7f;

	public const int ThrowFlybombtime = 250;

	public const float ThrowFlybombdistance = 0.1f;

	public const int NtelligenceFlybombtime = 500;

	public const float NtelligenceFlybombdistance = 1.5f;

	public const int XpShifangShakeTime = 500;

	public const float XpShifangDistance = 0.1f;

	public const int XpMingzhongShakeTime = 300;

	public const float XpMingzhongDistance = 1f;

	private int _shakeType;

	private int _shakeTime;

	private int _shakeMaxTime;

	private float _shakeDistance;

	public ShakePlaybackSystem(Contexts contexts)
	{
		_sceneObjectContext = contexts.sceneObject;
		_snapshotContext = contexts.snapshot;
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		if (!_sceneObjectContext.hasShake)
		{
			return;
		}
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		if (nowSnapshot == null)
		{
			return;
		}
		foreach (KeyValuePair<int, ShakeEventEntityData> item in nowSnapshot.ShakeEventEntityDataDict)
		{
			ShakeEventEntityData value = item.Value;
			InitShake(value);
		}
		UpdateShake();
	}

	private void InitShake(ShakeEventEntityData data)
	{
		_shakeType = data.ShakeType;
		switch (_shakeType)
		{
		case 1:
			_shakeMaxTime = 250;
			_shakeDistance = 0.7f;
			break;
		case 2:
			_shakeMaxTime = 250;
			_shakeDistance = 0.1f;
			break;
		case 3:
			_shakeMaxTime = 500;
			_shakeDistance = 1.5f;
			break;
		case 4:
			_shakeMaxTime = 500;
			_shakeDistance = 0.1f;
			break;
		case 5:
			_shakeMaxTime = 300;
			_shakeDistance = 1f;
			break;
		default:
			_shakeMaxTime = 0;
			_shakeDistance = 0f;
			break;
		}
		_shakeTime = _time.ClientRealTime;
	}

	private void UpdateShake()
	{
		_sceneObjectContext.shake.ShakeAngleOffset.Set(0f, 0f, 0f);
		int num = _time.ClientRealTime - _shakeTime;
		if (num <= _shakeMaxTime && _shakeTime != 0 && num != 0)
		{
			int shakeTime = _shakeMaxTime;
			if (_shakeType == 3)
			{
				num %= 100;
				shakeTime = 100;
			}
			Shake(num, shakeTime);
		}
		GameModelLocator.GetInstance().GameModel.ShakeAngleOffect = _sceneObjectContext.shake.ShakeAngleOffset;
	}

	private void Shake(int timeDelta, int shakeTime)
	{
		float num = 0f;
		if (timeDelta <= shakeTime / 6)
		{
			num = (float)timeDelta * _shakeDistance / 100f;
			_sceneObjectContext.shake.ShakeAngleOffset.x = num;
			_sceneObjectContext.shake.ShakeAngleOffset.y = num;
		}
		if (timeDelta <= shakeTime / 3)
		{
			_sceneObjectContext.shake.ShakeAngleOffset.x = _shakeDistance;
			_sceneObjectContext.shake.ShakeAngleOffset.y = _shakeDistance;
			num = (float)(timeDelta - shakeTime / 6) * _shakeDistance / 100f;
			_sceneObjectContext.shake.ShakeAngleOffset.x -= num;
		}
		else if (timeDelta <= shakeTime / 3 * 2)
		{
			_sceneObjectContext.shake.ShakeAngleOffset.x = 0f - _shakeDistance;
			_sceneObjectContext.shake.ShakeAngleOffset.y = _shakeDistance;
			num = (float)(timeDelta - shakeTime / 3) * _shakeDistance / 100f;
			_sceneObjectContext.shake.ShakeAngleOffset.x += num;
			_sceneObjectContext.shake.ShakeAngleOffset.y -= num;
		}
		else if (timeDelta <= shakeTime / 6 * 5)
		{
			_sceneObjectContext.shake.ShakeAngleOffset.x = _shakeDistance;
			_sceneObjectContext.shake.ShakeAngleOffset.y = 0f - _shakeDistance;
			num = (float)(timeDelta - shakeTime / 3 * 2) * _shakeDistance / 100f;
			_sceneObjectContext.shake.ShakeAngleOffset.x -= num;
		}
		else if (timeDelta <= shakeTime)
		{
			_sceneObjectContext.shake.ShakeAngleOffset.x = 0f - _shakeDistance;
			_sceneObjectContext.shake.ShakeAngleOffset.y = 0f - _shakeDistance;
			num = (float)(timeDelta - shakeTime / 6 * 5) * _shakeDistance / 100f;
			_sceneObjectContext.shake.ShakeAngleOffset.x += num;
			_sceneObjectContext.shake.ShakeAngleOffset.y += num;
		}
	}
}
