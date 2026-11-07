public class ProtectBigHeadModeDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/protectbigheadmodel";
		Providers.Add(new protectBigHeadModelProtectBigHeadCareerUIProvider(contexts));
		Providers.Add(new protectBigHeadModelProtectBigheadTipsUIProvider(contexts));
	}
}
