using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.PveCommon;
using NetData;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.PveCommon;

public class PveAllKillInfoCellModel : CommonIndividualScoreCellModel
{
	private PveAllKillInfoCellViewModel _extraViewModel;

	public override void Initialize()
	{
		_extraViewModel = new PveAllKillInfoCellViewModel();
		base.Initialize();
	}

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/pvecommon";
		_viewModel.ResourceAssetName = "PveAllKillInfoCell";
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_extraViewModel.CreateBinding(_viewModel.ViewGameObject);
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = StringCache.IntToString(data.KillNum);
		_viewModel.PlayerScoreString2 = StringCache.IntToString(data.KnifeKill);
		_viewModel.PlayerScoreString4 = StringCache.IntToString(data.Lv);
		bool[] shows = new bool[6];
		ConvertLargeNummber(data.Score, ref shows, out var wholeStr, out var decimalStr);
		LargeNumberPosition(shows[0], data.Score >= 10000, wholeStr, decimalStr, out var positions, Vector2.zero);
		_extraViewModel.SetScoreShowLargenumber(shows);
		_extraViewModel.SetScorePosiLargenumber(positions);
		_extraViewModel.SetScoreTextLargenumber(wholeStr, decimalStr);
	}

	protected override void LargeNumberPosition(bool usingDot, bool usingSuffix, string wholeStr, string decimalStr, out Vector3[] positions, Vector2 offset)
	{
		float num = 4f;
		float num2 = (usingDot ? 197f : (usingSuffix ? 203f : 209f));
		float num3 = (usingDot ? 22f : 11f);
		int num4 = wholeStr.Length - 1;
		positions = new Vector3[7]
		{
			new Vector3(num2 + offset.x, 5f + offset.y),
			new Vector3(5.5f + (float)num4 * num, -8.5f),
			new Vector3(11f + (float)num4 * num, 0f),
			new Vector3(num3 + (float)num4 * num, -4.5f),
			new Vector3(num3 + (float)num4 * num, -4.5f),
			new Vector3(num3 + (float)num4 * num, -4.5f),
			new Vector3(num3 + (float)num4 * num, -4.5f)
		};
	}

	protected override int UpdateHonoray(OneKillInfoData data)
	{
		int index = 1;
		index = SetHonoray(data.Ace, index, ref CommonIndividualScoreCellModel.AceAsset);
		index = SetHonoray(data.Ace2, index, ref CommonIndividualScoreCellModel.Ace2Asset);
		index = SetHonoray(data.Ace3, index, ref CommonIndividualScoreCellModel.Ace3Asset);
		HideHonoray(index);
		return index;
	}
}
