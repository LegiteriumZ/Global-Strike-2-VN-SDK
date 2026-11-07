using UnityEngine;

public class spirits_sword2_WeaponExtraDefineProvider : spirits_sword1_WeaponExtraDefineProvider
{
	private PlayerContext playerContext;

	public override void Init(Contexts contexts)
	{
		base.Init(contexts);
		_keyInfo = "spirits_sword2";
	}

	public override string updateFlashImg()
	{
		return "/weapon/spirits_sword2/ui/flash_" + Mathf.Min(textureIndex, textureTotalNum - 2);
	}
}
