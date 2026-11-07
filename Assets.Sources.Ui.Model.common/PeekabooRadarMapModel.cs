using Assets.Sources.Modules.Ui.UiEventCondition;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class PeekabooRadarMapModel : RadarMapModel
{
	protected override void DoSubscribe()
	{
		_duwuImage = _viewModel.DuwuObj.GetComponent<CircleImage>();
		SetMapPosition();
		_listener = NotifyManager.MakeTempNotifyList(UiIEventCondition.Get_minimapData_ImageList);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_ControlEntityData_Yaw, SetYaw, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_TacticsSoundTime, base.SetTacticsSoundTime, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_ControlEntityData_Position, base.SetPosition, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_minimapData_MapInfo, base.SetMapInfo, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_minimapData_ShowDuwu, base.SetShowDuwu, null, initinvoke: true);
		NotifyManager.MakeTempNotify(base.GetDuwuImage, base.SetDuwuImage, null, initinvoke: true);
		NotifyManager.MakeTempNotify(base.GetInnerOffset, base.SetInnerOffset, null, initinvoke: true);
		NotifyManager.MakeTempNotify(base.GetThickness, base.SetThickness, null, initinvoke: true);
		NotifyManager.MakeTempNotify(base.GetHideSelf, base.SetHideSelf, null, initinvoke: true);
		NotifyManager.MakeTempNotify(base.GetGray, base.SetGray, null, initinvoke: true);
		NotifyManager.MakeTempNotify(base.GetSafeSize, base.SetSafeSize, null, initinvoke: true);
		NotifyManager.MakeTempNotify(base.GetSafePosition, base.SetSafePosition, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_minimapData_ImageListCount, SetImageListCount, null, initinvoke: true);
		NotifyManager.MakeNotify(71, UiIEventCondition.Get_RadarMap_Show, base.SetRadarActive);
		NotifyManager.MakeNotify(72, UiIEventCondition.Get_RadarMap_Hide, base.SetRadarActive);
		SetBotLevel();
	}

	protected override void SetYaw(float ov, float yaw)
	{
		_viewModel.MapRotationRotation = Quaternion.Euler(0f, 0f, 0f - yaw + 90f);
		_listener.ForceInvoke();
	}

	protected override void SetImageListCount(int arg1, int arg2)
	{
		while (arg2 > _itemList.Count)
		{
			PeekabooRadarMapItemModel peekabooRadarMapItemModel = new PeekabooRadarMapItemModel
			{
				Index = _itemList.Count,
				MapData = this,
				IsInRadar = true
			};
			_itemList.Add(peekabooRadarMapItemModel);
			peekabooRadarMapItemModel.SetGameRuleContext(_gameRuleContext);
			peekabooRadarMapItemModel.Initialize();
		}
	}
}
