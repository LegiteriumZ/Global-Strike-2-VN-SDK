using System.Collections.Generic;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Mechwarrior;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Mechwarrior;

public class MechwarrionDecisiveBattleModel : AbstractModel, IPlaybackSystem
{
	private MechwarrionDecisiveBattleViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new MechwarrionDecisiveBattleViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			if (UiIEventCondition.Get_mechwarriorMessageData_UltimateTime() > 0 && UiIEventCondition.Get_mechwarriorMessageData_IsUltimateTime())
			{
				Contexts.sharedInstance.message.mechwarriorMessageData.UltimateTime -= _timeComponent.FrameInterval;
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_mechwarriorMessageData_UltimateTime, SetUltimateTime, null, initinvoke: true);
		NotifyManager.MakeNotifyClass(19, UiIEventCondition.Get_allKillInfo_All, SetAll, initinvoke: true);
	}

	private void SetAll(List<OneKillInfoData> ov, List<OneKillInfoData> all)
	{
		if (!_viewModel.TopShow)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < all.Count; i++)
		{
			if (!all[i].IsDead && PlayerCareerConstantUtility.IsMech(all[i].Career))
			{
				if (all[i].Team == 1)
				{
					num2++;
				}
				else if (all[i].Team == 2)
				{
					num++;
				}
			}
		}
		if (UiIEventCondition.Get_cameraOwnerData_Team() == 2)
		{
			_viewModel.HeroTextString = num.ToString();
			_viewModel.EmpressTextString = num2.ToString();
		}
		else
		{
			_viewModel.HeroTextString = num2.ToString();
			_viewModel.EmpressTextString = num.ToString();
		}
	}

	private void SetUltimateTime(int ov, int time)
	{
		if (time > 0 && UiIEventCondition.Get_mechwarriorMessageData_IsUltimateTime())
		{
			if (!_viewModel.TopShow)
			{
				SetAll(null, UiIEventCondition.Get_allKillInfo_All());
			}
			_viewModel.TopShow = true;
			_viewModel.UltimateTimeTextString = (time / 1000).ToString();
		}
		else
		{
			_viewModel.TopShow = false;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
