using SSJJUserCmd;
using weapon.predicateSystem.implementSeparately;

namespace Assets.Sources.Modules.Player.Attack.SharePredicationApapter;

public class CmdPropertiesAdapter : ICmdPropertiesAdapter
{
	public IUserCmd Cmd;

	public void SetUserCmd(UserCmd cmd)
	{
		Cmd = cmd;
	}

	public int GetSeq()
	{
		return Cmd.Seq;
	}

	public float GetMoveForward()
	{
		return Cmd.MoveForward;
	}

	public float GetMoveRight()
	{
		return Cmd.MoveRight;
	}

	public int GetFrameInterval()
	{
		return Cmd.FrameInterval;
	}

	public double GetCameraYaw()
	{
		return Cmd.CameraYaw;
	}

	public double GetCameraPitch()
	{
		return Cmd.CameraPitch;
	}

	public int GetButtons()
	{
		return Cmd.Buttons;
	}

	public int GetRenderTime()
	{
		return Contexts.sharedInstance.time.time.RenderTime;
	}

	public bool FirstPredication()
	{
		return Cmd.PredicatedOnce;
	}

	public bool IsLeftAttack()
	{
		return Cmd.IsAttackOn;
	}

	public bool IsRightAttack()
	{
		return Cmd.IsSecondaryAttackOn;
	}

	public bool IsLeft()
	{
		return Cmd.IsLeft;
	}

	public bool IsRight()
	{
		return Cmd.IsRight;
	}
}
