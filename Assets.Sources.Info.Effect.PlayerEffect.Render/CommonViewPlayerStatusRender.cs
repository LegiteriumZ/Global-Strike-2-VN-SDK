using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Info.Accessory;
using Assets.Sources.Info.Res;
using Assets.Sources.Utils;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class CommonViewPlayerStatusRender : AbstractPlayerEffectRender
{
	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		EffectObject = effectGameObject;
		if (player.hasFirstPersonUnityObjects && player.firstPersonUnityObjects.HandGameObject != null)
		{
			effectGameObject.transform.parent = player.firstPersonUnityObjects.HandGameObject.transform;
		}
		LayerUtility.SetLayerRecursively(effectGameObject, LayerMask.NameToLayer("FPSArmWeapon"));
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
	}

	public override void Update(int frameTime, PlayerEntity player, SceneObjectEntity effectEntity, IBattleRoom room)
	{
		if (!(EffectObject != null))
		{
			return;
		}
		IPlayerEffectInfo effectInfo = effectEntity.playerEffect.EffectInfo;
		string[] array = effectInfo.GetUniqueId().Split(' ');
		float[] array2 = new float[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = float.Parse(array[i]);
		}
		Matrix4x4 backWeaponTransform = BackWeaponXmlConfig.GetBackWeaponTransform(array2);
		EffectObject.transform.localPosition = backWeaponTransform.ExtractPosition();
		EffectObject.transform.localRotation = backWeaponTransform.ExtractRotation();
		EffectObject.transform.localScale = backWeaponTransform.ExtractScale();
		if (!string.IsNullOrEmpty(effectInfo.GetJointName()) && player.hasFirstPersonUnityObjects && player.firstPersonUnityObjects.HandCameraObject != null)
		{
			Transform bone = player.firstPersonUnityObjects.HandAnimator.GetBone(effectInfo.GetJointName());
			if (bone != null)
			{
				EffectObject.transform.SetParent(bone, worldPositionStays: false);
				EffectObject.transform.localPosition = backWeaponTransform.ExtractPosition();
				EffectObject.transform.localRotation = backWeaponTransform.ExtractRotation();
				EffectObject.transform.localScale = backWeaponTransform.ExtractScale();
			}
			Transform parent = player.firstPersonUnityObjects.HandGameObject.transform.parent;
			if (parent != null)
			{
				EffectObject.transform.SetParent(parent, worldPositionStays: true);
			}
		}
	}

	protected override void UpdatePosition(GameObject effectObject, PlayerEntity player, SceneObjectEntity effectEntity, IBattleRoom room, bool autosize, ref PlayerVolumeConfig.ConfigData config)
	{
	}

	protected override void UpdateRotation(GameObject effectObject, PlayerEntity player, SceneObjectEntity effectEntity, IBattleRoom room, bool autosize, ref PlayerVolumeConfig.ConfigData config)
	{
	}
}
