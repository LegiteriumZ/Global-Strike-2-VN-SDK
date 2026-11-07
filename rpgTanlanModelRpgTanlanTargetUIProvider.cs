using Assets.Sources.Components.Time;
using UnityEngine;

public class rpgTanlanModelRpgTanlanTargetUIProvider : IrpgTanlanModelRpgTanlanTargetUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public rpgTanlanModelRpgTanlanTargetUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (isTimeTip() && _gameRuleContext.rpgTanlan.targetCurNum > 0)
		{
			_gameRuleContext.rpgTanlan.targetCurNum -= time.FrameInterval;
		}
	}

	public bool checkShow()
	{
		return _gameRuleContext.rpgTanlan.targetShow;
	}

	public string updateLabel()
	{
		return "/ui/GameGUIRes/rpgTanlanModel/Texture/label_" + Mathf.Abs(_gameRuleContext.rpgTanlan.targetTipId);
	}

	public bool checkNumShow()
	{
		if (isTimeTip())
		{
			return true;
		}
		return _gameRuleContext.rpgTanlan.targetTotalNum > 0;
	}

	public float updateCurNum()
	{
		if (isTimeTip())
		{
			return Mathf.CeilToInt((float)_gameRuleContext.rpgTanlan.targetCurNum / 1000f);
		}
		return _gameRuleContext.rpgTanlan.targetCurNum;
	}

	public float updateTotalNum()
	{
		return _gameRuleContext.rpgTanlan.targetTotalNum;
	}

	public bool isTimeTip()
	{
		return _gameRuleContext.rpgTanlan.targetTipId == -141046;
	}
}
