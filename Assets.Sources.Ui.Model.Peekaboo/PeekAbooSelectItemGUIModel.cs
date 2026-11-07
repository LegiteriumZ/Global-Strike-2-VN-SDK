using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Peekaboo;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Input;
using SSJJBase.Singleton;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.Peekaboo;

[GameUiTest]
public class PeekAbooSelectItemGUIModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, IKeyboardResponder, ICursorControl
{
	private PeekAbooSelectItemGUIViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private MessageContext _msgContext;

	private int hideTime;

	private int selectIndex;

	private PeekabooSelectItemSprite selectItemSprite1;

	private PeekabooSelectItemSprite selectItemSprite2;

	private PeekabooSelectItemSprite selectItemSprite3;

	private Vector3 imgSelectPos;

	private int testTime;

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
		_msgContext = Contexts.sharedInstance.message;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		SimpleNotify.Add(GetVisible, SetVisible);
		SimpleNotify.Add(GetBtnConVisible, SetBtnConVisible);
		SimpleNotify.Add(GetTextNameVisible, SetTextNameVisible);
		SimpleNotify.Add(GetConTimeVisible, SetConTimeVisible);
		SimpleNotify.Add(GetTimeString, SetTimeString);
		SimpleNotify.Add(GetSelectVisible, SetSelectVisible);
		SimpleNotify.Add(GetBtn1State, SetBtn1State);
		SimpleNotify.Add(GetBtn2State, SetBtn2State);
		SimpleNotify.Add(GetBtn3State, SetBtn3State);
		SimpleNotify.Add(GetBtnSecondState, SetBtnSecondState);
		PeekabooSelectItemSprite.Loader = this.GetLoader();
	}

	private void SetBtn1State(bool arg1, int index)
	{
		if (_viewModel != null)
		{
			_viewModel.btnButtonable1 = arg1;
		}
	}

	private bool GetBtn1State(int index)
	{
		int num = 10;
		PeekabooChooseData chooseData = _msgContext.peekabooMessageData.chooseData;
		if (chooseData == null)
		{
			return true;
		}
		if (chooseData.HaveStarNum >= num)
		{
			return !chooseData.Special;
		}
		return false;
	}

	private void SetBtn2State(bool arg1, int index)
	{
		if (_viewModel != null)
		{
			_viewModel.btnButtonable2 = arg1;
		}
	}

	private bool GetBtn2State(int index)
	{
		int num = 25;
		PeekabooChooseData chooseData = _msgContext.peekabooMessageData.chooseData;
		if (chooseData == null)
		{
			return true;
		}
		if (chooseData.HaveStarNum >= num)
		{
			return !chooseData.Special;
		}
		return false;
	}

	private void SetBtn3State(bool arg1, int index)
	{
		if (_viewModel != null)
		{
			_viewModel.btnButtonable3 = arg1;
		}
	}

	private bool GetBtn3State(int index)
	{
		int num = 20;
		PeekabooChooseData chooseData = _msgContext.peekabooMessageData.chooseData;
		if (chooseData == null)
		{
			return true;
		}
		if (chooseData.PickUpItemId <= 0)
		{
			return false;
		}
		if (chooseData.HaveStarNum >= num)
		{
			return !chooseData.Special;
		}
		return false;
	}

	private void SetBtnSecondState(bool arg1, int index)
	{
		if (_viewModel != null)
		{
			_viewModel.btnSelectSecondButtonable = arg1;
		}
	}

	private bool GetBtnSecondState(int index)
	{
		int num = 5;
		PeekabooChooseData chooseData = _msgContext.peekabooMessageData.chooseData;
		if (chooseData == null)
		{
			return true;
		}
		if (chooseData.Special || !chooseData.CanRepick)
		{
			return false;
		}
		if (chooseData.HaveStarNum >= num)
		{
			return !chooseData.Special;
		}
		return false;
	}

	private void SetSelectVisible(bool arg1, int index)
	{
		if (_viewModel != null)
		{
			_viewModel.imgSelectShow = arg1;
			if (arg1)
			{
				imgSelectPos.y = -104f;
				imgSelectPos.x = 70 + 160 * (selectIndex - 1);
				_viewModel.imgSelectPosition = imgSelectPos;
			}
		}
	}

	private bool GetSelectVisible(int index)
	{
		if (_viewModel == null)
		{
			return true;
		}
		return _msgContext.peekabooMessageData.selectOK;
	}

	private void SetConTimeVisible(bool arg1, int index)
	{
		if (_viewModel != null)
		{
			_viewModel.conTimeShow = arg1;
		}
	}

	private bool GetConTimeVisible(int index)
	{
		PeekabooChooseData chooseData = _msgContext.peekabooMessageData.chooseData;
		if (chooseData == null)
		{
			return false;
		}
		return chooseData.Round == 2;
	}

	private void SetTimeString(string arg1, int index)
	{
		if (_viewModel != null)
		{
			_viewModel.txtTimeString = arg1;
		}
	}

	private string GetTimeString(int index)
	{
		return string.Concat(hideTime / 1000);
	}

	public override void CreateViewModel()
	{
		_viewModel = new PeekAbooSelectItemGUIViewModel();
	}

	private void initSpriteSelectItem()
	{
		if (selectItemSprite1 != null)
		{
			return;
		}
		List<int> itemIds = _msgContext.peekabooMessageData.itemIds;
		List<string> list = new List<string>();
		foreach (int item in itemIds)
		{
			list.Add(getImageUrl(item));
		}
		selectItemSprite1 = new PeekabooSelectItemSprite(list, _viewModel.imgItem0_Obj1, _viewModel.imgItemObj0, 128, 128);
		selectItemSprite2 = new PeekabooSelectItemSprite(list, _viewModel.imgItem1_Obj1, _viewModel.imgItemObj1, 128, 128);
		selectItemSprite3 = new PeekabooSelectItemSprite(list, _viewModel.imgItem2_Obj1, _viewModel.imgItemObj2, 128, 128);
	}

	private string getImageUrl(int id)
	{
		if (id <= 0)
		{
			return "Assets/Res/Assets/ui/GameGUIRes/peekabooModel/selectitem/noitem.png";
		}
		return "Assets/Res/Assets/ui/GameGUIRes/peekabooModel/item/" + id + ".png";
	}

	public void OnPlayback()
	{
		UpdateChips(_timeComponent);
	}

	protected override void DoSubscribe()
	{
		_viewModel.ShowShow = false;
		_viewModel.btnClicked0.AddListener(button0Click);
		_viewModel.btnClicked1.AddListener(button1Click);
		_viewModel.btnClicked2.AddListener(button2Click);
		_viewModel.btnClicked3.AddListener(button3Click);
		_viewModel.btnSelectSecondClicked.AddListener(buttonSecondClick);
		base.DoSubscribe();
	}

	private void SetVisible(bool arg1, int index)
	{
		if (arg1 && _viewModel == null)
		{
			CreateViewModel();
			InitChips();
		}
		else if (_viewModel != null)
		{
			_viewModel.ShowShow = arg1;
		}
	}

	private bool GetVisible(int index)
	{
		return hideTime > 0;
	}

	private void SetBtnConVisible(bool arg1, int index)
	{
		if (_viewModel != null)
		{
			_viewModel.conBtnShow = arg1;
			_viewModel.conSpecalImgShow = !arg1;
		}
	}

	private bool GetBtnConVisible(int index)
	{
		PeekabooChooseData chooseData = _msgContext.peekabooMessageData.chooseData;
		if (chooseData == null)
		{
			return false;
		}
		return !chooseData.Special;
	}

	private void SetTextNameVisible(bool arg1, int index)
	{
		if (_viewModel != null)
		{
			PeekabooChooseData chooseData = _msgContext.peekabooMessageData.chooseData;
			_viewModel.txtNameShow1 = arg1;
			if (arg1 && chooseData != null)
			{
				_viewModel.txtNameString1 = GameStringConfig.getItemNameByItemID(chooseData.PosItemId1);
			}
			_viewModel.txtNameShow2 = arg1;
			if (arg1 && chooseData != null)
			{
				_viewModel.txtNameString2 = GameStringConfig.getItemNameByItemID(chooseData.PosItemId2);
			}
			_viewModel.txtNameShow3 = arg1;
			if (arg1 && chooseData != null)
			{
				_viewModel.txtNameString3 = GameStringConfig.getItemNameByItemID(chooseData.PosItemId3);
			}
			_viewModel.txtNameShow4 = arg1;
			if (arg1 && chooseData != null)
			{
				_viewModel.txtNameString4 = GameStringConfig.getItemNameByItemID(chooseData.PickUpItemId);
			}
		}
	}

	private bool GetTextNameVisible(int index)
	{
		if (selectItemSprite1 == null)
		{
			return false;
		}
		if (selectItemSprite1.isStop() && selectItemSprite2.isStop())
		{
			return selectItemSprite3.isStop();
		}
		return false;
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (hideTime <= 0)
		{
			return false;
		}
		switch (key)
		{
		case KeyCode.Alpha1:
		case KeyCode.Keypad1:
			button0Click();
			break;
		case KeyCode.Alpha2:
		case KeyCode.Keypad2:
			button1Click();
			break;
		case KeyCode.Alpha3:
		case KeyCode.Keypad3:
			button2Click();
			break;
		case KeyCode.Alpha4:
		case KeyCode.Keypad4:
			button3Click();
			break;
		case KeyCode.Space:
			buttonSecondClick();
			break;
		}
		return false;
	}

	public void button0Click()
	{
		if (!_msgContext.peekabooMessageData.selectOK && selectItemSprite1.isStop())
		{
			selectIndex = 1;
			sendSelectIndex();
		}
	}

	private void button1Click()
	{
		if (!_msgContext.peekabooMessageData.selectOK && selectItemSprite2.isStop() && _viewModel.btnButtonable1)
		{
			selectIndex = 2;
			sendSelectIndex();
		}
	}

	private void button2Click()
	{
		if (!_msgContext.peekabooMessageData.selectOK && selectItemSprite3.isStop() && _viewModel.btnButtonable2)
		{
			selectIndex = 3;
			sendSelectIndex();
		}
	}

	private void button3Click()
	{
		if (!_msgContext.peekabooMessageData.selectOK && _viewModel.btnButtonable3)
		{
			selectIndex = 4;
			sendSelectIndex();
		}
	}

	private void buttonSecondClick()
	{
		if (_viewModel.btnSelectSecondButtonable)
		{
			selectIndex = 5;
			sendSelectIndex();
		}
	}

	private void sendSelectIndex()
	{
		ProtoIntData message = new ProtoIntData
		{
			Data = selectIndex
		};
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(15, message);
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

	public int GetForbidButtons()
	{
		return 0;
	}

	public int GetCursorState()
	{
		if (_viewModel == null)
		{
			return 0;
		}
		if (!_viewModel.ShowShow)
		{
			return 0;
		}
		return 1;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
		if (hideTime > 0)
		{
			hideTime -= time.FrameInterval;
		}
		initSpriteSelectItem();
		if (_msgContext.peekabooMessageData.chooseChanged)
		{
			playerModelSnd("selectitem");
			_msgContext.peekabooMessageData.chooseChanged = false;
			hideTime = _msgContext.peekabooMessageData.chooseData.PickTime;
			updateImageSprite(_viewModel.imgItemObj3, getImageUrl(_msgContext.peekabooMessageData.chooseData.PickUpItemId));
			selectItemSprite1.start(getImageUrl(_msgContext.peekabooMessageData.chooseData.PosItemId1));
			selectItemSprite2.start(getImageUrl(_msgContext.peekabooMessageData.chooseData.PosItemId2));
			selectItemSprite3.start(getImageUrl(_msgContext.peekabooMessageData.chooseData.PosItemId3));
		}
		else if (_msgContext.peekabooMessageData.selectOKChanged)
		{
			_msgContext.peekabooMessageData.selectOK = true;
			_msgContext.peekabooMessageData.selectOKChanged = false;
			playerModelSnd("selectitemok");
			if (hideTime > 500)
			{
				hideTime = 500;
			}
		}
		if (!_msgContext.peekabooMessageData.selectOK)
		{
			selectItemSprite1.run(time.FrameInterval);
			selectItemSprite2.run(time.FrameInterval);
			selectItemSprite3.run(time.FrameInterval);
		}
	}

	private void updateImageSprite(GameObject obj, string url)
	{
		Image image = obj.GetComponent<Image>();
		if (image != null)
		{
			AssetInfo assetInfo = new AssetInfo("ui/peekabooModel", url);
			this.GetLoader().RetriveSprite(assetInfo, delegate(Sprite sprite)
			{
				image.sprite = sprite;
			});
		}
	}

	private void playerModelSnd(string soundUrl)
	{
		AssetInfo soundUrl2 = SoundResourceUtility.GetSoundUrl(25, soundUrl);
		MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, soundUrl2, GameSoundManager.Config.AsideVolume);
	}
}
