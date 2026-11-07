using Assets.Sources.Framework;
using SSJJUserCmd;
using share.constant;

public class PlayerPreAttackPredictionSystem : IPredicateSystem
{
	public PlayerPreAttackPredictionSystem(Contexts contexts)
	{
	}

	public void OnPredicate(PlayerEntity player, IUserCmd cmd)
	{
		if (player.HasStatus(PlayerInfoStatusConstant.DOG_CAN_NOT_ATTACK.ID))
		{
			cmd.Clear(-65);
			cmd.Clear(-513);
		}
		else if (player.HasStatus(PlayerInfoStatusConstant.CAN_NOT_ATTACK_NORMAL.ID))
		{
			cmd.Clear(-65);
		}
	}
}
