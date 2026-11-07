using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using share.constant;

namespace Assets.Sources.Info.SkillProgress.Visiable;

public class DeformationVisiable : IVisiable
{
	public bool IsModeShow(WeaponSkillTable.Row config, BattleRoomEntity battleRoom)
	{
		return true;
	}

	public int Visiable(WeaponContext weaponContext, PlayerEntity player, WeaponSkillTable.Row config, TimeComponent time, int raceType)
	{
		if (player == null || !player.HasStatus(PlayerInfoStatusConstant.WANGGUAN_ON.ID))
		{
			return 0;
		}
		return 1;
	}
}
