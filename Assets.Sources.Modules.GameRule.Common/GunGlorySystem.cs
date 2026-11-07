using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using NotifyEvent;

namespace Assets.Sources.Modules.GameRule.Common;

public class GunGlorySystem : IGameRulePlaybackSystem, IPlaybackSystem, IGameRuleResetSystem, IEntityPreDestroySystem
{
	private GameRuleContext _gameRuleContext;

	private TimeComponent _timeComponent;

	public GunGlorySystem(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeComponent = contexts.time.time;
	}

	public void OnPlayback()
	{
		if (_gameRuleContext.gunGlory.GunGloryDelayShow > 0)
		{
			_gameRuleContext.gunGlory.GunGloryDelayShow -= _timeComponent.FrameInterval;
			if (_gameRuleContext.gunGlory.GunGloryDelayShow <= 0 && _gameRuleContext.gunGlory.GunGloryList.Count > 0)
			{
				NotifyManager.ForceInvoke(40);
			}
		}
	}

	public bool NeedStart(Contexts contexts)
	{
		return true;
	}

	public void OnEntityPreDestroy()
	{
		if (_gameRuleContext.gunGlory.GunGloryDelayShow <= 0)
		{
			_gameRuleContext.gunGlory.GunGloryList.Clear();
		}
	}
}
