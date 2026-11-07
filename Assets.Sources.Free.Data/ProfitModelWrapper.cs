using System.Collections.Generic;
using NetData;

namespace Assets.Sources.Free.Data;

public class ProfitModelWrapper
{
	private ProfitModel profitModel;

	private bool _changed;

	public bool changed
	{
		get
		{
			return _changed;
		}
		set
		{
			_changed = value;
		}
	}

	public int totalExp => profitModel.totalExp;

	public int totalExpPer => profitModel.totalExpPer;

	public int totalGp => profitModel.totalGp;

	public int totalGpPer => profitModel.totalGpPer;

	public int totalCrystal => profitModel.totalCrystal;

	public List<int> expPlusList => profitModel.expPlusList;

	public List<int> gpPlusList => profitModel.gpPlusList;

	public int totalAllExp => profitModel.totalAllExp;

	public int totalAllGp => profitModel.totalAllGp;

	public ProfitModel GetProfitModel()
	{
		return profitModel;
	}

	public ProfitModelWrapper()
	{
		profitModel = new ProfitModel();
	}

	public void profitDataChanged(ExpData expData)
	{
		_changed = true;
		profitModel.totalExp = expData.BaseExp;
		profitModel.totalGp = expData.BaseGp;
		profitModel.totalCrystal = expData.WhiteCrystalNum;
		profitModel.expPlusList.Clear();
		profitModel.expPlusList.Add(expData.BattleAddExp);
		profitModel.expPlusList.Add(expData.HeroWeaponAddExp);
		profitModel.expPlusList.Add(expData.AdvancedExpCardAddExp);
		profitModel.expPlusList.Add(expData.PrimaryExpCardAddExp);
		profitModel.expPlusList.Add(expData.TeamAndFriendAddExp);
		profitModel.expPlusList.Add(expData.DecorationAddExp);
		profitModel.expPlusList.Add(expData.VipAddExpRatio);
		profitModel.gpPlusList.Clear();
		profitModel.gpPlusList.Add(expData.BattleAddGp);
		profitModel.gpPlusList.Add(expData.HeroWeaponAddGp);
		profitModel.gpPlusList.Add(expData.AdvancedGpCardAddGp);
		profitModel.gpPlusList.Add(expData.PrimaryGpCardAddGp);
		profitModel.totalExpPer = 100;
		profitModel.totalGpPer = 100;
		int num = 0;
		for (num = 0; num < profitModel.expPlusList.Count; num++)
		{
			profitModel.totalExpPer += profitModel.expPlusList[num];
		}
		for (num = 0; num < profitModel.gpPlusList.Count; num++)
		{
			profitModel.totalGpPer += profitModel.gpPlusList[num];
		}
		profitModel.totalAllExp = (int)((double)(profitModel.totalExp * profitModel.totalExpPer) * 0.01);
		profitModel.totalAllGp = (int)((double)(profitModel.totalGp * profitModel.totalGpPer) * 0.01);
	}
}
