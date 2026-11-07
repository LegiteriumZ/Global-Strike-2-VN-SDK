using System.Collections.Generic;
using Assets.Sources.Framework;
using Entitas;
using share.constant;

namespace Assets.Sources.Modules.Player.Effect;

public class HideWeaponSystem : IPreRenderSystem
{
	private IGroup<PlayerEntity> _group;

	private readonly List<int> _noWeaponAnimStateIds = new List<int>
	{
		82, 97, 105, 145, 164, 152, 154, 159, 146, 147,
		165, 166, 197, 213, 219, 225, 214, 220, 226, 215,
		221, 227, 354, 370, 372
	};

	private readonly List<int> _noWeaponTorseAnimStateIds = new List<int> { 313, 355 };

	public HideWeaponSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.ThirdPersonUnityObjects);
	}

	public void OnPreRender()
	{
		foreach (PlayerEntity item in _group)
		{
			bool flag = false;
			if (item.hasSkill)
			{
				flag = item.skill.Status.ContainsKey(PlayerInfoStatusConstant.NO_ATTACH_WEAPON.ID);
				if (!flag)
				{
					flag = item.skill.Status.ContainsKey(PlayerInfoStatusConstant.HideWeapon.ID);
				}
			}
			if (!flag)
			{
				if (item.hasLegAnim && item.legAnim.LegsAnimInfo != null)
				{
					flag = _noWeaponAnimStateIds.Contains(item.legAnim.LegsAnimInfo.StateId);
				}
				if (!flag && item.hasTorseAnim && item.torseAnim.TorsoAnimInfo != null)
				{
					flag = _noWeaponTorseAnimStateIds.Contains(item.torseAnim.TorsoAnimInfo.StateId);
				}
			}
			if (!flag && item.HasStatus(PlayerInfoStatusConstant.PLAYER_KICKING_P3.ID))
			{
				flag = true;
			}
			bool flag2 = !item.hasVisiable || item.visiable.IsVisiable || item.visiable.IsNear;
			item.isHideWeapon = flag || !flag2;
		}
	}
}
