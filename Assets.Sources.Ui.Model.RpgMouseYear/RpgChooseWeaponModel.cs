using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.RpgMouseYear;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using SSJJBase.String;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.RpgMouseYear;

[GameUiTest]
public class RpgChooseWeaponModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ICursorControl
{
	private class AngleBounds
	{
		private int _min;

		private int _max;

		private int _index;

		internal int GetIndex()
		{
			return _index;
		}

		internal AngleBounds(int min, int max, int index)
		{
			_index = index;
			_min = min;
			_max = max;
		}

		internal bool IsInRange(float angle)
		{
			if (angle >= (float)_min && angle <= (float)_max)
			{
				return true;
			}
			return false;
		}
	}

	private RpgChooseWeaponViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private Dictionary<int, AngleBounds> _typeAngles = new Dictionary<int, AngleBounds>();

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
		InitTypeAngle();
	}

	private void InitTypeAngle()
	{
		_typeAngles.Add(1, new AngleBounds(18, 90, 1));
		_typeAngles.Add(2, new AngleBounds(90, 162, 3));
		_typeAngles.Add(3, new AngleBounds(162, 234, 4));
		_typeAngles.Add(4, new AngleBounds(234, 306, 2));
		_typeAngles.Add(5, new AngleBounds(306, 360, 5));
		_typeAngles.Add(6, new AngleBounds(0, 18, 5));
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgChooseWeaponViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
			UpdateBackgoundTouch();
		}
	}

	private int GetSelectType(Vector2 mousePosition)
	{
		Vector2 localPoint = Vector2.zero;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_viewModel.ImageBGObj.GetComponent<RectTransform>(), mousePosition, null, out localPoint))
		{
			float num = 0f;
			if (Mathf.Approximately(localPoint.x, 0f))
			{
				num = ((!(localPoint.y > 0f)) ? 270f : 90f);
			}
			else
			{
				num = Mathf.Atan(localPoint.y / localPoint.x) * 57.29578f;
				if (localPoint.x > 0f && localPoint.y < 0f)
				{
					num = 360f + num;
				}
				else if (localPoint.x < 0f && localPoint.y < 0f)
				{
					num = 180f + num;
				}
				else if (localPoint.x < 0f && localPoint.y > 0f)
				{
					num = 180f + num;
				}
			}
			if (IsInRect(localPoint, _viewModel.ImageBGRect.min, _viewModel.ImageBGRect.max))
			{
				foreach (KeyValuePair<int, AngleBounds> typeAngle in _typeAngles)
				{
					if (typeAngle.Value.IsInRange(num))
					{
						return typeAngle.Value.GetIndex();
					}
				}
			}
		}
		return -1;
	}

	private bool IsInRect(Vector2 pos, Vector2 min, Vector2 max)
	{
		if (pos.x < min.x || pos.x > max.x || pos.y < min.y || pos.y > max.y)
		{
			return false;
		}
		return true;
	}

	private void UpdateBackgoundTouch()
	{
		if (!_viewModel.ShowShow)
		{
			return;
		}
		ShowChooseWeaponUIResponse chooseWeaponUiResponse = _gameRuleContext.chooseWeapon.ChooseWeaponUiResponse;
		Vector3 mousePosition = Input.mousePosition;
		int selectType = GetSelectType(mousePosition);
		for (int i = 1; i < 6; i++)
		{
			_viewModel.SetNobombWeaponShow(i, i == selectType);
		}
		foreach (WeaponTypeEntity entity in chooseWeaponUiResponse.EntityList)
		{
			if (entity.IsChoose && entity.Type == selectType)
			{
				_viewModel.SetNobombWeaponShow(selectType, value: false);
			}
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.ShowShow = false;
		_viewModel.CreateTriggerEntry(_viewModel.ImageBGTriggers, EventTriggerType.PointerClick, WeaponChooseClick);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiChooseWeapon, StartChooseWeapon, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiChooseWeaponChanged, ChooseWeaponChanged, null, initinvoke: true);
		base.DoSubscribe();
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
		if (_viewModel.ShowShow)
		{
			_gameRuleContext.chooseWeapon.ChooseLeftTime -= _timeComponent.FrameInterval;
			_viewModel.AlertTextString = StringCache.IntToString(_gameRuleContext.chooseWeapon.ChooseLeftTime / 1000 + 1);
			if (_gameRuleContext.chooseWeapon.ChooseLeftTime < -100)
			{
				_gameRuleContext.chooseWeapon.CanChooseWeapon = false;
				Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(110, new ChooseWeaponTimeoutRequest
				{
					Tmp = 0
				});
			}
		}
	}

	private void ChooseWeaponChanged(bool arg1, bool arg2)
	{
		if (!arg1 && arg2)
		{
			InitChooseWeapon();
		}
	}

	private void StartChooseWeapon(bool arg1, bool arg2)
	{
		if (arg1 && arg2)
		{
			_viewModel.ShowShow = true;
			InitChooseWeapon();
		}
		else if (arg1)
		{
			_viewModel.ShowShow = false;
		}
	}

	private void InitChooseWeapon()
	{
		ShowChooseWeaponUIResponse chooseWeaponUiResponse = _gameRuleContext.chooseWeapon.ChooseWeaponUiResponse;
		for (int i = 1; i < 6; i++)
		{
			_viewModel.SetNobombWeaponShow(i, value: false);
			_viewModel.SetChooseShow(i, value: false);
		}
		foreach (WeaponTypeEntity entity in chooseWeaponUiResponse.EntityList)
		{
			if (entity.IsChoose)
			{
				WeaponHasChoose(entity.Type);
			}
		}
	}

	private void WeaponHasChoose(int type)
	{
		_viewModel.SetChooseShow(type, value: true);
		_viewModel.SetNobombWeaponShow(type, value: false);
	}

	private void WeaponChooseClick(int index)
	{
		if (!_gameRuleContext.chooseWeapon.HaveChoosedWeapon)
		{
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(105, new ChooseWeaponTypeRequest
			{
				Type = index
			});
			_gameRuleContext.chooseWeapon.HaveChoosedWeapon = true;
		}
	}

	private void WeaponChooseClick(BaseEventData obj)
	{
		ShowChooseWeaponUIResponse chooseWeaponUiResponse = _gameRuleContext.chooseWeapon.ChooseWeaponUiResponse;
		Vector3 mousePosition = Input.mousePosition;
		int selectType = GetSelectType(mousePosition);
		foreach (WeaponTypeEntity entity in chooseWeaponUiResponse.EntityList)
		{
			if (entity.IsChoose && entity.Type == selectType)
			{
				return;
			}
		}
		if (selectType != -1)
		{
			WeaponChooseClick(selectType);
		}
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowShow)
		{
			return 0;
		}
		return 4096;
	}

	public int GetForbidButtons()
	{
		return 175;
	}
}
