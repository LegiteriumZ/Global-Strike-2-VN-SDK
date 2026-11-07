using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class PlayerGhostEffectRender : AbstractPlayerEffectRender
{
	private GhostShadow _shadowComp;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		_shadowComp = effectGameObject.GetComponent<GhostShadow>();
		switch (player.GetCareer())
		{
		case "boss1011":
			_shadowComp.RimColor = new Color(1f, 0.05f, 0.05f);
			_shadowComp.Interval = 0.1f;
			break;
		case "boss1019":
			_shadowComp.RimColor = new Color(0.8f, 0f, 0f);
			_shadowComp.Interval = 0.1f;
			break;
		case "bossjy3004":
			_shadowComp.RimColor = new Color(0.25f, 0.65f, 0.15f);
			_shadowComp.Interval = 0.1f;
			break;
		case "bossjy3001":
			_shadowComp.RimColor = new Color(0.6f, 0.847f, 0.941f);
			_shadowComp.Intension = 0f;
			_shadowComp.Interval = 0.1f;
			break;
		case "bossjy1002":
			_shadowComp.RimColor = new Color(0f, 1f, 1f);
			_shadowComp.Interval = 0.1f;
			break;
		default:
			_shadowComp.RimColor = new Color(0.6f, 0.847f, 0.941f, 1f);
			_shadowComp.Interval = 0.05f;
			break;
		}
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		SkinnedMeshRenderer skinnedMeshRender = targetPlayer.GetSkinnedMeshRender();
		if (skinnedMeshRender != null)
		{
			_shadowComp.Render(skinnedMeshRender, targetPlayer);
		}
	}
}
