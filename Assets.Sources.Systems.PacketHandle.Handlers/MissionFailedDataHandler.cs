using Assets.Scripts.Utility.Sound;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using SSJJBase.Logger;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class MissionFailedDataHandler : ApcPacketHandler<object>
{
	private readonly BattleRoomContext _battleRoomContext;

	private readonly PlayerContext _playerContext;

	public MissionFailedDataHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_playerContext = contexts.player;
	}

	public override int MethodId()
	{
		return 19;
	}

	public override void Handle(object data)
	{
		this.Info("Receive FailedHandle !");
		_battleRoomContext.gameOver.IsWin = false;
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
		MonoBehaviourSingleton<AutoSoundManager>.Instance.OnAutoSound(flag ? AutoSoundEventType.Lose : AutoSoundEventType.Win);
	}
}
