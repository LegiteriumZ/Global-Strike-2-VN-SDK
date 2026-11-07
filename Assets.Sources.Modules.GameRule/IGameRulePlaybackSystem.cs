using Assets.Sources.Framework;

namespace Assets.Sources.Modules.GameRule;

public interface IGameRulePlaybackSystem : IPlaybackSystem
{
	bool NeedStart(Contexts contexts);
}
