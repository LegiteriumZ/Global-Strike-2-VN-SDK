using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Res;
using NetData;
using SSJJBase.Extensions;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class ViewPlayerStatusRender : AbstractPlayerEffectRender
{
	private GameObject otherobj = new GameObject();

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		Transform parent = effectGameObject.transform.parent;
		otherobj.transform.SetParent(parent);
		effectGameObject.transform.SetParent(otherobj.transform);
		EffectObject = effectGameObject;
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
		string[] array = effectEntity.playerEffect.EffectInfo.GetUniqueId().Split('|');
		int num = int.Parse(array[0]);
		int num2 = int.Parse(array[1]);
		int num3 = int.Parse(array[2]);
		float num4 = float.Parse(array[3]);
		int num5 = int.Parse(array[4]);
		EffectObject.transform.localPosition = VectorCoordConverter.SsjjToUnity(new Vector3(num, num2, num3));
		otherobj.transform.localPosition = UnityEngine.Camera.main.transform.position;
		otherobj.transform.SetSsjjRotationZ(player.GetViewYaw());
		otherobj.transform.SetSsjjRotationX(player.GetViewPitch());
		if (Contexts.sharedInstance.playerBag.hasC4Bag)
		{
			BaseWeaponData c4Weapon = Contexts.sharedInstance.playerBag.c4Bag.C4Weapon;
			if (num5 == 1)
			{
				num4 *= 0.5f + 0.5f * (float)c4Weapon.Power / (float)c4Weapon.MaxPower;
			}
			if (num5 == 2)
			{
				num4 *= 1f - 0.5f * (float)c4Weapon.Power2 / (float)c4Weapon.MaxPower2;
			}
		}
		EffectObject.transform.localScale = new Vector3(num4, num4, num4);
	}

	protected override void UpdatePosition(GameObject effectObject, PlayerEntity player, SceneObjectEntity effectEntity, IBattleRoom room, bool autosize, ref PlayerVolumeConfig.ConfigData config)
	{
	}

	protected override void UpdateRotation(GameObject effectObject, PlayerEntity player, SceneObjectEntity effectEntity, IBattleRoom room, bool autosize, ref PlayerVolumeConfig.ConfigData config)
	{
	}
}
