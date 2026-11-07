using Assets.Res.Assets.Scripts;
using Assets.Sources.Framework;
using Entitas;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Modules.Player.Effect;

public class PlayerChangeSkinSystem : IRenderSystem
{
	private IGroup<PlayerEntity> _group;

	public PlayerChangeSkinSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects));
	}

	public void OnRender()
	{
		foreach (PlayerEntity item in _group)
		{
			if (!(item.GetCareer() == "boss1019"))
			{
				continue;
			}
			int num = (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_BOSS19_RENJIA.ID) ? 1 : 0);
			if (!item.hasThirdPersonUnityObjects)
			{
				continue;
			}
			Renderer renderer = item.thirdPersonUnityObjects.MeshRenders[0];
			if (renderer != null)
			{
				TextureList component = item.thirdPersonUnityObjects.ThirdTran.BodyTransform.GetComponent<TextureList>();
				if (renderer.material.mainTexture != component.Textures[num])
				{
					renderer.material.mainTexture = component.Textures[num];
				}
			}
		}
	}
}
