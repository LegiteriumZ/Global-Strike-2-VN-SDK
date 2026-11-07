using System;
using System.Collections.Generic;
using Assets.Sources.Modules.Common;
using Entitas;

namespace Assets.Sources.Modules.SceneObject;

public class SceneObjectContextResourceInfo : IContextResourceInfo, IContextDestroyInfo, IContextCommonInfo, IContextLifeTimeInfo
{
	private readonly IGroup<SceneObjectEntity> _loadResourceEntities;

	private readonly IGroup<SceneObjectEntity> _destroyEntities;

	private readonly IGroup<SceneObjectEntity> _lifeTimeEntities;

	private readonly int[] _loadComponentIds = new int[15]
	{
		66, 57, 56, 64, 60, 68, 62, 55, 65, 61,
		58, 59, 44, 67, 63
	};

	private readonly int[] _unityComponentIds = new int[15]
	{
		136, 36, 34, 130, 52, 139, 98, 23, 133, 89,
		38, 39, 46, 140, 116
	};

	private readonly Type[] _componentTypes = SceneObjectComponentsLookup.componentTypes;

	public int[] LoadComponentIds => _loadComponentIds;

	public int[] UnityComponentIds => _unityComponentIds;

	public int LifeTimeComponentId => 5;

	public List<IEntity> LifeTimeEntities => _lifeTimeEntities.GetEntities();

	public Type[] ComponentTypes => _componentTypes;

	public string[] ComponentNames => SceneObjectComponentsLookup.componentNames;

	public List<IEntity> LoadResourceEntities => _loadResourceEntities.GetEntities();

	public int DestroyComponentId => 1;

	public List<IEntity> DestoryEntities => _destroyEntities.GetEntities();

	public SceneObjectContextResourceInfo(Contexts contexts)
	{
		_loadResourceEntities = contexts.sceneObject.GetGroup(SceneObjectMatcher.AnyOf(SceneObjectMatcher.LoadUnityObjects, SceneObjectMatcher.LoadEffectObjects, SceneObjectMatcher.LoadEffectConfig, SceneObjectMatcher.LoadSkyboxResource, SceneObjectMatcher.LoadLightMapResource, SceneObjectMatcher.LoadWeaponEffectResource, SceneObjectMatcher.LoadNpcResource, SceneObjectMatcher.LoadBaseEventResource, SceneObjectMatcher.LoadSparyResource, SceneObjectMatcher.LoadNeedLoadResource, SceneObjectMatcher.LoadExtend1Resource, SceneObjectMatcher.LoadExtend2Resource, SceneObjectMatcher.HangEffectLoad, SceneObjectMatcher.LoadWeaonUiResource, SceneObjectMatcher.LoadRuleUiResource));
		_destroyEntities = contexts.sceneObject.GetGroup(SceneObjectMatcher.AnyOf(SceneObjectMatcher.Destroy));
		_lifeTimeEntities = contexts.sceneObject.GetGroup(SceneObjectMatcher.AnyOf(SceneObjectMatcher.LifeTime));
	}
}
