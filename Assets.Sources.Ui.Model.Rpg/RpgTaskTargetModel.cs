using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.UiFramework.Libs;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgTaskTargetModel : AbstractModel, IPlaybackSystem
{
	private RpgTaskTargetViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgTaskTargetViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_rpgTaskTarget_Wave, SetWave, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_rpgTaskTarget_MasteryCoin, SetMasteryCoin, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_rpgTaskTarget_Obsidian, SetObsidian, null, initinvoke: true, isFrameSeparation: true);
	}

	private void SetWave(int ov, int nv)
	{
		_viewModel.WaveTextString = ScriptLocalization.Get("RpgTaskTargetWave").Replace("%d", nv.ToString());
	}

	private void SetMasteryCoin(int ov, int nv)
	{
		_viewModel.RewardString1 = ScriptLocalization.Get("RpgTaskTargetReward0").Replace("%d", nv.ToString());
	}

	private void SetObsidian(int ov, int nv)
	{
		_viewModel.RewardString2 = ScriptLocalization.Get("RpgTaskTargetReward1").Replace("%d", nv.ToString());
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
