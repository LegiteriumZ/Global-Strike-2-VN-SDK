using System;

namespace Assets.Sources.Info.Weapon.Constant;

internal class FovConstant
{
	public const int AwpFov1 = 40;

	public const int AwpFov2 = 10;

	public const int Normal = 90;

	public const int AugFov1 = 55;

	public static readonly double AwpFov1Scale = Math.Tan(Math.PI / 9.0);

	public static readonly double AwpFov2Scale = Math.Tan(Math.PI / 36.0);

	public static readonly double AugFov1Scale = Math.Tan(0.4799655442984406);
}
