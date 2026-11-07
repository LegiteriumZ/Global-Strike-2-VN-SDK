using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class WeightLessnessHandler : ApcPacketHandler<IntData>
{
	private readonly WeaponContext _weaponContext;

	public WeightLessnessHandler(Contexts contexts)
	{
		_weaponContext = contexts.weapon;
	}

	public override int MethodId()
	{
		return 200;
	}

	public override void Handle(IntData data)
	{
		if (data.DataSpecified)
		{
			_weaponContext.weightLessness.IsWeightLessness = data.Data > 0;
		}
	}
}
