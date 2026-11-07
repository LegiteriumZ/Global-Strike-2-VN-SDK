using Assets.Res.Assets.Scripts;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class SpikeRifle : AbstractThirdWeaponEffectLogic
{
	private TextureList _textureList;

	private const string WEAPON_EFFECT = "suogouchongsheng";

	private bool _show;

	private int _passTime;

	public override void Update(PlayerEntity player, int raceType)
	{
		int currentWeaponEffectLevel = player.GetCurrentWeaponEffectLevel();
		GetSkins(player)["weaponeffect21"].enabled = (currentWeaponEffectLevel & 0x10) <= 0;
		if ((currentWeaponEffectLevel & 0x10) > 0)
		{
			_show = true;
		}
		if ((currentWeaponEffectLevel & 0x10) == 0 && _show)
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
