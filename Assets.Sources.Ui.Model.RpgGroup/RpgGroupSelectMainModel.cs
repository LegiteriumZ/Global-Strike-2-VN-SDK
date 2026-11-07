using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.RpgGroup;
using Assets.UiFramework.Libs;
using NetData;
using SSJJBase.Extensions;
using SSJJBase.Input;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.RpgGroup;

public class RpgGroupSelectMainModel : AbstractModel, IPlaybackSystem, IKeyboardResponder, ICursorControl, ISetBattleServerContext
{
	private RpgGroupSelectMainViewModel _viewModel;

	private BattleServerContext _battleServerContext;

	private SelectItemList _selectItem;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public void SetBattleServerContext(BattleServerContext context)
	{
		_battleServerContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgGroupSelectMainViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (!_viewModel.PanelShow || _selectItem == null)
		{
			return;
		}
		for (int i = 0; i < _selectItem.ItemList.Count; i++)
		{
			if (_viewModel.GetCellLockShow(i + 1))
			{
				int lockLeftTime = _selectItem.ItemList[i].LockLeftTime;
				_viewModel.SetCellMinuteString(i + 1, ((lockLeftTime > 0) ? (lockLeftTime / 1000 / 60) : 0).ToString("D2"));
				_viewModel.SetCellSecondString(i + 1, ((lockLeftTime > 0) ? (lockLeftTime / 1000 % 60) : 0).ToString("D2"));
			}
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.PanelShow = false;
		for (int j = 0; j < 8; j++)
		{
			_viewModel.SetCellIndexString(j + 1, (j + 1).ToString());
			int i1 = j;
			_viewModel.GetCellClicked(j + 1).AddListener(delegate
			{
				SelectItem(i1);
			});
			_viewModel.SetCellShow(j + 1, value: false);
		}
		base.DoSubscribe();
		_viewModel.CloseBtnClicked.AddListener(delegate
		{
			SelectItem(-1);
		});
	}

	private void UpdateSelectItemList(SelectItemList list)
	{
		if (list == null)
		{
			return;
		}
		_viewModel.PanelShow = list.Visible;
		_selectItem = list;
		int i;
		for (i = 0; i < list.ItemList.Count; i++)
		{
			int index = i + 1;
			_viewModel.SetCellShow(index, value: true);
			SelectItem selectItem = list.ItemList[i];
			_viewModel.SetCellIconSprite(index, base.Loader.RetriveSprite("ui/rpggroupmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgGroupModel/selectCells/" + selectItem.Icon + ".png", delegate(Sprite sprite)
			{
				_viewModel.SetCellIconSprite(index, sprite);
			}));
			_viewModel.SetCellNameString(index, selectItem.Name);
			_viewModel.SetCellMoneyString(index, StringCache.IntToString(selectItem.Price));
			_viewModel.SetCellLockShow(index, selectItem.Locked);
		}
		for (; i < 8; i++)
		{
			_viewModel.SetCellShow(i + 1, value: false);
		}
	}

	private void SelectItem(int index)
	{
		if (_selectItem != null && index < _selectItem.ItemList.Count)
		{
			_battleServerContext.battleServer.Server.SendTcpMessage(27, new SelectClickEvent
			{
				Name = _selectItem.Name,
				EventId = ((index < 0) ? index : _selectItem.ItemList[index].EventId)
			});
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.B)
		{
			UiIEventCondition.Get_cameraOwnerData_Observer();
			_ = 0;
			return false;
		}
		if (_viewModel.PanelShow)
		{
			int alphaOrKeypadDiff = key.GetAlphaOrKeypadDiff();
			if (alphaOrKeypadDiff >= 0 && alphaOrKeypadDiff <= 8)
			{
				SelectItem(alphaOrKeypadDiff - 1);
			}
			return true;
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		if (_viewModel.PanelShow && key != KeyCode.B)
		{
			return true;
		}
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		if (_viewModel.PanelShow && key != KeyCode.B)
		{
			return true;
		}
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		if (_viewModel.PanelShow && key != KeyCode.B)
		{
			return true;
		}
		return false;
	}

	public int GetCursorState()
	{
		if (!_viewModel.PanelShow)
		{
			return 0;
		}
		return 64;
	}

	public int GetForbidButtons()
	{
		return 0;
	}
}
