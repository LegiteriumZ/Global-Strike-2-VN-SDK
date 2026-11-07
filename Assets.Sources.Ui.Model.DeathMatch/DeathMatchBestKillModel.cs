using Assets.Sources.Ui.Model.Common;
using NetData;
using UnityEngine;

namespace Assets.Sources.Ui.Model.DeathMatch;

public class DeathMatchBestKillModel : BestKillModel
{
	protected override void SetLastMvpData(LastMvpData arg1, LastMvpData arg2)
	{
		if (arg2 == null)
		{
			return;
		}
		_viewModel.BestItemShow1 = arg2.KillDataSpecified;
		if (_viewModel.BestItemShow1)
		{
			_viewModel.PlayerNameString1 = arg2.KillPlayerName;
			_viewModel.DataString1 = arg2.KillData.ToString();
			base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/bestplayer/bestkill.png", delegate(Sprite sprite)
			{
				_viewModel.BestItemSprite1 = sprite;
			});
		}
		_viewModel.BestItemShow2 = arg2.DamageDataSpecified;
		if (_viewModel.BestItemShow2)
		{
			_viewModel.PlayerNameString2 = arg2.DamagePlayerName;
			_viewModel.DataString2 = arg2.DamageData.ToString();
			base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/bestplayer/bestdamage.png", delegate(Sprite sprite)
			{
				_viewModel.BestItemSprite2 = sprite;
			});
		}
		_viewModel.BestItemShow3 = arg2.ReliveDataSpecified;
		if (_viewModel.BestItemShow3)
		{
			_viewModel.PlayerNameString3 = arg2.RelivePlayerName;
			_viewModel.DataString3 = arg2.ReliveData.ToString();
			base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/bestplayer/bestrelive.png", delegate(Sprite sprite)
			{
				_viewModel.BestItemSprite3 = sprite;
			});
		}
		_viewModel.BestItemShow4 = false;
		_viewModel.ShowShow = _viewModel.BestItemShow1 || _viewModel.BestItemShow2 || _viewModel.BestItemShow3 || _viewModel.BestItemShow4;
		base.ShowActiveChip.Time = (_viewModel.ShowShow ? 10000 : 0);
	}
}
