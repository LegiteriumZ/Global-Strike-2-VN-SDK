namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class GatlingDouRage2SceneWeaponRenderInfo : AbstractSceneWeaponInfo
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
		if (particle.Equals("qiangshen_1"))
		{
			return 0;
		}
		return 1;
	}
}
