using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.AcgCommon;
using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Modules.Ui.NewMode;

public class Acg_WarMode : BaseUiMode
{
	public Acg_WarMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem<MenuModel>();
		AddPlaybackSystem<ReportModel>();
		AddPlaybackSystem<ReportAlertModel>();
		AddPlaybackSystem<HowToPlayModel>();
		AddPlaybackSystem<AceReportModel>();
		AddPlaybackSystem<McGameSettingModel>();
		AddPlaybackSystem<MiniMapModel>();
		AddPlaybackSystem<AntiAddictionModel>();
		AddPlaybackSystem<BeingHitModel>();
		AddPlaybackSystem<AcgPlayerStatusBoardModel>();
		AddPlaybackSystem<AcgWeaponStatusBoardModel>();
		AddPlaybackSystem<AcgEnemyStatusBoardModel>();
		AddPlaybackSystem<AcgTeamStatusBoardModel>();
		AddPlaybackSystem<AcgSkillBoardModel>();
		AddPlaybackSystem<CommonCrossModel>();
		AddPlaybackSystem<HitCrossModel>();
		AddPlaybackSystem<AcgPowerUpCoinBoardModel>();
		AddPlaybackSystem<AcgTradeWindowModel>();
		AddPlaybackSystem<AcgPowerUpWindowModel>();
		AddPlaybackSystem<AcgTabWindowModel>();
		AddPlaybackSystem<AcgInstructionWindowModel>();
		AddPlaybackSystem<AcgDamageRankBoardModel>();
		AddPlaybackSystem<AcgMessageBoardModel>();
		AddPlaybackSystem<AcgTextNotificationBoardModel>();
		AddPlaybackSystem<AcgQuestBoardModel>();
		AddPlaybackSystem<AcgStateProgressModel>();
	}

	protected override bool IsMatchMode(int racetype)
	{
		return racetype == 200000;
	}
}
