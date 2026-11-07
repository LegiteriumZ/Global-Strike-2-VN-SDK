namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class DeagleStrikeSceneRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		if (Func == null)
		{
			Func = GetEffect1Flag;
		}
		SetParticleActiveBySkinName(entity, Func);
	}

	private int GetEffect1Flag(SceneObjectEntity entity, string skin, string particle)
	{
		if (particle == "11920_qiangshen")
		{
			return 1;
		}
		return 0;
	}
}
