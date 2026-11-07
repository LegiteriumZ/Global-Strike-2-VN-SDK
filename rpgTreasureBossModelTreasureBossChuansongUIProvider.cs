using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Rpg;
using Assets.Sources.Components.Time;
using Assets.Sources.Modules.Ui.UiEventCondition;
using UnityEngine;

public class rpgTreasureBossModelTreasureBossChuansongUIProvider : IrpgTreasureBossModelTreasureBossChuansongUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected BattleServerContext _battleServer;

	protected Vector3 _worldMin = Vector3.zero;

	protected Vector3 _worldMax = Vector3.zero;

	protected float _scaleX = 1f;

	protected float _scaleY = 1f;

	private Dictionary<int, float> pointXDic = new Dictionary<int, float>();

	private Dictionary<int, float> pointYDic = new Dictionary<int, float>();

	public rpgTreasureBossModelTreasureBossChuansongUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_battleServer = contexts.battleServer;
		_worldMin = UiIEventCondition.Get_uiPyEngine_Min();
		_worldMax = UiIEventCondition.Get_uiPyEngine_Max();
		Vector3 vector = _worldMax - _worldMin;
		_scaleX = 550f / vector.x;
		_scaleY = 550f / vector.y;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool checkBtnShow(int index)
	{
		if (!_gameRuleContext.rpgTreasureBossData.hasInitPointData)
		{
			return false;
		}
		return index < _gameRuleContext.rpgTreasureBossData.pointDatas.Count;
	}

	public float updateBtnX(int index)
	{
		if (!_gameRuleContext.rpgTreasureBossData.hasInitPointData)
		{
			return 0f;
		}
		if (index >= _gameRuleContext.rpgTreasureBossData.pointDatas.Count)
		{
			return 0f;
		}
		if (pointXDic.ContainsKey(index))
		{
			return pointXDic[index];
		}
		float num = (_gameRuleContext.rpgTreasureBossData.pointDatas[index].PosX - _worldMin.x) * _scaleX - 15f;
		pointXDic[index] = num;
		return num;
	}

	public float updateBtnY(int index)
	{
		if (!_gameRuleContext.rpgTreasureBossData.hasInitPointData)
		{
			return 0f;
		}
		if (index >= _gameRuleContext.rpgTreasureBossData.pointDatas.Count)
		{
			return 0f;
		}
		if (pointYDic.ContainsKey(index))
		{
			return 0f - pointYDic[index];
		}
		float posY = _gameRuleContext.rpgTreasureBossData.pointDatas[index].PosY;
		float num = 550f - (posY - _worldMin.y) * _scaleY - 22f;
		num = 0f - num;
		pointYDic[index] = num;
		return 0f - num;
	}

	public float btnIconClick(int index)
	{
		if (index >= _gameRuleContext.rpgTreasureBossData.pointDatas.Count)
		{
			return 0f;
		}
		_gameRuleContext.rpgTreasureBossData.showChuansongUI = false;
		ChuansongPointData chuansongPointData = _gameRuleContext.rpgTreasureBossData.pointDatas[index];
		_battleServer.battleServer.Server.SendTcpMessage(153, chuansongPointData.Id);
		return 0f;
	}

	public float hideView()
	{
		_gameRuleContext.rpgTreasureBossData.showChuansongUI = false;
		return 0f;
	}

	public bool checkRootShow()
	{
		return _gameRuleContext.rpgTreasureBossData.showChuansongUI;
	}
}
