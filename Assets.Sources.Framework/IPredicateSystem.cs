using SSJJUserCmd;

namespace Assets.Sources.Framework;

public interface IPredicateSystem
{
	void OnPredicate(PlayerEntity player, IUserCmd cmd);
}
