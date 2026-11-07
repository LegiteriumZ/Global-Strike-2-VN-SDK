using System.Collections.Generic;

namespace Assets.Sources.Info.EffectParser;

public class UVEffectNameConstant
{
	public const string UV2_HUXI_PLAYER = "uv2_huxi_player";

	public const string UV2_HUXI = "uv2_huxi";

	public const string UV1_HUXI = "uv1_huxi";

	public const string UV2_HUXI_XINPIAN = "uv2_huxi_xingpian";

	public const string UV2_LIUGUANG = "uv2_liuguang";

	public const string UV2_LIUGUANG_MASK = "uv2_liuguang_mask";

	public const string UV2_CHIBANG = "uv2_chibang";

	public const string UV2_LIUGUANG_LOUKONG = "uv2_liuguang_loukong";

	public const string UV2_LIUGUANG_GAOGUANG = "uv2_liuguang_gaoguang";

	public const string UV2_LIGHTMAP = "uv2_lightmap";

	public const string UV2_live2D = "uv2_live2D";

	public const string uv2_live2D_liuguang = "uv2_live2D_liuguang";

	public const string Xml_PlayerHuxi = "uv2effecthuxiplayer";

	public const string Xml_Huxi = "uv2effecthuxi";

	public const string Xml_PlayerHuxiColor = "uv2effectbianseplayer";

	public const string Xml_HuxiColor = "uv2effectbianse";

	public const string Xml_Liuguang = "uv2effectliuguang";

	public const string Xml_Light = "uv2effectlightmap";

	public const string Xml_U3d = "u3d";

	public const string Xml_live2D = "uv2effectlive2D";

	public const string Xml_live2DMask = "uv2liuguangeffect";

	public static HashSet<string> HuxiSet = new HashSet<string> { "uv1_huxi", "uv2_huxi", "uv2_huxi_xingpian" };

	public static HashSet<string> HuxiPlayerSet = new HashSet<string> { "uv2_huxi_player" };

	public static HashSet<string> LithtMap = new HashSet<string> { "uv2_lightmap" };

	public static HashSet<string> LiuGuangSet = new HashSet<string> { "uv2_liuguang", "uv2_chibang", "uv2_liuguang_loukong", "uv2_liuguang_gaoguang" };
}
