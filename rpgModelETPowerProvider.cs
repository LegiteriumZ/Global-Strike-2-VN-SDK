using System;
using System.Collections.Generic;
using Assets.Sources.Components.Time;
using NetData;
using NotifyEvent;

public class rpgModelETPowerProvider : IrpgModelETPowerProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerEntity;

	private List<SimpleBuffData> buffList = new List<SimpleBuffData>();

	public rpgModelETPowerProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerEntity = contexts.player;
		NotifyManager.MakeNotifyClass(119, GetTipsList, SetTipsEvent, initinvoke: true);
	}

	public List<SimpleBuffDiffData> GetTipsList()
	{
		return Contexts.sharedInstance.message.heroFightingBuffShow.BuffEvent;
	}

	protected virtual void SetTipsEvent(List<SimpleBuffDiffData> ov, List<SimpleBuffDiffData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			for (int j = 0; j < tipsEvent[i].UpdateBuffList.Count; j++)
			{
				SimpleBuffData simpleBuffData = tipsEvent[i].UpdateBuffList[j];
				if (simpleBuffData.Type != 1)
				{
					continue;
				}
				bool flag = true;
				for (int k = 0; k < buffList.Count; k++)
				{
					if (buffList[k].Id == simpleBuffData.Id)
					{
						buffList[k] = simpleBuffData;
						flag = false;
					}
				}
				if (flag)
				{
					buffList.Add(simpleBuffData);
				}
			}
			for (int l = 0; l < tipsEvent[i].DeleteIdList.Count; l++)
			{
				int num = tipsEvent[i].DeleteIdList[l];
				for (int m = 0; m < buffList.Count; m++)
				{
					if (buffList[m].Id == num)
					{
						buffList.RemoveAt(m);
						m--;
					}
				}
			}
		}
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool SetShow(int index)
	{
		if (buffList.Count > index)
		{
			return true;
		}
		return false;
	}

	public string SetImage(int index)
	{
		if (buffList.Count > index)
		{
			return "/ui/GameGUIRes/halfLoadedRes/rpgETBuff/" + buffList[index].BuffId;
		}
		return "";
	}

	public string SetValue(int index)
	{
		if (buffList.Count > index && GetCDTimer(index) > 0f)
		{
			return buffList[index].Cnt.ToString();
		}
		return "";
	}

	public bool GetFrameShow(int index)
	{
		if (buffList.Count > index)
		{
			SimpleBuffData simpleBuffData = buffList[index];
			int snapsotServerTime = _playerEntity.myPlayerEntity.basicInfo.SnapsotServerTime;
			if (simpleBuffData.NextCanUseTime > 0 && Math.Abs(simpleBuffData.NextCanUseTime - snapsotServerTime) < 500)
			{
				return true;
			}
		}
		return false;
	}

	public bool GetNumShow(int index)
	{
		if (buffList.Count > index && GetCDTimer(index) > 0f && buffList[index].Cnt > 0)
		{
			return true;
		}
		return false;
	}

	public float GetCDTimer(int index)
	{
		if (buffList.Count > index)
		{
			SimpleBuffData simpleBuffData = buffList[index];
			return (float)(_playerEntity.myPlayerEntity.basicInfo.SnapsotServerTime - simpleBuffData.StartTime) / ((float)simpleBuffData.Duration * 1f);
		}
		return 0f;
	}

	public string GetCDTimerDes(int index)
	{
		if (buffList.Count > index)
		{
			SimpleBuffData simpleBuffData = buffList[index];
			int snapsotServerTime = _playerEntity.myPlayerEntity.basicInfo.SnapsotServerTime;
			if (simpleBuffData.StartTime + simpleBuffData.Duration > snapsotServerTime)
			{
				return "";
			}
			int num = 1 + (simpleBuffData.NextCanUseTime - snapsotServerTime) / 1000;
			if (simpleBuffData.NextCanUseTime <= 0 || snapsotServerTime > simpleBuffData.NextCanUseTime)
			{
				buffList.RemoveAt(index);
				return "";
			}
			return num + "s";
		}
		return "";
	}
}
