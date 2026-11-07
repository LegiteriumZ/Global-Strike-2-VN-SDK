using System.Collections.Generic;
using Assets.Sources.Components.Common;
using Assets.Sources.Framework;
using Entitas;
using I2.Loc;
using SSJJAsset.Asset;

namespace Assets.Sources.Modules.SceneObject.MoveObject;

public class MoveObjectDrawMapImageSystem : IPlaybackSystem
{
	private readonly IGroup<SceneObjectEntity> _group;

	private readonly PlayerContext _playerContext;

	private static readonly Dictionary<string, AssetInfo> MapAssetDic = new Dictionary<string, AssetInfo>
	{
		{
			"wurenji_blue",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/wurenji_blue.png")
		},
		{
			"wurenji_white",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/wurenji_white.png")
		},
		{
			"RPG_SURVIVALPVP_BUFF_1",
			new AssetInfo("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/rader/buff.png")
		},
		{
			"TREASUREBOSS_NORMALBOSSAREA",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/bossArea_yellow.png")
		},
		{
			"TREASUREBOSS_NORMALBOSSAREA_small",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/bossArea_yellow_small.png")
		},
		{
			"TREASUREBOSS_CBTBOSSAREA",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/bossArea_red.png")
		},
		{
			"TREASUREBOSS_CBTBOSSAREA_small",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/bossArea_red_small.png")
		},
		{
			"TREASUREBOSS_BOX_FLAG",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/boxTrans.png")
		},
		{
			"GUOFENG_BAOXIANG_LV1",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/map_box0.png")
		},
		{
			"GUOFENG_BAOXIANG_LV2",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/map_box0.png")
		},
		{
			"GUOFENG_BAOXIANG_LV3",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/map_box1.png")
		},
		{
			"GUOFENG_BAOXIANG_LV4",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/map_box1.png")
		},
		{
			"GUOFENG_BAOXIANG_LV1_QUAN",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/map_boxbg1.png")
		},
		{
			"GUOFENG_BAOXIANG_LV2_QUAN",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/map_boxbg2.png")
		},
		{
			"GUOFENG_BAOXIANG_LV3_QUAN",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/map_boxbg3.png")
		},
		{
			"GUOFENG_BAOXIANG_LV4_QUAN",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/map_boxbg4.png")
		},
		{
			"CYBER_ESCAPE_AREA",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/extractionpoint.png")
		},
		{
			"TAN_LAN_SHOU_JI_XIANG_NAME",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/map_box1.png")
		},
		{
			"STAR_WALKER_BOX_RED",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/boxRed.png")
		},
		{
			"STAR_WALKER_BOX_YELLOW",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/boxYellow.png")
		},
		{
			"STAR_WALKER_BOSS",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/iconBoss.png")
		},
		{
			"STAR_WALKER_EXIT",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/iconExit.png")
		},
		{
			"STAR_WALKER_GREEN_MINI",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/missionGreen.png")
		},
		{
			"STAR_WALKER_BLUE_MINI",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/missionBlue.png")
		},
		{
			"STAR_WALKER_GOLD_MINI",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/missionGold.png")
		},
		{
			"STAR_WALKER_RED_MINI",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/missionRed.png")
		},
		{
			"STAR_WALKER_GREY",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/protectGrey.png")
		},
		{
			"STAR_WALKER_GREEN",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/protectGreen.png")
		},
		{
			"STAR_WALKER_BLUE",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/protectBlue.png")
		},
		{
			"STAR_WALKER_GOLD",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/protectGold.png")
		},
		{
			"STAR_WALKER_RED",
			new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/protectRed.png")
		}
	};

	public MoveObjectDrawMapImageSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.MoveObject).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlayback()
	{
		if (!_playerContext.isCameraOwner)
		{
			return;
		}
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		int team = cameraOwnerEntity.basicInfo.Current.Team;
		float viewYaw = cameraOwnerEntity.basicInfo.Current.ViewYaw;
		foreach (SceneObjectEntity item in _group)
		{
			string name = item.moveObject.Current.Name;
			if (item.moveObject.Current.Name == "RPG_SURVIVALPVP_BUFF_1")
			{
				DrawMapImage(item, MapAssetDic["RPG_SURVIVALPVP_BUFF_1"], MapAssetDic["RPG_SURVIVALPVP_BUFF_1"], viewYaw, rotationSelf: true);
				continue;
			}
			if (item.moveObject.Current.Name == "TREASUREBOSS_NORMALBOSSAREA" || item.moveObject.Current.Name == "TREASUREBOSS_CBTBOSSAREA")
			{
				DrawMapImage(item, MapAssetDic[item.moveObject.Current.Name + "_small"], MapAssetDic[item.moveObject.Current.Name], 0f, rotationSelf: false, hideHpAndName: true);
				continue;
			}
			if (item.moveObject.Current.Name == "TREASUREBOSS_BOX_FLAG")
			{
				DrawMapImage(item, MapAssetDic[item.moveObject.Current.Name], MapAssetDic[item.moveObject.Current.Name], 0f, rotationSelf: false, hideHpAndName: true);
				continue;
			}
			if (item.moveObject.Current.Name == "GUOFENG_BAOXIANG_LV1_QUAN" || item.moveObject.Current.Name == "GUOFENG_BAOXIANG_LV2_QUAN" || item.moveObject.Current.Name == "GUOFENG_BAOXIANG_LV3_QUAN" || item.moveObject.Current.Name == "GUOFENG_BAOXIANG_LV4_QUAN")
			{
				DrawMapImage(item, MapAssetDic[item.moveObject.Current.Name], MapAssetDic[item.moveObject.Current.Name], 0f, rotationSelf: false, hideHpAndName: true, showNamw: false, "", item.moveObject.Current.Scale, 7);
				continue;
			}
			if (item.moveObject.Current.Name == "CYBER_ESCAPE_AREA")
			{
				DrawMapImage(item, MapAssetDic[item.moveObject.Current.Name], MapAssetDic[item.moveObject.Current.Name], 0f, rotationSelf: false, hideHpAndName: true, showNamw: true, ScriptLocalization.Get("Extraction"));
				continue;
			}
			if (item.moveObject.Current.Name == "TAN_LAN_SHOU_JI_XIANG_NAME")
			{
				DrawMapImage(item, MapAssetDic[item.moveObject.Current.Name], MapAssetDic[item.moveObject.Current.Name], 0f, rotationSelf: false, hideHpAndName: true, showNamw: false, ScriptLocalization.Get("Extraction"));
				continue;
			}
			switch (name)
			{
			case "STAR_WALKER_BOX_RED":
			case "STAR_WALKER_BOX_YELLOW":
			case "STAR_WALKER_BOSS":
			case "STAR_WALKER_EXIT":
			case "STAR_WALKER_GREY":
			case "STAR_WALKER_GREEN":
			case "STAR_WALKER_BLUE":
			case "STAR_WALKER_GOLD":
			case "STAR_WALKER_RED":
			{
				int num;
				switch (name)
				{
				default:
					num = ((name == "STAR_WALKER_RED") ? 1 : 0);
					break;
				case "STAR_WALKER_GREEN":
				case "STAR_WALKER_BLUE":
				case "STAR_WALKER_GOLD":
					num = 1;
					break;
				}
				bool flag = (byte)num != 0;
				DrawMapImage(item, MapAssetDic[item.moveObject.Current.Name + (flag ? "_MINI" : "")], MapAssetDic[item.moveObject.Current.Name], 0f, rotationSelf: false, hideHpAndName: true, showNamw: false, ScriptLocalization.Get("Extraction"));
				continue;
			}
			}
			if (item.moveObject.Current.Team == team && (item.moveObject.Current.Name == "black_crow" || item.moveObject.Current.Name == "uav"))
			{
				if (item.moveObject.Current.Cid == cameraOwnerEntity.basicInfo.Cid)
				{
					DrawMapImage(item, MapAssetDic["wurenji_blue"], MapAssetDic["wurenji_blue"], item.moveObject.Current.Yaw - 90f, rotationSelf: false);
				}
				else
				{
					DrawMapImage(item, MapAssetDic["wurenji_white"], MapAssetDic["wurenji_white"], item.moveObject.Current.Yaw - 90f, rotationSelf: false);
				}
			}
		}
	}

	private void DrawMapImage(SceneObjectEntity entity, AssetInfo radarAssetInfo, AssetInfo smallMapAssetInfo, float rotation, bool rotationSelf, bool hideHpAndName = false, bool showNamw = false, string name = "", float size = 1f, int mask = 0)
	{
		if (!entity.hasSmallMapImage)
		{
			entity.AddComponent(13, new SmallMapImageComponent());
		}
		SmallMapImageComponent smallMapImage = entity.smallMapImage;
		smallMapImage.SmallMapImage = smallMapAssetInfo;
		smallMapImage.RadarImage = radarAssetInfo;
		smallMapImage.Position = entity.position.Origin;
		smallMapImage.Rotation = rotation;
		smallMapImage.AddRotateSelfInRadar = rotationSelf;
		smallMapImage.ScaleX = ((mask == 7) ? (size / 2f) : 1f);
		smallMapImage.ScaleY = ((mask == 7) ? (size / 2f) : 1f);
		smallMapImage.Alpha = 1f;
		smallMapImage.Mask = mask;
		smallMapImage.Name = (string.IsNullOrEmpty(name) ? entity.moveObject.Current.Name : name);
		smallMapImage.IsHideNameAndHp = hideHpAndName;
		smallMapImage.IsShowName = showNamw;
	}
}
