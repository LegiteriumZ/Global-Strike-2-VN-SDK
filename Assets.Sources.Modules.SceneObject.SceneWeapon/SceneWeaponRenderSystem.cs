using Assets.Sources.Framework;
using Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;
using Entitas;
using SSJJMath;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon;

public class SceneWeaponRenderSystem : IRenderSystem
{
	private readonly IGroup<SceneObjectEntity> _sceneWeapons;

	public SceneWeaponRenderSystem(Contexts contexts)
	{
		_sceneWeapons = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SceneWeapon, SceneObjectMatcher.UnityObjects, SceneObjectMatcher.Position, SceneObjectMatcher.Orientation));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity sceneWeapon in _sceneWeapons)
		{
			VectorCoordConverter.SsjjToUnity(sceneWeapon.position.Origin, out var dest);
			SceneWeaponRenderFactory.Instance.GetRenderInfo(sceneWeapon.sceneWeapon.Current.WeaponName, sceneWeapon.sceneWeapon.Current.WeaponType).Render(sceneWeapon);
			if (sceneWeapon.hasWeaponEffectResource)
			{
				sceneWeapon.weaponEffectResource.LoadResults[0].GameObject.transform.position = dest;
			}
		}
	}
}
