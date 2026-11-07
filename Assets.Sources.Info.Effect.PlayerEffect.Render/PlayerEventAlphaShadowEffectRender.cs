using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class PlayerEventAlphaShadowEffectRender : AbstractPlayerEffectRender
{
	private PlayerAlphaShadow _shadowComp;

	private int _time;

	public static PlayerEntity CameraOwnerEntity;

	public static PlayerEntity MyPlayerEntity;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		_shadowComp = effectGameObject.GetComponent<PlayerAlphaShadow>();
		CameraOwnerEntity = Contexts.sharedInstance.player.cameraOwnerEntity;
		MyPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		if (targetPlayer == null)
		{
			return;
		}
		if (targetPlayer.eventGhost.GhostAllTime != 0)
		{
			_time = targetPlayer.eventGhost.GhostAllTime;
			_shadowComp.Interval = (float)targetPlayer.eventGhost.GhostAllTime / 1000f;
			Renderer[] allRenders = targetPlayer.GetAllRenders();
			if (allRenders != null)
			{
				for (int i = 0; i < allRenders.Length; i++)
				{
					SkinnedMeshRenderer skinnedMeshRenderer = allRenders[i] as SkinnedMeshRenderer;
					if (skinnedMeshRenderer != null)
					{
						_shadowComp.MainTexture = skinnedMeshRenderer.sharedMaterial.mainTexture;
						_shadowComp.Color = new Color(1f, 1f, 1f, (float)targetPlayer.eventGhost.GhostAllTime % 10f / 10f);
						if (Mathf.Approximately(_shadowComp.Color.a, 0f))
						{
							_shadowComp.Color.a = 1f;
						}
						_shadowComp.Render(skinnedMeshRenderer, targetPlayer);
					}
				}
			}
			SkinnedMeshRenderer[] weaponSkinnedMeshRenderer = targetPlayer.GetWeaponSkinnedMeshRenderer();
			if (weaponSkinnedMeshRenderer != null)
			{
				SkinnedMeshRenderer[] array = weaponSkinnedMeshRenderer;
				foreach (SkinnedMeshRenderer skinnedMeshRenderer2 in array)
				{
					if (!(skinnedMeshRenderer2 == null))
					{
						_shadowComp.MainTexture = skinnedMeshRenderer2.sharedMaterial.mainTexture;
						_shadowComp.Color = new Color(1f, 1f, 1f, (float)targetPlayer.eventGhost.GhostAllTime % 10f / 10f);
						if (Mathf.Approximately(_shadowComp.Color.a, 0f))
						{
							_shadowComp.Color.a = 1f;
						}
						_shadowComp.Render(skinnedMeshRenderer2, targetPlayer);
					}
				}
			}
			targetPlayer.eventGhost.GhostAllTime = 0;
		}
		_time -= frameTime;
		if (_time <= 0)
		{
			targetPlayer.RemoveEventGhost();
		}
	}
}
