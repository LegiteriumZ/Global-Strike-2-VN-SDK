using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.BioChemical_Z;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BioChemical_Z;

[GameUiTest]
public class BioChemical_ZMsglDesModel : AbstractModel, IPlaybackSystem
{
	private BioChemical_ZMsglDesViewModel _viewModel;

	private ActiveChip _tSkillDes = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BioChemical_ZMsglDesViewModel();
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
		NotifyManager.MakeNotifyClass(125, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			if (tipsEvent[i].TypeId != -13533)
			{
				continue;
			}
			if (tipsEvent[i].Time1 >= 0)
			{
				base.Loader.RetriveSprite("ui/biochemical_z", $"Assets/Res/Assets/ui/GameGUIRes/biochemical_z/bgui/{tipsEvent[i].Time1}_bg.png", delegate(Sprite sprite)
				{
					_viewModel.bgSprite = sprite;
					_viewModel.bgShow = true;
				});
			}
			else
			{
				_viewModel.bgShow = false;
			}
			_viewModel.MsgString = tipsEvent[i].Str1;
			_tSkillDes.Time = 3000;
			tipsEvent.RemoveAt(i);
			i--;
		}
	}

	private void InitChips()
	{
		_tSkillDes = new ActiveChip();
	}

	private void UpdateChips(TimeComponent time)
	{
		_viewModel.ShowShow = _tSkillDes.Update(time);
	}
}
