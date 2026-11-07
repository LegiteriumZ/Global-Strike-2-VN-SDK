using Assets.Sources.Components.Time;
using share.constant;

public class rpgModelNezhaNengliangProvider : IrpgModelNezhaNengliangProvider, IModuleProvider
{
	private PlayerContext _playerContext;

	public rpgModelNezhaNengliangProvider(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool isShow()
	{
		if (_playerContext.cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.NE_ZHA_NENG_LIANG_DOU.ID))
		{
			return true;
		}
		if (_playerContext.cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.NE_ZHA_NENG_LIANG_DOU_USED.ID))
		{
			return true;
		}
		return false;
	}

	public bool isDouShow(int index)
	{
		if (_playerContext.cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.NE_ZHA_NENG_LIANG_DOU.ID))
		{
			return index < _playerContext.cameraOwnerEntity.skill.Status[PlayerInfoStatusConstant.NE_ZHA_NENG_LIANG_DOU.ID].Number;
		}
		return false;
	}

	public bool isDouuseShow(int index)
	{
		if (_playerContext.cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.NE_ZHA_NENG_LIANG_DOU_USED.ID))
		{
			return index < _playerContext.cameraOwnerEntity.skill.Status[PlayerInfoStatusConstant.NE_ZHA_NENG_LIANG_DOU_USED.ID].Number;
		}
		return false;
	}

	public bool isDou1Show()
	{
		return isDouShow(0);
	}

	public bool isDou2Show()
	{
		return isDouShow(1);
	}

	public bool isDou3Show()
	{
		return isDouShow(2);
	}

	public bool isDouuse1Show()
	{
		return isDouuseShow(0);
	}

	public bool isDouuse2Show()
	{
		return isDouuseShow(1);
	}

	public bool isDouuse3Show()
	{
		return isDouuseShow(2);
	}
}
