using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.Mode;
using Assets.UiFramework.Libs;

namespace Assets.Tests.PlayMode.UI;

public class TestUiMode<T> : AbstractMode where T : AbstractModel, IPlaybackSystem, new()
{
	public static T CurrModel;

	public TestUiMode(Contexts contexts)
		: base(contexts, flag: false)
	{
		CurrModel = new T();
		AddPlaybackSystem(CurrModel);
	}
}
