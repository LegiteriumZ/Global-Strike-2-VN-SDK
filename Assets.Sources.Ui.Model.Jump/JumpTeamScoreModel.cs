using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Jump;
using Assets.UiFramework.Libs;
using NetData;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Jump;

public class JumpTeamScoreModel : AbstractModel, IPlaybackSystem, ISetPlayerContext
{
	private JumpteamscoreViewModel _viewModel;

	private PlayerContext _playerContext;

	private string _timeImage;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new JumpteamscoreViewModel();
	}

	private void UpdateAll(List<OneKillInfoData> list)
	{
		if (list == null || !_playerContext.isMyPlayer)
		{
			return;
		}
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		for (int i = 0; i < list.Count; i++)
		{
			OneKillInfoData oneKillInfoData = list[i];
			if (oneKillInfoData.Id != myPlayerEntity.basicInfo.Current.Id)
			{
				continue;
			}
			if (oneKillInfoData.JumpTime > 0)
			{
				_viewModel.MinutesShow = true;
				_viewModel.PenaltyTextShow = true;
				if (_timeImage != "scorestarttime")
				{
					_timeImage = "scorestarttime";
					base.Loader.RetriveSprite("ui/jumpmodel", "Assets/Res/Assets/ui/GameGUIRes/jumpModel/teamscore/scorestarttime.png", delegate(Sprite sprite)
					{
						_viewModel.BackImageSprite = sprite;
					});
				}
				int num = oneKillInfoData.JumpTime / 1000;
				_viewModel.MinutesString = $"{num / 60:D}";
				_viewModel.SecondsString = $"{num % 60:D}";
				_viewModel.MillisecondsString = $"{oneKillInfoData.JumpTime % 1000 / 10:D}";
				_viewModel.PenaltyTextString = oneKillInfoData.AdditionalTime.ToString();
				break;
			}
			if (_timeImage != "nostarttime")
			{
				_timeImage = "nostarttime";
				_viewModel.BackImageSprite = base.Loader.RetriveSprite("ui/jumpmodel", "Assets/Res/Assets/ui/GameGUIRes/jumpModel/teamscore/nostarttime.png", delegate(Sprite sprite)
				{
					_viewModel.BackImageSprite = sprite;
				});
			}
			_viewModel.MinutesShow = false;
			_viewModel.PenaltyTextShow = false;
			break;
		}
	}

	public void OnPlayback()
	{
		UpdateAll(UiIEventCondition.Get_allKillInfo_All());
	}

	private void InitChips()
	{
	}
}
