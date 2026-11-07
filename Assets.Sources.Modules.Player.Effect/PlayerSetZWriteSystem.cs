using Assets.Sources.Framework;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Effect;

public class PlayerSetZWriteSystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	public PlayerSetZWriteSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _playerContext)
		{
			if (item.hasTextureConfig && !item.IsDead() && item.hasThirdPersonUnityObjects)
			{
				Renderer renderer = item.thirdPersonUnityObjects.MeshRenders[0];
				if (item.hasState && item.hasSkill && item.skill.getStealthAlpha() < 0.05f)
				{
					renderer.material.SetInt("_ZWrite", 0);
				}
				else
				{
					renderer.material.SetInt("_ZWrite", 1);
				}
			}
		}
	}
}
