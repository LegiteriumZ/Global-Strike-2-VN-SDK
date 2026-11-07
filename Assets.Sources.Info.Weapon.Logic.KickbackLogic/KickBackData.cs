using System;

namespace Assets.Sources.Info.Weapon.Logic.KickbackLogic;

[Serializable]
public class KickBackData
{
	public float upBase;

	public float lateralBase;

	public float upModifier;

	public float lateralModifier;

	public float upMax;

	public float lateralMax;

	public int directionChang;

	public string toString()
	{
		return upBase + "," + lateralBase + "," + upModifier + "," + lateralModifier + "," + upMax + "," + lateralMax + "," + directionChang;
	}
}
