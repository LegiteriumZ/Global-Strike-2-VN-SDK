using Assets.Sources.Free.UI;
using Assets.Sources.Modules.Ui.UiEventCondition;
using NotifyEvent;
using SSJJBase.Singleton;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.Common;

public class PeekabooMiniMapModel : MiniMapModel
{
	protected override void DoSubscribe()
	{
		_duwuImage = _viewModel.DuwuObj.GetComponent<CircleImage>();
		_freeMark = _gameRuleContext.currentRule.Rule.EnableFreeMark;
		SetMapPosition();
		_viewModel.ShowShow = false;
		_viewModel.HelpInfoShow = _freeMark;
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_ControlEntityData_Yaw, base.SetYaw, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_TacticsSoundTime, base.SetTacticsSoundTime, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_ControlEntityData_Position, base.SetPosition, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_IsDead, base.SetIsDead, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_cameraOwnerData_PlayerName, base.SetPlayerName, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Hp, base.SetHp, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_minimapData_MapInfo, base.SetMapInfo, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_minimapData_ShowDuwu, base.SetShowDuwu, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(base.GetDuwuImage, base.SetDuwuImage, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(base.GetInnerOffset, base.SetInnerOffset, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(base.GetThickness, base.SetThickness, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(base.GetHideSelf, base.SetHideSelf, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(base.GetGray, base.SetGray, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(base.GetSafeSize, base.SetSafeSize, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(base.GetSafePosition, base.SetSafePosition, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_minimapData_ImageListCount, base.SetImageListCount, null, initinvoke: true));
		_notifyGroup.SetSuspend(suspend: true);
		if (!_freeMark)
		{
			return;
		}
		_viewModel.CreateTriggerEntry(_viewModel.ImageBackTriggers, EventTriggerType.PointerClick, delegate(BaseEventData data)
		{
			if (data is PointerEventData { button: PointerEventData.InputButton.Right } pointerEventData && pointerEventData.position.x < (float)Display.main.systemWidth * 0.5f + _width * 0.5f && pointerEventData.position.y > (float)Display.main.systemHeight * 0.5f - _height * 0.5f)
			{
				Vector3 vector = new Vector3(pointerEventData.position.x - (float)Display.main.systemWidth * 0.5f - _viewModel.ItemsPosition.x, pointerEventData.position.y - (float)Display.main.systemHeight * 0.5f - _viewModel.ItemsPosition.y);
				vector = new Vector2(vector.x / _scaleX + _worldMin.x, vector.y / _scaleY + _worldMin.y);
				MonoBehaviourSingleton<FreeUiManager>.Instance.ClickSmallMap(vector, Vector3.Distance(_lastClickPos, pointerEventData.position));
				_lastClickPos = pointerEventData.position;
			}
		});
	}
}
