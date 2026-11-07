using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.UiFramework.Libs;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Biochemical;

public class BiochemicalHumanityGrowUpModel : AbstractModel, IPlaybackSystem
{
	private const int MaxCount = 10;

	private readonly BiochemicalhumanitygrowupViewModel _viewModel = new BiochemicalhumanitygrowupViewModel();

	private bool _isHumanity;

	private bool _isDead;

	protected override IUiViewModel ViewModel => _viewModel;

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_uiMyPlayer_Career, SetCareer, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Passed, SetPassed, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiMyPlayer_IsDead, SetIsDead, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_humanityGrowUp_GrowUpLevel, SetGrowUpLevel, null, initinvoke: true);
	}

	private void SetCareer(string ov, string career)
	{
		_isHumanity = PlayerCareerConstantUtility.IsHumanity(career);
	}

	private void SetIsDead(bool ov, bool isDead)
	{
		_isDead = isDead;
	}

	private void SetPassed(int ov, int passed)
	{
		_viewModel.BottomShow = _isHumanity && !_isDead && !IsOnGameStart(passed);
	}

	private void SetGrowUpLevel(int ov, int level)
	{
		for (int i = 0; i < 10; i++)
		{
			_viewModel.SetPointImageShow(i + 1, i < level);
		}
		_viewModel.HeadImageShow = level >= 10;
		UpdateHeroText(level);
	}

	protected virtual void UpdateHeroText(int level)
	{
		_viewModel.HeroTextString = ScriptLocalization.Get("AttackBonusPercentage") + (100 + level * 20) + "%";
	}

	public void OnPlayback()
	{
	}

	private bool IsOnGameStart(int passed)
	{
		if (15000 - passed > 0)
		{
			return true;
		}
		return false;
	}
}
