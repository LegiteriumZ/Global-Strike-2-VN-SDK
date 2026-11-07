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

namespace Assets.Sources.Ui.Model.BioChemical_Z;

[GameUiTest]
public class BioChemical_ZGoldModel : AbstractModel, IPlaybackSystem
{
	private BioChemical_ZGoldViewModel _viewModel;

	public int _userGoldId = 8;

	private ActiveChip[] _goleUpdate = new ActiveChip[8];

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BioChemical_ZGoldViewModel();
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
			if (tipsEvent[i].TypeId != -13524)
			{
				continue;
			}
			if (tipsEvent[i].Time2 != 0)
			{
				_viewModel.Getmoney_Obj(_userGoldId).transform.SetAsLastSibling();
				string text = "";
				text = ((tipsEvent[i].Time2 <= 0) ? $"<color=#ff0a0a>{tipsEvent[i].Time2}</color>" : $"<color=#dfd620>+{tipsEvent[i].Time2}</color>");
				_viewModel.Setmoney_String(_userGoldId, text);
				_goleUpdate[_userGoldId - 1].Time = 3000;
				_userGoldId--;
				if (_userGoldId <= 0)
				{
					_userGoldId = 8;
				}
			}
			_viewModel.moneyString = tipsEvent[i].Time1.ToString();
			Contexts.sharedInstance.message.bioZInit.gold = tipsEvent[i].Time1;
			tipsEvent.RemoveAt(i);
			i--;
		}
	}

	private void InitChips()
	{
		for (int i = 0; i < 8; i++)
		{
			_goleUpdate[i] = new ActiveChip();
		}
	}

	private void UpdateChips(TimeComponent time)
	{
		for (int i = 0; i < 8; i++)
		{
			_viewModel.Setmoney_Show(i + 1, _goleUpdate[i].Update(time));
			_viewModel.Setmoney_Alpha(i + 1, (float)_goleUpdate[i].Time / 3000f);
		}
	}
}
