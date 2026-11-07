using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Pve;
using Assets.Sources.Utils.UIChip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Pve;

public class PveStarsModel : UIUpdateModel
{
	private PvestarsViewModel _viewModel;

	private Vector2Chip _effectChip = new Vector2Chip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PvestarsViewModel();
	}

	public override void OnPlayback()
	{
		base.OnPlayback();
		if (_viewModel.IsInited && _effectChip.IsOver)
		{
			_viewModel.stareffectShow = false;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.GetPlayerStar, ForceUpdateNum);
	}

	protected override void OnGameobjectDestoryed()
	{
		base.OnGameobjectDestoryed();
		NotifyManager.RemoveUnused();
	}

	private void InitChips()
	{
		_effectChip.Start = new Vector2((float)(-Screen.width) / 2f, 0f);
		_effectChip.Target = new Vector2(-86f, 115.8f);
		_effectChip.Time = 300f;
	}

	protected override void GameUpdate(int frameInterval)
	{
		if (_viewModel.stareffectShow)
		{
			_viewModel.stareffectAnchoredposition = _effectChip.Update(frameInterval);
		}
	}

	private void PlayEffectAnim()
	{
		_viewModel.stareffectShow = true;
		_effectChip.Time = 300f;
	}

	private void ForceUpdateNum(int old, int val)
	{
		_viewModel.StarnumString = val.ToString();
		PlayEffectAnim();
	}
}
