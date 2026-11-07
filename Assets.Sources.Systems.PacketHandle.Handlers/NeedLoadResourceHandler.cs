using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class NeedLoadResourceHandler : ApcPacketHandler<NeedLoadResourceData>
{
	private readonly SceneObjectContext _sceneObjectContext;

	public NeedLoadResourceHandler(Contexts contexts)
	{
		_sceneObjectContext = contexts.sceneObject;
	}

	public override int MethodId()
	{
		return 127;
	}

	public override void Handle(NeedLoadResourceData data)
	{
		_sceneObjectContext.CreateEntity().AddNeedResource(data.SkillList);
	}
}
