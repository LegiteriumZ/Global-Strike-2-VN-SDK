using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Personal;
using NetData;

namespace Assets.Sources.Ui.Model.GunKing;

public class GunKingPlayerScoreCellModel : PersonalPlayerScoreCellModel
{
	protected override int UpdateHonoray(OneKillInfoData data)
	{
		int index = 1;
		index = SetHonoray(data.Id == UiIEventCondition.Get_gunKingTeamScoreData_GunkingPlayerId(), index, ref CommonIndividualScoreCellModel.GunkingAsset);
		index = SetHonoray(data.Ace2, index, ref CommonIndividualScoreCellModel.Ace2Asset);
		index = SetHonoray(data.Ace3, index, ref CommonIndividualScoreCellModel.Ace3Asset);
		index = SetHonoray(data.KdKing, index, ref CommonIndividualScoreCellModel.KdKingAsset);
		return SetHonoray(data.Mvp, index, ref CommonIndividualScoreCellModel.MvpAsset);
	}
}
