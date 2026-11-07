namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class ColaGrenadeSceneWeaponRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		int level = entity.sceneWeapon.Current.Level;
		SetParticleVisalbeByName(entity, "kele_qi1", (level & 1) > 0);
		SetParticleVisalbeByName(entity, "kele_qi2", (level & 2) > 0);
		SetParticleVisalbeByName(entity, "kele_qi3", (level & 4) > 0);
	}
}
