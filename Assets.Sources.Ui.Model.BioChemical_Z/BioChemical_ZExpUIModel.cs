using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.BioChemical_Z;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BioChemical_Z;

[GameUiTest]
public class BioChemical_ZExpUIModel : AbstractModel, IPlaybackSystem, ISetPlayerContext
{
	private BioChemical_ZExpUIViewModel _viewModel;

	private PlayerContext _playerContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BioChemical_ZExpUIViewModel();
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
			if (tipsEvent[i].TypeId == -13525)
			{
				_viewModel.expFillamount = (float)tipsEvent[i].Time1 * 1f / (float)tipsEvent[i].Time2;
				if (Contexts.sharedInstance.message.bioZInit.Level != tipsEvent[i].Time3)
				{
					Contexts.sharedInstance.message.bioZInit.Level = tipsEvent[i].Time3;
				}
				tipsEvent.RemoveAt(i);
				i--;
			}
			else if (tipsEvent[i].TypeId == -13528)
			{
				_viewModel.tyString = tipsEvent[i].Time2.ToString();
				_viewModel.shString = $"+{(tipsEvent[i].Time3 / 1000).ToString()}%";
				tipsEvent.RemoveAt(i);
				i--;
			}
		}
	}

	private void InitChips()
	{
	}

	public void OnPlayback()
	{
		if (_playerContext != null && _playerContext.isMyPlayer)
		{
			Vector3DData velocity = _playerContext.myPlayerEntity.basicInfo.Current.Velocity;
			Vector3 b = new Vector3(velocity.X, velocity.Y, 0f);
			_viewModel.ysString = ((int)Vector3.Distance(Vector3.zero, b)).ToString();
		}
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}
}
