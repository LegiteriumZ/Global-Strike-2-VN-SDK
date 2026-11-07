namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class RifleOpticorSceneWeaponRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		if (Func == null)
		{
			Func = SetEffectFlag;
		}
		SetParticleActiveBySkinName(entity, Func);
	}

	private int SetEffectFlag(SceneObjectEntity entity, string join, string particle)
	{
		if ((particle.Equals("1_shengpan_qiang") || particle.Equals("ciyuanhuanying_qiangshen")) && join.Equals("weapon_particle_effect1"))
		{
			return 1;
		}
		return 0;
	}
}
