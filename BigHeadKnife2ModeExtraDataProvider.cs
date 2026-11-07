public class BigHeadKnife2ModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/bigHeadKnife2Model";
		Providers.Add(new bigHeadKnife2ModelBigHeadKnife2BuffProvider(contexts));
		Providers.Add(new bigHeadKnife2ModelBigHeadKnife2SkillFItemProvider(contexts));
		Providers.Add(new bigHeadKnife2ModelBigHeadKnife2SkillMessageProvider(contexts));
		Providers.Add(new bigHeadKnife2ModelBigHeadKnife2WeaponProvider(contexts));
	}
}
