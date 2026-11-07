using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Modules.Ui.Utils;
using Assets.Sources.Ui.ViewModel.Pve;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJBase.Extensions;
using SSJJBase.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.Pve;

public class PvetdbuyweaponModel : AbstractModel, IPlaybackSystem, IKeyboardResponder, ICursorControl, ISetMessageContext
{
	private PvetdbuyweaponViewModel _viewModel;

	private MessageContext _messageContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public int GetForbidButtons()
	{
		return 0;
	}

	public int GetCursorState()
	{
		if (!_viewModel.pvetdbuyweaponShow)
		{
			return 0;
		}
		return 64;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PvetdbuyweaponViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.pvetdbuyweaponShow = false;
		_viewModel.montytxtString = UiIEventCondition.GetPlayerMoney().ToString();
		_viewModel.startxtString = UiIEventCondition.GetPlayerStar().ToString();
		UpdateSelectState();
		NotifyManager.MakeTempNotify(UiIEventCondition.GetPlayerMoney, SetMoney, _viewModel.pvetdbuyweaponObj);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetPlayerStar, SetStar, _viewModel.pvetdbuyweaponObj);
		GetButton(1).TryAddComponent<UILisenter>().onPointerClick.Add(ClickSelect1);
		GetButton(2).TryAddComponent<UILisenter>().onPointerClick.Add(ClickSelect2);
		GetButton(3).TryAddComponent<UILisenter>().onPointerClick.Add(ClickSelect3);
	}

	protected override void OnGameobjectDestoryed()
	{
		base.OnGameobjectDestoryed();
		NotifyManager.Remove(_viewModel.pvetdbuyweaponObj);
		GetButton(1).TryAddComponent<UILisenter>().onPointerClick.Remove(ClickSelect1);
		GetButton(2).TryAddComponent<UILisenter>().onPointerClick.Remove(ClickSelect2);
		GetButton(3).TryAddComponent<UILisenter>().onPointerClick.Remove(ClickSelect3);
	}

	private void UpdateSelectState()
	{
		GetButton(2).interactable = UiIEventCondition.GetPlayerMoney() >= 100;
		GetButton(3).interactable = UiIEventCondition.GetPlayerStar() >= 5;
		_viewModel.montytxtTextcolor = ((UiIEventCondition.GetPlayerMoney() >= 100) ? Color.white : Color.red);
		_viewModel.startxtTextcolor = ((UiIEventCondition.GetPlayerStar() >= 5) ? Color.white : Color.red);
	}

	private void SetMoney(int old, int newval)
	{
		_viewModel.montytxtString = newval.ToString();
		UpdateSelectState();
	}

	private void SetStar(int old, int newval)
	{
		_viewModel.startxtString = newval.ToString();
		UpdateSelectState();
	}

	private Button GetButton(int idx)
	{
		return _viewModel.UI.Get<Button>($"selectButton{idx.ToString()}");
	}

	private void ClickSelect1(GameObject go, BaseEventData data)
	{
		if (CanOpenSkillPanel())
		{
			_messageContext.pveUIMessage.SelectSkillPanel = 1;
		}
		_viewModel.pvetdbuyweaponShow = false;
	}

	private void ClickSelect2(GameObject go, BaseEventData data)
	{
		_viewModel.pvetdbuyweaponShow = false;
		_messageContext.pveUIMessage.SelectSkillPanel = 2;
		ProtoIntData protoIntData = new ProtoIntData();
		protoIntData.Data = UiIEventCondition.Get_pveUIMessage_SelectSkillPanel();
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(16, protoIntData);
	}

	private void ClickSelect3(GameObject go, BaseEventData data)
	{
		_viewModel.pvetdbuyweaponShow = false;
		_messageContext.pveUIMessage.SelectSkillPanel = 3;
		ProtoIntData protoIntData = new ProtoIntData();
		protoIntData.Data = UiIEventCondition.Get_pveUIMessage_SelectSkillPanel();
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(16, protoIntData);
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	private bool CanOpenSkillPanel()
	{
		if (Contexts.sharedInstance.player.myPlayerEntity.GetPlayerInfo().Lv >= 1)
		{
			return true;
		}
		_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("CANNOTOPEN_SKILLTREE"));
		NotifyManager.ForceInvoke(38);
		return false;
	}

	private void OnVisible()
	{
		bool num = _messageContext.pveUIMessage.MsgId == 22;
		bool flag = _messageContext.pveUIMessage.SelectSkillPanel == 1;
		if (num)
		{
			if (_viewModel.pvetdbuyweaponShow)
			{
				_viewModel.pvetdbuyweaponShow = false;
				if (CanOpenSkillPanel())
				{
					_messageContext.pveUIMessage.SelectSkillPanel = 1;
				}
				else
				{
					_messageContext.pveUIMessage.SelectSkillPanel = -1;
				}
			}
			else
			{
				if (!flag)
				{
					_viewModel.pvetdbuyweaponShow = true;
				}
				_messageContext.pveUIMessage.SelectSkillPanel = -1;
			}
		}
		else
		{
			_viewModel.pvetdbuyweaponShow = false;
			if (flag)
			{
				_messageContext.pveUIMessage.SelectSkillPanel = -1;
			}
			else if (CanOpenSkillPanel())
			{
				_messageContext.pveUIMessage.SelectSkillPanel = 1;
			}
		}
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.P)
		{
			int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
			if (RuleUtilty.IsPveModel(raceType) && !RuleUtilty.IsGeneralPve(raceType))
			{
				OnVisible();
				return true;
			}
		}
		else
		{
			if (key.CheckEqualKeyCode(KeyCode.Alpha1) && _viewModel.pvetdbuyweaponShow)
			{
				ClickSelect1(null, null);
				return true;
			}
			if (key.CheckEqualKeyCode(KeyCode.Alpha2) && _viewModel.pvetdbuyweaponShow)
			{
				if (GetButton(2).interactable)
				{
					ClickSelect2(null, null);
					return true;
				}
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha3) && _viewModel.pvetdbuyweaponShow && GetButton(3).interactable)
			{
				ClickSelect3(null, null);
				return true;
			}
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		if (key == KeyCode.P)
		{
			int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
			if (RuleUtilty.IsPveModel(raceType) && !RuleUtilty.IsGeneralPve(raceType))
			{
				return true;
			}
		}
		else
		{
			if ((key == KeyCode.Alpha1 || key == KeyCode.Keypad1) && _viewModel.pvetdbuyweaponShow)
			{
				return true;
			}
			if ((key == KeyCode.Alpha2 || key == KeyCode.Keypad2) && _viewModel.pvetdbuyweaponShow)
			{
				if (GetButton(2).interactable)
				{
					return true;
				}
			}
			else if ((key == KeyCode.Alpha3 || key == KeyCode.Keypad3) && _viewModel.pvetdbuyweaponShow && GetButton(3).interactable)
			{
				return true;
			}
		}
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}
}
