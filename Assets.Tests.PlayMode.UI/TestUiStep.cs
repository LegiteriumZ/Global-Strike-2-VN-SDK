namespace Assets.Tests.PlayMode.UI;

public static class TestUiStep
{
	public static void Step(string tips)
	{
		if (TestUiModuleUtils._text != null)
		{
			TestUiModuleUtils._text.text = tips;
		}
	}
}
