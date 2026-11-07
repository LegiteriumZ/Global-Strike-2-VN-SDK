using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class ConsoleMessageHandler : ApcPacketHandler<StringData>
{
	private MessageContext _messageContext;

	private const int NUM_PER_LINE = 55;

	public ConsoleMessageHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 342;
	}

	public override void Handle(StringData data)
	{
		int num = 0;
		while (data.Data.Length - num * 55 > 55)
		{
			_messageContext.consoleMessage.ConsoleMessage.Add(data.Data.Substring(num++ * 55, 55));
		}
		_messageContext.consoleMessage.ConsoleMessage.Add(data.Data.Substring(num * 55, data.Data.Length - num * 55));
	}
}
