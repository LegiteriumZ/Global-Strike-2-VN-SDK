using Assets.Sources.Components.Time;
using share.constant;

public class bigHeadKnife2ModelBigHeadKnife2WeaponProvider : IbigHeadKnife2ModelBigHeadKnife2WeaponProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	public bigHeadKnife2ModelBigHeadKnife2WeaponProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public string SetCountTime(int index)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		float num = 0f;
		if (cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.CANNOT_CHANGE_WEAPON_IN_ONE_BAG.ID))
		{
			num = cameraOwnerEntity.skill.Status[PlayerInfoStatusConstant.CANNOT_CHANGE_WEAPON_IN_ONE_BAG.ID].Number - cameraOwnerEntity.basicInfo.SnapsotServerTime;
		}
		return ((int)num / 1000).ToString();
	}
}
