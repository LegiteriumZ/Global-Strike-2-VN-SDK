using Assets.Generated.Table;
using Assets.Sources.Components.Interface.Info.GameRule;
using Assets.Sources.Constant;
using Assets.Sources.Info.GameRule;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.Timer;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class StartNewSectionHandler : ApcPacketHandler<TimeData>
{
	private readonly BattleRoomContext _battleRoomContext;

	private readonly PlayerContext _playerContext;

	private readonly TimeContext _timeContext;

	private readonly GameRuleContext _gameRuleContext;

	public StartNewSectionHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_playerContext = contexts.player;
		_timeContext = contexts.time;
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 13;
	}

	public override void Handle(TimeData data)
	{
		if (data.Time == 0)
		{
			return;
		}
		long num = TimeUtility.UnixTimeNow();
		_battleRoomContext.sectionTime.SectionStartTimeClient = num - (_battleRoomContext.roomData.Data.SectionTime - data.Time);
		IGameRule gameRule = GameRuleFactory.Instance.GetGameRule(_battleRoomContext.roomData.Data.RaceType);
		if (gameRule != null && _playerContext.isMyPlayer && _battleRoomContext.roomData.Data.SectionTime == data.Time)
		{
			AssetInfo startGameSound = gameRule.GetStartGameSound(_playerContext.myPlayerEntity.basicInfo.Current.Team);
			if (!string.IsNullOrEmpty(startGameSound.BundleName))
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, startGameSound, GameSoundManager.Config.AsideVolume);
			}
		}
		UnloadSign.CheckUnload(UnityEngine.Time.realtimeSinceStartup);
		if (_timeContext.commonTimer.CommonTimer != null && !_timeContext.commonTimer.CommonTimer.ContainsKey("ACG_GAME_TIMER"))
		{
			SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "ACG_GAME_TIMER", new SSJJTimer(data.Time));
		}
		if (RuleUtilty.IsBioUnion(_battleRoomContext.roomData.Data.RaceType))
		{
			_gameRuleContext.bioUnionBaseData.SelectPlayerPanelShow = false;
			_gameRuleContext.bioUnionBaseData.SelectTeamPanelShow = false;
		}
	}
}
