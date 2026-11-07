using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Biochemical;

public class BiochemicalVariantsGrowUpModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private const int MaxCount = 5;

	private readonly BiochemicalvariantsgrowupViewModel _viewModel = new BiochemicalvariantsgrowupViewModel();

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void OnPlayback()
	{
	}

	protected override void DoSubscribe()
	{
		if (_gameRuleContext.currentRule.Rule.IsNewVariantsGrowUp())
		{
			_viewModel.BottomShow = false;
			return;
		}
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_cameraOwnerData_Career, SetCareer, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Level, SetLevel, null, initinvoke: true);
	}

	private void SetCareer(string ov, string career)
	{
		_viewModel.BottomShow = PlayerCareerConstantUtility.IsDoun(career);
	}

	private void SetLevel(int ov, int level)
	{
		for (int i = 0; i < 5; i++)
		{
			_viewModel.SetSlotImageShow(i + 1, i < level);
		}
		_viewModel.HeroTextString = "Lv" + level;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
