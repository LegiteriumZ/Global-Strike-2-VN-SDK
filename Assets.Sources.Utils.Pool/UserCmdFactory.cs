using SSJJBase.Pool;
using SSJJUserCmd;

namespace Assets.Sources.Utils.Pool;

public class UserCmdFactory : PoolFactory<UserCmd>
{
	private static UserCmdFactory _instance = new UserCmdFactory();

	public static UserCmdFactory Instance()
	{
		return _instance;
	}

	protected override UserCmd CreateObj()
	{
		return new UserCmd();
	}

	public override void Reset(UserCmd element)
	{
		element.AxisX = 0f;
		element.AxisY = 0f;
		element.Buttons = 0;
		element.BagId = 0;
		element.CameraPitch = 0;
		element.CameraYaw = 0;
		element.FrameInterval = 0;
		element.RandomSeed = 0;
		element.RenderTime = 0;
		element.PredicatedOnce = false;
		element.MoveForward = 0f;
		element.MoveRight = 0f;
		element.Weapon = 0;
		element.QButton = false;
	}
}
