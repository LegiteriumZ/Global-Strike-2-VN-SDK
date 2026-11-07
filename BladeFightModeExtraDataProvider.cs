public class BladeFightModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/bladefightmodel";
		Providers.Add(new bladefightModelfogAreaTimeProvider(contexts));
		Providers.Add(new bladefightModelMessageProvider(contexts));
		Providers.Add(new bladefightModelReliveBagPickingProvider(contexts));
		Providers.Add(new bladefightModelReliveProvider(contexts));
		Providers.Add(new bladefightModelSurplusPlayerProvider(contexts));
		Providers.Add(new bladefightModelWaitPlayerProvider(contexts));
		Providers.Add(new bladefightModelGameOverProvider(contexts));
	}
}
