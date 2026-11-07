using System;
using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.AcgCommon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.AcgCommon;

[GameUiTest]
public class AcgTabWindowModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, IKeyboardResponder, ICursorControl
{
	private AcgTabWindowViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private PlayerContext _playerContext;

	protected NotifyGroup _notifyGroup = new NotifyGroup();

	protected IPlayerScoreCell[] _playerCells;

	protected Type CellClass;

	protected int TeamMemberNum = 3;

	protected List<Button> _powerUps;

	private int ONE_ROW_NUM = 6;

	private float WIDTH = 504f;

	private float HEIGHT_OFFSET = 60f;

	private float ONE_PU_X = 84f;

	private float ONE_PU_Y = 88f;

	private List<int> _ownedList;

	private Button _button;

	private bool _showCursor;

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

	public override void CreateViewModel()
	{
		_viewModel = new AcgTabWindowViewModel();
		CellClass = typeof(AcgPlayerInfoGridModel);
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
		_playerContext = Contexts.sharedInstance.player;
		_powerUps = new List<Button> { _viewModel.PowerUpIconButton };
		_viewModel.PowerUpIconButton.gameObject.SetActive(value: false);
		SetVisible(value: false);
		SetButton();
		CreateCells();
		NotifyManager.MakeNotify(109, GetOwnedPowerUps, SetOwnedPowerUps);
	}

	private void SetOwnedPowerUps(int oldId, int newId)
	{
		_ownedList = _gameRuleContext.acgPowerUp.OwnedList;
		if (_ownedList == null || _ownedList.Count == 0)
		{
			return;
		}
		if (_ownedList.Count > _powerUps.Count)
		{
			for (int i = _powerUps.Count; i < _ownedList.Count; i++)
			{
				_button = UnityEngine.Object.Instantiate(_viewModel.PowerUpIconObj, _viewModel.ContentObj.transform).GetComponent<Button>();
				_button.transform.localPosition = new Vector2((float)(i % ONE_ROW_NUM) * ONE_PU_X, (float)(-(i / ONE_ROW_NUM)) * ONE_PU_Y);
				_powerUps.Add(_button);
			}
		}
		else
		{
			for (int j = _ownedList.Count; j < _powerUps.Count; j++)
			{
				_powerUps[j].gameObject.SetActive(value: false);
			}
		}
		for (int k = 0; k < _ownedList.Count; k++)
		{
			int index = k;
			base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/PowerUpIcon/Small/" + _ownedList[index] + ".png", delegate(Sprite sprite)
			{
				_powerUps[index].image.sprite = sprite;
				_powerUps[index].onClick.RemoveAllListeners();
				_powerUps[index].onClick.AddListener(delegate
				{
					_viewModel.PowerUpIntroIconImage.sprite = sprite;
					_viewModel.PowerUpIntroTextString = "123";
					AcgPowerUpsTable.Row row = AcgInfoLoader.Instance.AcgPowerUpsTable.Find_Id(_ownedList[index]);
					_viewModel.PowerUpIntroNameString = row.Name;
					_viewModel.PowerUpIntroTextString = row.Discription;
				});
				_powerUps[index].gameObject.SetActive(value: true);
			});
		}
		_viewModel.PowerUpNumberString = _ownedList.Count.ToString();
		_viewModel.ContentSize = new Vector2(WIDTH, HEIGHT_OFFSET + ONE_PU_Y * (float)(_ownedList.Count / ONE_ROW_NUM));
		_powerUps[0].onClick.Invoke();
	}

	private int GetOwnedPowerUps()
	{
		return 0;
	}

	private void SetButton()
	{
		_viewModel.TeamInfoShow = true;
		_viewModel.TeamInfoSelectedTextShow = true;
		_viewModel.TeamInfoHighlightTextShow = false;
		_viewModel.TeamInfoCommonTextShow = false;
		_viewModel.TeamInfoButtonImage.enabled = true;
		_viewModel.PowerUpInfoShow = false;
		_viewModel.PowerUpInfoSelectedTextShow = false;
		_viewModel.PowerUpInfoHighlightTextShow = false;
		_viewModel.PowerUpInfoCommonTextShow = true;
		_viewModel.PowerUpInfoButtonImage.enabled = false;
		_viewModel.CreateTriggerEntry(_viewModel.TeamInfoButtonTriggers, EventTriggerType.PointerEnter, delegate
		{
			_viewModel.TeamInfoSelectedTextShow = false;
			_viewModel.TeamInfoHighlightTextShow = true;
			_viewModel.TeamInfoCommonTextShow = false;
		});
		_viewModel.CreateTriggerEntry(_viewModel.TeamInfoButtonTriggers, EventTriggerType.PointerExit, delegate
		{
			_viewModel.TeamInfoSelectedTextShow = _viewModel.TeamInfoShow;
			_viewModel.TeamInfoHighlightTextShow = false;
			_viewModel.TeamInfoCommonTextShow = !_viewModel.TeamInfoShow;
		});
		_viewModel.CreateTriggerEntry(_viewModel.TeamInfoButtonTriggers, EventTriggerType.PointerClick, delegate
		{
			_viewModel.TeamInfoShow = true;
			_viewModel.TeamInfoSelectedTextShow = true;
			_viewModel.TeamInfoHighlightTextShow = false;
			_viewModel.TeamInfoCommonTextShow = false;
			_viewModel.TeamInfoButtonImage.enabled = true;
			_viewModel.PowerUpInfoShow = false;
			_viewModel.PowerUpInfoSelectedTextShow = false;
			_viewModel.PowerUpInfoHighlightTextShow = false;
			_viewModel.PowerUpInfoCommonTextShow = true;
			_viewModel.PowerUpInfoButtonImage.enabled = false;
		});
		_viewModel.CreateTriggerEntry(_viewModel.PowerUpInfoButtonTriggers, EventTriggerType.PointerEnter, delegate
		{
			_viewModel.PowerUpInfoSelectedTextShow = false;
			_viewModel.PowerUpInfoHighlightTextShow = true;
			_viewModel.PowerUpInfoCommonTextShow = false;
		});
		_viewModel.CreateTriggerEntry(_viewModel.PowerUpInfoButtonTriggers, EventTriggerType.PointerExit, delegate
		{
			_viewModel.PowerUpInfoSelectedTextShow = _viewModel.PowerUpInfoShow;
			_viewModel.PowerUpInfoHighlightTextShow = false;
			_viewModel.PowerUpInfoCommonTextShow = !_viewModel.PowerUpInfoShow;
		});
		_viewModel.CreateTriggerEntry(_viewModel.PowerUpInfoButtonTriggers, EventTriggerType.PointerClick, delegate
		{
			_viewModel.TeamInfoShow = false;
			_viewModel.TeamInfoSelectedTextShow = false;
			_viewModel.TeamInfoHighlightTextShow = false;
			_viewModel.TeamInfoCommonTextShow = true;
			_viewModel.TeamInfoButtonImage.enabled = false;
			_viewModel.PowerUpInfoShow = true;
			_viewModel.PowerUpInfoSelectedTextShow = true;
			_viewModel.PowerUpInfoHighlightTextShow = false;
			_viewModel.PowerUpInfoCommonTextShow = false;
			_viewModel.PowerUpInfoButtonImage.enabled = true;
		});
	}

	protected virtual void CreateCells()
	{
		_playerCells = new IPlayerScoreCell[TeamMemberNum];
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(UiIEventCondition.Get_AcgAllPlayerEntity);
		for (int i = 0; i < _playerCells.Length; i++)
		{
			_playerCells[i] = (IPlayerScoreCell)Activator.CreateInstance(CellClass);
			_playerCells[i].Container = _viewModel.GridObj;
			_playerCells[i].Listener = listNotify;
			_playerCells[i].Index = i;
			_playerCells[i].SetPlayerContext(_playerContext);
			_playerCells[i].Initialize();
		}
		_notifyGroup.Add(listNotify.Id);
	}

	private void SetVisible(bool value)
	{
		_viewModel.ShowShow = value;
		_notifyGroup.SetSuspend(!value);
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.Tab)
		{
			SetVisible(value: true);
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		if (key == KeyCode.Tab)
		{
			_showCursor = false;
			SetVisible(value: false);
		}
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
		if (Input.GetMouseButtonDown(1))
		{
			_showCursor = true;
		}
		if (!_viewModel.ShowShow || !_showCursor)
		{
			return 0;
		}
		return 32;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
