using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Ultimatechallenge2Model;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.Ultimatechallenge2Model;

[GameUiTest]
public class Ultimatechallenge2Backpack_itemModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private Ultimatechallenge2Backpack_itemViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private RectTransform ScrollView_BackPack;

	private RectTransform ScrollView_Nearby;

	private List<RectTransform> weapon_Rect;

	private RectTransform Content_BackPack;

	private RectTransform Content_Nearby;

	private GameObject PanelObj;

	private Vector2 lastPos;

	private Vector2 lastMousePos;

	public int Index { get; set; }

	public int ID { get; set; }

	public IListNotify Listener { get; set; }

	public bool Show
	{
		set
		{
			_viewModel.Ultimatechallenge2Backpack_itemShow = value;
		}
	}

	public Transform Parent
	{
		set
		{
			_viewModel.Ultimatechallenge2Backpack_itemObj.transform.SetParent(value);
		}
	}

	protected override IUiViewModel ViewModel => _viewModel;

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

	public Ultimatechallenge2Backpack_itemModel(RectTransform ScrollView_BackPack, RectTransform ScrollView_Nearby, List<RectTransform> weapon_Rect, RectTransform Content_BackPack, RectTransform Content_Nearby, GameObject PanelObj)
	{
		this.ScrollView_BackPack = ScrollView_BackPack;
		this.ScrollView_Nearby = ScrollView_Nearby;
		this.weapon_Rect = weapon_Rect;
		this.Content_BackPack = Content_BackPack;
		this.Content_Nearby = Content_Nearby;
		this.PanelObj = PanelObj;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Ultimatechallenge2Backpack_itemViewModel();
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
		AddDragEvent(_viewModel.Ultimatechallenge2Backpack_itemObj.GetComponent<EventTrigger>());
	}

	public void UpdateEvent()
	{
		Listener.AddEvent<ItemInfo, int>("Count", Get_OneKillInfoData_Count, SetCount, Index);
		Listener.AddEvent<ItemInfo, string>("Image", Get_OneKillInfoData_Image, SetImage, Index);
		Listener.AddEvent<ItemInfo, string>("Name", Get_OneKillInfoData_Name, SetName, Index);
	}

	public static int Get_OneKillInfoData_Count(ItemInfo val, int idx)
	{
		return val.Count;
	}

	public static string Get_OneKillInfoData_Image(ItemInfo val, int idx)
	{
		return val.Img;
	}

	public static string Get_OneKillInfoData_Name(ItemInfo val, int idx)
	{
		return val.Key;
	}

	protected void SetCount(ItemInfo val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		_viewModel.TextString = val.Count.ToString();
	}

	protected void SetName(ItemInfo val, int idx, string oldfs, string newfs, ElementStatus status)
	{
		_viewModel.NameString = val.Key;
	}

	protected void SetImage(ItemInfo val, int idx, string oldfs, string newfs, ElementStatus status)
	{
		string assetName = string.Format("Assets/Res/Assets/ui/GameGUIRes/UltimateChallenge2Model/{0}", val.Img.Replace(".atf", ".png"));
		base.Loader.RetriveSprite("ui/ultimatechallenge2model", assetName, delegate(Sprite sprite)
		{
			_viewModel.ImageSprite = sprite;
		});
	}

	private void OnBeginDrag(RectTransform o)
	{
		o.SetParent(PanelObj.transform);
		lastPos = o.anchoredPosition;
		lastMousePos = Input.mousePosition;
	}

	private void OnDrag(RectTransform o)
	{
		Vector2 vector = Input.mousePosition;
		float num = vector.x - lastMousePos.x;
		float num2 = vector.y - lastMousePos.y;
		Vector2 anchoredPosition = new Vector2(lastPos.x + num, lastPos.y + num2);
		o.anchoredPosition = anchoredPosition;
	}

	private void OnEndDrag(RectTransform o)
	{
		for (int i = 0; i < 5; i++)
		{
			if (RectTransformUtility.RectangleContainsScreenPoint(weapon_Rect[i], Input.mousePosition))
			{
				UltChallenge message = new UltChallenge
				{
					EventId = 10004,
					Ins = { ID }
				};
				Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(124, message);
				return;
			}
		}
		if (RectTransformUtility.RectangleContainsScreenPoint(ScrollView_BackPack, Input.mousePosition))
		{
			o.SetParent(Content_BackPack);
			UltChallenge message2 = new UltChallenge
			{
				EventId = 10002,
				Ins = { ID }
			};
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(124, message2);
		}
		else if (RectTransformUtility.RectangleContainsScreenPoint(ScrollView_Nearby, Input.mousePosition))
		{
			o.SetParent(Content_Nearby);
			UltChallenge message3 = new UltChallenge
			{
				EventId = 10003,
				Ins = { ID }
			};
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(124, message3);
		}
		else
		{
			UltChallenge message4 = new UltChallenge
			{
				EventId = 10003,
				Ins = { ID }
			};
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(124, message4);
		}
	}

	private void AddDragEvent(EventTrigger e)
	{
		RectTransform tran = e.transform as RectTransform;
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.BeginDrag;
		entry.callback.AddListener(delegate
		{
			OnBeginDrag(tran);
		});
		EventTrigger.Entry entry2 = new EventTrigger.Entry();
		entry2.eventID = EventTriggerType.Drag;
		entry2.callback.AddListener(delegate
		{
			OnDrag(tran);
		});
		EventTrigger.Entry entry3 = new EventTrigger.Entry();
		entry3.eventID = EventTriggerType.EndDrag;
		entry3.callback.AddListener(delegate
		{
			Debug.LogError(ID);
			OnEndDrag(tran);
		});
		e.triggers.Add(entry);
		e.triggers.Add(entry2);
		e.triggers.Add(entry3);
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
