using System.Collections.Generic;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Utils;
using NetData;

namespace Assets.Sources.Ui.Model.RpgGroupAnnihilation;

public class RpgAnnihilationMessageModel : RpgMessageModel
{
	private int[] _tips = new int[16]
	{
		-2603, -2604, -2605, -2606, -2607, -2608, -2609, -2610, -2611, -2612,
		-2613, -2614, -2615, -2619, -2620, -2621
	};

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/RpgGroupAnnihilation";
		_viewModel.ResourceAssetName = "RpgAnnihilationMessage";
	}

	private bool CheckIsInTips(int tip)
	{
		for (int i = 0; i < _tips.Length; i++)
		{
			if (_tips[i] == tip)
			{
				return true;
			}
		}
		return false;
	}

	protected override void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null || !_playerContext.isMyPlayer)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			int typeId = tipsEvent[i].TypeId;
			if (!CheckIsInTips(typeId))
			{
				continue;
			}
			int num = 0;
			switch (typeId)
			{
			case -12601:
			case -2523:
			case -2522:
			case -2521:
			case -2520:
			case -2519:
				num = (int)(TimeUtility.UnixTimeNow() - Contexts.sharedInstance.battleRoom.sectionTime.LoadingSuccessTime) + 1000;
				break;
			case -12602:
			case -2526:
			case -2525:
			case -2524:
				if (!_playerContext.myPlayerEntity.basicInfo.Current.CanChangeBag)
				{
					continue;
				}
				num = (int)(TimeUtility.UnixTimeNow() - Contexts.sharedInstance.battleRoom.sectionTime.LoadingSuccessTime) + 1000;
				break;
			}
			ShowMessage(typeId, tipsEvent[i].Time1 - num, tipsEvent[i].Time2, tipsEvent[i].Str1, tipsEvent[i].Str2, !tipsEvent[i].ShowSpecified || tipsEvent[i].Show);
		}
		tipsEvent.Clear();
	}
}
