using System;
using Assets.Sources.Utils.PlayerAnim;
using SSJJUserCmd;
using math;
using share;

public class PlayerGlidingThirdAnimControl
{
	public static void processAnimLogic(PlayerEntity playerEntity, IUserCmd cmd)
	{
		calculateMoveAngles(playerEntity, cmd);
		calculateAnimation(playerEntity, cmd);
	}

	public static void calculateAnimation(PlayerEntity playerEntity, IUserCmd cmd)
	{
		animReactToCmd(playerEntity, cmd);
	}

	public static void animReactToCmd(PlayerEntity playerEntity, IUserCmd cmd)
	{
		bool num = isMoveForward(cmd);
		if (num)
		{
			moveForwardHandler(playerEntity);
		}
		if (!num)
		{
			notMoveForwardHandler(playerEntity);
		}
	}

	public static void notMoveForwardHandler(PlayerEntity playerEntity)
	{
		if (shouldSlowDownTorsoAnim(playerEntity))
		{
			PlayerAnimationUtility.SetTorseAnimation(playerEntity, 233);
		}
		if (shouldSlowDownLegsAnim(playerEntity))
		{
			PlayerAnimationUtility.SetLegsAnimation(playerEntity, 230);
		}
	}

	public static void moveForwardHandler(PlayerEntity playerEntity)
	{
		if (shouldBeginSpeedUpTorsoAnim(playerEntity))
		{
			PlayerAnimationUtility.SetTorseAnimation(playerEntity, 231);
		}
		if (shouldBeginSpeedUpLegsAnim(playerEntity))
		{
			PlayerAnimationUtility.SetLegsAnimation(playerEntity, 228);
		}
	}

	public static bool shouldSlowDownLegsAnim(PlayerEntity playerEntity)
	{
		if (playerEntity.legAnim.LegsAnimInfo.StateId != 228 && playerEntity.legAnim.LegsAnimInfo.StateId != 207 && playerEntity.legAnim.LegsAnimInfo.StateId != 230)
		{
			return playerEntity.legAnim.LegsAnimInfo.StateId != 209;
		}
		return false;
	}

	public static bool shouldSlowDownTorsoAnim(PlayerEntity playerEntity)
	{
		if (playerEntity.torseAnim.TorsoAnimInfo.StateId != 231 && playerEntity.torseAnim.TorsoAnimInfo.StateId != 206 && playerEntity.torseAnim.TorsoAnimInfo.StateId != 233)
		{
			return playerEntity.torseAnim.TorsoAnimInfo.StateId != 208;
		}
		return false;
	}

	public static bool shouldBeginSpeedUpLegsAnim(PlayerEntity playerEntity)
	{
		if (playerEntity.legAnim.LegsAnimInfo.StateId != 230 && playerEntity.legAnim.LegsAnimInfo.StateId != 228 && playerEntity.legAnim.LegsAnimInfo.StateId != 229)
		{
			return playerEntity.legAnim.LegsAnimInfo.StateId != 209;
		}
		return false;
	}

	public static bool shouldBeginSpeedUpTorsoAnim(PlayerEntity playerEntity)
	{
		if (playerEntity.torseAnim.TorsoAnimInfo.StateId != 233 && playerEntity.torseAnim.TorsoAnimInfo.StateId != 231 && playerEntity.torseAnim.TorsoAnimInfo.StateId != 232)
		{
			return playerEntity.torseAnim.TorsoAnimInfo.StateId != 208;
		}
		return false;
	}

	public static bool isMoveForward(IUserCmd cmd)
	{
		return cmd.IsForward;
	}

	public static void calculateMoveAngles(PlayerEntity playerState, IUserCmd cmd)
	{
		if (isFallingDown(playerState))
		{
			playerState.orientation.MovePitch = 0f;
			playerState.orientation.MoveRoll = 0f;
		}
		else
		{
			calMoveYawAndPitch(playerState);
			calMoveRoll(playerState, cmd);
			changeMoveRollToRange(playerState);
		}
	}

	public static void calMoveRoll(PlayerEntity playerState, IUserCmd cmd)
	{
		bool flag = isRight(cmd);
		bool num = isLeft(cmd);
		if (num && !flag)
		{
			playerState.orientation.MoveRoll -= 1f;
		}
		if (!num && flag)
		{
			playerState.orientation.MoveRoll += 1f;
		}
		if (!num && !flag && Math.Abs(playerState.orientation.MoveRoll) > 1f)
		{
			playerState.orientation.MoveRoll -= ((playerState.orientation.MoveRoll > 0f) ? 1 : (-1));
		}
	}

	public static void calMoveYawAndPitch(PlayerEntity playerState)
	{
		Vector3D vector3D = new Vector3D();
		vector3D.x = playerState.move.Velocity.x;
		vector3D.y = playerState.move.Velocity.y;
		vector3D.z = playerState.move.Velocity.z;
		vector3D.Normalize();
		Vector3D vector3D2 = AngleUtils.VectorToAngles(vector3D);
		playerState.orientation.MoveYaw = (float)AngleUtils.MakeAngleInRange(vector3D2.x);
		playerState.orientation.MovePitch = (float)AngleUtils.MakeAngleInRange(vector3D2.y);
	}

	public static bool isLeft(IUserCmd cmd)
	{
		return cmd.IsLeft;
	}

	public static bool isRight(IUserCmd cmd)
	{
		return cmd.IsRight;
	}

	public static void changeMoveRollToRange(PlayerEntity playerState)
	{
		playerState.orientation.MoveRoll = (float)AngleUtils.MakeAngleInRange(playerState.orientation.MoveRoll);
		if (playerState.orientation.MoveRoll > 45f)
		{
			playerState.orientation.MoveRoll = 45f;
		}
		if (playerState.orientation.MoveRoll < -45f)
		{
			playerState.orientation.MoveRoll = -45f;
		}
	}

	public static bool isFallingDown(PlayerEntity playerState)
	{
		Vector3D a = new Vector3D(0.0, 0.0, -1.0);
		Vector3D vector3D = new Vector3D(playerState.move.Velocity.x, playerState.move.Velocity.y, playerState.move.Velocity.z);
		return Math.Abs((double)VectorUtils.DotProduct(a, vector3D) / vector3D.GetLength() - 1.0) <= 0.001;
	}
}
