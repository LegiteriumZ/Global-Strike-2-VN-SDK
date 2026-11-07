using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Ui.UiEditorRunTime;

public class UiEditorDestorySystem : IEntityPreDestroySystem
{
	private readonly IGroup<SceneObjectEntity> _group;

	private readonly WeaponContext _weapon;

	public UiEditorDestorySystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.WeaponUiUnityObjects));
		_weapon = contexts.weapon;
	}

	public void OnEntityPreDestroy()
	{
		WeaponEntity currentWeaponEntity = _weapon.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasBasicInfo || currentWeaponEntity.basicInfo.Info == null)
		{
			return;
		}
		IEntitsWeaponInfo info = currentWeaponEntity.basicInfo.Info;
		foreach (SceneObjectEntity item in _group)
		{
			if (!item.weaponUiUnityObjects.WeaponName.Equals(info.Name))
			{
				if (item.weaponUiUnityObjects.LayoutAsset != null)
				{
					item.weaponUiUnityObjects.LayoutAsset.Collect();
				}
				item.RemoveWeaponUiUnityObjects();
			}
		}
	}
}
