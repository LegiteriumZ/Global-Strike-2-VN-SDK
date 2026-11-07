using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Snapshots;
using Assets.Sources.Utils;
using NetData;
using NotifyEvent;
using SSJJMath;
using UnityEngine;
using share;

namespace Assets.Sources.Modules.SceneObject.PveTower;

public class PveTowerUpdateMsgSystem : IPlaybackSystem
{
	private readonly SnapshotContext _snapshotContext;

	private MessageContext _messageContext;

	private readonly BattleRoomContext _room;

	private readonly PlayerContext _player;

	private static Vector3D temp = new Vector3D();

	public PveTowerUpdateMsgSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_messageContext = contexts.message;
		_room = contexts.battleRoom;
		_player = contexts.player;
	}

	public void OnPlayback()
	{
		int raceType = _room.roomData.Data.RaceType;
		PlayerEntity myPlayerEntity = _player.myPlayerEntity;
		if (myPlayerEntity == null)
		{
			return;
		}
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		if (!RuleUtilty.IsPveModel(raceType) || nowSnapshot == null || nowSnapshot.Observer != 0 || !myPlayerEntity.hasFpos)
		{
			return;
		}
		bool flag = false;
		Vector3 compenstatePos = _player.myPlayerEntity.GetCompenstatePos(_player.myPlayerEntity.fpos.Change.GetPosIndex());
		_messageContext.pveUIMessage.MsgId = -1;
		foreach (KeyValuePair<int, SceneBufEntityData> item in nowSnapshot.SceneBufEntityDataDict)
		{
			SceneBufEntityData value = item.Value;
			if (!(Mathf.Abs(compenstatePos.x - value.X) > value.Radius) && !(Mathf.Abs(compenstatePos.y - value.Y) > value.Radius) && !(Mathf.Abs(compenstatePos.z - value.Z) > value.Radius))
			{
				if (value.BufName == "buy_weapon_clip")
				{
					_messageContext.pveUIMessage.MsgId = 21;
					flag = true;
				}
				else if (value.BufName == "buy_skill")
				{
					_messageContext.pveUIMessage.MsgId = 22;
					flag = true;
				}
				else if (value.BufName == "energydevice")
				{
					_messageContext.pveUIMessage.MsgId = 35;
					flag = true;
				}
			}
		}
		if (flag)
		{
			NotifyManager.ForceInvoke(1);
		}
	}

	private void UpdateTitan(Snapshot nowSnapshot, PlayerEntity player, TimeComponent time)
	{
		if (nowSnapshot == null)
		{
			return;
		}
		SceneBufEntityData sceneBufEntityData = null;
		float num = -1f;
		bool visiable = false;
		float rotation = 0f;
		foreach (KeyValuePair<int, SceneBufEntityData> item in nowSnapshot.SceneBufEntityDataDict)
		{
			_ = item.Key;
			SceneBufEntityData value = item.Value;
			if (value.EType == 5 && value.BufName == "energydevice")
			{
				sceneBufEntityData = value;
				break;
			}
		}
		if (sceneBufEntityData != null)
		{
			float x = sceneBufEntityData.X;
			float y = sceneBufEntityData.Y;
			float z = sceneBufEntityData.Z + 80f;
			Vector3 compenstatePos = Contexts.sharedInstance.player.cameraOwnerEntity.GetCompenstatePos(Contexts.sharedInstance.player.cameraOwnerEntity.fpos.Change.GetPosIndex());
			Vector3 vector = new Vector3(x, y, z);
			Vector3 vector2 = compenstatePos - vector;
			num = vector2.magnitude * 0.01f;
			visiable = true;
			if (Mathf.Abs(PyEngineUtility.GetBoxTrace(UiIEventCondition.Get_uiPyEngine_PyEngine(), compenstatePos, vector, 33619977).Fraction - 1f) < 0.0001f)
			{
				vector2.Normalize();
				temp.x = vector2.x;
				temp.y = vector2.y;
				temp.z = vector2.z;
				if (VectorUtils.DotProduct(player.Viewaxis()[0], temp) > Mathf.Sin((float)player.fov.Fov * 0.5f))
				{
					visiable = false;
				}
			}
			vector2.z = 0f;
			vector2.Normalize();
			temp.x = vector2.x;
			temp.y = vector2.y;
			temp.z = vector2.z;
			AngleUtility.VectorToAngles(temp, temp);
			rotation = 0f - ((float)temp.x - player.GetViewYaw());
		}
		_messageContext.pveUIMessage.Distance = (int)num;
		_messageContext.pveUIMessage.Visiable = visiable;
		_messageContext.pveUIMessage.Rotation = rotation;
	}
}
