using System;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Entitas;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Modules.Message.Rpg;

public class RpgTipsSystem : IMessagePlaybackSystem, IPlaybackSystem
{
	private IGroup<SceneObjectEntity> _group;

	private MessageContext _messageContext;

	private GameRuleContext _gameRuleContext;

	public RpgTipsSystem(Contexts contexts)
	{
		_messageContext = contexts.message;
		_gameRuleContext = contexts.gameRule;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PveTower, SceneObjectMatcher.UnityObjects));
	}

	public void OnPlayback()
	{
		if (UiIEventCondition.Get_cameraOwnerData_Observer() > 0)
		{
			return;
		}
		foreach (SceneObjectEntity item in _group)
		{
			if (item.pveTower.Data.FileName.IndexOf("_replenishment", StringComparison.Ordinal) > 0 && Math.Abs(item.position.Origin.x - UiIEventCondition.Get_cameraOwnerData_Position().x) < 300f && Math.Abs(item.position.Origin.y - UiIEventCondition.Get_cameraOwnerData_Position().y) < 300f && Math.Abs(item.position.Origin.z - UiIEventCondition.Get_cameraOwnerData_Position().z) < 300f)
			{
				_messageContext.gameTipsShow.TipsEvent.Add(new RpgTipsEventData
				{
					TypeId = -3500
				});
				NotifyManager.ForceInvoke(14);
			}
		}
	}

	public bool NeedStart(Contexts contexts)
	{
		return _gameRuleContext.currentRule.Rule.IsRpg();
	}
}
