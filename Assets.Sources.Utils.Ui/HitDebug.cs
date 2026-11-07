using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.AnimData;
using NetData;
using SSJJAnim.Animator;
using SSJJAnim.Player;
using SSJJBase.Pool;
using SSJJMath;
using UnityEngine;
using physics.data;
using share;

namespace Assets.Sources.Utils.Ui;

public static class HitDebug
{
	private static StackObjectPool<CheckHitInfoData> HitInfoPool = new StackObjectPool<CheckHitInfoData>();

	private static float Normalize(double value)
	{
		return (float)Mathf.RoundToInt((float)(value * 100.0)) / 100f;
	}

	public static void SendHitStatics(int renderTime, PlayerEntity myPlayer, PlayerEntity enemy)
	{
		Vector3 compenstatePos = myPlayer.GetCompenstatePos(myPlayer.fpos.Change.GetPosIndex());
		Vector3 compenstatePos2 = enemy.GetCompenstatePos(enemy.fpos.Change.GetPosIndex());
		CheckHitInfoData checkHitInfoData = HitInfoPool.GetOrNull();
		if (checkHitInfoData == null)
		{
			checkHitInfoData = new CheckHitInfoData();
		}
		checkHitInfoData.RenderTime = renderTime;
		checkHitInfoData.Id = enemy.entityId.Value;
		checkHitInfoData.PlayerPos = ((int)(compenstatePos.x * 100f) << 16) + ((int)(compenstatePos.y * 100f) & 0xFFFF);
		checkHitInfoData.TargetPlayerPos = ((int)(compenstatePos2.x * 100f) << 16) + ((int)(compenstatePos2.y * 100f) & 0xFFFF);
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(24, checkHitInfoData);
		HitInfoPool.Add(checkHitInfoData);
	}

	public static void SendHitDebugInfo(PlayerEntity player, PlayerEntity enemy)
	{
		int renderTime = Contexts.sharedInstance.time.time.RenderTime;
		HitPlayerInfoData hitPlayerInfoData = new HitPlayerInfoData();
		hitPlayerInfoData.PlayerId = enemy.entityId.Value;
		hitPlayerInfoData.RenderTime = renderTime;
		List<HitBox> hitBoxList = enemy.hitBox.HitBoxList;
		SJAnimationPlayer componentInChildren = enemy.thirdPersonUnityObjects.ThirdTran.RootContainer.GetComponentInChildren<SJAnimationPlayer>();
		ISjAnimatior animator = enemy.thirdPersonUnityObjects.Animator;
		if (animator == null)
		{
			return;
		}
		SJAnimatorLayer sJAnimatorLayer = animator.GetLayer(0) as SJAnimatorLayer;
		Vector3 compenstatePos = enemy.GetCompenstatePos(enemy.fpos.Change.GetPosIndex());
		float num = 1f;
		if (enemy.legAnim.LegsAnimInfo.StateId == 1 || enemy.legAnim.LegsAnimInfo.StateId == 2)
		{
			num = (float)enemy.move.Velocity2D * 0.0016f;
		}
		string text = renderTime.ToString() + " legx : " + 0 + " yaw : " + enemy.orientation.Yaw + " moveYaw : " + enemy.orientation.MoveYaw + " origin : " + Normalize(compenstatePos.x) + " " + Normalize(compenstatePos.y) + " " + Normalize(compenstatePos.z) + " speed : " + sJAnimatorLayer.CurrentSpeed + " preSpeed: " + sJAnimatorLayer.MixSpeed + " velocity speed: " + num + " preVelocity2D: " + enemy.move.getPreVelocity2D() + " velocity2D: " + enemy.move.Velocity2D + " legsClipTime : " + ((sJAnimatorLayer.CurrentState != null) ? sJAnimatorLayer.CurrentState.Time : 0f) + " preClipTime : " + ((sJAnimatorLayer.MixState != null) ? sJAnimatorLayer.MixState.Time : (-1f)) + " legsSpeedAnimTime : " + enemy.legAnim.ScaledEclipsedTime + " legsAnim : " + ((sJAnimatorLayer.CurrentState != null) ? sJAnimatorLayer.CurrentState.Name : "") + " preAnim : " + ((sJAnimatorLayer.MixState != null) ? sJAnimatorLayer.MixState.Name : "") + " dbg_prew : " + ((sJAnimatorLayer.MixState != null) ? sJAnimatorLayer.MixState.Weight : 0f) + " serverTime : " + Contexts.sharedInstance.snapshot.snapshots.NowSnapshot.ServerTime + " renderTime ： " + renderTime + " multithread ： " + animator.IsMultiThread().ToString() + " mixRverse ： " + sJAnimatorLayer.MixReverse.ToString();
		foreach (HitBox item in hitBoxList)
		{
			Transform bone = componentInChildren.GetBone(item.GetJointName());
			if (!(bone == null))
			{
				Vector3D[] array = MatrixUtility.TransformToMatrix3D(bone, Matrix4x4.identity).Decompose();
				text = text + "\r\nBoneName : " + item.GetJointName() + " " + Normalize(array[0].x) + " " + Normalize(array[0].y) + " " + Normalize(array[0].z) + " " + Normalize(array[1].x) + " " + Normalize(array[1].y) + " " + Normalize(array[1].z);
			}
		}
		hitPlayerInfoData.HitInfo = text;
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(8, hitPlayerInfoData);
	}
}
