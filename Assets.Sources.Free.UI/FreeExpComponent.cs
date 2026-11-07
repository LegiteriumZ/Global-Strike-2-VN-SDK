using System.Collections.Generic;
using Assets.Sources.Free.Data;
using Assets.Sources.Free.Render;
using Assets.Sources.Free.Utility;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Free.UI;

public class FreeExpComponent : FreeBaseComponent
{
	protected IUiObject observerPlayerBackImage;

	protected List<IUiObject> observerPlayerName = new List<IUiObject>();

	protected IUiObject profitBackImage;

	protected IUiObject totalExpSprite;

	protected IUiObject totalExpPerSprite;

	protected IUiObject totalGpSprite;

	protected IUiObject totalGpPerSprite;

	protected IUiObject totalCrystalSprite;

	protected List<IUiObject> expImageList;

	protected List<IUiObject> expSpriteList;

	protected List<IUiObject> gpImageList;

	protected List<IUiObject> gpSpriteList;

	private List<string> expUrlList;

	private List<string> gpUrlList;

	protected const int ObserverPlayerH = 3;

	protected const int ObserverPlayerV = 5;

	private ProfitModelWrapper _profitData;

	private bool _moved;

	private AllObserverNameData allObserverNameData;

	public FreeExpComponent()
	{
		base.Type = 6;
		base.ValueType = 2;
		AssetInfoDirs = new Dictionary<string, AssetInfo>();
		GameObject gameObject = new GameObject("Exp");
		gameObject.AddComponent<RectTransform>();
		gameObject.AddComponent<CanvasRenderer>();
		UnityObject = new UnityUiObject(gameObject);
		UnityObject.GameObject.transform.SetParent(MonoBehaviourSingleton<FreeUiManager>.Instance.GetTemplateParent());
	}

	private void IniOb()
	{
		observerPlayerBackImage = UnityUiUtility.CreateImageDisplayObject(GetAssetInfoGenImageUrl(GetCommonUrl("observerPlayer/allKillInfoObserverPlayerBack.atf")), 700, 84);
		UnityObject.AddChild(observerPlayerBackImage);
		observerPlayerBackImage.PosX = 73f;
		observerPlayerBackImage.PosY = 0f;
		int num = 0;
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				IUiObject uiObject = UnityUiUtility.CreateEmptyDisplayObject();
				UnityObject.AddChild(uiObject);
				observerPlayerName.Add(uiObject);
				uiObject.PosX = observerPlayerBackImage.PosX + 15f + (float)(j * 130);
				uiObject.PosY = observerPlayerBackImage.PosY + 20f + (float)(i * 20);
				uiObject.ActiveVisible = false;
				num++;
			}
		}
	}

	private void IniExp()
	{
		profitBackImage = UnityUiUtility.CreateImageDisplayObject(GetAssetInfoGenImageUrl(GetCommonUrl("killList/profitback.atf")), 845, 142);
		UnityObject.AddChild(profitBackImage);
		profitBackImage.PosX = 0f;
		profitBackImage.PosY = 0f;
		profitBackImage.ActiveVisible = false;
		totalExpSprite = UnityUiUtility.CreateEmptyDisplayObject();
		UnityObject.AddChild(totalExpSprite);
		totalExpSprite.PosX = profitBackImage.PosX + 110f;
		totalExpSprite.PosY = profitBackImage.PosY + 47f;
		totalExpSprite.ActiveVisible = false;
		totalExpPerSprite = UnityUiUtility.CreateEmptyDisplayObject();
		UnityObject.AddChild(totalExpPerSprite);
		totalExpPerSprite.PosX = totalExpSprite.PosX + 80f;
		totalExpPerSprite.PosY = totalExpSprite.PosY + 3f;
		totalExpPerSprite.ActiveVisible = false;
		totalGpSprite = UnityUiUtility.CreateEmptyDisplayObject();
		UnityObject.AddChild(totalGpSprite);
		totalGpSprite.PosX = totalExpSprite.PosX + 325f;
		totalGpSprite.PosY = profitBackImage.PosY + 45f;
		totalGpSprite.ActiveVisible = false;
		totalGpPerSprite = UnityUiUtility.CreateEmptyDisplayObject();
		UnityObject.AddChild(totalGpPerSprite);
		totalGpPerSprite.PosX = totalGpSprite.PosX + 82f;
		totalGpPerSprite.PosY = totalGpSprite.PosY + 3f;
		totalGpPerSprite.ActiveVisible = false;
		totalCrystalSprite = UnityUiUtility.CreateEmptyDisplayObject();
		UnityObject.AddChild(totalCrystalSprite);
		totalCrystalSprite.PosX = profitBackImage.PosX + 770f;
		totalCrystalSprite.PosY = profitBackImage.PosY + 76f;
		totalCrystalSprite.ActiveVisible = false;
		totalExpSprite.AddChild(UnityUiUtility.CreateNumberTextDisplayObject(120));
		totalExpPerSprite.AddChild(UnityUiUtility.CreateNumberTextDisplayObject(130));
		totalGpSprite.AddChild(UnityUiUtility.CreateNumberTextDisplayObject(120));
		totalGpPerSprite.AddChild(UnityUiUtility.CreateNumberTextDisplayObject(130));
		totalCrystalSprite.AddChild(UnityUiUtility.CreateNumberTextDisplayObject(120));
		expImageList = new List<IUiObject>();
		expSpriteList = new List<IUiObject>();
		for (int i = 0; i < 7; i++)
		{
			IUiObject uiObject = UnityUiUtility.CreateImageDisplayObject(GetAssetInfoGenImageUrl(GetCommonUrl("killList/honorary.atf")), 48, 49);
			uiObject.GameObject.name = uiObject.GameObject.name + "_" + i;
			expImageList.Add(uiObject);
			UnityObject.AddChild(uiObject);
			uiObject.PosX = profitBackImage.PosX + 50f + (float)((uiObject.Width + 10) * i);
			uiObject.PosY = profitBackImage.PosY + 85f;
			uiObject.ActiveVisible = false;
			IUiObject uiObject2 = UnityUiUtility.CreateEmptyDisplayObject();
			expSpriteList.Add(uiObject2);
			UnityObject.AddChild(uiObject2);
			uiObject2.PosX = uiObject.PosX + 2f;
			uiObject2.PosY = uiObject.PosY + 35f;
			uiObject2.ActiveVisible = false;
			uiObject2.AddChild(UnityUiUtility.CreateNumberTextDisplayObject(140));
		}
		gpImageList = new List<IUiObject>();
		gpSpriteList = new List<IUiObject>();
		for (int j = 0; j < 4; j++)
		{
			IUiObject uiObject3 = UnityUiUtility.CreateImageDisplayObject(GetAssetInfoGenImageUrl(GetCommonUrl("killList/honorary.atf")), 48, 49);
			uiObject3.GameObject.name = uiObject3.GameObject.name + "_" + j;
			gpImageList.Add(uiObject3);
			UnityObject.AddChild(uiObject3);
			uiObject3.PosX = profitBackImage.PosX + 420f + (float)((uiObject3.Width + 10) * j);
			uiObject3.PosY = profitBackImage.PosY + 85f;
			uiObject3.ActiveVisible = false;
			IUiObject uiObject4 = UnityUiUtility.CreateEmptyDisplayObject();
			uiObject3.GameObject.name = uiObject3.GameObject.name + "_" + j;
			gpSpriteList.Add(uiObject4);
			UnityObject.AddChild(uiObject4);
			uiObject4.PosX = uiObject3.PosX + 2f;
			uiObject4.PosY = uiObject3.PosY + 35f;
			uiObject4.ActiveVisible = false;
			uiObject4.AddChild(UnityUiUtility.CreateNumberTextDisplayObject(140));
		}
		expUrlList = new List<string>();
		expUrlList.Add("killList/honorary.atf");
		expUrlList.Add("killList/heroweapon.atf");
		expUrlList.Add("killList/bigexp.atf");
		expUrlList.Add("killList/smallexp.atf");
		expUrlList.Add("killList/friend.atf");
		expUrlList.Add("killList/accessory.atf");
		expUrlList.Add("vip/expvip.atf");
		gpUrlList = new List<string>();
		gpUrlList.Add("killList/honorary.atf");
		gpUrlList.Add("killList/heroweapon.atf");
		gpUrlList.Add("killList/biggp.atf");
		gpUrlList.Add("killList/smallgp.atf");
	}

	private string GetExpImageUrl(string url)
	{
		if ("vip/expvip.atf" == url)
		{
			Dictionary<string, int> vipLevels = Contexts.sharedInstance.battleRoom.playerInfo.VipLevels;
			int num = 1;
			if (Contexts.sharedInstance.player.isCameraOwner)
			{
				string playerName = Contexts.sharedInstance.player.cameraOwnerEntity.basicInfo.PlayerName;
				foreach (KeyValuePair<string, int> item in vipLevels)
				{
					if (playerName == item.Key)
					{
						num = item.Value;
					}
				}
			}
			return GetCommonUrl("vip/expvip" + num + ".atf");
		}
		return GetCommonUrl(url);
	}

	private string GetCommonUrl(string url)
	{
		return "common/" + url;
	}

	public override void Frame(IUIDataManager uiDataManager, int frameTime, IComponentGroup gGroup)
	{
		base.Frame(uiDataManager, frameTime, gGroup);
		SetProfitData();
		SetObserverPlayerNameData(uiDataManager);
	}

	public override IFreeComponent Clone()
	{
		return new FreeExpComponent();
	}

	public override void Initial(params object[] ini)
	{
		IniOb();
		IniExp();
	}

	public override void SetPos(IComponentGroup freeUI, float x, float y, int width, int heigth, int relative, int parent, bool isInWorld = true)
	{
		base.SetPos(freeUI, x, y, width, heigth, relative, parent, isInWorld);
		UnityObject.Width = 845;
		UnityObject.Height = 142;
	}

	private void MoveObserverImageToProfitImageBottom()
	{
		if (_moved)
		{
			return;
		}
		_moved = true;
		observerPlayerBackImage.PosY = profitBackImage.PosY + (float)profitBackImage.Height;
		int num = 0;
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				observerPlayerName[num].PosY = (int)(observerPlayerBackImage.PosY + 20f + (float)(i * 20));
				num++;
			}
		}
	}

	protected void SetObserverPlayerNameData(IUIDataManager uiDataManager)
	{
		allObserverNameData = uiDataManager.AllObserverNameData;
		if (allObserverNameData.Changed)
		{
			allObserverNameData.Changed = false;
			int count = allObserverNameData.NameList.Count;
			if (count > 0)
			{
				observerPlayerBackImage.ActiveVisible = true;
			}
			else
			{
				observerPlayerBackImage.ActiveVisible = false;
			}
			for (int i = 0; i < count && i <= 15; i++)
			{
				UnityUiUtility.SetTexture(observerPlayerName[i], GetAssetInfoGenImageUrl(allObserverNameData.NameList[i]), 48, 49);
				observerPlayerName[i].ActiveVisible = true;
			}
			count = observerPlayerName.Count;
			for (int j = 0; j < count; j++)
			{
				observerPlayerName[j].ActiveVisible = false;
			}
		}
	}

	private void SetProfitData()
	{
		BattleModel gameModel = GameModelLocator.GetInstance().GameModel;
		if (!gameModel.IsObserver && !(UnityObject.GameObject.transform.parent == null) && UnityObject.ActiveVisible)
		{
			_profitData = gameModel.ProfitModel;
			if (_profitData.changed)
			{
				_profitData.changed = false;
				ShowProfitImage();
				HideProfitImage();
				MoveObserverImageToProfitImageBottom();
				UpdateTotalExpImage();
				UpdateTotalGpImage();
				UpdateTotalCrystalImage();
				UpdateExpImage();
				UpdateGpImage();
			}
		}
	}

	private void UpdateGpImage()
	{
		int count = _profitData.gpPlusList.Count;
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			if (_profitData.gpPlusList[i] > 0)
			{
				gpImageList[num].ActiveVisible = true;
				UnityUiUtility.SetTexture(gpImageList[num], GetAssetInfoGenImageUrl(GetExpImageUrl(gpUrlList[i])), 48, 49);
				gpSpriteList[num].ActiveVisible = true;
				SetNumber(gpSpriteList[num], _profitData.gpPlusList[i]);
				num++;
			}
		}
	}

	private void UpdateExpImage()
	{
		int count = _profitData.expPlusList.Count;
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			if (_profitData.expPlusList[i] > 0)
			{
				expImageList[num].ActiveVisible = true;
				UnityUiUtility.SetTexture(expImageList[num], GetAssetInfoGenImageUrl(GetExpImageUrl(expUrlList[i])), 48, 49);
				expSpriteList[num].ActiveVisible = true;
				SetNumber(expSpriteList[num], _profitData.expPlusList[i]);
				num++;
			}
		}
	}

	private void UpdateTotalGpImage()
	{
		SetNumber(totalGpSprite, _profitData.totalGp);
		SetNumber(totalGpPerSprite, _profitData.totalGpPer);
	}

	private void UpdateTotalExpImage()
	{
		SetNumber(totalExpSprite, _profitData.totalExp);
		SetNumber(totalExpPerSprite, _profitData.totalExpPer);
	}

	private void UpdateTotalCrystalImage()
	{
		SetNumber(totalCrystalSprite, _profitData.totalCrystal);
	}

	private void ShowProfitImage()
	{
		profitBackImage.ActiveVisible = true;
		totalExpSprite.ActiveVisible = true;
		totalExpPerSprite.ActiveVisible = true;
		totalGpSprite.ActiveVisible = true;
		totalGpPerSprite.ActiveVisible = true;
		totalCrystalSprite.ActiveVisible = true;
	}

	private void HideProfitImage()
	{
		int num = 0;
		for (num = 0; num < expImageList.Count; num++)
		{
			expImageList[num].ActiveVisible = false;
			expSpriteList[num].ActiveVisible = false;
		}
		for (num = 0; num < gpImageList.Count; num++)
		{
			gpImageList[num].ActiveVisible = false;
			gpSpriteList[num].ActiveVisible = false;
		}
	}

	protected override void SetPureValue(string vale)
	{
	}
}
