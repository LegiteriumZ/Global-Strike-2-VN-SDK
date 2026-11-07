using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using Assets.Sources.CsvLoader;
using Assets.Sources.Utils.Timer;

public class commonPlayerInfoSkillMessageProvider : IcommonPlayerInfoSkillMessageProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	protected TimeContext _timeContext;

	private List<PlayerInfoSkillTable.Row> _configs;

	private PlayerInfoSkillTable.Row _config;

	private ISSJJTimer _timer;

	private int _currentTime;

	private bool _statusChanged;

	private string _lastCareer;

	public commonPlayerInfoSkillMessageProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
		_timeContext = contexts.time;
		_configs = PlayerInfoSkillLoader.Instance.Table.GetRowList();
	}

	public void OnFrame(TimeComponent time)
	{
		if (_config != null)
		{
			if ((_config.StartProgress && _statusChanged) || (_playerContext.cameraOwnerEntity != null && _lastCareer != _playerContext.cameraOwnerEntity.basicInfo.Current.Career))
			{
				_timer = SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, _config.Message, new SSJJTimer(_config.Time));
				_statusChanged = false;
				_currentTime = 0;
			}
			if (!_config.StartProgress && _statusChanged)
			{
				_timer = null;
				_currentTime = _config.Time;
			}
			if (_config.Up)
			{
				_currentTime += time.FrameInterval;
			}
			else
			{
				_currentTime -= time.FrameInterval;
			}
			if (_currentTime <= 0)
			{
				_config = null;
			}
			_lastCareer = _playerContext.cameraOwnerEntity.basicInfo.Current.Career;
		}
	}

	public float SetMessagePosX()
	{
		if (_config == null)
		{
			return 0f;
		}
		return _config.MessagePosX;
	}

	public string SetImage()
	{
		if (_config == null || _config.Message == "")
		{
			return "/ui/GameGUIRes/common/default";
		}
		return _config.Message;
	}

	public float SetMessagePosY()
	{
		if (_config == null)
		{
			return 0f;
		}
		return -_config.MessagePosY;
	}

	public float SetPBackPosX()
	{
		if (_config == null)
		{
			return 0f;
		}
		return _config.PBackPosX;
	}

	public string SetPBackImage()
	{
		if (_config == null)
		{
			return "";
		}
		return _config.ProgressBack;
	}

	public float SetPBackPosY()
	{
		if (_config == null)
		{
			return 0f;
		}
		return -_config.PBackPosY;
	}

	public float SetPBarPosX()
	{
		if (_config == null)
		{
			return 0f;
		}
		return _config.PBarPosX;
	}

	public string SetPBarImage()
	{
		if (_config == null)
		{
			return "";
		}
		return _config.ProgressBar;
	}

	public float SetPBarPosY()
	{
		if (_config == null)
		{
			return 0f;
		}
		return -_config.PBarPosY;
	}

	public float SetProgress()
	{
		if (_config == null)
		{
			return 0f;
		}
		return (float)_currentTime / (float)_config.Time;
	}

	public bool IsProgressShow()
	{
		if (_config == null)
		{
			return false;
		}
		return _config.ProgressBack != "";
	}

	public bool IsShow()
	{
		if (_playerContext.cameraOwnerEntity == null)
		{
			return false;
		}
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		foreach (PlayerInfoSkillTable.Row config in _configs)
		{
			if (cameraOwnerEntity.HasStatus(config.PlayerInfoId))
			{
				_statusChanged = _config != config;
				_config = config;
				return _currentTime > 0;
			}
		}
		return false;
	}
}
