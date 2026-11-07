using Assets.Sources.Components.Interface;
using Assets.Sources.Components.SceneObject.PlayerHpBar;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.BattleRoom;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.PlayerHpBar;

public class PlayerHpBarRenderSystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _effectGroup;

	private IBattleRoom _battleRoomAdapter;

	private TimeContext _timeContext;

	private TimeComponent _time;

	private int _frameInterval;

	private PlayerEntity _targetPlayer;

	private GameObject _effectGameObject;

	private PlayerHpBarComponent _playerHpBar;

	public PlayerHpBarRenderSystem(Contexts contexts)
	{
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
		_timeContext = contexts.time;
		_time = _timeContext.time;
		_effectGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PlayerHpBar, SceneObjectMatcher.UnityObjects, SceneObjectMatcher.Position).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnRender()
	{
		_frameInterval = _time.FrameInterval;
		foreach (SceneObjectEntity item in _effectGroup)
		{
			_playerHpBar = item.playerHpBar;
			if (UiIEventCondition.Cid2PlayerEntity.TryGetValue(_playerHpBar.Cid, out _targetPlayer) && _targetPlayer != null && item.hasPlayerHpBarRender && item.playerHpBarRender.Render.Render(_frameInterval, _targetPlayer, _battleRoomAdapter))
			{
				_effectGameObject = _playerHpBar.HpBarObj;
				_effectGameObject.transform.position = VectorCoordConverter.SsjjToUnity(_targetPlayer.GetCompenstatePos(_targetPlayer.fpos.Change.GetPosIndex()) + new Vector3(0f, 0f, item.playerHpBarRender.Render.CareerHeight));
			}
		}
	}
}
