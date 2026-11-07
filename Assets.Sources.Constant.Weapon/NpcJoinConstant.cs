using System.Collections.Generic;
using System.Reflection;
using SSJJBase.String;

namespace Assets.Sources.Constant.Weapon;

public class NpcJoinConstant
{
	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "npc_particle_effect", QueueIdx = 1)]
	public const string npc_particle_effect = "npc_particle_effect";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "npc_particle_effect1", QueueIdx = 1)]
	public const string npc_particle_effect1 = "npc_particle_effect1";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "npc_particle_effect2", QueueIdx = 1)]
	public const string npc_particle_effect2 = "npc_particle_effect2";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "npc_particle_effect3", QueueIdx = 1)]
	public const string npc_particle_effect3 = "npc_particle_effect3";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "npc_particle_effect4", QueueIdx = 1)]
	public const string npc_particle_effect4 = "npc_particle_effect4";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "npc_particle_effect5", QueueIdx = 1)]
	public const string npc_particle_effect5 = "npc_particle_effect5";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "npc_particle_effect6", QueueIdx = 1)]
	public const string npc_particle_effect6 = "npc_particle_effect6";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "npc_particle_effect7", QueueIdx = 1)]
	public const string npc_particle_effect7 = "npc_particle_effect7";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "npc_particle_effect8", QueueIdx = 1)]
	public const string npc_particle_effect8 = "npc_particle_effect8";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "npc_particle_effect9", QueueIdx = 1)]
	public const string npc_particle_effect9 = "npc_particle_effect9";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "npc_particle_effect10", QueueIdx = 1)]
	public const string npc_particle_effect10 = "npc_particle_effect10";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "npc_particle_effect11", QueueIdx = 1)]
	public const string npc_particle_effect11 = "npc_particle_effect11";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "npc_particle_effect12", QueueIdx = 1)]
	public const string npc_particle_effect12 = "npc_particle_effect12";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "npc_particle_effect13", QueueIdx = 1)]
	public const string npc_particle_effect13 = "npc_particle_effect13";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "npc_particle_effect14", QueueIdx = 1)]
	public const string npc_particle_effect14 = "npc_particle_effect14";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "npc_particle_effect15", QueueIdx = 1)]
	public const string npc_particle_effect15 = "npc_particle_effect15";

	public static Dictionary<IgnoreCaseString, JoinAttribute> JoinsInfo { get; set; }

	static NpcJoinConstant()
	{
		JoinsInfo = new Dictionary<IgnoreCaseString, JoinAttribute>();
		FieldInfo[] fields = typeof(NpcJoinConstant).GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (fieldInfo.FieldType != typeof(string))
			{
				continue;
			}
			string text = fieldInfo.GetRawConstantValue() as string;
			object[] customAttributes = fieldInfo.GetCustomAttributes(inherit: true);
			foreach (object obj in customAttributes)
			{
				if (obj is JoinAttribute)
				{
					JoinAttribute value = (JoinAttribute)obj;
					JoinsInfo[text] = value;
				}
			}
		}
	}
}
