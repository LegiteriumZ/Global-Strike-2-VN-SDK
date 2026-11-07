using SSJJNetworking.Server;

namespace Assets.Sources.Systems.PacketHandle;

public interface IPacketHandler<T>
{
	IPacketBodyParser<T> Parser { get; }

	int MethodId();

	void Handle(T data);
}
