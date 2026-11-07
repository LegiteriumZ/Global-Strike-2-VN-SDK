using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Message;

public interface IMessageResetSystem : IEntityPreDestroySystem
{
	bool NeedStart(Contexts contexts);
}
