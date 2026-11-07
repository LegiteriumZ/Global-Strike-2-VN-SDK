using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.RpgKillOther;

[GameUiTest]
public class RpgKillOtherPlayerInfoCellModel : CommonIndividualScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/rpgkillother";
		_viewModel.ResourceAssetName = "RpgKillOtherPlayerInfoCell";
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = data.Score.ToString();
	}

	protected override int UpdateHonoray(OneKillInfoData data)
	{
		return 1;
	}

	protected override void SetHasHeroWeapon(OneKillInfoData val, int idx, bool oldfs, bool newfs, ElementStatus status)
	{
		_viewModel.HeroImageShow = false;
	}
}
