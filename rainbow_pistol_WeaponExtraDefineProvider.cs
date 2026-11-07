using Assets.Sources.Components.Time;

public class rainbow_pistol_WeaponExtraDefineProvider : Abstractrainbow_pistol_WeaponExtraDefineProvider
{
	private int textureIndex;

	private int nowFrame;

	private int frameGap = 5;

	public override void OnFrame(TimeComponent time)
	{
		if (nowFrame > frameGap)
		{
			nowFrame = 0;
			textureIndex++;
			textureIndex %= 5;
		}
		else
		{
			nowFrame++;
		}
	}

	public override string updateAutoHitUrl()
	{
		return "/weapon/rainbow_pistol/ui/autohit_" + (textureIndex + 1);
	}
}
