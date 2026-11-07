using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Pve;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Pve;

public class Td5SpidereggnumModel : AbstractModel, IPlaybackSystem
{
	private Td5spidereggnumViewModel _viewModel;

	private ActiveChip _activechip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Td5spidereggnumViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited && UiIEventCondition.Get_pveUIMessage_MaxSpiderEggNum() != 0)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.td5spidereggnumShow = false;
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveUIMessage_CurSpiderEggNum, UpdateEggNum, _viewModel.td5spidereggnumObj);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveUIMessage_MaxSpiderEggNum, UpdateEggMaxNum, _viewModel.td5spidereggnumObj);
		base.Loader.RetriveSprite("ui/lostgravemodel", "Assets/Res/Assets/ui/GameGUIRes/lostGraveModel/message/SpiderEgg.png", delegate(Sprite sprite)
		{
			_viewModel.spidereggbackImgSprite = sprite;
		});
	}

	protected override void OnGameobjectDestoryed()
	{
		base.OnGameobjectDestoryed();
		NotifyManager.RemoveUnused();
	}

	private void InitChips()
	{
		_activechip.Time = 1000;
	}

	private void UpdateChips()
	{
		if (UiIEventCondition.Get_pveUIMessage_CurSpiderEggNum() == UiIEventCondition.Get_pveUIMessage_MaxSpiderEggNum())
		{
			_activechip.Update(_timeComponent);
		}
		_viewModel.td5spidereggnumShow = _activechip.Value;
	}

	private void UpdateEggMaxNum(int old, int val)
	{
		_viewModel.td5spidereggnumShow = true;
		_viewModel.eggnumtxtString = val.ToString();
	}

	private void UpdateEggNum(int old, int val)
	{
		_viewModel.td5spidereggnumShow = true;
		_viewModel.eggdeadnumtxtString = val.ToString();
	}
}
