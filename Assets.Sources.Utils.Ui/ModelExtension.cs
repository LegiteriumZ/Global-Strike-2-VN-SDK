using Assets.Sources.Modules.Ui;
using Assets.UiFramework.Libs;

namespace Assets.Sources.Utils.Ui;

public static class ModelExtension
{
	public static UiResourcesLoader GetLoader(this AbstractModel model)
	{
		return (UiResourcesLoader)AbstractModel.GetUiResourceLoader();
	}
}
