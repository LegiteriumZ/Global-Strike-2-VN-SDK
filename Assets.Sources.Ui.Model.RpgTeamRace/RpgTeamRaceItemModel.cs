using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.RpgTeamRace;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.RpgTeamRace;

[GameUiTest]
public class RpgTeamRaceItemModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private RpgTeamRaceItemViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgTeamRaceItemViewModel();
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotify(GetTotalBones, SetTotalBones, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetPersonBones, SetPersonBones, null, initinvoke: true);
	}

	private void SetPersonBones(int arg1, int arg2)
	{
		_viewModel.PersonNumString = arg2.ToString();
	}

	private int GetPersonBones()
	{
		return _gameRuleContext.teamRaceUi.PersonBones;
	}

	private void SetTotalBones(int arg1, int arg2)
	{
		_viewModel.GroupNumString = arg2.ToString();
	}

	private int GetTotalBones()
	{
		return _gameRuleContext.teamRaceUi.TotalBones;
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
