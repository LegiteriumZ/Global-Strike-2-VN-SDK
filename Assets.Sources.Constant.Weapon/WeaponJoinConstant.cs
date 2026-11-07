using System.Collections.Generic;
using System.Reflection;
using SSJJBase.String;

namespace Assets.Sources.Constant.Weapon;

public class WeaponJoinConstant
{
	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, IsFire = true)]
	public const string Fire = "fire";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.None, IsFire = true)]
	public const string Fire2 = "fire2";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 0)]
	public const string WEAPONANCHOR = "weaponanchor";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.None, QueueIdx = 1)]
	public const string WEAPONANCHOR2 = "weaponanchor2";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 10)]
	public const string WEAPONANCHOR3 = "weaponanchor3";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.None, QueueIdx = 20)]
	public const string WEAPONANCHOR4 = "weaponanchor4";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 69)]
	public const string WEAPONANCHOR5 = "weaponanchor5";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 70)]
	public const string WEAPONANCHOR6 = "weaponanchor6";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 71)]
	public const string WEAPONANCHOR7 = "weaponanchor7";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 0)]
	public const string WUQI_1 = "wuqi1";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 0)]
	public const string WUQI_2 = "wuqi2";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 0)]
	public const string WUQI_3 = "wuqi3";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 0)]
	public const string WUQI_4 = "wuqi4";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 0)]
	public const string WUQI_5 = "wuqi5";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.Model, QueueIdx = 2)]
	public const string LEFT_JOIN_NAME_WEAPONEFFECT = "weaponeffect2";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.Model, QueueIdx = 28)]
	public const string LEFT_JOIN_NAME_WEAPONEFFECT2 = "weaponeffect4";

	[Join(HandType = (JoinHandType.Left | JoinHandType.Right), EffectType = JoinEffectType.Model, XmlNodeName = "weaponfireeffect", IsFire = true, QueueIdx = 3)]
	public const string LEFT_JOIN_NAME_WEAPONFIREEFFECT = "weaponfireeffect2";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, QueueIdx = 4)]
	public const string RIGHT_JOIN_NAME_WEAPONEFFECT = "weaponeffect";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, XmlNodeName = "weaponfireeffect", IsFire = true, QueueIdx = 5)]
	public const string RIGHT_JOIN_NAME_WEAPONFIREEFFECT = "weaponfireeffect";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, XmlNodeName = "weaponfireeffect", IsFire = true, QueueIdx = 24)]
	public const string RIGHT_JOIN_NAME_WEAPONFIREEFFECT3 = "weaponfireeffect3";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, QueueIdx = 6)]
	public const string JOIN_NAME_CHUANTOUJIAN = "chuantoujian";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, QueueIdx = 7)]
	public const string JOIN_NAME_BINGDONGJIAN = "bingdongjian";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, QueueIdx = 18)]
	public const string JOIN_NAME_CHUANTOUJIANEFFECT = "chuantoujianeffect";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, QueueIdx = 19)]
	public const string JOIN_NAME_BINGDONGJIANEFFECT = "bingfengjianeffect";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.Model, QueueIdx = 8)]
	public const string JOIN_NAME_PUTONG = "putong";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.Model, QueueIdx = 9)]
	public const string JOIN_NAME_MANGONG = "mangong";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.Model, QueueIdx = 21)]
	public const string JOIN_NAME_PUTONG_EFFECT = "putongeffect";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.Model, QueueIdx = 22)]
	public const string JOIN_NAME_MANGONG_EFFECT = "mangongeffect";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, XmlNodeName = "weaponeffect", QueueIdx = 11)]
	public const string WEAPON_JOIN_NAME_WEAPONEFFECT = "weaponeffect3";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, XmlNodeName = "jiguangjianeffect", QueueIdx = 12)]
	public const string WEAPON_JOIN_NAME_M4A1_HERO_JIGUANGJIAN = "m4a1_hero_jiguangjian";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, XmlNodeName = "jiguangjianviewshoweffect", QueueIdx = 13)]
	public const string WEAPON_JOIN_NAME_M4A1_HERO_JIGUANGJIAN_VIEWSHOW = "m4a1_hero_jiguangjian_viewshow";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, XmlNodeName = "jiguangeffect", QueueIdx = 14)]
	public const string WEAPON_JOIN_NAME_M4A1_HERO_JIGUANG = "m4a1_hero_jiguang";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, XmlNodeName = "weaponeffect1", QueueIdx = 15)]
	public const string WEAPON_JOIN_NAME_M4A1_HERO_EFFECT1 = "m4a1_hero_effect1";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, XmlNodeName = "weaponeffect2", QueueIdx = 16)]
	public const string WEAPON_JOIN_NAME_M4A1_HERO_EFFECT2 = "m4a1_hero_effect2";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, XmlNodeName = "weaponeffect3", QueueIdx = 17)]
	public const string WEAPON_JOIN_NAME_M4A1_HERO_EFFECT3 = "m4a1_hero_effect3";

	[Join(HandType = JoinHandType.None, EffectType = JoinEffectType.HuXi, QueueIdx = 23)]
	public const string WEAPON_JOIN_NAME_UV2_HUXI = "uv2_huxi";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.LiuGuang, QueueIdx = 25)]
	public const string WEAPON_JOIN_NAME_UV2_LIUGUANGGAOGUANG = "uv2_liuguang_gaoguang";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.live2D, QueueIdx = 25)]
	public const string WEAPON_JOIN_NAME_UV2_LIVE2D = "uv2_live2D";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model)]
	public const string WEAPON_JOIN_NAME_RIGHTATTACHEFFECT = "rightattacheffect";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model)]
	public const string WEAPON_JOIN_NAME_RIGHTATTACHEFFECT2 = "rightattacheffect2";

	[Join(HandType = JoinHandType.None, EffectType = JoinEffectType.None)]
	public const string WEAPON_JOIN_NAME_UI_ICON = "ui_icon";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 26)]
	public const string WEAPON_JOIN_NAME_WEAPON_RAIL_EFFECT = "weapon_rail_effect";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.None, QueueIdx = 27)]
	public const string WEAPON_JOIN_NAME_WEAPON_RAIL_EFFECT2 = "weapon_rail_effect2";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Particle, QueueIdx = 25)]
	public const string WEAPON_JOIN_NAME_PARTICLE_EFFECT = "weapon_particle_effect";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.Particle, QueueIdx = 52)]
	public const string WEAPON_JOIN_NAME_LEFT_PARTICLE_EFFECT = "weapon_left_particle_effect";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Particle, IsFire = true, QueueIdx = 50)]
	public const string WEAPON_JOIN_NAME_PARTICLE_FIRE_EFFECT = "weapon_particle_fire_effect";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.Particle, IsFire = true, QueueIdx = 54)]
	public const string WEAPON_JOIN_NAME_LEFT_PARTICLE_FIRE_EFFECT = "weapon_left_particle_fire_effect";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Particle, QueueIdx = 56)]
	public const string WEAPON_JOIN_NAME_DUMMY_PARTICLE_EFFECT = "weapon_dummy_particle_effect";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Particle, QueueIdx = 57)]
	public const string WEAPON_JOIN_NAME_DUMMY_PARTICLE_EFFECT1 = "weapon_dummy_particle_effect1";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Particle, QueueIdx = 58)]
	public const string WEAPON_JOIN_NAME_DUMMY_PARTICLE_EFFECT2 = "weapon_dummy_particle_effect2";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Particle, QueueIdx = 59)]
	public const string WEAPON_JOIN_NAME_DUMMY_PARTICLE_EFFECT3 = "weapon_dummy_particle_effect3";

	[Join(HandType = (JoinHandType.Left | JoinHandType.Right), EffectType = JoinEffectType.Particle, IsFire = true, QueueIdx = 60)]
	public const string WEAPON_JOIN_NAME_DUMMY_PARTICLE_FIRE_EFFECT = "weapon_dummy_particle_fire_effect";

	[Join(HandType = (JoinHandType.Left | JoinHandType.Right), EffectType = JoinEffectType.Particle, IsFire = true, QueueIdx = 61)]
	public const string WEAPON_JOIN_NAME_DUMMY_PARTICLE_FIRE_EFFECT1 = "weapon_dummy_particle_fire_effect1";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Particle, QueueIdx = 47)]
	public const string WEAPON_JOIN_NAME_PARTICLE_EFFECT1 = "weapon_particle_effect1";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Particle, QueueIdx = 48)]
	public const string WEAPON_JOIN_NAME_PARTICLE_EFFECT2 = "weapon_particle_effect2";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Particle, QueueIdx = 49)]
	public const string WEAPON_JOIN_NAME_PARTICLE_EFFECT3 = "weapon_particle_effect3";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Particle, QueueIdx = 62)]
	public const string WEAPON_JOIN_NAME_PARTICLE_EFFECT4 = "weapon_particle_effect4";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Particle, QueueIdx = 112)]
	public const string WEAPON_JOIN_NAME_PARTICLE_EFFECT5 = "weapon_particle_effect5";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Particle, QueueIdx = 113)]
	public const string WEAPON_JOIN_NAME_PARTICLE_EFFECT6 = "weapon_particle_effect6";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Particle, QueueIdx = 114)]
	public const string WEAPON_JOIN_NAME_PARTICLE_EFFECT7 = "weapon_particle_effect7";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.Particle, IsFire = true, QueueIdx = 53)]
	public const string WEAPON_JOIN_NAME_LEFT_PARTICLE_EFFECT1 = "weapon_left_particle_effect1";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.Particle, IsFire = true, QueueIdx = 63)]
	public const string WEAPON_JOIN_NAME_LEFT_PARTICLE_EFFECT2 = "weapon_left_particle_effect2";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.Particle, IsFire = true, QueueIdx = 64)]
	public const string WEAPON_JOIN_NAME_LEFT_PARTICLE_EFFECT3 = "weapon_left_particle_effect3";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.Particle, IsFire = true, QueueIdx = 65)]
	public const string WEAPON_JOIN_NAME_LEFT_PARTICLE_EFFECT4 = "weapon_left_particle_effect4";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.Particle, IsFire = true, QueueIdx = 67)]
	public const string WEAPON_JOIN_NAME_LEFT_PARTICLE_EFFECT5 = "weapon_left_particle_effect5";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.Particle, IsFire = true, QueueIdx = 68)]
	public const string WEAPON_JOIN_NAME_LEFT_PARTICLE_EFFECT6 = "weapon_left_particle_effect6";

	[Join(HandType = (JoinHandType.Left | JoinHandType.Right), EffectType = JoinEffectType.Particle, IsFire = true)]
	public const string WEAPON_JOIN_NAME_PARTICLE_FIRE_EFFECT1 = "weapon_particle_fire_effect1";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.Particle, IsFire = true, QueueIdx = 55)]
	public const string WEAPON_JOIN_NAME_LEFT_PARTICLE_FIRE_EFFECT1 = "weapon_left_particle_fire_effect1";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 30)]
	public const string WEAPON_JOIN_NAME_WEAPONEFFECT21 = "weaponeffect21";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 31)]
	public const string WEAPON_JOIN_NAME_WEAPONEFFECT22 = "weaponeffect22";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 32)]
	public const string WEAPON_JOIN_NAME_WEAPONEFFECT23 = "weaponeffect23";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 33)]
	public const string WEAPON_JOIN_NAME_WEAPONEFFECT24 = "weaponeffect24";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 34)]
	public const string WEAPON_JOIN_NAME_WEAPONEFFECT25 = "weaponeffect25";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 35)]
	public const string WEAPON_JOIN_NAME_WEAPONEFFECT26 = "weaponeffect26";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 36)]
	public const string WEAPON_JOIN_NAME_WEAPONEFFECT27 = "weaponeffect27";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 37)]
	public const string WEAPON_JOIN_NAME_WEAPONEFFECT28 = "weaponeffect28";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.None, QueueIdx = 46)]
	public const string WEAPON_JOIN_NAME_WEAPONEFFECT29 = "weaponeffect29";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.None, QueueIdx = 38)]
	public const string WEAPON_JOIN_NAME_LEFT_WEAPONEFFECT21 = "leftweaponeffect21";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.None, QueueIdx = 39)]
	public const string WEAPON_JOIN_NAME_LEFT_WEAPONEFFECT22 = "leftweaponeffect22";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.None, QueueIdx = 40)]
	public const string WEAPON_JOIN_NAME_LEFT_WEAPONEFFECT23 = "leftweaponeffect23";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.None, QueueIdx = 41)]
	public const string WEAPON_JOIN_NAME_LEFT_WEAPONEFFECT24 = "leftweaponeffect24";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.None, QueueIdx = 42)]
	public const string WEAPON_JOIN_NAME_LEFT_WEAPONEFFECT25 = "leftweaponeffect25";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.None, QueueIdx = 43)]
	public const string WEAPON_JOIN_NAME_LEFT_WEAPONEFFECT26 = "leftweaponeffect26";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.None, QueueIdx = 44)]
	public const string WEAPON_JOIN_NAME_LEFT_WEAPONEFFECT27 = "leftweaponeffect27";

	[Join(HandType = JoinHandType.Left, EffectType = JoinEffectType.None, QueueIdx = 45)]
	public const string WEAPON_JOIN_NAME_LEFT_WEAPONEFFECT28 = "leftweaponeffect28";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, XmlNodeName = "weaponeffect", QueueIdx = 101)]
	public const string SORT_JOIN_NAME_WEAPONEFFECT1 = "rightweaponeffect1";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, XmlNodeName = "weaponeffect2", QueueIdx = 102)]
	public const string SORT_JOIN_NAME_WEAPONEFFECT2 = "rightweaponeffect2";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, XmlNodeName = "weaponeffect", QueueIdx = 110)]
	public const string SORT_JOIN_NAME_WEAPONEFFECT10 = "weaponeffect10";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Model, XmlNodeName = "weaponeffect", QueueIdx = 111)]
	public const string SORT_JOIN_NAME_WEAPONEFFECT11 = "weaponeffect11";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Particle, QueueIdx = 53)]
	public const string PLAYER_JOIN_PARTICLE_EFFECT = "player_particle_effect";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Particle, QueueIdx = 113)]
	public const string PLAYER_JOIN_PARTICLE_EFFECT1 = "player_particle_effect1";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Particle, QueueIdx = 114)]
	public const string PLAYER_JOIN_PARTICLE_EFFECT2 = "player_particle_effect2";

	[Join(HandType = JoinHandType.Right, EffectType = JoinEffectType.Particle, QueueIdx = 115)]
	public const string PLAYER_JOIN_PARTICLE_EFFECT3 = "player_particle_effect3";

	public static HashSet<IgnoreCaseString> LeftFireJoins { get; set; }

	public static HashSet<IgnoreCaseString> RightFireJoins { get; set; }

	public static HashSet<IgnoreCaseString> RightWeaponJoins { get; set; }

	public static HashSet<IgnoreCaseString> LeftWeaponJoins { get; set; }

	public static Dictionary<IgnoreCaseString, JoinAttribute> JoinsInfo { get; set; }

	static WeaponJoinConstant()
	{
		LeftFireJoins = new HashSet<IgnoreCaseString>();
		RightFireJoins = new HashSet<IgnoreCaseString>();
		RightWeaponJoins = new HashSet<IgnoreCaseString>();
		LeftWeaponJoins = new HashSet<IgnoreCaseString>();
		JoinsInfo = new Dictionary<IgnoreCaseString, JoinAttribute>();
		FieldInfo[] fields = typeof(WeaponJoinConstant).GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
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
					JoinAttribute joinAttribute = (JoinAttribute)obj;
					JoinsInfo[text] = joinAttribute;
					if (joinAttribute.IsFire && ((joinAttribute.HandType & JoinHandType.Left) != 0 || joinAttribute.HandType == JoinHandType.None))
					{
						LeftFireJoins.Add(text);
					}
					if (joinAttribute.IsFire && ((joinAttribute.HandType & JoinHandType.Right) != 0 || joinAttribute.HandType == JoinHandType.None))
					{
						RightFireJoins.Add(text);
					}
					if ((joinAttribute.HandType & JoinHandType.Left) != 0)
					{
						LeftWeaponJoins.Add(text);
					}
					if ((joinAttribute.HandType & JoinHandType.Right) != 0)
					{
						RightWeaponJoins.Add(text);
					}
				}
			}
		}
	}
}
