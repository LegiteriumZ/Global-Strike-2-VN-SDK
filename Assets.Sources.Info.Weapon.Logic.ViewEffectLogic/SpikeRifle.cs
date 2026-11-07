using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class SpikeRifle : AbstractViewWeaponEffectLogic
{
	private TextureList _textureList;

	private const string WEAPON_EFFECT = "suogouchongsheng";

	private bool _show;

	private int _passTime;

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		int num = (currentWeapon.hasSpecial ? currentWeapon.special.EffectLevel : 0);
		BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		GetSkins(player)["weaponeffect21"].enabled = (num & 0x10) <= 0;
		if ((num & 0x10) > 0)
		{
			_show = true;
		}
		if ((num & 0x10) == 0 && _show)
		{
			if (!GetPaticleByParticleName(player, "suogouchongsheng").GetInsActiveState())
			{
				_passTime = player.clientTime.ClientTime + 1000;
				SetParticleActiveParticleName(player, "suogouchongsheng", flag: true);
			}
			if (_passTime - player.clientTime.ClientTime < 0)
			{
				_show = false;
			}
		}
		else
		{
			SetParticleActiveParticleName(player, "suogouchongsheng", flag: false);
		}
	}
}
