namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class GearMouseRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		int level = entity.sceneWeapon.Current.Level;
		UpdateModelVisible(entity);
		if (level >= 0)
		{
			UpdateModelVisible(entity, flag: false);
		}
	}
}
