using Assets.Sources.Components.Time;
using share.constant;

public class rpgModelSkatingMechaModelProvider : IrpgModelSkatingMechaModelProvider, IModuleProvider
{
	protected PlayerContext _playerEntity;

	public rpgModelSkatingMechaModelProvider(Contexts contexts)
	{
		_playerEntity = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float SetFuelValue()
	{
		return (float)_playerEntity.myPlayerEntity.basicInfo.Current.JijiaRanliao / (float)_playerEntity.myPlayerEntity.basicInfo.Current.JijiaMaxRanliao;
	}

	public bool IsSkatingMechaModelShow()
	{
		return _playerEntity.myPlayerEntity.HasStatus(PlayerInfoStatusConstant.jijiazhuangjia.ID);
	}
}
