using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Ultimatechallenge2Model;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.Ultimatechallenge2Model;

[GameUiTest]
public class Ultimatechallenge2BackpackModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, ISetPlayerContext, ICursorControl
{
	private Ultimatechallenge2BackpackViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private Stack<Ultimatechallenge2Backpack_itemModel> item_pool;

	private List<Ultimatechallenge2Backpack_itemModel> near_item;

	private List<Ultimatechallenge2Backpack_itemModel> default_item;

	private PlayerContext _playerContext;

	private RectTransform ScrollView_BackPack;

	private RectTransform ScrollView_Nearby;

	private List<RectTransform> weapon_Rect;

	private RectTransform Content_BackPack;

	private RectTransform Content_Nearby;

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

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Ultimatechallenge2BackpackViewModel();
		item_pool = new Stack<Ultimatechallenge2Backpack_itemModel>();
		default_item = new List<Ultimatechallenge2Backpack_itemModel>();
		near_item = new List<Ultimatechallenge2Backpack_itemModel>();
	}

	public Ultimatechallenge2Backpack_itemModel GetBackpackItem(Transform parent)
	{
		Ultimatechallenge2Backpack_itemModel ultimatechallenge2Backpack_itemModel;
		if (item_pool.Count > 0)
		{
			ultimatechallenge2Backpack_itemModel = item_pool.Pop();
		}
		else
		{
			ultimatechallenge2Backpack_itemModel = new Ultimatechallenge2Backpack_itemModel(ScrollView_BackPack, ScrollView_Nearby, weapon_Rect, Content_BackPack, Content_Nearby, _viewModel.PanelObj);
			ultimatechallenge2Backpack_itemModel.Initialize();
		}
		ultimatechallenge2Backpack_itemModel.Parent = parent;
		ultimatechallenge2Backpack_itemModel.Show = true;
		return ultimatechallenge2Backpack_itemModel;
	}

	public void PushBackpackItem(Ultimatechallenge2Backpack_itemModel item)
	{
		item.Show = false;
		item_pool.Push(item);
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
			if (Input.GetKeyDown(KeyCode.Tab) && Contexts.sharedInstance.message.ultimatechallenge2.gameStage > 0)
			{
				_viewModel.backpackShow = !_viewModel.backpackShow;
			}
			Input.GetKeyDown(KeyCode.BackQuote);
			if (Input.GetKeyUp(KeyCode.F) && Contexts.sharedInstance.message.ultimatechallenge2.gameStage == 0)
			{
				_viewModel.skillShow = !_viewModel.skillShow;
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotifyClass(118, GetMessageList, SetTipsEvent, initinvoke: true);
		for (int j = 0; j < 6; j++)
		{
			int i = j;
			_viewModel.SetButtonTriggers(j + 1, new List<EventTrigger.Entry>
			{
				new EventTrigger.Entry
				{
					eventID = EventTriggerType.PointerDown,
					callback = new EventTrigger.TriggerEvent()
				}
			});
			_viewModel.GetButtonTriggers(j + 1)[0].callback.AddListener(delegate
			{
				if (i + 1 <= 3)
				{
					Contexts.sharedInstance.message.ultimatechallenge2.killInitiative = i + 1;
				}
				else
				{
					Contexts.sharedInstance.message.ultimatechallenge2.killPassive = i + 1;
				}
				UltChallenge message = new UltChallenge
				{
					EventId = 10001,
					Ins = { i + 1 }
				};
				Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(124, message);
				for (int m = 1; m < 7; m++)
				{
					if (m == Contexts.sharedInstance.message.ultimatechallenge2.killInitiative || m == Contexts.sharedInstance.message.ultimatechallenge2.killPassive)
					{
						_viewModel.SetselectShow(m, value: true);
					}
					else
					{
						_viewModel.SetselectShow(m, value: false);
					}
				}
			});
		}
		Contexts.sharedInstance.userCommand.input.CursorControls.Add(this);
		_viewModel.skillShow = false;
		_viewModel.backpackShow = false;
		ScrollView_Nearby = _viewModel.ScrollView_NearbyObj.GetComponent<RectTransform>();
		ScrollView_BackPack = _viewModel.ScrollView_BackPackObj.GetComponent<RectTransform>();
		weapon_Rect = new List<RectTransform>(5);
		for (int k = 1; k < 6; k++)
		{
			weapon_Rect.Add(_viewModel.GetRect_weaponObj(k).GetComponent<RectTransform>());
		}
		Content_BackPack = _viewModel.Content_BackPackObj.GetComponent<RectTransform>();
		Content_Nearby = _viewModel.Content_NearbyObj.GetComponent<RectTransform>();
		for (int l = 0; l < 100; l++)
		{
			Ultimatechallenge2Backpack_itemModel ultimatechallenge2Backpack_itemModel = new Ultimatechallenge2Backpack_itemModel(ScrollView_BackPack, ScrollView_Nearby, weapon_Rect, Content_BackPack, Content_Nearby, _viewModel.PanelObj);
			ultimatechallenge2Backpack_itemModel.Initialize();
			PushBackpackItem(ultimatechallenge2Backpack_itemModel);
		}
	}

	public List<UltChallenge> GetMessageList()
	{
		return Contexts.sharedInstance.message.ultimatechallenge2.MessageEvent;
	}

	protected virtual void SetTipsEvent(List<UltChallenge> ov, List<UltChallenge> messageEvent)
	{
		if (messageEvent == null)
		{
			return;
		}
		for (int j = 0; j < messageEvent.Count; j++)
		{
			if (messageEvent[j].EventId == 21)
			{
				_viewModel.default_sizeString = $"{messageEvent[j].Ins[0]}/{messageEvent[j].Ins[1]}";
				messageEvent.RemoveAt(j);
				j--;
			}
			else if (messageEvent[j].EventId == 20)
			{
				_viewModel.bag_size_maxFillamount = (float)messageEvent[j].Ds[1];
				_viewModel.bag_sizeFillamount = (float)messageEvent[j].Ds[0];
				if (messageEvent[j].Ss.Count > 0 && !string.IsNullOrEmpty(messageEvent[j].Ss[0]))
				{
					string assetName = $"Assets/Res/Assets/ui/GameGUIRes/UltimateChallenge2Model/item/{messageEvent[j].Ss[0]}.png";
					base.Loader.RetriveSprite("ui/ultimatechallenge2model", assetName, delegate(Sprite sprite)
					{
						_viewModel.bag_IconShow = true;
						_viewModel.bag_IconSprite = sprite;
					});
				}
				else
				{
					_viewModel.bag_IconShow = false;
				}
				messageEvent.RemoveAt(j);
				j--;
			}
			else if (messageEvent[j].EventId == 11)
			{
				_viewModel.skillShow = false;
				messageEvent.RemoveAt(j);
				j--;
			}
			else if (messageEvent[j].EventId == 13)
			{
				_viewModel.helmetInfo_redShow = messageEvent[j].Ds[0] < 0.0;
				if (messageEvent[j].Ss.Count > 0 && !string.IsNullOrEmpty(messageEvent[j].Ss[0]))
				{
					string assetName2 = $"Assets/Res/Assets/ui/GameGUIRes/UltimateChallenge2Model/item/{messageEvent[j].Ss[0]}.png";
					base.Loader.RetriveSprite("ui/ultimatechallenge2model", assetName2, delegate(Sprite sprite)
					{
						_viewModel.helmetInfo_iconShow = true;
						_viewModel.helmetInfo_iconSprite = sprite;
					});
				}
				else
				{
					_viewModel.helmetInfo_iconShow = false;
				}
				messageEvent.RemoveAt(j);
				j--;
			}
			else if (messageEvent[j].EventId == 14)
			{
				_viewModel.armorInfo_redShow = messageEvent[j].Ds[0] < 0.0;
				if (messageEvent[j].Ss.Count > 0 && !string.IsNullOrEmpty(messageEvent[j].Ss[0]))
				{
					string assetName3 = $"Assets/Res/Assets/ui/GameGUIRes/UltimateChallenge2Model/item/{messageEvent[j].Ss[0]}.png";
					base.Loader.RetriveSprite("ui/ultimatechallenge2model", assetName3, delegate(Sprite sprite)
					{
						_viewModel.armorInfo_iconShow = true;
						_viewModel.armorInfo_iconSprite = sprite;
					});
				}
				else
				{
					_viewModel.armorInfo_iconShow = false;
				}
				messageEvent.RemoveAt(j);
				j--;
			}
			else if (messageEvent[j].EventId == 15)
			{
				_viewModel.hpInfo_num_String1 = messageEvent[j].Ins[0].ToString();
				if (messageEvent[j].Ss.Count > 0 && !string.IsNullOrEmpty(messageEvent[j].Ss[0]))
				{
					string assetName4 = $"Assets/Res/Assets/ui/GameGUIRes/UltimateChallenge2Model/item/{messageEvent[j].Ss[0]}.png";
					base.Loader.RetriveSprite("ui/ultimatechallenge2model", assetName4, delegate(Sprite sprite)
					{
						_viewModel.hpInfo_icon_Show1 = true;
						_viewModel.hpInfo_icon_Sprite1 = sprite;
					});
				}
				else
				{
					_viewModel.hpInfo_icon_Show1 = false;
				}
				messageEvent.RemoveAt(j);
				j--;
			}
			else if (messageEvent[j].EventId == 16)
			{
				_viewModel.hpInfo_num_String2 = messageEvent[j].Ins[0].ToString();
				if (messageEvent[j].Ss.Count > 0 && !string.IsNullOrEmpty(messageEvent[j].Ss[0]))
				{
					string assetName5 = $"Assets/Res/Assets/ui/GameGUIRes/UltimateChallenge2Model/item/{messageEvent[j].Ss[0]}.png";
					base.Loader.RetriveSprite("ui/ultimatechallenge2model", assetName5, delegate(Sprite sprite)
					{
						_viewModel.hpInfo_icon_Show2 = true;
						_viewModel.hpInfo_icon_Sprite2 = sprite;
					});
				}
				else
				{
					_viewModel.hpInfo_icon_Show2 = false;
				}
				messageEvent.RemoveAt(j);
				j--;
			}
			else if (messageEvent[j].EventId == 17)
			{
				_viewModel.hpInfo_num_String3 = messageEvent[j].Ins[0].ToString();
				if (messageEvent[j].Ss.Count > 0 && !string.IsNullOrEmpty(messageEvent[j].Ss[0]))
				{
					string assetName6 = $"Assets/Res/Assets/ui/GameGUIRes/UltimateChallenge2Model/item/{messageEvent[j].Ss[0]}.png";
					base.Loader.RetriveSprite("ui/ultimatechallenge2model", assetName6, delegate(Sprite sprite)
					{
						_viewModel.hpInfo_icon_Show3 = true;
						_viewModel.hpInfo_icon_Sprite3 = sprite;
					});
				}
				else
				{
					_viewModel.hpInfo_icon_Show3 = false;
				}
				messageEvent.RemoveAt(j);
				j--;
			}
			else if (messageEvent[j].EventId == 18)
			{
				UltChallenge ultChallenge = messageEvent[j];
				int count = messageEvent[j].ItemList.Count;
				if (messageEvent[j].Ss[0] == "near")
				{
					UpdateItem(count, near_item, ultChallenge.ItemList, Content_Nearby);
				}
				else
				{
					UpdateItem(count, default_item, ultChallenge.ItemList, Content_BackPack);
				}
				messageEvent.RemoveAt(j);
				j--;
			}
			else
			{
				if (messageEvent[j].EventId != 19)
				{
					continue;
				}
				for (int k = 1; k < 6; k++)
				{
					if (!(messageEvent[j].Ss[0] == "weapon" + k) || messageEvent[j].WeaponInfo == null)
					{
						continue;
					}
					_viewModel.SetBullet_weaponString(k, $"{messageEvent[j].WeaponInfo.Clip}/{messageEvent[j].WeaponInfo.CarryClip}");
					_viewModel.SetName_weaponString(k, messageEvent[j].WeaponInfo.Img);
					if (messageEvent[j].Ss.Count > 0 && !string.IsNullOrEmpty(messageEvent[j].Ss[0]))
					{
						string assetName7 = $"Assets/Res/Assets/ui/GameGUIRes/UltimateChallenge2Model/weaponBigIcon/{messageEvent[j].WeaponInfo.Img}.png";
						int i = k;
						base.Loader.RetriveSprite("ui/ultimatechallenge2model", assetName7, delegate(Sprite sprite)
						{
							_viewModel.SetWeapon_IconShow(i, value: true);
							_viewModel.SetWeapon_IconSprite(i, sprite);
						});
					}
				}
				messageEvent.RemoveAt(j);
				j--;
			}
		}
	}

	public void UpdateItem(int length, List<Ultimatechallenge2Backpack_itemModel> list, List<ItemInfo> listItem, Transform parent)
	{
		if (list.Count > length)
		{
			for (int num = list.Count - 1; num >= length; num--)
			{
				PushBackpackItem(list[num]);
				list.RemoveAt(num);
			}
		}
		else
		{
			for (int i = list.Count; i < length; i++)
			{
				list.Add(GetBackpackItem(parent));
			}
		}
		IListNotify listener = NotifyManager.MakeTempNotifyList(() => listItem);
		for (int j = 0; j < list.Count; j++)
		{
			list[j].Listener = listener;
			list[j].Index = j;
			list[j].ID = listItem[j].ItemId;
			list[j].UpdateEvent();
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}

	public int GetCursorState()
	{
		if (!_viewModel.skillShow && !_viewModel.backpackShow)
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
