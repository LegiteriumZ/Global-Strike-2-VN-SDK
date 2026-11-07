using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class Boss1019EffectRender : AbstractPlayerShowEffectRender
{
	private TextureList _list;

	private Material _material;

	public override void Init(PlayerEntity player)
	{
	}

	public override void Render(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		if (_list == null && targetPlayer != null)
		{
			Transform bodyTransform = targetPlayer.thirdPersonUnityObjects.ThirdTran.BodyTransform;
			_list = bodyTransform.GetComponent<TextureList>();
			foreach (SkinnedMeshRenderer careerSkin in targetPlayer.thirdPersonUnityObjects.CareerSkins)
			{
				if (careerSkin.enabled)
				{
					_material = careerSkin.sharedMaterial;
				}
			}
		}
		if (_list != null && _material != null)
		{
			_material.mainTexture = (targetPlayer.HasStatus(PlayerInfoStatusConstant.RPG_BOSS19_RENJIA.ID) ? _list.Textures[1] : _list.Textures[0]);
		}
	}
}
