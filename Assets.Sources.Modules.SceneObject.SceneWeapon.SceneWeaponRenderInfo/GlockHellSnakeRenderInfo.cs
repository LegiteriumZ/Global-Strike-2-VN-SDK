namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class GlockHellSnakeRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		SetParticleVisalbeByName(entity, "qiangshen_hong", flag: true);
		SetParticleVisalbeByName(entity, "qiangshen_zi", flag: true);
	}
}
