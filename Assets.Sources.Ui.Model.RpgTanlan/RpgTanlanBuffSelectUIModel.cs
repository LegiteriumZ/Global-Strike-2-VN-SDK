using System;
using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.RpgTanlan;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.RpgTanlan;

[GameUiTest]
public class RpgTanlanBuffSelectUIModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, ISetBattleServerContext, ICursorControl
{
	private RpgTanlanBuffSelectUIViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private BattleServerContext _battleServer;

	private int _selectBuffId;

	private int _selectIndex;

	private int _myBuffSelectIndex = -1;

	private Transform lastSelectChildObj;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		if (context.hasRoomData)
		{
			_raceType = context.roomData.Data.RaceType;
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	protected override void FitToScreen(GameObject instance)
	{
		Canvas component = instance.GetComponent<Canvas>();
		if (null != component)
		{
			CanvasScaler canvasScaler = component.GetComponent<CanvasScaler>();
			if (null == canvasScaler)
			{
				canvasScaler = component.gameObject.AddComponent<CanvasScaler>();
			}
			canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
			canvasScaler.matchWidthOrHeight = 0f;
			canvasScaler.referenceResolution = new Vector2(1680f, 1050f);
		}
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgTanlanBuffSelectUIViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetALLItemChange, SetItems, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetWeightChange, SetWeight, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetSelectBuffChange, SetSelectBuff, null, initinvoke: true);
		_viewModel.btnContinueClicked.AddListener(OnContinue);
		_viewModel.btnRefreshClicked.AddListener(OnRefresh);
		_viewModel.btnReturnClicked.AddListener(onReturn);
		_viewModel.btnNextRewardRefreshClicked.AddListener(OnNextRewardRefresh);
	}

	private void OnContinue()
	{
		_battleServer.battleServer.Server.SendTcpMessage(165, _selectBuffId);
	}

	private void OnNextRewardRefresh()
	{
		if (_gameRuleContext.rpgTanlan.LeftDropCount > 0)
		{
			_battleServer.battleServer.Server.SendTcpMessage(167, _gameRuleContext.rpgTanlan.LeftDropCount);
		}
	}

	private void OnRefresh()
	{
		if (_gameRuleContext.rpgTanlan.CanRefreshBuffCount > 0)
		{
			_battleServer.battleServer.Server.SendTcpMessage(164, _gameRuleContext.rpgTanlan.CanRefreshBuffCount);
		}
	}

	private void onReturn()
	{
		_battleServer.battleServer.Server.SendTcpMessage(166);
	}

	private void onItemRefresh(ButtonClickDataEvent evt)
	{
		_battleServer.battleServer.Server.SendTcpMessage(163, new TanLanLockRequestData
		{
			ItemId = evt.data.Id,
			Locked = !evt.data.Locked
		});
	}

	private void onSelectItemClick(ButtonClickIntEvent evt)
	{
		if (_selectIndex != evt.index)
		{
			_selectIndex = evt.index;
			_selectBuffId = evt.data;
			updateSelectItemIcon();
		}
	}

	private void onSelectMyBuffItemClick(ButtonClickIntEvent evt)
	{
		if (_myBuffSelectIndex <= 0 || _myBuffSelectIndex != evt.index)
		{
			updateImgSelectPosition(show: true, evt.index);
			updateBuffTips(_gameRuleContext.rpgTanlan.CurBuffList[evt.index]);
		}
	}

	private void updateBuffTips(TanLanReadyBuffData data)
	{
		_viewModel.txtTipDescString = data.Desc;
	}

	private void updateImgSelectPosition(bool show, int selectIndex)
	{
		_viewModel.imgSelectShow = show;
		if (show)
		{
			Vector3 localPosition = _viewModel.myBuffContentObj.transform.GetChild(selectIndex).GetComponent<RectTransform>().localPosition;
			Vector3 imgSelectPosition = _viewModel.imgSelectPosition;
			imgSelectPosition = localPosition;
			_viewModel.imgSelectPosition = imgSelectPosition;
		}
		else
		{
			_myBuffSelectIndex = -1;
		}
	}

	private void SetSelectBuff(bool arg1, bool arg2)
	{
		if (arg2)
		{
			updateSelectItems();
		}
		_gameRuleContext.rpgTanlan.SelectBuffChange = false;
	}

	private bool GetSelectBuffChange()
	{
		return _gameRuleContext.rpgTanlan.SelectBuffChange;
	}

	private void SetWeight(bool arg1, bool arg2)
	{
		if (arg2)
		{
			_viewModel.txtTotalWeightString = _gameRuleContext.rpgTanlan.CurrentWeight + "/" + _gameRuleContext.rpgTanlan.TotalWeight;
		}
		_gameRuleContext.rpgTanlan.WeightChange = false;
	}

	private bool GetWeightChange()
	{
		return _gameRuleContext.rpgTanlan.WeightChange;
	}

	private void SetItems(bool arg1, bool arg2)
	{
		if (arg2)
		{
			updateNextRewardItems();
			updateAllItems();
		}
		_gameRuleContext.rpgTanlan.ItemChange = false;
	}

	private bool GetALLItemChange()
	{
		return _gameRuleContext.rpgTanlan.ItemChange;
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
		if (arg2)
		{
			_viewModel.imgLabelSuccessShow = _gameRuleContext.rpgTanlan.labelSuccessShow;
			updateMyBuffItems();
		}
	}

	private void updateSelectItemIcon()
	{
		Transform transform = null;
		Transform transform2 = null;
		Transform transform3 = null;
		if (lastSelectChildObj != null)
		{
			transform = lastSelectChildObj.Find("imgLabelSelect");
			transform2 = lastSelectChildObj.Find("icon0");
			transform3 = lastSelectChildObj.Find("greyIcon");
			updateActive(transform.gameObject, flag: true);
			updateActive(transform2.gameObject, flag: false);
			updateActive(transform3.gameObject, flag: true);
		}
		Transform child = _viewModel.selectBuffContentObj.transform.GetChild(_selectIndex);
		transform = child.Find("imgLabelSelect");
		transform2 = child.Find("icon0");
		transform3 = child.Find("greyIcon");
		updateActive(transform.gameObject, flag: false);
		updateActive(transform2.gameObject, flag: true);
		updateActive(transform3.gameObject, flag: false);
		updateImgSelectPosition(show: false, 0);
		updateBuffTips(_gameRuleContext.rpgTanlan.SelectBuffList[_selectIndex]);
		lastSelectChildObj = child;
	}

	private void updateIcon(GameObject obj, string url)
	{
		if (!(obj == null))
		{
			Image img = obj.GetComponent<Image>();
			this.GetLoader().RetriveSprite("ui/rpgtanlanmodel", "Assets/Res/Assets/" + url + ".png", delegate(Sprite sprite)
			{
				img.sprite = sprite;
			});
		}
	}

	private void updateText(GameObject obj, string msg)
	{
		if (!(obj == null))
		{
			Text component = obj.GetComponent<Text>();
			if (component != null)
			{
				component.text = msg;
			}
		}
	}

	private void updateActive(GameObject obj, bool flag)
	{
		if (!(obj == null))
		{
			obj.SetObjectActive(flag);
		}
	}

	private void updateContentHeight(GameObject obj, int itemCount)
	{
		GridLayoutGroup component = obj.GetComponent<GridLayoutGroup>();
		RectTransform component2 = obj.GetComponent<RectTransform>();
		if (component != null && component2 != null)
		{
			float y = (float)Mathf.CeilToInt((float)itemCount / (float)component.constraintCount) * (component.cellSize.y + component.spacing.y);
			component2.sizeDelta = new Vector2(component2.sizeDelta.x, y);
		}
		component2.anchoredPosition = Vector2.zero;
	}

	private void updateContentWidth(GameObject obj, int itemCount)
	{
		GridLayoutGroup component = obj.GetComponent<GridLayoutGroup>();
		RectTransform component2 = obj.GetComponent<RectTransform>();
		if (component != null && component2 != null)
		{
			float x = (float)itemCount * (component.cellSize.x + component.spacing.x);
			component2.sizeDelta = new Vector2(x, component2.sizeDelta.y);
		}
		component2.anchoredPosition = Vector2.zero;
	}

	private void updateAllItems()
	{
		List<TanLanReadyItemCellData> itemList = _gameRuleContext.rpgTanlan.ItemList;
		GameObject rewardContentObj = _viewModel.rewardContentObj;
		int childCount = rewardContentObj.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Transform child = rewardContentObj.transform.GetChild(i);
			updateActive(child.gameObject, flag: false);
		}
		for (int j = 0; j < itemList.Count; j++)
		{
			if (j >= rewardContentObj.transform.childCount)
			{
				Transform transform = UnityEngine.Object.Instantiate(rewardContentObj.transform.GetChild(0));
				transform.transform.parent = rewardContentObj.transform;
				transform.transform.localScale = Vector3.one;
			}
			Transform child2 = rewardContentObj.transform.GetChild(j);
			if (j >= itemList.Count)
			{
				continue;
			}
			updateActive(child2.gameObject, flag: true);
			TanLanReadyItemCellData tanLanReadyItemCellData = itemList[j];
			GameObject gameObject = child2.FindChild("icon0").gameObject;
			GameObject gameObject2 = child2.FindChild("itemBg").gameObject;
			GameObject gameObject3 = child2.FindChild("txtItemName0").gameObject;
			GameObject gameObject4 = child2.FindChild("txtWeight0").gameObject;
			GameObject gameObject5 = child2.FindChild("lock0").gameObject;
			updateIcon(gameObject, "ui/GameGUIRes/rpgTanlanModel/item/item_" + tanLanReadyItemCellData.Type + "_" + tanLanReadyItemCellData.Tid);
			updateIcon(gameObject2, "ui/GameGUIRes/rpgTanlanModel/UnityTexture/chip_grade_" + tanLanReadyItemCellData.Lv);
			updateText(gameObject3, tanLanReadyItemCellData.ItemName);
			updateText(gameObject4, tanLanReadyItemCellData.Weight.ToString());
			updateActive(gameObject5, tanLanReadyItemCellData.Locked);
			Transform transform2 = child2.FindChild("txtNum");
			if (transform2 != null)
			{
				updateText(transform2.gameObject, tanLanReadyItemCellData.Num.ToString());
			}
			Button component = child2.GetComponent<Button>();
			if (component != null)
			{
				component.onClick.RemoveAllListeners();
				ButtonClickDataEvent buttonClickEvent = new ButtonClickDataEvent(tanLanReadyItemCellData);
				component.onClick.AddListener(delegate
				{
					onItemRefresh(buttonClickEvent);
				});
			}
		}
		updateContentHeight(rewardContentObj, itemList.Count);
		_viewModel.txtNextRewardRefreshCountString = _gameRuleContext.rpgTanlan.LeftDropCount.ToString();
		_viewModel.btnNextRewardRefreshButtonable = _gameRuleContext.rpgTanlan.LeftDropCount > 0;
	}

	private void updateNextRewardItems()
	{
		List<TanLanReadyItemCellData> nextCanAwardList = _gameRuleContext.rpgTanlan.NextCanAwardList;
		GameObject nextRewardContentObj = _viewModel.nextRewardContentObj;
		int childCount = nextRewardContentObj.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Transform child = nextRewardContentObj.transform.GetChild(i);
			updateActive(child.gameObject, flag: false);
		}
		for (int j = 0; j < nextCanAwardList.Count; j++)
		{
			if (j >= nextRewardContentObj.transform.childCount)
			{
				Transform transform = UnityEngine.Object.Instantiate(nextRewardContentObj.transform.GetChild(0));
				transform.transform.parent = nextRewardContentObj.transform;
				transform.transform.localScale = Vector3.one;
			}
			Transform child2 = nextRewardContentObj.transform.GetChild(j);
			if (j < nextCanAwardList.Count)
			{
				updateActive(child2.gameObject, flag: true);
				TanLanReadyItemCellData tanLanReadyItemCellData = nextCanAwardList[j];
				GameObject gameObject = child2.FindChild("icon0").gameObject;
				GameObject gameObject2 = child2.FindChild("itemBg").gameObject;
				GameObject gameObject3 = child2.FindChild("txtItemName0").gameObject;
				GameObject gameObject4 = child2.FindChild("txtNum").gameObject;
				updateIcon(gameObject, "ui/GameGUIRes/rpgTanlanModel/item/item_" + tanLanReadyItemCellData.Type + "_" + tanLanReadyItemCellData.Tid);
				updateIcon(gameObject2, "ui/GameGUIRes/rpgTanlanModel/UnityTexture/chip_grade_" + tanLanReadyItemCellData.Lv);
				updateText(gameObject3, tanLanReadyItemCellData.ItemName);
				updateText(gameObject4, tanLanReadyItemCellData.Num.ToString());
			}
		}
		updateContentHeight(nextRewardContentObj, nextCanAwardList.Count);
	}

	private void updateMyBuffItems()
	{
		List<TanLanReadyBuffData> curBuffList = _gameRuleContext.rpgTanlan.CurBuffList;
		GameObject myBuffContentObj = _viewModel.myBuffContentObj;
		int childCount = myBuffContentObj.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Transform child = myBuffContentObj.transform.GetChild(i);
			updateActive(child.gameObject, flag: false);
		}
		for (int j = 0; j < curBuffList.Count; j++)
		{
			if (j >= myBuffContentObj.transform.childCount)
			{
				Transform transform = UnityEngine.Object.Instantiate(myBuffContentObj.transform.GetChild(0));
				transform.transform.parent = myBuffContentObj.transform;
				transform.transform.localScale = Vector3.one;
			}
			Transform child2 = myBuffContentObj.transform.GetChild(j);
			if (j >= curBuffList.Count)
			{
				continue;
			}
			updateActive(child2.gameObject, flag: true);
			TanLanReadyBuffData tanLanReadyBuffData = curBuffList[j];
			GameObject gameObject = child2.FindChild("icon0").gameObject;
			updateIcon(gameObject, "ui/GameGUIRes/rpgTanlanModel/item/buff_" + tanLanReadyBuffData.Tid);
			Button component = child2.GetComponent<Button>();
			if (component != null)
			{
				component.onClick.RemoveAllListeners();
				ButtonClickIntEvent buttonClickEvent = new ButtonClickIntEvent(tanLanReadyBuffData.Tid, j);
				component.onClick.AddListener(delegate
				{
					onSelectMyBuffItemClick(buttonClickEvent);
				});
			}
		}
	}

	private void updateSelectItems()
	{
		List<TanLanReadyBuffData> selectBuffList = _gameRuleContext.rpgTanlan.SelectBuffList;
		GameObject selectBuffContentObj = _viewModel.selectBuffContentObj;
		int childCount = selectBuffContentObj.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Transform child = selectBuffContentObj.transform.GetChild(i);
			updateActive(child.gameObject, flag: false);
		}
		for (int j = 0; j < selectBuffList.Count; j++)
		{
			if (j >= selectBuffContentObj.transform.childCount)
			{
				Transform transform = UnityEngine.Object.Instantiate(selectBuffContentObj.transform.GetChild(0));
				transform.transform.parent = selectBuffContentObj.transform;
				transform.transform.localScale = Vector3.one;
			}
			Transform child2 = selectBuffContentObj.transform.GetChild(j);
			if (j >= selectBuffList.Count)
			{
				continue;
			}
			updateActive(child2.gameObject, flag: true);
			TanLanReadyBuffData tanLanReadyBuffData = selectBuffList[j];
			GameObject gameObject = child2.FindChild("icon0").gameObject;
			GameObject gameObject2 = child2.FindChild("greyIcon").gameObject;
			GameObject gameObject3 = child2.FindChild("txtItemName0").gameObject;
			updateIcon(gameObject, "ui/GameGUIRes/rpgTanlanModel/item/buff_" + tanLanReadyBuffData.Tid);
			updateIcon(gameObject2, "ui/GameGUIRes/rpgTanlanModel/item/buff_" + tanLanReadyBuffData.Tid + "_grey");
			updateText(gameObject3, tanLanReadyBuffData.BuffName);
			Button component = child2.GetComponent<Button>();
			if (component != null)
			{
				component.onClick.RemoveAllListeners();
				ButtonClickIntEvent buttonClickEvent = new ButtonClickIntEvent(tanLanReadyBuffData.Tid, j);
				component.onClick.AddListener(delegate
				{
					onSelectItemClick(buttonClickEvent);
				});
			}
		}
		_viewModel.txtRefreshCountString = string.Concat(_gameRuleContext.rpgTanlan.CanRefreshBuffCount);
		_viewModel.btnRefreshButtonable = _gameRuleContext.rpgTanlan.CanRefreshBuffCount > 0;
		_selectIndex = 0;
		if (selectBuffList.Count > 0)
		{
			_selectBuffId = selectBuffList[0].Tid;
		}
		updateSelectItemIcon();
		updateContentWidth(selectBuffContentObj, selectBuffList.Count);
	}

	private bool GetVisible()
	{
		return _gameRuleContext.rpgTanlan.IsUIShow;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
		if (_gameRuleContext.rpgTanlan.IsUIShow)
		{
			int num = Math.Max(_gameRuleContext.rpgTanlan.UIEndServerTime - time.ServerTime, 0);
			_viewModel.txtTimeDownString = string.Concat(num / 1000);
		}
	}

	public void SetBattleServerContext(BattleServerContext context)
	{
		_battleServer = context;
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowShow)
		{
			return 0;
		}
		return 16;
	}

	public int GetForbidButtons()
	{
		return 0;
	}
}
