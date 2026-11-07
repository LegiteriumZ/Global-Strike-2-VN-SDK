using System.Collections.Generic;
using Assets.Sources.Components.Camera;
using Assets.Sources.Free;
using Assets.Sources.Free.Const;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class SimpleUiDataHandler : ApcPacketHandler<SimpleProto>
{
	private SceneObjectContext _sceneObjectContext;

	private MessageContext _messageContext;

	private BattleRoomContext _battleRoomContext;

	private RoomData _data;

	public SimpleUiDataHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
		_battleRoomContext = contexts.battleRoom;
		_sceneObjectContext = contexts.sceneObject;
		if (!_sceneObjectContext.hasLocalEvent)
		{
			_sceneObjectContext.SetLocalEvent(new List<SimpleProto>());
		}
	}

	public override int MethodId()
	{
		return 100;
	}

	public override void Handle(SimpleProto data)
	{
		if (_battleRoomContext.roomData.Data != null && !_battleRoomContext.roomData.Data.IsLoadFreeTypeRes)
		{
			return;
		}
		SimpleMessageManager.Instance.Handle(data);
		if (data.Key == 1000)
		{
			WorldCameraContext worldCamera = Contexts.sharedInstance.worldCamera;
			if (!worldCamera.hasCameraValue)
			{
				worldCamera.SetCameraValue(new CameraValueComponent.CameraValue());
			}
			worldCamera.cameraValue.Value.Camera = data.Bs[0];
			if (worldCamera.cameraValue.Value.Camera)
			{
				SetCamera(worldCamera.cameraValue.Value, data);
				worldCamera.cameraValue.Value.Start = Contexts.sharedInstance.time.time.RenderTime;
			}
		}
		else if (SimpleProtoConstant.IsUIKey(data.Key))
		{
			if (data.Key == 3)
			{
				_battleRoomContext.gameOver.IsJumpGameOver = true;
				_battleRoomContext.gameOver.SimpleProto = data;
			}
			else if (data.Key == 1)
			{
				_messageContext.gameMessageData.SimpleProto = data;
				_messageContext.gameMessageData.Changed = true;
				NotifyManager.ForceInvoke(13);
			}
		}
		else
		{
			_sceneObjectContext.localEvent.EventDataList.Add(data);
		}
	}

	private void SetCamera(CameraValueComponent.CameraValue value, SimpleProto simpleProto)
	{
		int num = (value.Type = simpleProto.Ins[0]);
		if (num == 1)
		{
			for (int i = 0; i < 5; i++)
			{
				value.View[i] = (float)simpleProto.Ds[i];
			}
		}
		if (num == 2)
		{
			for (int j = 0; j < 5; j++)
			{
				value.View[j] = (float)simpleProto.Ds[j];
			}
			for (int k = 0; k < 5; k++)
			{
				value.Des[k] = (float)simpleProto.Ds[k + 5];
			}
			value.MoveForword = simpleProto.Bs[1];
			value.Total = simpleProto.Ins[1];
		}
		if (num == 3)
		{
			value.Total = simpleProto.Ins[1];
			value.Direction = simpleProto.Ins[2];
			value.Pos[0] = (float)simpleProto.Ds[0];
			value.Pos[1] = (float)simpleProto.Ds[1];
			value.Pos[2] = (float)simpleProto.Ds[2];
		}
		if (num == 4)
		{
			value.Total = simpleProto.Ins[1];
			value.Angle = simpleProto.Ins[2];
			value.Des[0] = (float)simpleProto.Ds[0];
			value.Des[1] = (float)simpleProto.Ds[1];
			value.Des[2] = (float)simpleProto.Ds[2];
			value.Pos[0] = (float)simpleProto.Ds[5];
			value.Pos[1] = (float)simpleProto.Ds[6];
			value.Pos[2] = (float)simpleProto.Ds[7];
		}
	}
}
