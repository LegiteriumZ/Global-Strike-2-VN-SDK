using System.Collections.Generic;
using System.Linq;
using Assets.Sources.Components.Time;
using Assets.Sources.Modules.Ui.UiEventCondition;
using NetData;
using NotifyEvent;

public class rpgModelBlackScreenProvider : IrpgModelBlackScreenProvider, IModuleProvider
{
	protected PlayerContext _playerEntity;

	private float showtime = 600f;

	private float currentTimer;

	private float notesTimer = -500f;

	private float showTimer = 1900f;

	private float startShowTime;

	public rpgModelBlackScreenProvider(Contexts contexts)
	{
		_playerEntity = contexts.player;
		NotifyManager.MakeNotifyClass(14, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent.Any((RpgTipsEventData t) => t.TypeId == -3080))
		{
			startShowTime = currentTimer;
		}
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool IsBlackScreenShow()
	{
		currentTimer = _playerEntity.myPlayerEntity.basicInfo.SnapsotServerTime;
		if (currentTimer - notesTimer <= showtime)
		{
			return true;
		}
		if (currentTimer - startShowTime > showTimer && currentTimer - startShowTime - showTimer < showtime)
		{
			notesTimer = currentTimer;
		}
		return false;
	}

	public float setBlackScreen()
	{
		return (currentTimer - notesTimer) / showtime + 0.1f;
	}
}
