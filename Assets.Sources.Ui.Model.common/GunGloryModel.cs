using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class GunGloryModel : AbstractModel, IPlaybackSystem
{
	private GunGloryViewModel _viewModel;

	private FrameAnimaChip[] _animaChips;

	private ActiveChip _activeChip;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new GunGloryViewModel();
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
		_viewModel.ShowShow = false;
		NotifyManager.MakeNotifyClass(40, UiIEventCondition.Get_killPlayerInfo_GunGloryList, SetGunGloryList, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_killPlayerInfo_GunGloryDelayShow, SetGunGloryDelayShow, null, initinvoke: true);
	}

	private void SetGunGloryDelayShow(int ov, int time)
	{
		if (time > 0)
		{
			_activeChip.Time = 0;
		}
	}

	private void SetGunGloryList(List<int> ov, List<int> gunGloryList)
	{
		if (gunGloryList.Count <= 0)
		{
			return;
		}
		int j;
		for (j = 0; j < gunGloryList.Count; j++)
		{
			int i1 = j;
			base.Loader.RetriveSprite("ui/halfloadedres/gunglory", "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/gunglory/" + gunGloryList[j] + ".png", delegate(Sprite sprite)
			{
				_viewModel.SetGlorySprite(i1 + 1, sprite);
			});
			_viewModel.SetGloryShow(j + 1, value: true);
			_viewModel.SetEffectShow(j + 1, value: true);
		}
		for (; j < 3; j++)
		{
			_viewModel.SetGloryShow(j + 1, value: false);
			_viewModel.SetEffectShow(j + 1, value: false);
		}
		_activeChip.Time = 3000;
	}

	private void InitChips()
	{
		_animaChips = new FrameAnimaChip[4];
		for (int i = 1; i < _animaChips.Length; i++)
		{
			_animaChips[i] = new FrameAnimaChip
			{
				Path = "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/gunglory/effect",
				Delay = 100,
				Count = 7,
				IsLoop = true
			};
			_animaChips[i].Init();
		}
		_activeChip = new ActiveChip();
	}

	private void UpdateChips()
	{
		_viewModel.ShowShow = _activeChip.Update(_timeComponent);
		if (!_viewModel.ShowShow)
		{
			return;
		}
		for (int j = 1; j < _animaChips.Length; j++)
		{
			if (!_viewModel.GetEffectShow(j))
			{
				continue;
			}
			_animaChips[j].Update(_timeComponent);
			if (_animaChips[j].Changed)
			{
				int i1 = j;
				base.Loader.RetriveSprite("ui/halfloadedres/gunglory", _animaChips[j].Value, delegate(Sprite sprite)
				{
					_viewModel.SetEffectSprite(i1, sprite);
				});
			}
		}
	}
}
