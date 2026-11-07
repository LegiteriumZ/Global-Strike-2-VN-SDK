using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class SkyDeagleCrossModel : AbstractModel, IPlaybackSystem
{
	private SkyDeagleCrossViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new SkyDeagleCrossViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_SkyDeagleCross, SetSkyDeagleCross, null, initinvoke: true);
		base.Loader.RetriveSprite("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/skillCross/skillcross.png", delegate(Sprite sprite)
		{
			_viewModel.ImageSprite = sprite;
		});
	}

	private void SetSkyDeagleCross(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
