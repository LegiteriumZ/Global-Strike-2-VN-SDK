using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.BioChemical_Z;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using SSJJNetworking.BattleServer;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BioChemical_Z;

[GameUiTest]
public class BioChemical_ZBtnListModel : AbstractModel, IKeyboardResponder, IPlaybackSystem
{
	private BioChemical_ZBtnListViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BioChemical_ZBtnListViewModel();
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotifyClass(125, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
		NotifyManager.MakeNotifyClass(126, UiIEventCondition.Get_gameBioZ_DiffWeaponEvent, SetBioZDiffWeaponEvent);
		for (int i = 1; i < 6; i++)
		{
			_viewModel.SetbtnIconShow(i, value: false);
		}
	}

	protected virtual void SetBioZDiffWeaponEvent(NBioZDiffWeaponData ov, NBioZDiffWeaponData biozData)
	{
		Contexts.sharedInstance.message.bioZInit.bioz_show_shop = true;
	}

	private void InitChips()
	{
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			bool flag = false;
			if (tipsEvent[i].TypeId == -13520)
			{
				_viewModel.btnIconShow1 = tipsEvent[i].Show;
				_viewModel.SkillCountString = tipsEvent[i].Time1.ToString();
				flag = true;
			}
			else if (tipsEvent[i].TypeId == -13521)
			{
				_viewModel.btnIconShow3 = tipsEvent[i].Show;
				if (!tipsEvent[i].Show)
				{
					Contexts.sharedInstance.message.bioZInit.bioz_show_shop = false;
				}
				flag = true;
			}
			else if (tipsEvent[i].TypeId == -13522)
			{
				flag = true;
				_viewModel.btnIconShow2 = tipsEvent[i].Show;
			}
			else if (tipsEvent[i].TypeId == -13526)
			{
				flag = true;
				_viewModel.btnIconShow5 = tipsEvent[i].Show;
			}
			else if (tipsEvent[i].TypeId == -13527)
			{
				flag = true;
				_viewModel.btnIconShow4 = tipsEvent[i].Show;
			}
			if (flag)
			{
				tipsEvent.RemoveAt(i);
				i--;
			}
		}
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.V)
		{
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(143);
		}
		else if (key == KeyCode.P)
		{
			if (!Contexts.sharedInstance.message.bioZInit.playerSkilltShow)
			{
				Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(144);
			}
			else
			{
				Contexts.sharedInstance.message.bioZInit.playerSkilltShow = false;
			}
		}
		else if (key == KeyCode.M && !Contexts.sharedInstance.message.bioZInit.playerSelectShow && _viewModel.btnIconShow2)
		{
			if (Contexts.sharedInstance.message.bioZInit.playerSelectShow)
			{
				Contexts.sharedInstance.message.bioZInit.playerSelectShow = false;
			}
			else
			{
				Contexts.sharedInstance.message.bioZInit.playerSelectShow = true;
			}
		}
		else if (key == KeyCode.B && (_viewModel.btnIconShow3 || Contexts.sharedInstance.message.bioZInit.bioz_show_shop))
		{
			if (!Contexts.sharedInstance.message.bioZInit.bioz_show_shop)
			{
				IBattleServer server = Contexts.sharedInstance.battleServer.battleServer.Server;
				IntData message = new IntData
				{
					Data = 1
				};
				server.SendTcpMessage(146, message);
			}
			else
			{
				Contexts.sharedInstance.message.bioZInit.bioz_show_shop = false;
			}
		}
		else if (key == KeyCode.L && _viewModel.btnIconShow4 && !Contexts.sharedInstance.message.bioZInit.playerSkilltShow)
		{
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(142);
		}
		else if (key == KeyCode.N && _viewModel.btnIconShow5)
		{
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(145);
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

	public void OnPlayback()
	{
	}
}
