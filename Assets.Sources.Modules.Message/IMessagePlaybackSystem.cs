using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Message;

public interface IMessagePlaybackSystem : IPlaybackSystem
{
	bool NeedStart(Contexts contexts);
}
