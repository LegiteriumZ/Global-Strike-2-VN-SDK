using SSJJNetworking.Server;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public abstract class ApcPacketHandler<T> : IPacketHandler<T>
{
	public IPacketBodyParser<T> Parser => ApcBodyParser<T>.Instance;

	public abstract int MethodId();

	public abstract void Handle(T data);
}
