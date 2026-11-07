using System.Collections.Generic;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.Biochemical;

public class BiochemicalDecisiveBattleModel : AbstractModel, IPlaybackSystem
{
	private BiochemicaldecisivebattleViewModel _viewModel = new BiochemicaldecisivebattleViewModel();

	protected override IUiViewModel ViewModel => _viewModel;

	public void OnPlayback()
	{
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotifyClass(19, UiIEventCondition.Get_allKillInfo_All, SetAll, initinvoke: true);
	}

	private void SetAll(List<OneKillInfoData> ov, List<OneKillInfoData> list)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (!list[i].IsDead)
			{
				if (PlayerCareerConstantUtility.IsHero(list[i].Career))
				{
					num++;
				}
				else if (PlayerCareerConstantUtility.IsEmpress(list[i].Career) || PlayerCareerConstantUtility.IsDoun(list[i].Career))
				{
					num2++;
				}
			}
		}
		_viewModel.TopShow = num > 0;
		if (num > 0)
		{
			_viewModel.HeroTextString = StringCache.IntToString(num);
			_viewModel.EmpressTextString = StringCache.IntToString(num2);
		}
	}
}
