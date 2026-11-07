using System.Collections.Generic;
using Assets.Sources.Components.Time;
using NetData;

public class rpgStralExpertModelRpgStralExpertMaterialProvider : IrpgStralExpertModelRpgStralExpertMaterialProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private List<int> _countList;

	public rpgStralExpertModelRpgStralExpertMaterialProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_countList = new List<int> { 0, 0, 0, 0 };
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float getCount(int index)
	{
		MaterialsData materialData = _gameRuleContext.rpgCommon.MaterialData;
		if (materialData == null)
		{
			return 0f;
		}
		return index switch
		{
			0 => materialData.HoldNum, 
			1 => materialData.MaxHoldNum, 
			2 => materialData.SubmitNum, 
			3 => materialData.MaxSubmitNum, 
			_ => 0f, 
		};
	}
}
