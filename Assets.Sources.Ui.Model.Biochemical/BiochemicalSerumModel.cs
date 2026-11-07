using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Biochemical;

public class BiochemicalSerumModel : AbstractModel, IPlaybackSystem
{
	private BiochemicalserumViewModel _viewModel = new BiochemicalserumViewModel();

	private PingPongChip[] _animaChips;

	protected override IUiViewModel ViewModel => _viewModel;

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		for (int i = 1; i < _animaChips.Length; i++)
		{
			if (_viewModel.GetItemEffectShow(i))
			{
				_animaChips[i].Update(_timeComponent);
				_viewModel.SetItemEffectAlpha(i, _animaChips[i].Value);
			}
		}
	}

	protected override void DoSubscribe()
	{
		_animaChips = new PingPongChip[4];
		for (int i = 1; i < _animaChips.Length; i++)
		{
			_animaChips[i] = new PingPongChip
			{
				From = 0f,
				To = 1f,
				Time = 1000,
				RunTime = 0
			};
		}
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_BiochemicalSerum, SetBiochemicalSerum, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_BiochemicalMagazineFlag, SetBiochemicalMagazineFlag, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_bioItems_BioItemsData, SetBioItemsData, null, initinvoke: true);
	}

	private void SetBiochemicalMagazineFlag(bool arg1, bool arg2)
	{
		_viewModel.ClipImageShow = arg2;
	}

	private void SetBiochemicalSerum(bool arg1, bool arg2)
	{
		_viewModel.HemicalSerumImageShow = arg2;
	}

	private void SetBioItemsData(BioItemsData ov, BioItemsData data)
	{
		if (data == null)
		{
			_viewModel.ItemBackShow = false;
			return;
		}
		_viewModel.ItemBackShow = data.List.Count > 0;
		int j;
		for (j = 1; j <= data.List.Count; j++)
		{
			BioItemData bioItemData = data.List[j - 1];
			_viewModel.SetItemShow(j, value: true);
			_viewModel.SetItemCountString(j, StringCache.IntToString(bioItemData.Num));
			_viewModel.SetItemKeyString(j, StringCache.IntToString(bioItemData.KeyBorad));
			int i2 = j;
			base.Loader.Load("number", "Assets/Res/Assets/number/" + ((bioItemData.Num < 10) ? 440 : 40) + ".fontsettings", delegate(Object v)
			{
				_viewModel.SetItemCountTextfont(i2, (Font)v);
				_viewModel.SetItemNeedTextfont(i2, (Font)v);
			});
			_viewModel.SetItemEffectShow(j, bioItemData.Active);
			_viewModel.SetItemDisableShow(j, (bioItemData.Disable && !bioItemData.Active) || bioItemData.Num < 10);
			int i1 = j;
			base.Loader.RetriveSprite("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/item/" + bioItemData.ItemId + ".png", delegate(Sprite v)
			{
				_viewModel.SetItemImageSprite(i1, v);
			});
		}
		for (; j <= 3; j++)
		{
			_viewModel.SetItemShow(j, value: false);
		}
	}
}
