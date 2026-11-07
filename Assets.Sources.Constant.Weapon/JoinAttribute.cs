using System;

namespace Assets.Sources.Constant.Weapon;

public class JoinAttribute : Attribute
{
	public string XmlNodeName { get; set; }

	public bool IsFire { get; set; }

	public bool BothFire { get; set; }

	public JoinHandType HandType { get; set; }

	public JoinEffectType EffectType { get; set; }

	public int QueueIdx { get; set; }

	public bool IsParticle { get; set; }

	public JoinAttribute()
	{
		IsFire = false;
		QueueIdx = -1;
		HandType = JoinHandType.None;
		EffectType = JoinEffectType.None;
		XmlNodeName = "";
		IsParticle = false;
		BothFire = false;
	}
}
