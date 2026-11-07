using Assets.Sources.Framework;

namespace Assets.Sources.Modules.GameRule;

public interface IGameRuleResetSystem : IEntityPreDestroySystem
{
	bool NeedStart(Contexts contexts);
}
