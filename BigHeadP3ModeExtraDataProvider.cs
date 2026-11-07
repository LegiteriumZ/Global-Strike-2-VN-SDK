public class BigHeadP3ModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/bigheadp3model";
		Providers.Add(new bigHeadP3ModelBigHeadP3SkillProvider(contexts));
	}
}
