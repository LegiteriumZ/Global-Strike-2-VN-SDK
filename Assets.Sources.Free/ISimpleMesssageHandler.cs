using NetData;

namespace Assets.Sources.Free;

public interface ISimpleMesssageHandler
{
	bool CanHandle(int key);

	void Handle(SimpleProto data);
}
