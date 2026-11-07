namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class RandomKingSceneWeaponRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		entity.unityObjects.LoadResults["WeaponModel"].GameObject.SetObjectActive(isactive: false);
	}
}
