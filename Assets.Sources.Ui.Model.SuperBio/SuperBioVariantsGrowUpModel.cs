using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Superbio;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.SuperBio;

public class SuperBioVariantsGrowUpModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private const int MaxCount = 5;

	private SuperbiovariantsgrowupViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	private bool _isDoun;

	private bool _checkRaceType;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new SuperbiovariantsgrowupViewModel();
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
		NotifyManager.MakeNotify(5, UiIEventCondition.Get_finalBioMessageData_VariantsGrowupChanged, SetVariantsGrowupChanged, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiRoomData_RaceType, SetRaceType, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_cameraOwnerData_Career, SetCareer, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Level, SetLevel, null, initinvoke: true);
	}

	private void SetLevel(int ov, int level)
	{
		for (int i = 0; i < 5; i++)
		{
			_viewModel.SetSlotImageShow(i + 1, i < level);
		}
		_viewModel.HeroTextString = "Lv" + level;
	}

	private void SetCareer(string ov, string career)
	{
		_isDoun = PlayerCareerConstantUtility.IsDoun(career);
		CheckVisible();
	}

	private void SetRaceType(int ov, int raceType)
	{
		_checkRaceType = !_gameRuleContext.currentRule.Rule.IsNewVariantsGrowUp();
		CheckVisible();
	}

	private void CheckVisible()
	{
		_viewModel.BottomShow = _checkRaceType && _isDoun;
	}

	private void SetVariantsGrowupChanged(bool ov, bool changed)
	{
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
