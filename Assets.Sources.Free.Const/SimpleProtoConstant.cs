namespace Assets.Sources.Free.Const;

public class SimpleProtoConstant
{
	public const int UI_JUMP_MESSAGE = 1;

	public const int UI_JUMP_DANMU = 2;

	public const int UI_JUMP_COMPLETE = 3;

	public const int EFFECT_JUMP_SAVEPOINT = 101;

	public const int EFFECT_AUTO_SAVEPOINT = 102;

	public static bool IsUIKey(int key)
	{
		return key < 100;
	}
}
