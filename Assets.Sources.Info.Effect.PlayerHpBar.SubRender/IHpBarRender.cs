using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public interface IHpBarRender
{
	void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar);

	void Update(PlayerEntity playerEntity, Vector3 pos);
}
