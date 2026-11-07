using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Framework;
using Assets.Sources.Info.WeaponAnim;
using Entitas;
using SSJJAsset.Asset;

namespace Assets.Sources.Modules.Player.PlayerBag;

public class PlayerWeaponConfigPreLoadSystem : LoadAndInitResourceSystem<PlayerEntity>
{
	private PlayerContext _playerContext;

	private WeaponContext _weaponContext;

	private INoneOfMatcher<PlayerEntity> _nonematcher = PlayerMatcher.AllOf(PlayerMatcher.CameraOwner).NoneOf(PlayerMatcher.WeaponConfigPreloadFinish, PlayerMatcher.LoadBagWeaponConfigResource);

	private IAllOfMatcher<PlayerEntity> _allmatcher = PlayerMatcher.AllOf(PlayerMatcher.BagWeaponConfigResource);

	public PlayerWeaponConfigPreLoadSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_weaponContext = contexts.weapon;
	}

	protected override IGroup<PlayerEntity> GetLoadGroup()
	{
		return _playerContext.GetGroup(_nonematcher);
	}

	protected override IGroup<PlayerEntity> GetInitGroup()
	{
		return _playerContext.GetGroup(_allmatcher);
	}

	protected override void OnLoadEntityResource(PlayerEntity entity)
	{
		LoadRequests loadRequests = new LoadRequests();
		foreach (WeaponEntity item in _weaponContext)
		{
			if (item.slot.BagId == entity.basicInfo.Current.CurrentBagId)
			{
				IEntitsWeaponInfo info = item.basicInfo.Info;
				loadRequests.Add(item.weaponId.Value, new LoadRequest(new AssetInfo(info.AnimConfigBundleName, info.ViewAnimConfigAssetName, typeof(WeaponAnimAsset), optional: true)));
			}
		}
		entity.AddLoadBagWeaponConfigResource(loadRequests, null);
	}

	protected override bool IsResourceMatch(PlayerEntity entity)
	{
		return true;
	}

	protected override void CleanResouceComponent(PlayerEntity entity)
	{
		entity.RemoveBagWeaponConfigResource();
	}

	protected override void OnInitEntityResource(PlayerEntity entity)
	{
		foreach (LoadResults.MultiTV loadResult in entity.bagWeaponConfigResource.LoadResults)
		{
			if (!loadResult.IntKey.HasValue)
			{
				continue;
			}
			foreach (WeaponEntity item in _weaponContext)
			{
				if (item.weaponId.Value == loadResult.IntKey.Value)
				{
					IEntitsWeaponInfo info = item.basicInfo.Info;
					LoadResult value = loadResult.Value;
					WeaponAnimAsset weaponAnimAsset = value.Object as WeaponAnimAsset;
					if (!WeaponAnimInfoFactory.Instance.Exists(info))
					{
						WeaponAnimInfoFactory.Instance.Add(info, weaponAnimAsset.WeaponAnimInfo);
					}
				}
			}
		}
		entity.isWeaponConfigPreloadFinish = true;
	}
}
