using System;
using Assets.Sources.Components.GameRule.MechKing;
using Assets.Sources.Components.Time;

public class mechKingModelReliveProcessProvider : ImechKingModelReliveProcessProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private float _relivePower;

	private float _reliveNowPower;

	private int _reliveMaxPower;

	private float _reliveSpeed;

	private float _progress;

	public mechKingModelReliveProcessProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		updateRelive(time);
	}

	private void updateRelive(TimeComponent time)
	{
		DynamicProcessUIData byType = getByType(1);
		if (byType != null)
		{
			if (byType.resetrelive)
			{
				byType.resetrelive = false;
				_relivePower = byType._currentPower;
				_reliveMaxPower = byType._maxPower;
				_reliveSpeed = byType._addPowerSpeed;
			}
			else if (_reliveMaxPower > 0)
			{
				_relivePower += _reliveSpeed * (float)time.FrameInterval * 0.001f;
				_reliveNowPower = _reliveNowPower * 0.8f + _relivePower * 0.2f;
			}
		}
		else
		{
			_reliveNowPower = 0f;
			_reliveMaxPower = 0;
		}
	}

	public float showPoint()
	{
		return 492f * _progress - 222f;
	}

	public float setProgress()
	{
		if (_reliveMaxPower > 0)
		{
			_progress = Math.Min(1f, _reliveNowPower / (float)_reliveMaxPower);
			return _progress;
		}
		return 0f;
	}

	public bool isShow()
	{
		DynamicProcessUIData byType = getByType(1);
		int key = -1;
		if (byType != null)
		{
			key = byType._id;
		}
		if (!_gameRuleContext.reliveProcessData._allUIData.ContainsKey(key))
		{
			return false;
		}
		return _gameRuleContext.reliveProcessData._allUIData[key] != null;
	}

	private DynamicProcessUIData getByType(int type)
	{
		foreach (DynamicProcessUIData value in _gameRuleContext.reliveProcessData._allUIData.Values)
		{
			if (value._type == type)
			{
				return value;
			}
		}
		return null;
	}
}
