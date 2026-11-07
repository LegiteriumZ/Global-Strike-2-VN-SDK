namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class SkyDomeBeaconRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		SetParticleVisalbeByName(entity, "qiangshentexiao_Lv0_shouqi", flag: false);
		SetParticleVisalbeByName(entity, "qiangshentexiao_Lv1_shouqi", flag: false);
		SetParticleVisalbeByName(entity, "qiangshentexiao_Lv2_shouqi", flag: false);
	}
}
