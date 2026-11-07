namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class M4A1LegendRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		SetParticleVisalbeByName(entity, "11852_jinjieshanguang", flag: false);
		SetParticleVisalbeByName(entity, "11852_ci_effect2", flag: false);
		GetPaticleByParticleName(entity, "11852_daoren_effect3").SetInsScale(0.5f);
	}
}
