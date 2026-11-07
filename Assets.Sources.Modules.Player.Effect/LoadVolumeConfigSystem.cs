using Assets.Sources.Framework;
using Assets.Sources.Info.Res;
using Assets.Sources.Particle;
using Entitas;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Effect;

public class LoadVolumeConfigSystem : LoadAndInitResourceSystem<PlayerEntity>
{
	private IGroup<PlayerEntity> _loadGroup;

	private IGroup<PlayerEntity> _initGroup;

	public LoadVolumeConfigSystem(Contexts contexts)
	{
		_loadGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.PlayerVolume).NoneOf(PlayerMatcher.Destroy));
		_initGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.PlayerVolumeResource).NoneOf(PlayerMatcher.Destroy));
	}

	protected override void CleanResouceComponent(PlayerEntity entity)
	{
		entity.RemovePlayerVolumeResource();
	}

	protected override IGroup<PlayerEntity> GetLoadGroup()
	{
		return _loadGroup;
	}

	protected override IGroup<PlayerEntity> GetInitGroup()
	{
		return _initGroup;
	}

	protected override bool IsResourceMatch(PlayerEntity entity)
	{
		if (entity.playerVolumeResource.Identifier == null)
		{
			return false;
		}
		return entity.playerVolumeResource.Identifier.Equals("playerVolumeConfig");
	}

	protected override void OnInitEntityResource(PlayerEntity entity)
	{
		if (entity.hasPlayerVolumeResource)
		{
			TextAsset textAsset = entity.playerVolumeResource.LoadResults["playerVolumeConfig"].Object as TextAsset;
			if (textAsset != null)
			{
				PlayerVolumeConfig playerVolumeConfig = new PlayerVolumeConfig();
				playerVolumeConfig.SyncParse(textAsset.text);
				ParticleManager.Instance().AddVolumeConfig(playerVolumeConfig);
			}
		}
	}

	protected override void OnLoadEntityResource(PlayerEntity entity)
	{
		if (!entity.hasLoadPlayerVolumeResource)
		{
			LoadRequests loadRequests = new LoadRequests();
			AssetInfo assetInfo = new AssetInfo("player/default", "Assets/Res/Assets/Player/playerVolumeConfig.xml");
			loadRequests.Add("playerVolumeConfig", new LoadRequest(assetInfo));
			entity.AddLoadPlayerVolumeResource(loadRequests, "playerVolumeConfig");
			entity.isPlayerVolume = false;
		}
	}
}
