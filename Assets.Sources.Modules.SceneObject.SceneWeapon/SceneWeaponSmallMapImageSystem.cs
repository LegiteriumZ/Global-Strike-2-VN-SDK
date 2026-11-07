using Assets.Sources.Components.Common;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Entitas;
using NetData;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon;

public class SceneWeaponSmallMapImageSystem : IPlaybackSystem
{
	private IGroup<SceneObjectEntity> _group;

	private GameRuleContext _gameRuleContext;

	private static AssetInfo _c4iconAsset = new AssetInfo("ui/blastmodel", "Assets/Res/Assets/ui/GameGUIRes/blastModel/map/c4icon.png");

	private static AssetInfo _c4dropiconAsset = new AssetInfo("ui/blastmodel", "Assets/Res/Assets/ui/GameGUIRes/blastModel/map/c4dropicon.png");

	public SceneWeaponSmallMapImageSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.SceneWeapon);
		_gameRuleContext = contexts.gameRule;
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			if (!item.hasSmallMapImage)
			{
				item.AddComponent(13, new SmallMapImageComponent());
			}
			SceneWeaponEntityData current2 = item.sceneWeapon.Current;
			item.smallMapImage.Position = new Vector3(current2.X, current2.Y, current2.Z);
			item.smallMapImage.ScaleX = 1f;
			item.smallMapImage.ScaleY = 1f;
			item.smallMapImage.Alpha = 1f;
			AssetInfo assetInfo = default(AssetInfo);
			if (current2.WeaponName == "c4" && UiIEventCondition.Get_cameraOwnerData_Team() == 1)
			{
				assetInfo = ((!_gameRuleContext.hasC4State || !_gameRuleContext.c4State.Active) ? _c4dropiconAsset : _c4iconAsset);
			}
			item.smallMapImage.SmallMapImage = assetInfo;
			item.smallMapImage.RadarImage = assetInfo;
		}
	}
}
