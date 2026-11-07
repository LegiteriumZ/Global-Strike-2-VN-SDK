public class CommonModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		base.Init(contexts);
		_keyInfo = "ui/common";
		Providers.Add(new commonSkatePressGuiProvider(contexts));
		Providers.Add(new commonPlayerExpressionProvider(contexts));
		Providers.Add(new commonSelfUseExpressionProvider(contexts));
		Providers.Add(new commonVideoHelpProvider(contexts));
		Providers.Add(new commonOctopusPositionSetProvider(contexts));
		Providers.Add(new commonPlayerInfoMessageProvider(contexts));
		Providers.Add(new commonStateProgressProvider(contexts));
		Providers.Add(new commonChallengeAffixProvider(contexts));
		Providers.Add(new commonTipsMessageProvider(contexts));
		Providers.Add(new commonPlayerInfoSkillMessageProvider(contexts));
		Providers.Add(new commonRandomKingTipProvider(contexts));
		Providers.Add(new commonNonstopdanceSkillProvider(contexts));
		Providers.Add(new commonHypertechSkillProvider(contexts));
		Providers.Add(new commonGameUITipsProvider(contexts));
		Providers.Add(new commonWeaponPromptProvider(contexts));
		Providers.Add(new commonbioReliveEProvider(contexts));
		Providers.Add(new commonbioGameUITipsProvider(contexts));
		Providers.Add(new commonwingflyProvider(contexts));
		Providers.Add(new commonDragonAuraSkillProvider(contexts));
		Providers.Add(new commonKickVoteUIProvider(contexts));
	}
}
