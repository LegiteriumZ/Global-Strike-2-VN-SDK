using Assets.Libs.UiEditor.RunTime;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Framework;
using Assets.Sources.Info.Weapon;
using Entitas;
using SSJJAnim.Weapon;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJUIEditor.UI;

namespace Assets.Sources.Modules.Ui.UiEditorRunTime;

public class UiEditorLoadSystem : LoadAndInitResourceSystem<SceneObjectEntity>
{
	private IGroup<SceneObjectEntity> _loadGroup;

	private IGroup<SceneObjectEntity> _initGroup;

	private PlayerContext _player;

	private WeaponContext _weapon;

	public UiEditorLoadSystem(Contexts contexts)
	{
		_loadGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.MyWeaponEditorUi).NoneOf(SceneObjectMatcher.WeaponUiUnityObjects, SceneObjectMatcher.LoadWeaonUiResource, SceneObjectMatcher.WeaponUiResource, SceneObjectMatcher.Destroy));
		_initGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.MyWeaponEditorUi, SceneObjectMatcher.WeaponUiResource).NoneOf(SceneObjectMatcher.WeaponUiUnityObjects, SceneObjectMatcher.Destroy));
		_weapon = contexts.weapon;
		_player = contexts.player;
	}

	protected override IGroup<SceneObjectEntity> GetLoadGroup()
	{
		return _loadGroup;
	}

	protected override IGroup<SceneObjectEntity> GetInitGroup()
	{
		return _initGroup;
	}

	protected override void OnLoadEntityResource(SceneObjectEntity entity)
	{
		WeaponEntity currentWeaponEntity = _weapon.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasBasicInfo && currentWeaponEntity.basicInfo.Info != null)
		{
			IEntitsWeaponInfo info = currentWeaponEntity.basicInfo.Info;
			LoadRequests loadRequests = new LoadRequests();
			loadRequests.AddAsset("WeaponUiLayout", new AssetInfo(info.AssetBundleName, info.WeaponLayoutAssetName, typeof(UiEditorLayoutAsset), optional: true));
			loadRequests.AddAsset("WeaponUiLogic", new AssetInfo(info.AssetBundleName, info.WeaponLogicAssetName, typeof(UiEditorLogicAsset), optional: true));
			RunTimeBindingManager.Instance.Refresh(info.Name);
			entity.myWeaponEditorUi.WeaponName = info.Name;
			entity.AddLoadWeaonUiResource(loadRequests, info);
		}
	}

	protected override bool IsResourceMatch(SceneObjectEntity entity)
	{
		return WeaponInfoFactory.Instance.GetWeaponInfo(entity.myWeaponEditorUi.WeaponName) == (IWeaponInfo)entity.weaponUiResource.Identifier;
	}

	protected override void CleanResouceComponent(SceneObjectEntity entity)
	{
		entity.RemoveWeaponUiResource();
	}

	protected override void OnInitEntityResource(SceneObjectEntity entity)
	{
		LoadResults loadResults = entity.weaponUiResource.LoadResults;
		UiEditorLayoutAsset uiEditorLayoutAsset = null;
		if (loadResults.ContainsKey("WeaponUiLayout"))
		{
			uiEditorLayoutAsset = UiEditorLayoutAssetResultUtil.GetUiEditorLayoutAsset(loadResults["WeaponUiLayout"]);
			uiEditorLayoutAsset.GetGameObject().SetObjectActive(isactive: true);
			uiEditorLayoutAsset.GetGameObject().transform.SetParent(MonoBehaviourSingleton<UiEditorParentManager>.Instance.Parent.transform, worldPositionStays: false);
		}
		UiEditorLogicAsset newLogicAsset = null;
		if (loadResults.ContainsKey("WeaponUiLogic"))
		{
			newLogicAsset = loadResults["WeaponUiLogic"].Object as UiEditorLogicAsset;
		}
		entity.AddWeaponUiUnityObjects(uiEditorLayoutAsset, newLogicAsset, entity.myWeaponEditorUi.WeaponName);
	}
}
