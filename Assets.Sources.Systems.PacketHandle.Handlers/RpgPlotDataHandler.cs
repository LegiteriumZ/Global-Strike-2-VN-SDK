using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgPlotDataHandler : ApcPacketHandler<PlotData>
{
	private MessageContext _messageContext;

	public RpgPlotDataHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 202;
	}

	public override void Handle(PlotData data)
	{
		_messageContext.dialog.PlotData = data;
	}
}
