using Assets.Scripts.Utility.Sound;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using NetData;
using SSJJBase.Logger;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class MissionSuccessDataHandler : ApcPacketHandler<StringData>
{
	private BattleRoomContext _battleRoomContext;

	private PlayerContext _playerContext;

	public MissionSuccessDataHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_playerContext = contexts.player;
	}

	public override int MethodId()
	{
		return 18;
	}

	public override void Handle(StringData data)
	{
		this.Info("Receive SuccessHandle !");
		_battleRoomContext.gameOver.IsWin = true;
		if (data != null)
		{
			_battleRoomContext.gameOver.WinnerName = data.Data;
		}
		_battleRoomContext.gameOver.IsGameOver = true;
		_battleRoomContext.gameOver.IsGameOverDataChange = true;
		if (!_battleRoomContext.hasRoomData)
		{
			return;
		}
		bool flag = true;
		if (RuleUtilty.IsBioMode(_battleRoomContext.roomData.Data.RaceType) && _playerContext.isMyPlayer)
		{
			string career = _playerContext.myPlayerEntity.basicInfo.Current.Career;
			if (PlayerCareerConstantUtility.IsDoun(career) || PlayerCareerConstantUtility.IsEmpress(career))
			{
				flag = false;
			}
		}
		MonoBehaviourSingleton<AutoSoundManager>.Instance.OnAutoSound((!flag) ? AutoSoundEventType.Lose : AutoSoundEventType.Win);
	}
}
