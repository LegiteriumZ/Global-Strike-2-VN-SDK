public interface IBroadSwordModelPowerProvider : IModuleProvider
{
	bool IsLiuGuangShow();

	float GetLiuGuangPosX();

	bool IsBottomShow();

	float GetPercent();

	bool IsRedShow();

	string UpdateRedImage();

	float UpdateRedPercent();

	bool IsYellowShow(int index);
}
