using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using NetData;
using SSJJMath;
using UnityEngine;
using share;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class PlayerYingyangHuanyinEffectRender : AbstractPlayerEffectRender
{
	private GameObject _hyPlayer;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		if (player.thirdPersonUnityObjects != null)
		{
			_hyPlayer = player.thirdPersonUnityObjects.ThirdTran.RootContainer;
		}
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		if (targetPlayer.thirdPersonUnityObjects != null)
		{
			_hyPlayer = targetPlayer.thirdPersonUnityObjects.ThirdTran.RootContainer;
		}
		SceneBufEntityData sceneBufEntityData = null;
		foreach (KeyValuePair<int, SceneBufEntityData> item in Contexts.sharedInstance.snapshot.snapshots.NowSnapshot.SceneBufEntityDataDict)
		{
			if (item.Value.AttachPlayerId == SceneBufTypeUtility.ConvertYinyangHyPlayerId(targetPlayer.GetId()) && SceneBufTypeUtility.IsYingyangBigMirror(item.Value.BufName))
			{
				sceneBufEntityData = item.Value;
				break;
			}
		}
		if (sceneBufEntityData != null)
		{
			float num = updatePositionRotation(sceneBufEntityData, Contexts.sharedInstance.player.myPlayerEntity);
			_hyPlayer.SetActive(num > 0f);
		}
	}

	private float updatePositionRotation(SceneBufEntityData buffer, PlayerEntity player)
	{
		float f = buffer.Yaw * (float)Maths.RAD;
		float f2 = (buffer.Yaw + 90f) * (float)Maths.RAD;
		Vector3 vector = VectorCoordConverter.SsjjToUnity(new Vector3D(player.GetX(), player.GetY(), player.GetZ()));
		Vector3 vector2 = VectorCoordConverter.SsjjToUnity(new Vector3D(buffer.X, buffer.Y, buffer.Z));
		Vector3 rhs = vector - vector2;
		rhs.y = 0f;
		Vector3 vector3 = new Vector3(Mathf.Cos(f), 0f, Mathf.Sin(f));
		float f3 = Vector3.Dot(vector3, rhs);
		if (Mathf.Abs(f3) >= 180f)
		{
			return 0f;
		}
		vector3.Set(Mathf.Cos(f2), 0f, Mathf.Sin(f2));
		f3 = Vector3.Dot(vector3, rhs);
		vector3 *= (0f - f3) * 2f;
		vector += vector3;
		_hyPlayer.transform.position = vector;
		Vector3 localEulerAngles = _hyPlayer.transform.localEulerAngles;
		localEulerAngles.y = (0f - buffer.Yaw + 90f) * 2f + player.GetViewYaw();
		_hyPlayer.transform.localEulerAngles = localEulerAngles;
		return 1f;
	}
}
