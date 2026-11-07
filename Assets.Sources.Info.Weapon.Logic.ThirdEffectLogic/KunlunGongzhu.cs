using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class KunlunGongzhu : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		if (player.thirdPersonUnityObjects.AllPlayerTransforms.TryGetValue("Bone_yu_01", out var value))
		{
			if (player.HasPlayerInfo(PlayerInfoStatusConstant.KUNLUNGONGZHU_SHIFT_USING.ID))
			{
				updateTransformScale(value, 1f);
			}
			else
			{
				updateTransformScale(value, 0.001f);
			}
		}
	}

	private void updateTransformScale(Transform trans, float scaleNum)
	{
		Vector3 localScale = trans.localScale;
		localScale.Set(scaleNum, scaleNum, scaleNum);
		trans.localScale = localScale;
	}
}
