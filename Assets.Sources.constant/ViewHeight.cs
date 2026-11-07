using careerConfigPackage;

namespace Assets.Sources.Constant;

public class ViewHeight
{
	public static int GetNormalViewHeight(string career)
	{
		if (!string.IsNullOrEmpty(career) && CareerConfigManager.GetInstance().GetConfig(career) != null)
		{
			return (int)CareerConfigManager.GetInstance().GetConfig(career).normal_view_height;
		}
		return 150;
	}

	public static int GetDuckViewHeight(string career)
	{
		if (!string.IsNullOrEmpty(career) && CareerConfigManager.GetInstance().GetConfig(career) != null)
		{
			return (int)CareerConfigManager.GetInstance().GetConfig(career).duck_view_height;
		}
		return 93;
	}
}
