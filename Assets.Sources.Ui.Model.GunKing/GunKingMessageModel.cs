using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.GunKing;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.GunKing;

public class GunKingMessageModel : AbstractModel, IPlaybackSystem
{
	private GunKingMessageViewModel _viewModel;

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
		_viewModel = new GunKingMessageViewModel();
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
		NotifyManager.MakeNotify(23, UiIEventCondition.Get_gunKingMessageData_Type, SetType, initinvoke: true);
	}

	private void SetType(int ov, int type)
	{
		_viewModel.MessageSprite = base.Loader.RetriveSprite("ui/gunkingmodel", "Assets/Res/Assets/ui/GameGUIRes/gunkingModel/message/phase" + type + ".png", delegate(Sprite sprite)
		{
			_viewModel.MessageSprite = sprite;
		});
		_centerActiveChip.Time = 2000;
	}

	private void InitChips()
	{
		_centerActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.CenterShow = _centerActiveChip.Update(_timeComponent);
	}
}
