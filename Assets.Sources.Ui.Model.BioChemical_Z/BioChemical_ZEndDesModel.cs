using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.BioChemical_Z;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BioChemical_Z;

[GameUiTest]
public class BioChemical_ZEndDesModel : AbstractModel, IPlaybackSystem
{
	private BioChemical_ZEndDesViewModel _viewModel;

	private ActiveChip _centerActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BioChemical_ZEndDesViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotifyClass(132, Get_gameBioZ_Event, SetBioZEvent);
		_viewModel.cLevelString1 = ScriptLocalization.Get("BioChemical_Z_CLevel");
		_viewModel.cLevelString2 = ScriptLocalization.Get("BioChemical_Z_CLevel");
		_viewModel.eNumString1 = ScriptLocalization.Get("BioChemical_Z_ENum");
		_viewModel.eNumString2 = ScriptLocalization.Get("BioChemical_Z_ENum");
	}

	public NBioZSessionReport Get_gameBioZ_Event()
	{
		return Contexts.sharedInstance.message.bioZInit.nBioZSession;
	}

	protected virtual void SetBioZEvent(NBioZSessionReport ov, NBioZSessionReport biozData)
	{
		_centerActiveChip.Time = 4000;
		_viewModel.jsString1 = biozData.HumanBest.KillNum.ToString();
		_viewModel.levelString1 = biozData.HumanBest.Lv.ToString();
		_viewModel.nameString1 = biozData.HumanBest.Name;
		base.Loader.RetriveSprite("ui/halfloadedres/pvpplayerstate", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pvpplayerstate/{biozData.HumanBest.Career}.png", delegate(Sprite sprite)
		{
			_viewModel.iconSprite1 = sprite;
		});
		_viewModel.jsString2 = biozData.BioBest.KillNum.ToString();
		_viewModel.levelString2 = biozData.BioBest.Lv.ToString();
		_viewModel.nameString2 = biozData.BioBest.Name;
		base.Loader.RetriveSprite("ui/halfloadedres/pvpplayerstate", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pvpplayerstate/{biozData.BioBest.Career}.png", delegate(Sprite sprite)
		{
			_viewModel.iconSprite2 = sprite;
		});
		_viewModel.winShow = biozData.WinTeam == 1;
		_viewModel.loseShow = biozData.WinTeam == 2;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
		_viewModel.ShowShow = _centerActiveChip.Update(time);
	}
}
