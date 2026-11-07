using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class BioItemsHandler : ApcPacketHandler<BioItemsData>
{
	private GameRuleContext _gameRuleContext;

	public BioItemsHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 212;
	}

	public override void Handle(BioItemsData data)
	{
		data.List.Sort(CompareFunc);
		_gameRuleContext.bioItems.BioItemsData = data;
	}

	private int CompareFunc(BioItemData a, BioItemData b)
	{
		if (a.KeyBorad > b.KeyBorad)
		{
			return 1;
		}
		if (a.KeyBorad == b.KeyBorad)
		{
			return 0;
		}
		return -1;
	}
}
