using Entitas;

namespace Assets.Sources.Systems.GameRule;

public class GameRuleFeature : Feature
{
	public GameRuleFeature(Contexts contexts)
		: base("GameRuleFeature")
	{
		Add(new SectionTimeSystem(contexts));
		Add(new PlayerMoveControlSystem(contexts));
	}

	public sealed override Entitas.Systems Add(ISystem system)
	{
		return base.Add(system);
	}
}
