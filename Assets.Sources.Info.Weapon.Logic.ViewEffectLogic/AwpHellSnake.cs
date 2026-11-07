using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Weapon.Attach;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class AwpHellSnake : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		IPaticlePrefabInstancecs paticleBySkinName = GetPaticleBySkinName(player, "weapon_dummy_particle_effect1");
		AwpHellSnakeAttach awpHellSnakeAttach = currentWeapon.attach.Data as AwpHellSnakeAttach;
		if (paticleBySkinName == null || awpHellSnakeAttach == null)
		{
			return;
		}
		if (currentWeapon.special.EffectLevel <= awpHellSnakeAttach.OriginalEffectLevel)
		{
			awpHellSnakeAttach.OriginalEffectLevel = currentWeapon.special.EffectLevel;
			if (!awpHellSnakeAttach.IsReset)
			{
				paticleBySkinName.Stop();
				paticleBySkinName.SetInsActive(flag: false);
			}
			else if (paticleBySkinName.IsStoped())
			{
				awpHellSnakeAttach.IsReset = false;
			}
		}
		else
		{
			paticleBySkinName.SetInsActive(flag: true);
			paticleBySkinName.Restart();
			awpHellSnakeAttach.OriginalEffectLevel = currentWeapon.special.EffectLevel;
			awpHellSnakeAttach.IsReset = true;
		}
	}
}
