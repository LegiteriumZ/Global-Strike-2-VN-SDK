using System;
using Assets.Sources.Utils.Weapon;
using Entitas;
using I2.Loc;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Attack.Action;

public class AwmLegendSpecialFrameAction : IFrameCmdAction, ICmdAction
{
	private readonly IGroup<SceneObjectEntity> _effectGroup;

	private readonly MessageContext _messageContext;

	public AwmLegendSpecialFrameAction(Contexts contexts)
	{
		_messageContext = contexts.message;
		_effectGroup = Contexts.sharedInstance.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PredictionEffect).NoneOf(SceneObjectMatcher.Destroy));
	}

	protected virtual bool IsSkill1Active(WeaponEntity currentWeapon)
	{
		if (currentWeapon.special.EffectLevel == 1)
		{
			return AwmLegendBaseAction.IsMiaoZhun(currentWeapon);
		}
		return false;
	}

	public virtual bool Action(ref CommonWeaponArg arg)
	{
		if (IsSkill1Active(arg.CurrentWeapon))
		{
			MouseLogic(arg.Player, arg.CurrentWeapon);
		}
		return true;
	}

	protected void MouseLogic(PlayerEntity player, WeaponEntity currentWeapon)
	{
		Vector3 endPos = FireUtility.TraceWorldInDistance(player, currentWeapon);
		if (!endPos.Equals(Vector3.zero))
		{
			AddSkillMarkEntity(endPos, currentWeapon);
		}
		else
		{
			MarkFailedHint();
		}
	}

	protected virtual void MarkFailedHint()
	{
		_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("OUT_OF_RANGE"), 100);
		NotifyManager.ForceInvoke(38);
	}

	private void AddSkillMarkEntity(Vector3 endPos, WeaponEntity currentWeapon)
	{
		endPos.z += 5f;
		SceneObjectEntity sceneObjectEntity = null;
		using (IGroup<SceneObjectEntity>.Enumator enumator = _effectGroup.GetEnumerator())
		{
			if (enumator.MoveNext())
			{
				sceneObjectEntity = enumator.Current;
			}
		}
		if (sceneObjectEntity == null)
		{
			sceneObjectEntity = Contexts.sharedInstance.sceneObject.CreateEntity();
			AssetInfo markEffectAsset = GetMarkEffectAsset(currentWeapon);
			sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(markEffectAsset), -1);
			sceneObjectEntity.isPredictionEffect = true;
		}
		sceneObjectEntity.ReplaceLifeTime(DateTime.Now, 100);
		sceneObjectEntity.ReplacePosition(endPos);
	}

	protected virtual AssetInfo GetMarkEffectAsset(WeaponEntity currentWeapon)
	{
		return new AssetInfo("weapon/" + currentWeapon.basicInfo.Data.WeaponName, $"Assets/Res/Assets/weapon/{currentWeapon.basicInfo.Data.WeaponName}/effect/11470_biaoji/Prefab/11470_biaoji.prefab");
	}
}
