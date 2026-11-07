namespace Assets.Sources.Utils;

public static class ViewHeightUtility
{
	public static float GetViewHeight(PlayerEntity entity)
	{
		if (entity.DuckState() == 3)
		{
			return (float)entity.basicInfo.CareerInfo.NormalViewHeight;
		}
		return (float)entity.basicInfo.CareerInfo.DuckViewHeight;
	}
}
