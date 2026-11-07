using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Finalbio;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.FinalBio;

public class FinalBioDecisiveBattleModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext
{
	public static int UltimateTime = 45000;

	public const int Waitultimatetime = 55000;

	private FinalbiodecisivebattleViewModel _viewModel;

	private BattleRoomContext _batleRoomContext;

	public static int humanityCount = 0;

	private int _variantsCount;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_batleRoomContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new FinalbiodecisivebattleViewModel();
	}

	public void OnPlayback()
	{
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Passed, SetPassed, null, initinvoke: true);
		NotifyManager.MakeNotifyClass(19, UiIEventCondition.Get_allKillInfo_All, SetAll, initinvoke: true);
		if (RuleUtilty.IsBioEvoLutionMode(UiIEventCondition.Get_uiRoomData_RaceType()))
		{
			UltimateTime = 60000;
		}
	}

	private void SetPassed(int ov, int Passed)
	{
		if (RuleUtilty.IsBioEvoLutionMode(UiIEventCondition.Get_uiRoomData_RaceType()) && humanityCount == 0)
		{
			_viewModel.TopShow = false;
			return;
		}
		long num = _batleRoomContext.sectionTime.SectionTime;
		if (num <= UltimateTime && num >= 0)
		{
			if (!_viewModel.TopShow)
			{
				_viewModel.TopShow = true;
				SetAll(null, UiIEventCondition.Get_allKillInfo_All());
			}
			_viewModel.UltimateTimeTextString = StringCache.IntToStringD2((int)(num / 1000));
		}
		else
		{
			_viewModel.TopShow = false;
		}
	}

	private void SetAll(List<OneKillInfoData> ov, List<OneKillInfoData> all)
	{
		humanityCount = 0;
		_variantsCount = 0;
		for (int num = all.Count - 1; num >= 0; num--)
		{
			if (!all[num].IsDead)
			{
				if (PlayerCareerConstantUtility.IsHero(all[num].Career))
				{
					humanityCount++;
				}
				else if (PlayerCareerConstantUtility.IsEmpress(all[num].Career) || PlayerCareerConstantUtility.IsDoun(all[num].Career))
				{
					_variantsCount++;
				}
			}
		}
		if (_viewModel.TopShow)
		{
			_viewModel.HeroTextString = StringCache.IntToString(humanityCount);
			_viewModel.EmpressTextString = StringCache.IntToString(_variantsCount);
		}
	}

	private void InitChips()
	{
	}
}
