using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Time;
using share.constant;

public class yuetu_WeaponExtraDefineProvider : Abstractyuetu_WeaponExtraDefineProvider
{
	private readonly int remainTime = 10000;

	private readonly int maxCount = 5;

	public override void OnFrame(TimeComponent time)
	{
	}

	public override float updateCountProgress()
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity != null)
		{
			PlayerInfoComponent.StatusDes value = null;
			if (_battleRoomContext.playerInfo.StatusDatas.ContainsKey(myPlayerEntity.GetCharacterId()))
			{
				_battleRoomContext.playerInfo.StatusDatas[myPlayerEntity.GetCharacterId()].TryGetValue(PlayerInfoStatusConstant.YUETU_CARROT_NUM.ID, out value);
			}
			if (value != null)
			{
				return (float)value.Number / (float)maxCount;
			}
		}
		return 0f;
	}

	public override float updateTimeProgress()
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity != null)
		{
			PlayerInfoComponent.StatusDes value = null;
			if (_battleRoomContext.playerInfo.StatusDatas.ContainsKey(myPlayerEntity.GetCharacterId()))
			{
				_battleRoomContext.playerInfo.StatusDatas[myPlayerEntity.GetCharacterId()].TryGetValue(PlayerInfoStatusConstant.YUETU_CARROT_RELIVE_TIME.ID, out value);
			}
			if (value != null)
			{
				int number = value.Number;
				int serverTime = _timeContext.time.ServerTime;
				int num = number - serverTime;
				if (num < 0)
				{
					num = 0;
				}
				return 1f - (float)num / (float)remainTime;
			}
		}
		return 0f;
	}

	public override string updateTxtCount()
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity != null)
		{
			PlayerInfoComponent.StatusDes value = null;
			if (_battleRoomContext.playerInfo.StatusDatas.ContainsKey(myPlayerEntity.GetCharacterId()))
			{
				_battleRoomContext.playerInfo.StatusDatas[myPlayerEntity.GetCharacterId()].TryGetValue(PlayerInfoStatusConstant.YUETU_CARROT_NUM.ID, out value);
			}
			if (value != null)
			{
				return "x" + value.Number;
			}
		}
		return "";
	}
}
