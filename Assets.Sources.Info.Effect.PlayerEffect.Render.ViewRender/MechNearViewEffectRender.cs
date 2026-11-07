using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using Assets.Sources.Modules.Ui;
using Assets.UiFramework.Libs;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render.ViewRender;

public class MechNearViewEffectRender : AbstractPlayerViewShowEffectRender
{
	private ModelTextureSheetAnimation _animation;

	public UiResourcesLoader Loader;

	private int _loadTextureCount;

	private bool _load;

	public override void Init(PlayerEntity player)
	{
		Loader = (UiResourcesLoader)AbstractModel.GetUiResourceLoader();
	}

	public override void Render(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		Transform transform = null;
		SkinnedMeshRenderer[] handSkinnedMeshRenderers = targetPlayer.firstPersonUnityObjects.HandSkinnedMeshRenderers;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in handSkinnedMeshRenderers)
		{
			if (skinnedMeshRenderer.name == "Plane001")
			{
				transform = skinnedMeshRenderer.transform;
				break;
			}
		}
		if (transform == null)
		{
			return;
		}
		if (!_load)
		{
			_load = true;
			_animation = transform.gameObject.AddComponent<ModelTextureSheetAnimation>();
			_animation.Speed = 100;
			_animation.Textures = new Texture2D[8];
			for (int k = 1; k < 9; k++)
			{
				int i1 = k;
				Loader.Load("weapon/mechnear", "Assets/Res/Assets/weapon/mechnear/effect/weaponanchor" + k + ".png", delegate(Object sprite)
				{
					_animation.Textures[i1 - 1] = sprite as Texture2D;
					_loadTextureCount++;
				});
			}
			_animation.gameObject.SetActive(value: false);
		}
		if (_animation != null && _loadTextureCount == 8)
		{
			_animation.gameObject.SetActive(value: true);
		}
	}
}
