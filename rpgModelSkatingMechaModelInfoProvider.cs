using Assets.Sources.Components.Time;
using share.constant;

public class rpgModelSkatingMechaModelInfoProvider : IrpgModelSkatingMechaModelInfoProvider, IModuleProvider
{
	protected PlayerContext _playerEntity;

	public rpgModelSkatingMechaModelInfoProvider(Contexts contexts)
	{
		_playerEntity = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float SetHpValue()
	{
		return (float)_playerEntity.myPlayerEntity.basicInfo.Current.JijiaHp / (float)_playerEntity.myPlayerEntity.basicInfo.Current.JijiaMaxHp;
	}

	public string SetRanliaoValue()
	{
		return _playerEntity.myPlayerEntity.basicInfo.Current.JijiaHp.ToString();
	}

	public bool IsSkatingMechaModelShow()
	{
		return _playerEntity.myPlayerEntity.HasStatus(PlayerInfoStatusConstant.jijiazhuangjia.ID);
	}
}
