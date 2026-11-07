namespace Assets.Sources.Free.UI;

public class FreeRadioButtonComponent : FreeButtonComponent
{
	public FreeRadioButtonComponent()
	{
		FreeCheckUIButton button = GetButton();
		if (button != null)
		{
			button.Mode |= FreeCheckUIButton.CheckUiMode.Single;
		}
	}

	public override IFreeComponent Clone()
	{
		return new FreeButtonComponent();
	}
}
