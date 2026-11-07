using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Biochemical;

public class BiochemicalHeroKillDamageModel : AbstractModel, IPlaybackSystem
{
	private BiochemicalherokilldamageViewModel _viewModel;

	private ActiveChip _panelActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotify(57, UiIEventCondition.Get_bioDamageScoreData_HeroDamageScore, SetHeroDamageScore, initinvoke: true);
	}

	private void SetHeroDamageScore(int ov, int score)
	{
		if (score != 0)
		{
			if (PlayerCareerConstantUtility.IsHumanity(UiIEventCondition.Get_cameraOwnerData_Career()))
			{
				_panelActiveChip.Time = 0;
				return;
			}
			_panelActiveChip.Time = 1000;
			_viewModel.NumberString = "-" + score;
		}
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BiochemicalherokilldamageViewModel();
	}

	public void OnPlayback()
	{
		UpdateChips();
	}

	private void InitChips()
	{
		_panelActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.PanelShow = _panelActiveChip.Update(_timeComponent);
	}
}
