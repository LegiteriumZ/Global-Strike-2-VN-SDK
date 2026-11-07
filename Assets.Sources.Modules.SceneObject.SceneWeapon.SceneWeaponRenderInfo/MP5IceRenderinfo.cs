namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class MP5IceRenderinfo : AbstractSceneWeaponInfo
{
	private const string FIRE_EFFECT = "QiangKouHuoHua";

	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		SetParticleVisalbeByName(entity, "QiangKouHuoHua", flag: false);
	}
}
