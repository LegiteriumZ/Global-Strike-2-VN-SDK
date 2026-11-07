using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Framework;
using Assets.Sources.Modules.BattleRoom;
using Entitas;
using NetData;
using NotifyEvent;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneBuff;

public class SceneBuffEffectRenderSystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _effectGroup;

	private TimeContext _timeContext;

	private IBattleRoom _battleRoomAdapter;

	private PlayerContext _playerContext;

	private MessageContext _messageContext;

	private bool _inBreakPoint;

	private bool _canPickWeapon;

	private bool _canOpenKongzhiqi;

	private bool _canCloseKongzhiqi;

	private bool _jumpStart;

	private bool _jumpStop;

	public SceneBuffEffectRenderSystem(Contexts contexts)
	{
		_messageContext = contexts.message;
		_playerContext = contexts.player;
		_timeContext = contexts.time;
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
		_effectGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SceneBufferEffect, SceneObjectMatcher.UnityObjects, SceneObjectMatcher.Position, SceneObjectMatcher.Scale).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnRender()
	{
		_inBreakPoint = false;
		_canPickWeapon = false;
		_canOpenKongzhiqi = false;
		_canCloseKongzhiqi = false;
		_jumpStart = false;
		_jumpStop = false;
		foreach (SceneObjectEntity item in _effectGroup)
		{
			if (item.hasSceneBufferEffectRender)
			{
				ISceneBuffEffectRender render = item.sceneBufferEffectRender.Render;
				render.Render(_timeContext.time.FrameInterval, _battleRoomAdapter);
				item.position.Origin = render.GetOffset(_battleRoomAdapter);
				item.scale.Scale = render.GetScale(_battleRoomAdapter);
				_inBreakPoint = _inBreakPoint || render.InBreakPoint();
				_canPickWeapon = _canPickWeapon || render.CanPickWeapon();
				_canOpenKongzhiqi = _canOpenKongzhiqi || render.CanOpenKongzhiqi();
				_canCloseKongzhiqi = _canCloseKongzhiqi || render.CanCloseKongzhiqi();
				_jumpStart = _jumpStart || render.JumpStart();
				_jumpStop = _jumpStop || render.JumpStop();
			}
			if (item.sceneBufferEffect.Target is SceneObjectEntity { hasSceneBuff: not false } sceneObjectEntity && item.hasSceneBufferEffectRender)
			{
				Vector3 inv = new Vector3(sceneObjectEntity.sceneBuff.Data.X, sceneObjectEntity.sceneBuff.Data.Y, sceneObjectEntity.sceneBuff.Data.Z) + item.position.Origin;
				Vector3 inv2 = new Vector3(item.scale.Scale.x * item.sceneBuff.Data.Scale.X, item.scale.Scale.y * item.sceneBuff.Data.Scale.Y, item.scale.Scale.z * item.sceneBuff.Data.Scale.Z);
				ISceneBuffEffectRender render2 = item.sceneBufferEffectRender.Render;
				Transform transform = item.unityObjects.LoadResults[0].GameObject.transform;
				transform.position = VectorCoordConverter.SsjjToUnity(inv);
				transform.eulerAngles = render2.GetRotation(sceneObjectEntity);
				transform.localScale = VectorCoordConverter.SsjjScaleToUnity(inv2);
			}
		}
		if (_playerContext.isMyPlayer)
		{
			_playerContext.myPlayerEntity.isInBreakpoint = _inBreakPoint;
		}
		if (_canPickWeapon)
		{
			_messageContext.gameMessageData.MsgTypeDic[5] = 1;
			_messageContext.gameMessageData.Changed = true;
			NotifyManager.ForceInvoke(13);
		}
		else
		{
			_messageContext.gameMessageData.MsgTypeDic.Remove(5);
		}
		if (_canOpenKongzhiqi)
		{
			_messageContext.gameMessageData.MsgTypeDic[6] = 1;
			_messageContext.gameMessageData.Changed = true;
			NotifyManager.ForceInvoke(13);
		}
		else
		{
			_messageContext.gameMessageData.MsgTypeDic.Remove(6);
		}
		if (_canCloseKongzhiqi)
		{
			_messageContext.gameMessageData.MsgTypeDic[7] = 1;
			_messageContext.gameMessageData.Changed = true;
			NotifyManager.ForceInvoke(13);
		}
		else
		{
			_messageContext.gameMessageData.MsgTypeDic.Remove(7);
		}
		if (_jumpStart)
		{
			_messageContext.gameMessageData.SimpleProto = new SimpleProto
			{
				Key = 1,
				Ins = { 0, 1006 }
			};
			_messageContext.gameMessageData.Changed = true;
			NotifyManager.ForceInvoke(13);
		}
		if (_jumpStop)
		{
			_messageContext.gameMessageData.SimpleProto = new SimpleProto
			{
				Key = 1,
				Ins = { 0, 1007 }
			};
			_messageContext.gameMessageData.Changed = true;
			NotifyManager.ForceInvoke(13);
		}
	}
}
