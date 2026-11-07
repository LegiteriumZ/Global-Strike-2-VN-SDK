using Assets.UiFramework.Libs;
using SSJJUIEditor.RunTime;

namespace SSJJUIEditor.UI;

public class TextStyleManager : BaseTextStyleManager
{
	private static TextStyleManager _intance;

	public static TextStyleManager Instance
	{
		get
		{
			if (_intance == null)
			{
				_intance = new TextStyleManager();
			}
			return _intance;
		}
	}

	protected override IUiEditorResourcesLoader initUiResourcesLoader()
	{
		return (IUiEditorResourcesLoader)AbstractModel.GetUiResourceLoader();
	}
}
