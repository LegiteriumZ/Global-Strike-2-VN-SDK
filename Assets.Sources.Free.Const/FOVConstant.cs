using System;
using UnityEngine;

namespace Assets.Sources.Free.Const;

public class FOVConstant
{
	public const int AWP_FOV1 = 40;

	public const int AWP_FOV2 = 10;

	public const int NORMAL = 90;

	public const int AUG_FOV1 = 55;

	public const float AWP_FOV1_SCALE = 0f;

	public const float AWP_FOV2_SCALE = 0f;

	public const float AUG_FOV1_SCALE = 0f;

	public static float AWP_FOV1_SCALE_Result = Mathf.Tan((float)Math.PI / 9f);

	public static float AWP_FOV2_SCALE_Result = Mathf.Tan((float)Math.PI / 36f);

	public static float AUG_FOV1_SCALE_Result = Mathf.Tan(0.47996554f);
}
