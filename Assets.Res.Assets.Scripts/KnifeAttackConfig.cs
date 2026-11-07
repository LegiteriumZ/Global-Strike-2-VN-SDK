using System;

namespace Assets.Res.Assets.Scripts;

[Serializable]
public class KnifeAttackConfig
{
	public int AnimId;

	public int EffectTime;

	public bool isFrist;

	public int WaitTime;

	public int DoubleLv;

	public int level = -1;

	public int LessLevel = -1;

	public int BigLevel = -1;

	public int EffectLevel;

	public bool Enable(int animId, int weaponlv, int current, int effectLevel)
	{
		if (AnimId == animId && (level == -1 || level == weaponlv) && (LessLevel == -1 || LessLevel > weaponlv) && (BigLevel == -1 || BigLevel < weaponlv) && (EffectLevel == 0 || (effectLevel & (1 << EffectLevel - 1)) > 0) && current > WaitTime && current < WaitTime + EffectTime - 50)
		{
			return true;
		}
		return false;
	}

	public bool CheckAnimEnable(int animId)
	{
		return AnimId == animId;
	}

	public bool FullEnable(int animId, int weapondoublelv, int weaponlv, int current, int effectLevel)
	{
		if (AnimId == animId && DoubleLv == weapondoublelv && (LessLevel == -1 || LessLevel > weaponlv) && (BigLevel == -1 || BigLevel < weaponlv) && (level == -1 || level == weaponlv) && (EffectLevel == 0 || (effectLevel & (1 << EffectLevel - 1)) > 0) && current > WaitTime && current < WaitTime + EffectTime - 50)
		{
			return true;
		}
		return false;
	}
}
