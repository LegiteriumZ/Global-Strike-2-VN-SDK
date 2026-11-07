using Assets.Sources.Ui.Model.Common;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.RpgSurvivalPvp;

public class RpgSurvivalPvpIndividualScoreCellModel : CommonIndividualScoreCellModel
{
	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		base.Listener.AddEvent<OneKillInfoData, int>("Team", GetTeam, SetTeam, base.Index);
	}

	private void SetTeam(OneKillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		_viewModel.PlayerScoreString2 = ((newfs > 0) ? newfs.ToString() : "");
	}

	private int GetTeam(OneKillInfoData val, int idx)
	{
		return val.Team;
	}

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/rpgsurvivalpvp";
		_viewModel.ResourceAssetName = "RpgSurvivalPvpIndividualScoreCell";
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

	protected override void SetVipLevel(OneKillInfoData val, int idx, int oldfs, int level, ElementStatus status)
	{
		_viewModel.VipShow = false;
	}
}
