using System.Collections.Generic;
using System.Reflection;
using SSJJBase.String;

namespace Assets.Sources.Constant.Weapon;

public class PlayerJoinConstant
{
	[Join(EffectType = JoinEffectType.None, XmlNodeName = "playereffect", QueueIdx = 1)]
	public const string JOINT_NAME_BOMB = "bomb";

	[Join(EffectType = JoinEffectType.None, XmlNodeName = "playereffect", QueueIdx = 0)]
	public const string JOINT_NAME_PELVIS = "bip01_pelvis";

	[Join(EffectType = JoinEffectType.None, XmlNodeName = "playereffect", QueueIdx = 2)]
	public const string JOINT_NAME_BACKACCESSORY = "backaccessory";

	[Join(EffectType = JoinEffectType.None, XmlNodeName = "zuibaeffect", QueueIdx = 3)]
	public const string JOINT_NAME_ZUIBA = "zuiba";

	[Join(EffectType = JoinEffectType.None, XmlNodeName = "flyeffect", QueueIdx = 4)]
	public const string JOINT_NAME_FLYEFFECT = "flyeffect";

	[Join(EffectType = JoinEffectType.None, XmlNodeName = "weaponanchor", QueueIdx = 5)]
	public const string JOINT_NAME_JIGUANGJIAN = "jiguangjianeffect";

	[Join(EffectType = JoinEffectType.None, XmlNodeName = "jiguangpao", QueueIdx = 6)]
	public const string JOINT_NAME_JIGUANGPAO = "jiguangpao";

	[Join(EffectType = JoinEffectType.None, XmlNodeName = "boss09fireeffect", QueueIdx = 7)]
	public const string JOINT_NAME_BOSS09FIREL = "boss09firel";

	[Join(EffectType = JoinEffectType.None, XmlNodeName = "boss09fireeffect", QueueIdx = 8)]
	public const string JOINT_NAME_BOSS09FIRER = "boss09firer";

	[Join(EffectType = JoinEffectType.None, XmlNodeName = "weaponanchor", QueueIdx = 9)]
	public const string JOINT_NAME_LEFTJIGUANGJIAN = "leftjiguangjian";

	[Join(EffectType = JoinEffectType.None, XmlNodeName = "righteffect1", QueueIdx = 10)]
	public const string JOINT_NAME_RIGHTEFFECT1 = "righteffect1";

	[Join(EffectType = JoinEffectType.None, XmlNodeName = "righteffect2", QueueIdx = 11)]
	public const string JOINT_NAME_RIGHTEFFECT2 = "righteffect2";

	[Join(EffectType = JoinEffectType.None, XmlNodeName = "playereffect", QueueIdx = 12)]
	public const string UV2_HUXI = "uv2_huxi";

	[Join(EffectType = JoinEffectType.None, XmlNodeName = "playereffect", QueueIdx = 13)]
	public const string UV2_LIUGUANG = "uv2_liuguang";

	[Join(EffectType = JoinEffectType.None, XmlNodeName = "playereffect", QueueIdx = 14)]
	public const string UV2_HUXI_PLAYER = "uv2_huxi_player";

	[Join(EffectType = JoinEffectType.None, XmlNodeName = "playereffect", QueueIdx = 15)]
	public const string UV2_LIUGUANG_LOUKONG = "uv2_liuguang_loukong";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "playereffect", QueueIdx = 16)]
	public const string JOINT_NAME_PARTICLE_EFFECT1 = "player_particle_effect1";

	[Join(EffectType = JoinEffectType.None, XmlNodeName = "feixingqieffect", QueueIdx = 17)]
	public const string JOINT_NAME_FEIXINGQI = "feixingqi_texiao";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "playereffect", QueueIdx = 18)]
	public const string JOINT_NAME_PARTICLE_EFFECT2 = "player_particle_effect2";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "playereffect", QueueIdx = 19)]
	public const string JOINT_NAME_PARTICLE_EFFECT3 = "player_particle_effect3";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "playereffect", QueueIdx = 20)]
	public const string JOINT_NAME_PARTICLE_EFFECT4 = "player_particle_effect4";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "playereffect", QueueIdx = 21)]
	public const string JOINT_NAME_PARTICLE_EFFECT5 = "player_particle_effect5";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "playereffect", QueueIdx = 22)]
	public const string JOINT_NAME_PARTICLE_EFFECT6 = "player_particle_effect6";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "playereffect", QueueIdx = 23)]
	public const string JOINT_NAME_PARTICLE_EFFECT = "player_particle_effect";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "playereffect", QueueIdx = 24)]
	public const string JOINT_NAME_PARTICLE_EFFECT7 = "player_particle_effect7";

	[Join(EffectType = JoinEffectType.Particle, XmlNodeName = "playereffect", QueueIdx = 25)]
	public const string JOINT_NAME_PARTICLE_FIRE_EFFECT = "Player_particle_fire_effect";

	[Join(EffectType = JoinEffectType.None, XmlNodeName = "playereffect", QueueIdx = 26)]
	public const string JOINT_NAME_PLAYER_MESH = "playermesh";

	public static Dictionary<IgnoreCaseString, JoinAttribute> JoinsInfo { get; set; }

	static PlayerJoinConstant()
	{
		JoinsInfo = new Dictionary<IgnoreCaseString, JoinAttribute>();
		FieldInfo[] fields = typeof(PlayerJoinConstant).GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
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
