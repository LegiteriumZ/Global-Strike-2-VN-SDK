using System.Collections.Generic;
using Assets.Sources.Components.Time;
using share.constant;

public class commonPlayerInfoMessageProvider : IcommonPlayerInfoMessageProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	private Dictionary<int, string> _configs;

	private int _currentKey;

	public commonPlayerInfoMessageProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
		_configs = new Dictionary<int, string>();
		_configs[PlayerInfoStatusConstant.InLightBirthWarning.ID] = "/weapon/light_birth2/ui/warning";
		_configs[PlayerInfoStatusConstant.ENEMY_IN_SYMPHONY_SHIELD.ID] = "/weapon/ak47_symphony/ui/skillTips";
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool IsShow()
	{
		foreach (int key in _configs.Keys)
		{
			if (_playerContext.cameraOwnerEntity != null && _playerContext.cameraOwnerEntity.HasStatus(key))
			{
				_currentKey = key;
				return true;
			}
		}
		return false;
	}

	public string SetImage()
	{
		if (_currentKey > 0 && _configs.TryGetValue(_currentKey, out var value))
		{
			return value;
		}
		return "";
	}
}
