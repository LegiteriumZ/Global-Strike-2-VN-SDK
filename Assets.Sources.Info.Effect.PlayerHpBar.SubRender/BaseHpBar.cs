using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface.Info.GameRule;
using Assets.Sources.Modules.Ui;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.UiFramework.Libs;
using NetData;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class BaseHpBar : IHpBarRender
{
	public static Dictionary<AssetInfo, Sprite> SpriteDic = new Dictionary<AssetInfo, Sprite>();

	public static int MyTeam;

	public static PlayerEntity CameraOwner;

	public static int FrameTime;

	public int RaceType;

	public string FreeType;

	public UiResourcesLoader Loader;

	public UnityEngine.Camera MainCamera;

	public PlayerHpBarRender HpBar;

	public float ScreenScale;

	public PlayerEntity PlayerEntity;

	public PlayerEntityData PlayerData;

	public GameObject EffectGameObject;

	public Transform Tran;

	public IGameRule GameRule;

	public BattleRoomContext battleContext;

	public GameRuleContext gameRuleContext;

	public bool SameCameraTeam;

	public virtual void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		HpBar = hpBar;
		PlayerEntity = playerEntity;
		PlayerData = playerEntity.basicInfo.Current;
		EffectGameObject = effectGameObject;
		GameRule = contexts.gameRule.currentRule.Rule;
		MainCamera = contexts.worldCamera.unityObjects.mainCamera;
		ScreenScale = FaceToCamera.GetScreenScale();
		Tran = effectGameObject.transform;
		Loader = (UiResourcesLoader)AbstractModel.GetUiResourceLoader();
		RaceType = contexts.battleRoom.roomData.Data.RaceType;
		FreeType = contexts.battleRoom.roomData.Data.FreeType;
		battleContext = contexts.battleRoom;
		gameRuleContext = contexts.gameRule;
	}

	public static void Render(PlayerEntity cameraOwner, int frameTime)
	{
		MyTeam = UiIEventCondition.Get_uiMyPlayer_Team();
		CameraOwner = cameraOwner;
		FrameTime = frameTime;
	}

	public virtual void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		PlayerEntity = playerEntity;
		PlayerData = playerEntity.basicInfo.Current;
		SameCameraTeam = UiIEventCondition.Get_cameraOwnerData_Team() == PlayerData.Team;
	}

	public void SetActive(GameObject obj, ref bool lastActive, bool newActive, bool force = false)
	{
		if (newActive != lastActive || force)
		{
			obj.SetObjectActive(newActive);
			lastActive = newActive;
		}
	}

	public void SetPosition(Transform tran, ref Vector3 lastPos, Vector3 newPos)
	{
		if (lastPos != newPos)
		{
			tran.localPosition = newPos;
			lastPos = newPos;
		}
	}

	public Sprite SaveSprite(AssetInfo asset, Sprite sprite)
	{
		if (!SpriteDic.ContainsKey(asset))
		{
			SpriteDic[asset] = sprite;
		}
		return SpriteDic[asset];
	}

	protected int GetDistance(PlayerEntity player)
	{
		return (int)(Vector3.Distance(UiIEventCondition.Get_cameraOwnerData_Position(), player.GetCompenstatePos(player.fpos.Change.GetPosIndex())) * 0.01f);
	}
}
