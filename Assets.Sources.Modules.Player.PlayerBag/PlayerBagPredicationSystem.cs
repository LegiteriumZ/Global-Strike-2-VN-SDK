using Assets.Sources.Framework;
using SSJJBase.Logger;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.PlayerBag;

public class PlayerBagPredicationSystem : IPredicateSystem
{
	private readonly PlayerBagContext _bagContext;

	public PlayerBagPredicationSystem(Contexts contexs)
	{
		_bagContext = contexs.playerBag;
	}

	public void OnPredicate(PlayerEntity player, IUserCmd cmd)
	{
		if (cmd.BagId >= 1)
		{
			PlayerBagEntity entityWithBagId = _bagContext.GetEntityWithBagId(cmd.BagId);
			if (entityWithBagId != null && _bagContext.currentBagEntity == null)
			{
				this.LogError("Current Bag Is Null ??!!");
			}
		}
	}
}
