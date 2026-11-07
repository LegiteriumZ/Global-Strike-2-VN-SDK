using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Modules.Ui.Utils;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Extensions;
using SSJJBase.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.Rpg;

[GameUiTest]
public class RpgSelectMainModel : AbstractModel, IPlaybackSystem, IKeyboardResponder, ICursorControl
{
	private RpgSelectMainViewModel _viewModel;

	private Dictionary<int, UiReferences> _dict = new Dictionary<int, UiReferences>();

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public int GetForbidButtons()
	{
		return 0;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgSelectMainViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			SelectItemList selectNodeData_SelectItemList = UiIEventCondition.Get_SelectNodeData_SelectItemList();
			if (selectNodeData_SelectItemList != null)
			{
				UpdateSelectItem(null, selectNodeData_SelectItemList);
			}
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.RpgSelectMainShow = false;
		_viewModel.closebtnClicked.AddListener(CloseEvent);
		UiReferences uiReferences = _viewModel.UI.Get("cell").TryAddComponent<UiReferences>();
		uiReferences.name = "0";
		uiReferences.Get<Button>("cellbtn").TryAddComponent<UILisenter>().onPointerClick.Add(Click);
		_dict[0] = uiReferences;
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_rpgSkillStateData_Money, UpdatePrice, _viewModel.RpgSelectMainObj, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_SelectNodeData_SelectItemList_Visible, UpdateSelectVisible, _viewModel.RpgSelectMainObj, initinvoke: true);
	}

	protected override void OnGameobjectDestoryed()
	{
		base.OnGameobjectDestoryed();
		_viewModel.closebtnClicked.RemoveListener(CloseEvent);
		NotifyManager.Remove(_viewModel.RpgSelectMainObj);
		_dict.Clear();
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	private void Click(GameObject go, BaseEventData data)
	{
		if (int.TryParse(go.transform.parent.name, out var result))
		{
			SelectItemList selectNodeData_SelectItemList = UiIEventCondition.Get_SelectNodeData_SelectItemList();
			SelectClickIndex(result + 1, selectNodeData_SelectItemList);
		}
	}

	[GameTestFloatRange(new object[] { 1, -10000000, 10000000 })]
	[GameUiTestMethod]
	private void UpdatePrice(int old, int newprice)
	{
		newprice = Mathf.Abs(newprice);
		_viewModel.moneyinfoString = newprice.ToString();
	}

	[GameUiTestMethod]
	private void UpdateSelectItem(SelectItemList old, SelectItemList newitemlist)
	{
		if (newitemlist == null || newitemlist.ItemList == null)
		{
			return;
		}
		int count = _dict.Count;
		int num = ((newitemlist.ItemList != null) ? newitemlist.ItemList.Count : 0);
		for (int i = 0; i < num; i++)
		{
			UiReferences cellInstance = GetCellInstance(i);
			if ((bool)cellInstance)
			{
				cellInstance.SetObjectActive(isactive: true);
				UpdateItem(cellInstance, newitemlist.ItemList[i], i + 1);
			}
		}
		for (int j = num; j < count; j++)
		{
			UiReferences cellInstance2 = GetCellInstance(j);
			if ((bool)cellInstance2)
			{
				cellInstance2.SetObjectActive(isactive: false);
			}
		}
	}

	[GameUiTestMethod]
	private UiReferences GetCellInstance(int idx)
	{
		if (!_dict.TryGetValue(idx, out var value) && _dict.TryGetValue(0, out var value2))
		{
			GameObject gameObject = value2.gameObject.CreateInstance();
			gameObject.transform.SetParent(value2.transform.parent);
			value = gameObject.GetComponent<UiReferences>();
			value.Get<Button>("cellbtn").TryAddComponent<UILisenter>().onPointerClick.Add(Click);
			_dict.Add(idx, value);
		}
		value.name = idx.ToString();
		value.transform.SetObjectActive(isactive: true);
		return value;
	}

	private void UpdateItem(UiReferences ui, SelectItem item, int idx)
	{
		ui.Get<Text>("indextxt").text = idx.ToString();
		string name = item.Name;
		ui.Get<Text>("weaponname").text = name;
		Text text = ui.Get<Text>("moneytxt");
		if (item.Price != 0)
		{
			text.SetObjectActive(isactive: true);
			text.text = item.Price.ToString();
		}
		else
		{
			text.SetObjectActive(isactive: false);
		}
		Image img = ui.Get<Image>("cellback");
		base.Loader.RetriveSprite("ui/freerpg_110000model", $"Assets/Res/Assets/ui/GameGUIRes/freeRpg_110000Model/selectCells/{item.Icon}.png", img, autosetnative: true);
		float f = Time.timeSinceLevelLoad - UiIEventCondition.Get_selectNodeData_ReceivedtTime();
		int num = item.LockLeftTime - Mathf.RoundToInt(f);
		ui.Get<Image>("lockback").SetObjectActive(num > 0);
		Image comp = ui.Get<Image>("sellout");
		if (item.Locked)
		{
			comp.SetObjectActive(num <= 0);
		}
		else
		{
			comp.SetObjectActive(isactive: false);
		}
		Text text2 = ui.Get<Text>("downtime");
		if (num > 0)
		{
			text2.SetObjectActive(isactive: true);
			int num2 = num / 60;
			int num3 = num % 60;
			ui.Get<Text>("downrighttime").text = $"{num3 / 10}{num3 % 10}";
			text2.text = $"{num2 / 10}{num2 % 10}";
		}
		else
		{
			text2.SetObjectActive(isactive: false);
		}
	}

	[GameUiTestMethod]
	private void UpdateSelectVisible(bool old, bool newval)
	{
		_viewModel.RpgSelectMainShow = newval;
	}

	[GameUiTestMethod]
	private void CloseEvent()
	{
		_viewModel.RpgSelectMainShow = false;
		SelectItemList selectNodeData_SelectItemList = UiIEventCondition.Get_SelectNodeData_SelectItemList();
		if (selectNodeData_SelectItemList != null)
		{
			SelectClickEventHandler(selectNodeData_SelectItemList.Name, -1);
		}
	}

	[GameUiTestMethod]
	private void SelectClickIndex(int idx, SelectItemList itemlist)
	{
		int num = idx - 1;
		if (itemlist != null && itemlist.ItemList != null && itemlist.Visible && num < itemlist.ItemList.Count)
		{
			SelectItem selectItem = itemlist.ItemList[num];
			SelectClickEventHandler(itemlist.Name, selectItem.EventId);
		}
	}

	private void SelectClickEventHandler(int name, int id)
	{
		if (Contexts.sharedInstance.battleServer.hasBattleServer)
		{
			SelectClickEvent selectClickEvent = new SelectClickEvent();
			selectClickEvent.Name = name;
			selectClickEvent.EventId = id;
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(27, selectClickEvent);
		}
	}

	[GameTestFloatRange(new object[] { 0, -10, 500 })]
	[GameUiTestMethod]
	public bool OnKeyDown(KeyCode key)
	{
		if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 20000)
		{
			if (_viewModel.RpgSelectMainShow)
			{
				if (KeyCode.B == key)
				{
					CloseEvent();
				}
				else
				{
					int alphaOrKeypadDiff = key.GetAlphaOrKeypadDiff();
					if (alphaOrKeypadDiff >= 1 && alphaOrKeypadDiff <= 8)
					{
						SelectItemList selectNodeData_SelectItemList = UiIEventCondition.Get_SelectNodeData_SelectItemList();
						SelectClickIndex(alphaOrKeypadDiff, selectNodeData_SelectItemList);
					}
				}
			}
			return false;
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	public int GetCursorState()
	{
		if (!_viewModel.RpgSelectMainShow)
		{
			return 0;
		}
		return 1;
	}
}
