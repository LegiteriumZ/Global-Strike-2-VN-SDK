using Assets.Sources.Components.Interface;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Sources.Info.Effect.LocalEntityEffect.Render;

public class LeibaohongzhaStartEffectRender : AbstractLocalEntityEffectRender
{
	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		this.Info("lei bao hong zha !");
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
	}
}
