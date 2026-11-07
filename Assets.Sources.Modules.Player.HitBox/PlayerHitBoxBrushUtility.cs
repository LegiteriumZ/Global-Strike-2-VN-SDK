using System.Collections.Generic;
using SSJJBase.String;
using SSJJMath;
using UnityEngine;
using physics.data;
using share;
using share.constant;

namespace Assets.Sources.Modules.Player.HitBox;

public class PlayerHitBoxBrushUtility
{
	private static Matrix4x4 s_matrix_ = Matrix4x4.identity;

	public static void UpdatePlayerHitBoxBrush(PlayerEntity player, Vector3D start, Vector3D shotDir, float traceSize)
	{
		if (!player.hasHitBox || !player.hasThirdPersonUnityObjects || !player.hitBox.HitBoxBrushDirty)
		{
			return;
		}
		player.hitBox.HitBoxBrush = new List<HitBoxBrush>();
		foreach (physics.data.HitBox hitBox in player.hitBox.HitBoxList)
		{
			player.hitBox.HitBoxBrush.Add(CalculateBrushFromHitBox(player, hitBox, pointTrace: true, start, shotDir, traceSize, isCheckNeedTrace: true));
		}
		player.hitBox.HitBoxBrushDirty = false;
	}

	public static void UpdatePlayerAllHitBoxBrush(PlayerEntity player)
	{
		if (player.hasThirdPersonGPUAnim)
		{
			player.hitBox.HitBoxBrush = new List<HitBoxBrush>();
			for (int i = 0; i < player.hitBox.HitBoxList.Count; i++)
			{
				player.hitBox.HitBoxBrush.Add(CalculateGPUAnimBrushFromHitBox(player, player.hitBox.HitBoxList[i], pointTrace: true, null, null, 0f, isCheckNeedTrace: false, i));
			}
		}
		else
		{
			if (!player.hasHitBox || !player.hasThirdPersonUnityObjects || !player.hitBox.HitBoxBrushDirty)
			{
				return;
			}
			player.hitBox.HitBoxBrush = new List<HitBoxBrush>();
			foreach (physics.data.HitBox hitBox in player.hitBox.HitBoxList)
			{
				player.hitBox.HitBoxBrush.Add(CalculateBrushFromHitBox(player, hitBox, pointTrace: true, null, null, 0f, isCheckNeedTrace: false));
			}
			player.hitBox.HitBoxBrushDirty = false;
		}
	}

	private static bool HitboxPreliminaryTrace(Vector3D start, Vector3D shotDir, float traceSize, physics.data.HitBox hitBox, Matrix3D matrix)
	{
		return false;
	}

	protected static HitBoxBrush CalculateBrushFromHitBox(PlayerEntity player, physics.data.HitBox hitBox, bool pointTrace, Vector3D start, Vector3D shotDir, float traceSize, bool isCheckNeedTrace)
	{
		HitBoxBrush hitBoxBrush = new HitBoxBrush();
		hitBoxBrush.SetBoneName(hitBox.GetJointName());
		Transform playerBoneTransform = GetPlayerBoneTransform(player, hitBoxBrush.GetBoneName());
		if (playerBoneTransform == null)
		{
			return hitBoxBrush;
		}
		float m = 1f;
		if (hitBox.GetJointName().Equals("Bip01_Head") && PlayerCareerUtil.IsHumanity(player.GetCareer()) && player.hasThirdPersonUnityObjects)
		{
			m = 1f / player.thirdPersonUnityObjects.ThirdTran.HeadSize;
		}
		s_matrix_.m00 = (s_matrix_.m11 = (s_matrix_.m22 = m));
		Matrix3D matrix = MatrixUtility.TransformToMatrix3D(playerBoneTransform, s_matrix_);
		if (!isCheckNeedTrace || !HitboxPreliminaryTrace(start, shotDir, traceSize, hitBox, matrix))
		{
			hitBoxBrush.AddBrushDefineSide(hitBox, matrix);
			if (!pointTrace)
			{
				hitBoxBrush.AddBrushBevelSide(hitBox, matrix);
			}
		}
		return hitBoxBrush;
	}

	protected static HitBoxBrush CalculateGPUAnimBrushFromHitBox(PlayerEntity player, physics.data.HitBox hitBox, bool pointTrace, Vector3D start, Vector3D shotDir, float traceSize, bool isCheckNeedTrace, int i)
	{
		HitBoxBrush hitBoxBrush = new HitBoxBrush();
		hitBoxBrush.SetBoneName(hitBox.GetJointName());
		GPUSkinningPlayerMono gPUSkinningPlayerMono = player.thirdPersonGPUAnim.gpuSkinningPlayerMono as GPUSkinningPlayerMono;
		if (gPUSkinningPlayerMono.Player == null)
		{
			return hitBoxBrush;
		}
		if (i >= gPUSkinningPlayerMono.anim.boneHitid.Length)
		{
			i = gPUSkinningPlayerMono.anim.boneHitid.Length - 1;
		}
		Matrix3D matrix = MatrixUtility.Unity2Ssjj(MatrixUtility.Matrix4x4ToFlashMatrix4x4(player.thirdPersonUnityObjects.ThirdTran.BodyTransform.localToWorldMatrix * gPUSkinningPlayerMono.Player.PlayerClip.frames[gPUSkinningPlayerMono.Player.LastPlayingFrameIndex].bonemMatrices[gPUSkinningPlayerMono.anim.boneHitid[i]]));
		if (!isCheckNeedTrace || !HitboxPreliminaryTrace(start, shotDir, traceSize, hitBox, matrix))
		{
			hitBoxBrush.AddBrushDefineSide(hitBox, matrix);
			if (!pointTrace)
			{
				hitBoxBrush.AddBrushBevelSide(hitBox, matrix);
			}
		}
		return hitBoxBrush;
	}

	public static Transform GetPlayerBoneTransform(PlayerEntity playerEntity, string bonename)
	{
		int hashCode = new IgnoreCaseString(bonename).GetHashCode();
		if (playerEntity.hitBox.BonetTransform.TryGetValue(hashCode, out var value))
		{
			return value;
		}
		return null;
	}
}
